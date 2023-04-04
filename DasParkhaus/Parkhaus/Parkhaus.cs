
class Parkhaus 
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
     //Manager hat alle funktionen zum verwalten
    IManager _manager;
    //Parkplätze vom IManager abgeholt
    public List<Parkplatz> AlleParkplaetze 
    { 
        get { return _manager.AlleParkplaetze; } 
    }

    public List<Parkplatz> FreieAutoParkplaetze
    {
       get { return _manager.FreieAutoParkplaetze(); }

    }
    public List<Parkplatz> FreieMotorradParkplaetze
    {
        get { return _manager.FreieMotorradParkplaetze(); }
    }
    public Parkhaus(string name,IManager manager)
    {
        _name = name;
        _manager = manager;
    }
    public string Registrierung(Fahrzeug fahrzeug)
    {
        string infotext = "...";
        Parkplatz? platz = _manager.SucheKennzeichen(fahrzeug.Kennzeichen);

        if (platz is not null)
        {
            _manager.Ausparken(platz);
            infotext = $"{fahrzeug.Kennzeichen} hat das Parkhaus verlassen";
        }
        if (FreieAutoParkplaetze.Count > 0 && fahrzeug.Type.Equals(FahrzeugType.Auto))
        {
            platz = FreieAutoParkplaetze[0];
            _manager.AutoEinparken(fahrzeug);
            infotext = $"Bitte nehmen Sie den Platz Nr{platz.PlatzNr} auf Parkdeck {platz.DeckName}";
        }
        if (FreieAutoParkplaetze.Count > 0 || FreieMotorradParkplaetze.Count > 0 && fahrzeug.Type.Equals(FahrzeugType.Motorrad))
        {
            platz = FreieAutoParkplaetze[0];
            _manager.MotorradEinparken(fahrzeug);
            infotext = $"Bitte nehmen Sie den Platz Nr{platz.PlatzNr} auf Parkdeck {platz.DeckName}";
        }
        return infotext;
    }
}
