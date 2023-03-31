

using static ParkMaster.ParkhausSimulator;

namespace ParkMaster
{
    public class Parkplatz
    {
        char _deckName;
        public char DeckName
        {
            get { return _deckName; }
        }

        int _platzNr;
        public int PlatzNr
        {
            get { return _platzNr; }
        }


        bool _autoStellplatz;
        public bool AutoStellplatz
        {
            get { return _autoStellplatz; }
        }

        Fahrzeug? _fahrzeug;
        public Fahrzeug? Fahrzeug
        {
            get { return _fahrzeug; }
            set { _fahrzeug = value; }
        }

        public Parkplatz(char deckName, int platzNr, bool autoStellplatz)
        {
            _deckName = deckName;
            _platzNr = platzNr;
            _autoStellplatz = autoStellplatz;
        }



    }
}
