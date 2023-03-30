using System;
using System.Collections.Generic;

namespace ParkMaster3000
{
    public class Menu
    {
        string _titel;
        string[] _optionen;
        int _auswahlIndex = 0;
        int _cursorOffsetLinks = 35;
        int _cursorOffsetOben = 14;

        public Menu(string titel, string[] optionen)
        {
            _titel = titel;
            _optionen = optionen;
        }

        void OptionenAnzeigen()
        {
            System.Console.WriteLine(_titel);
            for (int i = 0; i < _optionen.Length; i++)
            {
                string aktuelleOption = _optionen[i];
                if (i == _auswahlIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                //Console.SetCursorPosition(_cursorOffsetLinks, _cursorOffsetOben + i);
                Console.Write($"<< {aktuelleOption} >>");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        void EingabeOptionen()
        {
            for (int i = 0; i < _optionen.Length; i++)
            {
                string aktuelleOption = _optionen[i];
                if (i == _auswahlIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                //Console.SetCursorPosition(_cursorOffsetLinks, _cursorOffsetOben + i);
                Console.Write($"<< {aktuelleOption} >>");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        public int Run()
        {
            Console.WriteLine(_titel + "\n\n\n");
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                OptionenAnzeigen();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _auswahlIndex--;
                    if (_auswahlIndex == -1)
                    {
                        _auswahlIndex = _optionen.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _auswahlIndex++;
                    if (_auswahlIndex == _optionen.Length)
                    {
                        _auswahlIndex = 0;
                    }
                }

           }  while (keyPressed != ConsoleKey.Enter);
            return _auswahlIndex;
        }
    }
}

