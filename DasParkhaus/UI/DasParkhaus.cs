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
        menu = new Menu(_titel, _nutzer.Parkhaus.Name, optionen);

        Console.CursorVisible = false;
        int _auswahlIndex = menu.Start();

        if(_auswahlIndex == 0){
            _nutzer = new Nutzer(ParkhausBuild.ParkhausAnlegen());
            Bearbeiten();
        }
        if(_auswahlIndex == 1)
            Simulation();
        if(_auswahlIndex == 2)
            Environment.Exit(0);
        
    }

    void Simulation(){
        Random _rand = new Random();

        List<Fahrzeug> fahrzeuge = ParkhausBuild.FahrzeugeErstellen(_nutzer.Parkhaus.AlleParkplaetze.Count + 5 );
        do{
            ParkstellenAnzeigen();
            
            System.Console.WriteLine(_nutzer.Parkhaus.Registrierung(fahrzeuge[_rand.Next(fahrzeuge.Count)]));


            Thread.Sleep(_rand.Next(6000));                
        }
        while (true);
        Bearbeiten();
    }    
    void ParkstellenAnzeigen(){
        char etage = (char) 65;
        Console.WriteLine(_nutzer.Parkhaus.Info);
        foreach (var parkplatz in _nutzer.Parkhaus.AlleParkplaetze)
        {
            if (parkplatz.DeckName != etage)
                Console.WriteLine(); 
            if(parkplatz.Fahrzeug is not null)                   
                Console.Write($" {parkplatz.DeckName} {parkplatz.PlatzNr} {parkplatz.Fahrzeug.Kennzeichen}    ");
            Console.Write($" {parkplatz.DeckName} {parkplatz.PlatzNr}             ");
            etage = parkplatz.DeckName;

        }
    }
}
