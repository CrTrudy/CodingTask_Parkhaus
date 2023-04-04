public sealed class DasParkhaus {
    Nutzer _nutzer;
    string _titel = "DasParkhaus";
    private static readonly Lazy<DasParkhaus> lazyInstance = new Lazy<DasParkhaus>(() => new DasParkhaus(), true);
    public static DasParkhaus Instance => lazyInstance.Value;

    public DasParkhaus()
    {
            _nutzer = new Nutzer(ParkhausBuild.ParkhausAnlegen());
            Bearbeiten();
    }


        

    void Bearbeiten() {
        Menu menu;
        string[] optionen = { "Parkhaus bearbeiten", "Simulation","Beenden"};
        menu = new Menu(_titel, optionen);

        int _auswahlIndex = menu.Start();

        Console.CursorVisible = false;
        if(_auswahlIndex == 0)
            _nutzer = new Nutzer(ParkhausBuild.ParkhausAnlegen());
            Bearbeiten();
        if(_auswahlIndex == 1)
            Simulation();
        if(_auswahlIndex == 2)
            Environment.Exit(0);
        
    }

    void Simulation()
    {
        Random _rand = new Random();

        List<Fahrzeug> fahrzeuge = ParkhausBuild.FahrzeugeErstellen(_nutzer.Parkhaus.AlleParkplaetze.Count);
        do{
            ParkstellenAnzeigen();
            
            System.Console.WriteLine(_nutzer.Parkhaus.Registrierung(fahrzeuge[_rand.Next(fahrzeuge.Count)]));


            Thread.Sleep(_rand.Next(4000));                
        }
        while (!Console.KeyAvailable);
    //Bearbeiten();
    
    }
    //Anzahl der erzeugten Fahrzeuge abhängig von Parkhaus größe
    
    void ParkstellenAnzeigen(){
        char deck = (char) 65;
        foreach (var stelle in _nutzer.Parkhaus.AlleParkplaetze)
        {
            if (stelle.DeckName != deck)
                Console.WriteLine(); 
            if(stelle.Fahrzeug is not null)                   
                Console.Write($" {stelle.DeckName} {stelle.PlatzNr} {stelle.Fahrzeug.Kennzeichen}    ");
            Console.Write($" {stelle.DeckName} {stelle.PlatzNr}             ");
            deck = stelle.DeckName;

        }
    }
}
