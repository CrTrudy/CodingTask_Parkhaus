interface IManager
{

    List<Parkplatz> Parkplaetze { get; }
    string SucheKennzeichen(string kennzeichen);
    string Durchgang(Fahrzeug fahrzeug);

    bool FreiAuto();
    bool FreiMotorrad();
}
