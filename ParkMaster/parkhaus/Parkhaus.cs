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
        List<Parkplatz> _alleparkstellen;
        public List<Parkplatz> AlleParkstellen
        {
            get { return _alleparkstellen; }
        }

        //Freie Auto Parkplätze
        public List<Parkplatz> FreieParkstellenAuto
        {
            get { List<Parkplatz> platz = new List<Parkplatz>();
                foreach (Parkplatz parkplatz in _alleparkstellen)
                    if (parkplatz.AutoStellplatz && parkplatz.Fahrzeug == null)
                        platz.Add(parkplatz);
                return platz;
            }
        }


        //Freie Motorrad Parkplätze sind auch Auto Parkplätze
        //beginnend mit freien Motorrad Parkplätze
        public List<Parkplatz> MotorradParkstellen
        {
            get
            {
                List<Parkplatz> platz = new List<Parkplatz>();
                foreach (Parkplatz parkplsatz in _alleparkstellen)
                    if (parkplsatz.AutoStellplatz && parkplsatz.Fahrzeug == null)
                        platz.Add(parkplsatz);
                return platz;
            }
        }




        public Parkhaus(string name, List<Parkplatz> parkstellen)
        {
            _name = name;
            _alleparkstellen = parkstellen;
        }




        public string Registrierung(Fahrzeug fahrzeug)
        {
            Parkplatz? platz = SucheKennzeichen(fahrzeug.Kennzeichen);

            if (platz != null)
                {
                    Ausparken(platz);
                    return $"{fahrzeug.Kennzeichen} hat das Parkhaus verlassen";
                }
            if (FreieParkstellenAuto.Count > 0 && fahrzeug.Auto)
                {
                    platz = FreieParkstellenAuto[0];
                    AutoEinparken(fahrzeug);
                    return $"Bitte nehmen Sie den Platz Nr{platz.PlatzNr} auf Parkdeck {platz.DeckName}";
                }
            MotorradEinparken(fahrzeug);
            return $"{platz.PlatzNr} {platz.DeckName}";
        }


        public Parkplatz? SucheKennzeichen(string kennzeichen)
        {
            foreach (Parkplatz platz in _alleparkstellen)
            {
                if( platz.Fahrzeug != null)
                    if (kennzeichen == platz.Fahrzeug.Kennzeichen)
                        return platz;
            }
            return null;
        }

        void Ausparken(Parkplatz parkplatz)
        {
            foreach (Parkplatz stelle in _alleparkstellen)
            {
                if (stelle == parkplatz)
                {
                    stelle.Fahrzeug = null;
                }
            }
        }

        void AutoEinparken(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz stelle in _alleparkstellen)
            {
                if (stelle == FreieParkstellenAuto[0])
                {
                    stelle.Fahrzeug = fahrzeug;
                }
            }
        }

        void MotorradEinparken(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz stelle in _alleparkstellen)
            {
                if (MotorradParkstellen.Count > 0 && stelle == MotorradParkstellen[0])
                {
                    stelle.Fahrzeug = fahrzeug;
                }
                if(stelle == FreieParkstellenAuto[0])
                    stelle.Fahrzeug = fahrzeug;
            }
        }

    }
}
