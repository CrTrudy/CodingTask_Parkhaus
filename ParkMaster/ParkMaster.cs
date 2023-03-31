using System;
using System.Collections.Generic;

namespace ParkMaster
{
    public class ParkMaster {
        ParkhausSimulator _sim = new ParkhausSimulator();
        Nutzer _nutzer;
        Random _rand = new Random();
        string _titel = "ParkMaster3000";

        public ParkMaster()
        {
            _nutzer = new Nutzer(_sim.ParkhausAnlegen());
            Bearbeiten();
        }
        


        void Bearbeiten() {
            Menu menu;
            string[] optionen = { "Bearbeiten", "Simulation","Beenden"};
            menu = new Menu(_titel, optionen);

            int _auswahlIndex = menu.Run();

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
            ConsoleKeyInfo key;
            List<Fahrzeug> fahrzeuge = _sim.FahrzeugeErstellen(_nutzer.Parkhaus.AlleParkstellen.Count);
            do{
                ParkstellenAnzeigen();

                _nutzer.Parkhaus.Registrierung(fahrzeuge[_rand.Next(fahrzeuge.Count)]);


                key = Console.ReadKey(); 
                Thread.Sleep(_rand.Next(4000));
            } while(key.Key != null);

            Bearbeiten();
        }
        //Anzahl der erzeugten Fahrzeuge abhängig von Parkhaus größe
        
        void ParkstellenAnzeigen(){
            char deck = (char) 65;
            foreach (var stelle in _nutzer.Parkhaus.AlleParkstellen)
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
