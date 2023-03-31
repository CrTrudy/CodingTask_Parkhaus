namespace ParkMaster
{
    partial class ParkhausSimulator
    {

        Random _rand = new Random();

    public Parkhaus ParkhausAnlegen()
    {
        string name;
        int decks;
        List<Parkplatz> platz;
        do{
            Console.Write("Parkhaus Name: ");
            name = Console.ReadLine();
        } while(string.IsNullOrEmpty(name));

        
        decks = NurInt("Anzahl Parkdecks: ");
        platz = ParkstellenEingeben(decks);
        
        return new Parkhaus(name, platz);
    }
    List<Parkplatz> ParkstellenEingeben(int decks)
    {
        List<int> parkplaetzAuto = new List<int>();
        List<int> parkplaetzeMotorrad = new List<int>();
        int auto;
        int motorrad;
    
        for (int deck = 0; deck < decks; deck++)
            {
                char a = (char) (deck + 65);
                auto = NurInt($"Anzahl der Auto Parkstellen auf deck {a}: ");
                motorrad = NurInt($"Anzahl der Motorrad Parkstellen auf deck {a}: ");

                parkplaetzAuto.Add(auto);
                parkplaetzeMotorrad.Add(motorrad);
            }
        return ParkplatzAnlegen(parkplaetzAuto, parkplaetzeMotorrad);
    }
    public List<Fahrzeug> FahrzeugeErstellen(int parkstellen)
        {
            List<Fahrzeug> fahrzeuge = new List<Fahrzeug>();
            string kennzeichen;
            bool zufallsType = true;

            for (int kfz = 0; kfz < parkstellen + 3; kfz++)
            {
                zufallsType = true;
                if(_rand.Next(4) < 2)
                    zufallsType = false;

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
                    parkplatz = new Parkplatz(deckName, i, true);
                    platz.Add(parkplatz);
                }
                for (int i = 0; i < motorrad[deck]; i++)
                {
                    parkplatz = new Parkplatz(deckName, i, false);
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

