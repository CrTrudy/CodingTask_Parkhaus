
class Beobachter 
{
    public List<Parkplatz> FreieAutoParkplaetze(List<Parkplatz> alleparkplaetze)
    {
        List<Parkplatz> platz = new List<Parkplatz>();
        foreach (Parkplatz parkplatz in alleparkplaetze)
            if (parkplatz.Type.Equals(FahrzeugType.Auto) && parkplatz.Fahrzeug is null)
                platz.Add(parkplatz);
        return platz;
    }
    //Freie Motorrad Parkplätze sind auch Auto Parkplätze
    //beginnend mit freien Motorrad Parkplätze
    public List<Parkplatz> FreieMotorradParkplaetze(List<Parkplatz> alleparkplaetze)
    {
        List<Parkplatz> platz = new List<Parkplatz>();
        foreach (Parkplatz parkplatz in alleparkplaetze)
            if (parkplatz.Type.Equals(FahrzeugType.Motorrad) && parkplatz.Fahrzeug is null)
                platz.Add(parkplatz);
        return platz;
    }
    public Parkplatz? SucheKennzeichen(string kennzeichen, List<Parkplatz> alleparkplaetze)
    {
        foreach (Parkplatz platz in alleparkplaetze)
        {
            if (platz.Fahrzeug is not null)
                if (kennzeichen == platz.Fahrzeug.Kennzeichen)
                    return platz;
        }
        return null;
    }
}
