using static ParkMaster3000.ParkMaster;

namespace ParkMaster3000
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


        FahrzeugType _fahrzeugType;
        public FahrzeugType FahrzeugType
        {
            get { return _fahrzeugType; }
        }

        Fahrzeug _fahrzeug;
        public Fahrzeug Fahrzeug
        {
            get { return _fahrzeug; }
            set { _fahrzeug = value; }
        }

        public Parkplatz(char deckName, int platzNr, FahrzeugType fahrzeugtype)
        {
            _deckName = deckName;
            _platzNr = platzNr;
            _fahrzeugType = fahrzeugtype;
        }



    }
}
