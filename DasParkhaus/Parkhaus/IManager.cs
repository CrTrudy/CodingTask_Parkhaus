interface IManager
{

    List<Parkplatz> AlleParkplaetze { get; }
    Parkplatz? SucheKennzeichen(string kennzeichen);

    void Ausparken(Parkplatz parkplatz);
    void AutoEinparken(Fahrzeug fahrzeug);
    List<Parkplatz> FreieAutoParkplaetze();
    List<Parkplatz> FreieMotorradParkplaetze();
    void MotorradEinparken(Fahrzeug fahrzeug);
}
