interface IManager
{

    List<Parkplatz> Parkplaetze { get; }
    string SucheKennzeichen(string kennzeichen);

    bool FreiAuto();
    bool FreiMotorrad();

    void Ausparken(string platzNr);
    string AutoEinparken(Fahrzeug fahrzeug);
    string MotorradEinparken(Fahrzeug fahrzeug);
}
