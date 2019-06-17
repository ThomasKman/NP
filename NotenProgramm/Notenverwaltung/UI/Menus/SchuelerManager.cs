using System;
using System.Collections.Generic;
using System.Linq;
 



using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    public class Schülermanager : Menu
    {
        private int navIndex;
        private int menuModifier;
        private List<string> Menupunkte = new List<string>();

        private List<string> SchülerListe = new List<string>();


        public Schülermanager(){
            this.navIndex = 0;
            this.menuModifier = 0;
            this.Menupunkte = new List<string>() { "Schülerübersicht", "Neuer Schüler", "Zurück zum Klassenmanager", "Beenden" };
            generiereSchülerListe();
         }

        public override int Navigieren(ConsoleKey gedrückteTaste)
        {

            menuModifier = 0;

            if (gedrückteTaste.Equals(ConsoleKey.Enter))
            {
                gedrückteTaste = Ausführen();
            }

            if (gedrückteTaste.Equals(ConsoleKey.Enter))
            {
               Grafiken.ZeichneMenu();
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
                    navIndex = 0;
                }
            }

            return menuModifier;
        }

        public override ConsoleKey Ausführen()
        {


            if (navIndex == 0)
            {
                NavigiereSchülerAuswahl();
            }


            if (navIndex == 1)
            {
                neuerSchüler();
            }

            if (navIndex == 2)
            {
                menuModifier--;
                navIndex = 0;

            }

            if (navIndex == 3)
            {
                ConsoleKey key =Grafiken.zeichneDialog("wirklich beenden? [Y/n]", ConsoleColor.DarkRed,ConsoleColor.Red);
                if (key.Equals(ConsoleKey.Enter) || key.Equals(ConsoleKey.Y))
                {
                    menuModifier = -3;
                }
                else
                {
                    return key;
                }

            }
            return ConsoleKey.Enter;

        }



        public override void UpDateMenu()  // In Grafiken Packen, auto generieren mit auto abständen zwischen MenüPunkten. Überschrift über box! 
        {




           Grafiken.ZeichneMenuPunkte(1, 14, Console.WindowWidth - 2, navIndex, Menupunkte);

            if (UI.menuIndex.Equals(3))
            {
                generiereSchülerListe();
                Grafiken.zeichneElementListe(SchülerListe, -1);
            }
            else
            {

                Grafiken.zeichneBox(1, 21, (Console.WindowWidth / 4) - 2, 25, ' ', ConsoleColor.Black, ConsoleColor.Black, false);
            }

        }
        private void generiereSchülerListe()
        {
            SchülerListe.Clear();
            if (UI.AktuelleSchulklasse.getSchülerListe().Any()) { 
            foreach (Schüler schüler in UI.AktuelleSchulklasse.getSchülerListe())
            {

                SchülerListe.Add(schüler.getNachName()+" "+schüler.getVorName());
            }
            }

        }
        public void NavigiereSchülerAuswahl()
        {
            bool exit = false;
            int auswahlIndex = 0;


            ConsoleKey gedrückteTaste;
            do
            {
                if (!Program.klassenListe.Any())
                {
                 //   neueKlasse();
                }
                UI.AktuellerSchüler = UI.AktuelleSchulklasse.getSchülerListe().ElementAt(auswahlIndex);
                Grafiken.zeichneObjektInfo(UI.AktuellerSchüler.showInfo(), 2, false);
                Grafiken.zeichneElementListe(SchülerListe, auswahlIndex);
                gedrückteTaste = Console.ReadKey(true).Key;



                if (gedrückteTaste.Equals(ConsoleKey.UpArrow))
                {
                    if (auswahlIndex > 0)
                    {
                        auswahlIndex--;

                        Grafiken.zeichneObjektInfo(UI.AktuellerSchüler.showInfo(), 2, true);
                    }
                    else
                    {
                        exit = true;
                    }
                }
                if (gedrückteTaste.Equals(ConsoleKey.DownArrow))
                {
                    if (auswahlIndex < SchülerListe.Count() - 1)
                    {
                        auswahlIndex++;

                        Grafiken.zeichneObjektInfo(UI.AktuellerSchüler.showInfo(), 2, true);
                    }
                    else
                    {
                        auswahlIndex = 0;
                    }
                }
                Grafiken.zeichneElementListe(SchülerListe, auswahlIndex);

                if (gedrückteTaste.Equals(ConsoleKey.Escape))
                {
                    exit = true;
                }

                if (gedrückteTaste.Equals(ConsoleKey.Enter))
                {
                    //ZeichneKlassenUnterMenu();
                    exit = true;
                }


                Console.SetCursorPosition(0, 0);

                Console.Write(UI.menuIndex + "  " + UI.AktuelleSchulklasse.getName());



            } while (!exit);

            Grafiken.zeichneObjektInfo(UI.AktuellerSchüler.showInfo(), 2, true);


        }

        static void neuerSchüler()
        {


            List<string> EingabeInfo = new List<string>() { "string", "Vorname  :", "string", "Nachname : " };
            List<string> Name;


            Name = Grafiken.zeichneEingabeMenü(EingabeInfo);

            UI.AktuelleSchulklasse.AddSchüler(Name.First(), Name.Last());


            Console.CursorVisible = false;
            ConsoleKey Key = Grafiken.Bestätigen("Speichern? [Y/n]");
            if (Key.Equals(ConsoleKey.Enter) || Key.Equals(ConsoleKey.Y))
            {
                FileWriter.saveFile(Program.klassenListe);
            }

            Grafiken.zeichneTextBox(38, 38, '#', ConsoleColor.Black, ConsoleColor.Black, Grafiken.NeuerSchülerDialog);


        }
        public void NavigiereKlassenAuswahl()
        {
            bool exit = false;
            int auswahlIndex = 0;


            ConsoleKey gedrückteTaste;
            do
            {
                if (!Program.klassenListe.Any())
                {
                    neuerSchüler();
                }
                UI.AktuelleSchulklasse = Program.klassenListe.ElementAt(auswahlIndex);
               // generiereKlassenInfo();
               // Grafiken.zeichneObjektInfo(KlassenInfo, 2, false);
              //  Grafiken.zeichneElementListe(KlassenListe, auswahlIndex);
                gedrückteTaste = Console.ReadKey(true).Key;



                if (gedrückteTaste.Equals(ConsoleKey.UpArrow))
                {
                    if (auswahlIndex > 0)
                    {
                        auswahlIndex--;

             //           Grafiken.zeichneObjektInfo(KlassenInfo, 2, true);
                    }
                    else
                    {
                        exit = true;
                    }
                }
                if (gedrückteTaste.Equals(ConsoleKey.DownArrow))
                {
                    if (auswahlIndex < SchülerListe.Count() - 1)
                    {
                        auswahlIndex++;

                     //   Grafiken.zeichneObjektInfo(KlassenInfo, 2, true);
                    }
                    else
                    {
                        auswahlIndex = 0;
                    }
                }
                Grafiken.zeichneElementListe(SchülerListe, auswahlIndex);

                if (gedrückteTaste.Equals(ConsoleKey.Escape))
                {
                    exit = true;
                }

                if (gedrückteTaste.Equals(ConsoleKey.Enter))
                {
                 //   ZeichneKlassenUnterMenu();
                    exit = true;
                }


                Console.SetCursorPosition(0, 0);

                Console.Write(UI.menuIndex + "  " + UI.AktuelleSchulklasse.getName());



            } while (!exit);

       //     Grafiken.zeichneObjektInfo(UI.AktuelleSchulklasse.showInfo(), 2, true);


        }
    }
}
