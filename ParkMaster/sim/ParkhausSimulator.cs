namespace ParkMaster
{
    partial class ParkhausSimulator
    {
        public enum FahrzeugType
        {
            Auto,
            Motorrad
        }
        Random _rand = new Random();

    public Parkhaus ParkhausAnlegen()
        {
            string name;
            int decks;
            List<Parkplatz> platz;
            
            Console.Write("Parkhaus Name: ");
            name = Console.ReadLine();

            
            decks = NurInt("Anzahl Parkdecks: ");
            platz = ParkstellenEingeben(decks);
            
            return new Parkhaus(name, platz);
        }
        List<Parkplatz> ParkstellenEingeben(int decks)
    {
        List<int> autoStellen = new List<int>();
        List<int> motorradStellen = new List<int>();
        int auto;
        int motorrad;
    
        for (int deck = 0; deck < decks; deck++)
            {
                char a = (char) (deck + 65);
                auto = NurInt($"Anzahl der Auto Parkstellen auf deck {a}: ");
                motorrad = NurInt($"Anzahl der Motorrad Parkstellen auf deck {a}: ");

                autoStellen.Add(auto);
                motorradStellen.Add(motorrad);
            }
        return ParkplatzAnlegen(autoStellen, motorradStellen);
    }
    public List<Fahrzeug> FahrzeugeErstellen(int parkstellen)
        {
            List<Fahrzeug> fahrzeuge = new List<Fahrzeug>();
            string kennzeichen;
            FahrzeugType zufallsType;

            for (int kfz = 0; kfz < parkstellen + 3; kfz++)
            {
                FahrzeugType[] alleFahrzeugtypen = (FahrzeugType[])Enum.GetValues(typeof(FahrzeugType));
                zufallsType = alleFahrzeugtypen[_rand.Next(0, alleFahrzeugtypen.Length)];

                Landkreis[] alleKreise = (Landkreis[])Enum.GetValues(typeof(Landkreis));
                Landkreis zufallsKreis = alleKreise[_rand.Next(0, alleKreise.Length)];

                char a = (char) _rand.Next(65,90);
                char b = (char) _rand.Next(65,90);            
                int zufallsZahl = _rand.Next(1,999);

                kennzeichen = $"{zufallsKreis} {a}{b} {zufallsZahl}"; 

                fahrzeuge.Add(new Fahrzeug(zufallsType, kennzeichen));
                System.Console.WriteLine(kennzeichen);
            }
            return fahrzeuge;
        }
    
    List<Parkplatz> ParkplatzAnlegen(List<int> auto, List<int> motorrad) {
        List<Parkplatz> platz = new List<Parkplatz>();
        Parkplatz parkplatz;
        for (var deck = 0; deck < auto.Count; deck++)
        {
            char deckName = (char) (deck + 65);

            for (int i = 0; i < auto[deck]; i++)
            {
                parkplatz = new Parkplatz(deckName, i, FahrzeugType.Auto);
                platz.Add(parkplatz);
            }
            for (int i = 0; i < motorrad[deck]; i++)
            {
                parkplatz = new Parkplatz(deckName, i, FahrzeugType.Motorrad);
                platz.Add(parkplatz);
            }
        }
        return platz;
    }

    int NurInt(string frage)
    {
        int zahl;
        string eingabe;
        do
            {
                Console.Write(frage);
                eingabe = Console.ReadLine();
            } while (!int.TryParse(eingabe, out zahl));
        return zahl;
    }
    }
    
}

