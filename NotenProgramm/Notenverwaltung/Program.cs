using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class Program
    {
        public static List<SchulKlasse> klassenListe;

        // TODO: 
        // UI:
        //// Menus mehr automatisieren, Navigation zentralisieren
        //// Weitere Menus: 
        //// Klassenmanager.
        //// HauptfächerManager.
        //// Schülermanager.
        //// Zeugnismanager.
        //// ZeugnisÜbersicht.
        //// LoadOptimierung
        // Backend:
        //// SomiNote
        //// Zugangsberechtigung
        // IO:
        //// Verschlüsseln 
        //// IO Optimierung. 

        // Doku



        static void Main(string[] args)
        {
           
            klassenListe = FileReader.readFiles(); 
            UI.Start();

        }
           

      

        public static SchulKlasse findeKlasse(string Name)
        {
            SchulKlasse gefundeneKlasse = new SchulKlasse("error", 404, 404);
            for (int i = 0; i < Program.klassenListe.Count; i++)
            {
                if (Name == klassenListe.ElementAt(i).getName())
                {
                    gefundeneKlasse = klassenListe.ElementAt(i);
                }
            }

            return gefundeneKlasse;
        }


    }
    



}

