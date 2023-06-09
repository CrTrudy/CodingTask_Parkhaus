class Manager : IManager
{
    List<Parkplatz> _parkplaetze;
    public List<Parkplatz> Parkplaetze
    {
        get { return _parkplaetze; }
    }
    public Manager(List<Parkplatz> parkplaetze)
    {
        _parkplaetze = parkplaetze;
    }

    public string Durchgang(Fahrzeug fahrzeug)
    {
        string platzNr = SucheKennzeichen(fahrzeug.Kennzeichen);

        if (platzNr.Length > 2)
        {
            Ausparken(platzNr);
            return $"{fahrzeug.Kennzeichen} hat das Parkhaus verlassen";
        }
        if (!FreiAuto() || !FreiMotorrad())
        {
            return "Das Parkhaus ist voll belegt";
        }
        if (fahrzeug.Type.Equals(FahrzeugType.Auto) && FreiAuto())
        {
            return $"Bitte nehmen Sie platz NR: {AutoEinparken(fahrzeug)}";
        }
        if (fahrzeug.Type.Equals(FahrzeugType.Motorrad) && (FreiMotorrad() || FreiAuto()))
        {
            return $"Bitte nehmen Sie den Platz Nr: {MotorradEinparken(fahrzeug)}";
        }
        return "";
    }

    void Ausparken(string platzNr)
    {
        for (int parkplatz = 0; parkplatz < _parkplaetze.Count; parkplatz++)
        {
            if (_parkplaetze[parkplatz].PlatzNr == platzNr)
            {
                _parkplaetze[parkplatz].Kennzeichen = "";
            }
        }
    }

    public string SucheKennzeichen(string kennzeichen)
    {
        foreach (var parkplatz in _parkplaetze)
        {
            if(parkplatz.Kennzeichen == kennzeichen)
                return parkplatz.PlatzNr;
        }
        return "";
    }



    List<Parkplatz> FreieAutoParkplaetze()
    {
        List<Parkplatz> platz = new List<Parkplatz>();
        foreach (var parkplatz in _parkplaetze)
        {
            if (parkplatz.Type.Equals(FahrzeugType.Auto) && parkplatz.Frei)
                platz.Add(parkplatz);
        }
        return platz;
    }

    public bool FreiAuto()
    {
        return FreieAutoParkplaetze().Count > 0;
    }

    //Freie Motorrad Parkplätze sind auch Auto Parkplätze
    //beginnend mit freien Motorrad Parkplätze
    List<Parkplatz> FreieMotorradParkplaetze()
    {
        List<Parkplatz> platz = new List<Parkplatz>();
        foreach (var parkplatz in _parkplaetze)
        {
            if (parkplatz.Type.Equals(FahrzeugType.Motorrad) && parkplatz.Frei)
                platz.Add(parkplatz);
        }
        return platz;
    }

    public bool FreiMotorrad()
    {
        return FreieMotorradParkplaetze().Count > 0;
    }



    string AutoEinparken(Fahrzeug fahrzeug)
    {
            foreach (var parkplatz in _parkplaetze)
            {
                if (parkplatz.PlatzNr == FreieAutoParkplaetze()[0].PlatzNr)
                {
                    parkplatz.Kennzeichen = fahrzeug.Kennzeichen;
                    return parkplatz.PlatzNr;
                }
            }
        return "";
    }

    string MotorradEinparken(Fahrzeug fahrzeug)
    {
        foreach (var parkplatz in _parkplaetze)
        {
            if (parkplatz.PlatzNr == FreieMotorradParkplaetze()[0].PlatzNr)
            {
                parkplatz.Kennzeichen = fahrzeug.Kennzeichen;
                return parkplatz.PlatzNr;
            }
            if (parkplatz.PlatzNr == FreieAutoParkplaetze()[0].PlatzNr)
            {
                parkplatz.Kennzeichen = fahrzeug.Kennzeichen;
                return parkplatz.PlatzNr;
            }
        }
        return "";
    }
}
