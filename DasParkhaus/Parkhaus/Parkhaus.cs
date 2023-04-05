
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
    public List<Parkplatz> Parkplaetze 
    { 
        get { return _manager.Parkplaetze; } 
    }

    public bool FreieAutoParkplaetze
    {
       get { return _manager.FreiAuto(); }

    }
    bool FreieMotorradParkplaetze
    {
        get { return _manager.FreiMotorrad(); }
    }




    public Parkhaus(string name,IManager manager)
    {
        _name = name;
        _manager = manager;
    }
    public string Registrierung(Fahrzeug fahrzeug)
    {
        return _manager.Durchgang(fahrzeug);
    }
}
