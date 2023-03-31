using System;
using System.Collections.Generic;

namespace ParkMaster
{
    public class ParkMaster {
        ParkhausSimulator _sim = new ParkhausSimulator();
        Nutzer _nutzer;
        Random _rand = new Random();
        Menu? _menu;
        string _titel = "ParkMaster3000";

        public ParkMaster()
        {
            _nutzer = new Nutzer(_sim.ParkhausAnlegen());
            Bearbeiten();
        }
        


        void Bearbeiten() {
            string[] _optionen = { "Bearbeiten", "Simulation","Beenden"};
            _menu = new Menu(_titel, _optionen);

            int _auswahlIndex = _menu.Run();

            Console.CursorVisible = false;
            if(_auswahlIndex == 0)
                _nutzer = new Nutzer(_sim.ParkhausAnlegen());
                Bearbeiten();
            if(_auswahlIndex == 1)
                Simulation();
            if(_auswahlIndex == 2)
                Environment.Exit(0);
            
        }



        void Simulation()
        {
            ConsoleKey key;
            
            do{




                key = Console.ReadKey().Key;
            } while(key != ConsoleKey.Enter);

            Bearbeiten();
        }
        //Anzahl der erzeugten Fahrzeuge abhängig von Parkhaus größe
        
        void ParkstellenAnzeigen(){
            char deck = (char) 65;
            foreach (var stelle in _nutzer.Parkhaus.Parkstelle)
            {
                if (stelle.DeckName != deck)
                    Console.WriteLine(); 
                if(stelle.Fahrzeug != null)                   
                    Console.Write($" {stelle.DeckName} {stelle.PlatzNr} {stelle.Fahrzeug.Kennzeichen}    ");
                Console.Write($" {stelle.DeckName} {stelle.PlatzNr}             ");
                deck = stelle.DeckName;

            }
        }
    }
}
