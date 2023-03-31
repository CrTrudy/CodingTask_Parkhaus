using System.Collections.Generic;
using static ParkMaster.ParkhausSimulator;
using static ParkMaster.ParkMaster;

namespace ParkMaster
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
        }

        //alle Parkplätze
        List<Parkplatz> _parkstelle;
        public List<Parkplatz> Parkstelle
        {
            get { return _parkstelle; }
        }

        //Freie Auto Parkplätze
        public List<Parkplatz> AutoParkstellen
        {
            get { List<Parkplatz> aStellen = new List<Parkplatz>();
                foreach (Parkplatz stelle in _parkstelle)
                    if (stelle.Type == ParkhausSimulator.FahrzeugType.Auto)
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
                foreach (Parkplatz stelle in _parkstelle)
                    if (stelle.Type == FahrzeugType.Motorrad)
                        mStellen.Add(stelle);
                foreach (Parkplatz stelle in _parkstelle)
                    if (stelle.Type == FahrzeugType.Auto)
                        mStellen.Add(stelle);
                return mStellen;
            }
        }




        public Parkhaus(string name, List<Parkplatz> parkstelle)
        {
            _name = name;
            _parkstelle = parkstelle;
        }




        public string Registrierung(Fahrzeug fahrzeug)
        {
            Parkplatz? platz = SucheKennzeichen(fahrzeug.Kennzeichen);
            if (platz != null)
                {
                Ausparken(platz);
                return $"{fahrzeug.Kennzeichen} hat das Parkhaus verlassen";
                }
            if (fahrzeug.Type == FahrzeugType.Auto)
                {
                platz = AutoEinparken(fahrzeug);
                return $"Bitte nehmen Sie den Platz Nr{platz.PlatzNr} auf Parkdeck {platz.DeckName}";
                }
            platz = MotorradEinparken(fahrzeug);
            return $"{platz.PlatzNr} {platz.DeckName}";
        }


        public Parkplatz? SucheKennzeichen(string kennzeichen)
        {
            foreach (Parkplatz platz in _parkstelle)
            {
                if( platz.Fahrzeug != null)
                    if (kennzeichen == platz.Fahrzeug.Kennzeichen)
                        return platz;
            }
            return null;
        }

        void Ausparken(Parkplatz? parkplatz)
        {
            foreach (Parkplatz stelle in _parkstelle)
            {
                if (stelle == parkplatz)
                {
                    stelle.Fahrzeug = null;
                }
            }
        }

        Parkplatz? AutoEinparken(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz stelle in _parkstelle)
            {
                if (stelle == AutoParkstellen[0])
                {
                    stelle.Fahrzeug = fahrzeug;
                    return stelle;
                }
            }
            return null;
        }

        Parkplatz? MotorradEinparken(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz stelle in _parkstelle)
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
