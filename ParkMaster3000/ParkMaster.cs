using System;
using System.Collections.Generic;

namespace ParkMaster3000
{
    public class ParkMaster {
        Parkhaus _parkhaus;
        List<Fahrzeug> _fahrzeug;
        Menu _menu;
        public enum FahrzeugType
        {
            Auto,
            Motorrad
        }



        public void ParkhausAnlegen()
        {
            string name = Console.ReadLine();
            int decks = 0;
            bool eingabe = false;
            {
                try
                {
                    decks = Convert.ToInt32(Console.ReadLine());
                    eingabe = true;
                }
                catch (Exception)
                {

                }
            } while (!eingabe)

            for (int deck = 0; deck < decks; deck++)
            {
                    eingabe = false;
                    {
                        try
                        {
                            decks = Convert.ToInt32(Console.ReadLine());
                            eingabe = true;
                        }
                        catch (Exception)
                        {

                        }
                    } while (!eingabe)
            }
            _parkhaus = new Parkhaus(name, decks, autoMotorrad);
        }

        public void ParkhausBearbeiten()
        {

        }

        public void Simulation()
        {

        }
        //Anzahl der erzeugten Fahrzeuge abhängig von Parkhaus größe
        void FahrzeugeErstellen(int anzParkstellen)
        {

        }
    }
}
