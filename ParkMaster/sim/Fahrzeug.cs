using static ParkMaster.ParkhausSimulator;

namespace ParkMaster
{
    public class Fahrzeug
    {
        FahrzeugType _type;
        string _kennzeichen;
        public FahrzeugType Type
        {
            get { return _type; }
        }
        public string Kennzeichen
        {
            get { return _kennzeichen; }
        }

        public Fahrzeug(FahrzeugType type, string kennzeichen)
        {
            _type = type;
            _kennzeichen = kennzeichen;
        }
    }

}
