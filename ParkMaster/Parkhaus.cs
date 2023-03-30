using System.Collections.Generic;

namespace ParkMaster3000
{
    public class Parkhaus
    {
        string _name;
        public string Name
        {
            get { return _name; }
        }

        //Infotex für Anzeigetafel
        string _info = "*";
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }

        //alle Parkplätze
        List<Parkplatz> _parkstellen;
        public List<Parkplatz> Parkstellen
        {
            get { return _parkstellen; }
        }

        //Freie Auto Parkplätze
        public List<Parkplatz> AutoParkstellen
        {
            get { List<Parkplatz> aStellen = new List<Parkplatz>();
                foreach (Parkplatz stelle in _parkstellen)
                    if (stelle.FahrzeugType == ParkMaster.FahrzeugType.Auto)
                        aStellen.Add(stelle);
                return aStellen;
            }
        }


        //Freie Motorrad Parkplätze sind auch Auto Parkplätze
        //beginnend mit freien Motorrad Parkplätze
        public List<Parkplatz> MotorradParkstellen
        {
            get
            {
                List<Parkplatz> mStellen = new List<Parkplatz>();
                foreach (Parkplatz stelle in _parkstellen)
                    if (stelle.FahrzeugType == ParkMaster.FahrzeugType.Motorrad)
                        mStellen.Add(stelle);
                foreach (Parkplatz stelle in _parkstellen)
                    if (stelle.FahrzeugType == ParkMaster.FahrzeugType.Auto)
                        mStellen.Add(stelle);
                return mStellen;
            }
        }




        public Parkhaus(string name, int anzahlParkDecks, List<int[]> autoMotorradStellen)
        {
            _name = name;

            ParkstellenGenerator(anzahlParkDecks, autoMotorradStellen);
            
                

        }


        void ParkstellenGenerator(int decks, List<int[]> stellen)
        {
            for (var deck = 0; deck > decks; deck++)
            {
                //Parkdeck Namen beginnend mit A aufsteigend
                char deckName = (char)(deck + 65);
                for (int auto = 0; auto < stellen[deck][0]; auto++)
                {
                    _parkstellen.Add(new Parkplatz(deckName, auto, ParkMaster.FahrzeugType.Auto));
                }

                //platzNr Motorrad Parstellen beginnt mit anzahl Autoparkstellen
                for (int motorrad = stellen[deck][0]; motorrad < stellen[deck][1] + stellen[deck][1]; motorrad++)
                {
                    _parkstellen.Add(new Parkplatz(deckName, motorrad, ParkMaster.FahrzeugType.Motorrad));
                }
            }
        }


        public void Registrierung(Fahrzeug fahrzeug)
        {
            Parkplatz platz = SucheNummernschild(fahrzeug.Nummernschild);
            if (platz != null)
                Ausparken(platz);

        }


        public Parkplatz SucheNummernschild(string nummernschild)
        {
            foreach (Parkplatz platz in _parkstellen)
            {
                if (nummernschild == platz.Fahrzeug.Nummernschild)
                    return platz;
            }
            return null;
        }

        void Ausparken(Parkplatz parkplatz)
        {
            foreach (Parkplatz stelle in _parkstellen)
            {
                if (stelle == parkplatz)
                {
                    stelle.Fahrzeug = null;
                }
            }
        }

        Parkplatz AutoEinparken(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz stelle in _parkstellen)
            {
                if (stelle == AutoParkstellen[0])
                {
                    stelle.Fahrzeug = fahrzeug;
                    return stelle;
                }
            }
            return null;
        }

        Parkplatz MotorradEinparken(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz stelle in _parkstellen)
            {
                if (stelle == MotorradParkstellen[0])
                {
                    stelle.Fahrzeug = fahrzeug;
                    return stelle;
                }
            }
            return null;
        }

    }
}
