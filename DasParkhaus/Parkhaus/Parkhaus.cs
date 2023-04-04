
interface IManager
{

    List<Parkplatz> AlleParkplaetze { get; }

    void Ausparken(Parkplatz parkplatz);
    void AutoEinparken(Fahrzeug fahrzeug);
    List<Parkplatz> FreieAutoParkplaetze();
    List<Parkplatz> FreieMotorradParkplaetze();
    void MotorradEinparken(Fahrzeug fahrzeug);
}

class Parkhaus : IManager
{
    string _name;
    public string Name
    {
        get { return _name; }
    }

    //Infotext für Anzeigetafel
    string _info = "*";
    public string Info
    {
        get { return _info; }
    }

    //Parkplatz Abfragen: Auto frei, Motorrad frei, Kennzeichen platz
    Beobachter _beobachter;

    //ParkAutomat _parkAutomat;

    List<Parkplatz> _alleparkplaetze;
    public List<Parkplatz> AlleParkplaetze
    {
        get { return _alleparkplaetze; }
    }



    public Parkhaus(string name, List<Parkplatz> parkplaetze, Beobachter beobachter)
    {
        _name = name;
        _alleparkplaetze = parkplaetze;
        _beobachter = beobachter;
        //_parkAutomat = parkAutomat;
    }
    public string Registrierung(Fahrzeug fahrzeug)
    {
        string infotext = "...";
        Parkplatz? platz = this._beobachter.SucheKennzeichen(fahrzeug.Kennzeichen, AlleParkplaetze);

        if (platz is not null)
        {
            Ausparken(platz);
            infotext = $"{fahrzeug.Kennzeichen} hat das Parkhaus verlassen";
        }
        if (FreieAutoParkplaetze().Count > 0 && fahrzeug.Type.Equals(FahrzeugType.Auto))
        {
            platz = FreieAutoParkplaetze()[0];
            AutoEinparken(fahrzeug);
            infotext = $"Bitte nehmen Sie den Platz Nr{platz.PlatzNr} auf Parkdeck {platz.DeckName}";
        }
        if (FreieAutoParkplaetze().Count > 0 || FreieMotorradParkplaetze().Count > 0 && fahrzeug.Type.Equals(FahrzeugType.Motorrad))
        {
            platz = FreieAutoParkplaetze()[0];
            MotorradEinparken(fahrzeug);
            infotext = $"Bitte nehmen Sie den Platz Nr{platz.PlatzNr} auf Parkdeck {platz.DeckName}";
        }
        return infotext;
    }

    public List<Parkplatz> FreieAutoParkplaetze()
    {
        return _beobachter.FreieAutoParkplaetze(_alleparkplaetze);

    }
    public List<Parkplatz> FreieMotorradParkplaetze()
    {
        return _beobachter.FreieMotorradParkplaetze(_alleparkplaetze);
    }

    public void Ausparken(Parkplatz parkplatz)
    {
        foreach (Parkplatz stelle in _alleparkplaetze)
        {
            if (stelle == parkplatz)
            {
                stelle.Fahrzeug = null;
            }
        }
    }

    public void AutoEinparken(Fahrzeug fahrzeug)
    {
        foreach (Parkplatz stelle in _alleparkplaetze)
        {
            if (stelle == FreieAutoParkplaetze()[0])
            {
                stelle.Fahrzeug = fahrzeug;
            }
        }
    }

    public void MotorradEinparken(Fahrzeug fahrzeug)
    {
        foreach (Parkplatz stelle in _alleparkplaetze)
        {
            if (FreieMotorradParkplaetze().Count > 0 && stelle == FreieMotorradParkplaetze()[0])
            {
                stelle.Fahrzeug = fahrzeug;
            }
            if (stelle == FreieAutoParkplaetze()[0])
                stelle.Fahrzeug = fahrzeug;
        }
    }

}
