
static class ParkhausBuild
    {
    public static Parkhaus ParkhausAnlegen()
    {
        string name;
        int etagenZahl;

        Console.Write("Parkhaus Name: ");
        name = Console.ReadLine();

        
        etagenZahl = InputZahl("Anzahl Parketagen: ");
        //return List<Etagen>
        Manager manager = new Manager(ParkstellenEingeben(etagenZahl));
        
        return new Parkhaus(name, manager);
    }

    static List<Parkplatz> ParkstellenEingeben(int etagenZahl)
    {
        List<Parkplatz> parkplaetze = new List<Parkplatz>();
        int auto;
        int motorrad;
    
        for (int etage = 0; etage < etagenZahl; etage++)
            {
                char etageName = (char) (etage + 65);
                auto = InputZahl($"Anzahl der Auto Parkstellen auf deck {etageName}: ");
                for (int nr = 0; nr < auto; nr++)
                {
                    parkplaetze.Add(new Parkplatz($"{etageName} {nr + 1}", FahrzeugType.Auto));
                }
                motorrad = InputZahl($"Anzahl der Motorrad Parkstellen auf deck {etageName}: ");
                for (int nr = 0 + auto; nr < motorrad + auto; nr++)
                {
                    parkplaetze.Add(new Parkplatz($"{etageName} {nr + 1}", FahrzeugType.Motorrad));
                }
            }
        return parkplaetze;
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