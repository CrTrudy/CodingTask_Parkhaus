
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

        List<Parkplatz> _alleparkstellen;
        public List<Parkplatz> AlleParkstellen
        {
            get { return _alleparkstellen; }
        }
        public Parkhaus(string name, List<Parkplatz> parkstellen)
        {
            _name = name;
            _alleparkstellen = parkstellen;
        }
        public List<Parkplatz> FreieParkstellenAuto()
        {
            List<Parkplatz> platz = new List<Parkplatz>();
                foreach (Parkplatz parkplatz in _alleparkstellen)
                    if (parkplatz.AutoStellplatz && parkplatz.Fahrzeug is null)
                        platz.Add(parkplatz);
                return platz;
        }
        //Freie Motorrad Parkplätze sind auch Auto Parkplätze
        //beginnend mit freien Motorrad Parkplätze
        public List<Parkplatz> FreieParkstellenMotorrad()
        {

                List<Parkplatz> platz = new List<Parkplatz>();
                foreach (Parkplatz parkplatz in _alleparkstellen)
                    if (parkplatz.AutoStellplatz && parkplatz.Fahrzeug is null)
                        platz.Add(parkplatz);
                return platz;
        }
        public string Registrierung(Fahrzeug fahrzeug)
        {
            string infotext ="";
            Parkplatz? platz = SucheKennzeichen(fahrzeug.Kennzeichen);

            if (platz is not null)
                {
                    Ausparken(platz);
                    infotext =  $"{fahrzeug.Kennzeichen} hat das Parkhaus verlassen";
                }
            if (FreieParkstellenAuto().Count > 0 && fahrzeug.Auto)
                {
                    platz = FreieParkstellenAuto()[0];
                    AutoEinparken(fahrzeug);
                    infotext = $"Bitte nehmen Sie den Platz Nr{platz.PlatzNr} auf Parkdeck {platz.DeckName}";
                }
            if (FreieParkstellenAuto().Count > 0 || FreieParkstellenMotorrad().Count > 0 && fahrzeug.Auto)
                {
                    platz = FreieParkstellenAuto()[0];
                    MotorradEinparken(fahrzeug);
                    infotext = $"Bitte nehmen Sie den Platz Nr{platz.PlatzNr} auf Parkdeck {platz.DeckName}";
                }
            return infotext;
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
                if (stelle == FreieParkstellenAuto()[0])
                {
                    stelle.Fahrzeug = fahrzeug;
                }
            }
        }

        void MotorradEinparken(Fahrzeug fahrzeug)
        {
            foreach (Parkplatz stelle in _alleparkstellen)
            {
                if (FreieParkstellenMotorrad().Count > 0 && stelle == FreieParkstellenMotorrad()[0])
                {
                    stelle.Fahrzeug = fahrzeug;
                }
                if(stelle == FreieParkstellenAuto()[0])
                    stelle.Fahrzeug = fahrzeug;
            }
        }

    }
}
