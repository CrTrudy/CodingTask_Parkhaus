class Manager : IManager
{
    List<Parkplatz> _alleparkplaetze;
    public List<Parkplatz> AlleParkplaetze
    {
        get { return _alleparkplaetze; }
    }
    public Manager(List<Parkplatz> parkplaetze)
    {
        _alleparkplaetze = parkplaetze;
    }










    public List<Parkplatz> FreieAutoParkplaetze()
    {
        List<Parkplatz> platz = new List<Parkplatz>();
        foreach (Parkplatz parkplatz in _alleparkplaetze)
        {
            if (parkplatz.Type.Equals(FahrzeugType.Auto) && parkplatz.Frei)
                platz.Add(parkplatz);
        }
        return platz;
    }
    //Freie Motorrad Parkplätze sind auch Auto Parkplätze
    //beginnend mit freien Motorrad Parkplätze
    public List<Parkplatz> FreieMotorradParkplaetze()
    {
        List<Parkplatz> platz = new List<Parkplatz>();
        foreach (Parkplatz parkplatz in _alleparkplaetze)
        {
            if (parkplatz.Type.Equals(FahrzeugType.Motorrad) && parkplatz.Frei)
                platz.Add(parkplatz);
        }
        return platz;
    }
    public Parkplatz? SucheKennzeichen(string kennzeichen)
    {
        foreach (Parkplatz platz in _alleparkplaetze)
        {
            if (platz.Fahrzeug is not null)
                if (kennzeichen == platz.Fahrzeug.Kennzeichen)
                    return platz;
        }
        return null;
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
        if(FreieAutoParkplaetze().Count > 0){
            foreach (Parkplatz stelle in _alleparkplaetze)
            {
                if (stelle == FreieAutoParkplaetze()[0])
                {
                    stelle.Fahrzeug = fahrzeug;
                }
            }
        }
    }

    public void MotorradEinparken(Fahrzeug fahrzeug)
    {
        if(FreieMotorradParkplaetze().Count > 0){
        foreach (Parkplatz stelle in _alleparkplaetze)
        {
            if (stelle == FreieMotorradParkplaetze()[0])
            {
                stelle.Fahrzeug = fahrzeug;
            }
            if (stelle == FreieAutoParkplaetze()[0])
            {
                stelle.Fahrzeug = fahrzeug;
            }
        }
    }
    }
}
