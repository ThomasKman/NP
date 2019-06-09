using System;
using System.Collections.Generic;
using System.Linq;
using static Notenverwaltung.Grafiken;
using static Notenverwaltung.UI;
using static System.Console;
using static System.ConsoleColor;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    public class HauptMenu : Menu
    {
        private int navIndex;
        private int menuModifier;
        private List<string> Menupunkte = new List<string>();

        

        public  HauptMenu(){
            this.navIndex = 0;
            this.menuModifier = 0;
            this.Menupunkte = new List<string>() { "Klassenübersicht", "Laden", "Speichern", "Beenden" };
         }

        public override int Navigieren(ConsoleKey gedrückteTaste)
        {

            menuModifier = 0;

            if (gedrückteTaste.Equals(ConsoleKey.Enter))
            {
                gedrückteTaste = Ausführen();
            }

            if (gedrückteTaste.Equals(ConsoleKey.LeftArrow))
            {
                if (navIndex > 0)
                {
                    navIndex--;
                }
                else
                {
                    navIndex = Menupunkte.Count() - 1;
                }
            }
            if (gedrückteTaste.Equals(ConsoleKey.RightArrow))
            {
                if (navIndex < Menupunkte.Count() - 1)
                {
                    navIndex++;
                }
                else
                {
                    navIndex =0;
                }
            }
            
            return menuModifier;
        }


        public override ConsoleKey Ausführen()
        {
            menuModifier = 0;
            if (navIndex == 0)
            {
                menuModifier++;

                navIndex = 0;
            }


            if (navIndex == 1)
            {
                Program.klassenListe = FileReader.readFiles();
                return Bestätigen("Laden Erfolgreich");
                
            }

            if (navIndex == 2)
            {
                return FileWriter.saveFile(Program.klassenListe);

            }

            if (navIndex == 3)
            {
                ConsoleKey key = zeichneDialog("wirklich beenden? [Y/n]", DarkRed, Red);
                if (key.Equals(ConsoleKey.Enter) || key.Equals(ConsoleKey.Y))
                {
                    menuModifier--;
                    navIndex = 0;
                }
                else
                {
                    return key;
                }
               
            }
            return ConsoleKey.Enter;

        }



        public override void UpDateMenu()
        {


            ZeichneMenuPunkte(1, 14, WindowWidth-2, navIndex,  Menupunkte);
        }


    }
}
