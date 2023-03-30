using static ParkMaster3000.ParkMaster;

namespace ParkMaster3000
{
    public class Fahrzeug
    {
        FahrzeugType _type;
        string _nummernschild;
        
        public FahrzeugType Type
        {
            get { return _type; }
        }
        public string Nummernschild
        {
            get { return _nummernschild; }
        }

        public Fahrzeug(FahrzeugType type, string nummernschild)
        {
            _type = type;
            _nummernschild = nummernschild;
        }
    }

}
