using System;
using System.Collections.Generic;

namespace ParkMaster3000
{
    public class Menu
    {
        string _titel;
        List<string> _optionen;
        List<string> _eingabe;
        int _index = 0;

        public Menu(string titel)
        {
            _titel = titel;
        }

        public void Ausgabe(List<string> optionen)
        {
            _optionen = optionen;
            _optionen.Add("Beenden");

            Console.WriteLine(_titel);
            Console.WriteLine();
            for (int i = 0; i < _optionen.Count; i++)
            {
                if (i == _index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(_optionen[i]);
                }
                else
                {
                    Console.WriteLine(_optionen[i]);
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public List<string> Eingabe()
        {

            return _eingabe;
        }


        public int Index()
        {
            return _index;
        }



    }

}
