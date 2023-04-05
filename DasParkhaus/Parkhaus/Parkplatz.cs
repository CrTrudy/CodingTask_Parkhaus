public class Parkplatz
{

    string _platzNr;
    public string PlatzNr
    {
        get { return _platzNr; }
    }
    public bool Frei {
        get { 
            if(_kennzeichen is null)
            {
                return true; 
            }
            return false;
        }
    }

    FahrzeugType _fahrzeugType;
    public FahrzeugType Type
    {
        get { return _fahrzeugType; }
    }

    string _kennzeichen = "";
    public string Kennzeichen
    {
        get { return _kennzeichen; }
        set { _kennzeichen = value; }
    }

    public Parkplatz(string platzNr, FahrzeugType fahrzeugType)
    {
        _platzNr = platzNr;
        _fahrzeugType = fahrzeugType;
    }
}