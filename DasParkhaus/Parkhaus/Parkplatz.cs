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
    public bool Frei {
        get { 
            if(_fahrzeug is null)
            {
                return true; 
            }
            return false;
        }

        set { value = !value; }
    }

    FahrzeugType _fahrzeugType;
    public FahrzeugType Type
    {
        get { return _fahrzeugType; }
    }

    Fahrzeug? _fahrzeug;
    public Fahrzeug? Fahrzeug
    {
        get { return _fahrzeug; }
        set { _fahrzeug = value; }
    }

    public Parkplatz(char deckName, int platzNr, FahrzeugType fahrzeugType)
    {
        _deckName = deckName;
        _platzNr = platzNr;
        _fahrzeugType = fahrzeugType;
    }



}

