using System;
using System.Collections.Generic;

namespace ParkMaster3000
{
    public class ParkMaster {
        Parkhaus _parkhaus;
        List<Fahrzeug> _fahrzeug;
        Menu _menu;
        string _titel = "ParkMaster3000";
        string[] _optionen;

        public enum FahrzeugType
        {
            Auto,
            Motorrad
        }
        enum Landkreis {
                SAW, KLZ, WOB, M, H, HH, Wü, SHG, D, BS, B, SDL, F, DO, E, HE, MD
        }

        public ParkMaster()
        {
            Startmenu();
        }

        void Startmenu() {
            string[] _optionen = { "Anlegen", "Beenden"};
            _menu = new Menu(_titel, _optionen);
            Console.Clear();
            int _selectedIndex = _menu.Run();
            Console.CursorVisible = false;
            if(_selectedIndex == 0)
                Console.Clear();
                ParkhausAnlegen();
            if(_selectedIndex == 1)
                Environment.Exit(0);
            
        }
        void ParkhausAnlegen()
        {
            string eingabe;
            int decks;
            List<int[]> stellplatz = new List<int[]> {};
            int auto;
            int motorrad;


            
            Console.Write("Parkhaus Name: ");
            string name = Console.ReadLine();

            do
            {
                Console.Write("Anzahl Parkdecks: ");
                eingabe = Console.ReadLine();
            } while (!int.TryParse(eingabe, out decks));
            for (int deck = 0; deck < decks; deck++)
            {
                do {
                        Console.Write($"Anzahl der Auto Parkstellen auf deck{deck}: ");
                        eingabe = Console.ReadLine();
                    } while (!int.TryParse(eingabe, out auto));
                do
                    {
                        Console.Write($"Anzahl der Motorrad Parkstellen auf deck{deck}: ");
                        eingabe = Console.ReadLine();
                    } while (!int.TryParse(eingabe, out motorrad));
                int[] stellen = { auto, motorrad};
                stellplatz.Add(stellen);
            }
            _parkhaus = new Parkhaus(name, decks, stellplatz);

            Hauptmenu();
        }


        void Hauptmenu() {
            string[] _optionen = { "Bearbeiten", "Simulation","Beenden"};
            _menu = new Menu(_titel, _optionen);

            int _auswahlIndex = _menu.Run();

            Console.Clear();
            Console.CursorVisible = false;
            if(_auswahlIndex == 0)
                ParkhausBearbeiten();
            if(_auswahlIndex == 1)
                Simulation();
            if(_auswahlIndex == 2)
                Environment.Exit(0);
            
        }
        public void ParkhausBearbeiten()
        {
            string eingabe;
            int decks;
            List<int[]> stellplatz = new List<int[]> {};
            int auto;
            int motorrad;


            Console.Clear();
            Console.Write("Parkhaus Name: ");
            string name = Console.ReadLine();

            do
            {
                Console.Write($"Anzahl Parkdecks, bisher {_parkhaus.Parkstellen.Count}: ");
                eingabe = Console.ReadLine();
            } while (!int.TryParse(eingabe, out decks));
            for (int deck = 0; deck < decks; deck++)
            {
                do {
                        Console.Write($"Anzahl der Auto Parkstellen auf deck {deck}: ");
                        eingabe = Console.ReadLine();
                    } while (!int.TryParse(eingabe, out auto));
                do
                    {
                        Console.Write($"Anzahl der Motorrad Parkstellen auf deck {deck}: ");
                        eingabe = Console.ReadLine();
                    } while (!int.TryParse(eingabe, out motorrad));
                int[] stellen = { auto, motorrad};
                stellplatz.Add(stellen);
            }
            _parkhaus = new Parkhaus(name, decks, stellplatz);

            Hauptmenu();
        }

        public void Simulation()
        {
            FahrzeugeErstellen(_parkhaus.Parkstellen.Count);


        }
        //Anzahl der erzeugten Fahrzeuge abhängig von Parkhaus größe
        void FahrzeugeErstellen(int parkstellen)
        {
            Random rand = new Random();
            string kennzeichen;

            for (int kfz = 0; kfz < parkstellen*2; kfz++)
            {
                FahrzeugType[] alleFahrzeugtypen = (FahrzeugType[])Enum.GetValues(typeof(FahrzeugType));
                FahrzeugType zufallsType = alleFahrzeugtypen[rand.Next(alleFahrzeugtypen.Length)];

                Landkreis[] alleKreise = (Landkreis[])Enum.GetValues(typeof(Landkreis));
                Landkreis zufallsKreis = alleKreise[rand.Next(alleKreise.Length)];

                char a = (char) rand.Next(65,90);
                char b = (char) rand.Next(65,90);            
                int zufallsZahl = rand.Next(1,9999);

                kennzeichen = $"{zufallsKreis} {a}{b} {zufallsZahl}"; 

                _fahrzeug.Add(new Fahrzeug(zufallsType, kennzeichen));
            }
            
        }
    }
}
