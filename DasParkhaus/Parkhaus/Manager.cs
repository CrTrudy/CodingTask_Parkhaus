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

    public void Ausparken(string platzNr)
    {
        foreach (var parkplatz in _parkplaetze)
        {
            if (parkplatz.PlatzNr == platzNr)
            {
                parkplatz.Kennzeichen = "";
                break;
            }
        }
    }

    public string AutoEinparken(Fahrzeug fahrzeug)
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

    public string MotorradEinparken(Fahrzeug fahrzeug)
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
