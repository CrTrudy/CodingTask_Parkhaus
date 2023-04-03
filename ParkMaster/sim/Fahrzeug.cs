namespace ParkMaster
{
    public class Fahrzeug
    {
        bool _auto;
        string _kennzeichen;
        public bool Auto
        {
            get { return _auto; }
        }
        public string Kennzeichen
        {
            get { return _kennzeichen; }
        }

        public Fahrzeug(bool auto, string kennzeichen)
        {
            _auto = auto;
            _kennzeichen = kennzeichen;
        }
    }

}
