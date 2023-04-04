
static class ParkhausBuild
    {
    public static  Parkhaus ParkhausAnlegen()
    {
        string? name;
        int etagen;
        List<Parkplatz> parkstellen;

        do{
            Console.Write("Parkhaus Name: ");
            name = Console.ReadLine();
        } while(name is null);

        
        etagen = InputZahl("Anzahl Parkdecks: ");
        //return List<Parkplaetze>
        parkstellen = ParkstellenEingeben(etagen);
        Manager beobachter = new Manager(parkstellen);
        
        return new Parkhaus(name, beobachter);
    }

    static List<Parkplatz> ParkstellenEingeben(int etagen)
    {
        List<int> parkplaetzeAuto = new List<int>();
        List<int> parkplaetzeMotorrad = new List<int>();
        int auto;
        int motorrad;
    
        for (int etage = 0; etage < etagen; etage++)
            {
                char a = (char) (etage + 65);
                auto = InputZahl($"Anzahl der Auto Parkstellen auf deck {a}: ");
                motorrad = InputZahl($"Anzahl der Motorrad Parkstellen auf deck {a}: ");

                parkplaetzeAuto.Add(auto);
                parkplaetzeMotorrad.Add(motorrad);
            }
        return ParkplatzAnlegen(parkplaetzeAuto, parkplaetzeMotorrad);
    }
    public static List<Fahrzeug> FahrzeugeErstellen(int parkstellen)
        {
            Random _rand = new Random();
            List<Fahrzeug> fahrzeuge = new List<Fahrzeug>();
            string[] landkreise = {"SAW", "KLZ", "WOB", "M", "H", "HH", "Wü", "SHG", "D", "BS", "B", "SDL", "F", "DO", "E", "HE", "MD"};
            string kennzeichen;
            FahrzeugType type;

            for (int kfz = 0; kfz < parkstellen + 3; kfz++)
            {
                //50/50 auto oder motorrad
                if(_rand.Next(4) < 2){
                    type = FahrzeugType.Motorrad;
                }
                else {
                    type = FahrzeugType.Auto;
                }


                string zufallsKreis = landkreise[_rand.Next(landkreise.Length)];

                char a = (char) _rand.Next(65,90);
                char b = (char) _rand.Next(65,90);            
                int zufallsZahl = _rand.Next(1,999);

                kennzeichen = $"{zufallsKreis} {a}{b} {zufallsZahl}"; 

                fahrzeuge.Add(new Fahrzeug(type, kennzeichen));
            }
            return fahrzeuge;
        }
        static List<Parkplatz> ParkplatzAnlegen(List<int> auto, List<int> motorrad) {
            List<Parkplatz> Parkplätze = new List<Parkplatz>();
            Parkplatz parkplatz;
            for (var etage = 0; etage < auto.Count; etage++)
            {
                char deckName = (char) (etage + 65);

                for (int i = 0; i < auto[etage]; i++)
                {
                    parkplatz = new Parkplatz(deckName, i, FahrzeugType.Auto);
                    Parkplätze.Add(parkplatz);
                }
                for (int i = 0; i < motorrad[etage]; i++)
                {
                    parkplatz = new Parkplatz(deckName, i, FahrzeugType.Motorrad);
                    Parkplätze.Add(parkplatz);
                }
            }
            return Parkplätze;
        }


        //wiederholt readline wenn eingabe nicht int
        static int InputZahl(string frage)
        {
            int zahl;
            string? eingabe;
            do
                {
                    Console.Write(frage);
                    eingabe = Console.ReadLine();
                } while (!int.TryParse(eingabe, out zahl));
            return zahl;
        }
    }