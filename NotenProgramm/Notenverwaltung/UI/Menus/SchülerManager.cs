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
                ZeichneMenu();
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
                ConsoleKey key = zeichneDialog("wirklich beenden? [Y/n]", DarkRed, Red);
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




            ZeichneMenuPunkte(1, 14, WindowWidth - 2, navIndex, Menupunkte);

            if (menuIndex.Equals(3))
            {
                generiereSchülerListe();
                zeichneElementListe(SchülerListe, -1);
            }
            else
            {

                zeichneBox(1, 21, (WindowWidth / 4) - 2, 25, ' ', Black, Black, false);
            }

        }
        private void generiereSchülerListe()
        {
            SchülerListe.Clear();
            if (AktuelleSchulklasse.getSchülerListe().Any()) { 
            foreach (Schüler schüler in AktuelleSchulklasse.getSchülerListe())
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
                UI.AktuellerSchüler = AktuelleSchulklasse.getSchülerListe().ElementAt(auswahlIndex);
                zeichneObjektInfo(AktuelleSchulklasse.showInfo(), 2, false);
                zeichneElementListe(SchülerListe, auswahlIndex);
                gedrückteTaste = ReadKey(true).Key;



                if (gedrückteTaste.Equals(ConsoleKey.UpArrow))
                {
                    if (auswahlIndex > 0)
                    {
                        auswahlIndex--;

                        zeichneObjektInfo(AktuelleSchulklasse.showInfo(), 2, true);
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

                        zeichneObjektInfo(AktuelleSchulklasse.showInfo(), 2, true);
                    }
                    else
                    {
                        auswahlIndex = 0;
                    }
                }
                zeichneElementListe(SchülerListe, auswahlIndex);

                if (gedrückteTaste.Equals(ConsoleKey.Escape))
                {
                    exit = true;
                }

                if (gedrückteTaste.Equals(ConsoleKey.Enter))
                {
                    //ZeichneKlassenUnterMenu();
                    exit = true;
                }


                SetCursorPosition(0, 0);

                Write(menuIndex + "  " + AktuelleSchulklasse.getName());



            } while (!exit);

            zeichneObjektInfo(AktuelleSchulklasse.showInfo(), 2, true);


        }

        static void neuerSchüler()
        {


            List<string> EingabeInfo = new List<string>() { "string", "Vorname  :", "string", "Nachname : " };
            List<string> Name;


            Name = zeichneEingabeMenü(EingabeInfo);

            AktuelleSchulklasse.getSchülerListe().Add(new Schüler(Name.First(), Name.Last()));
            AktuelleSchulklasse.findeSchüler(Name.Last()).neuesZeugnis(AktuelleSchulklasse.getSemester(), AktuelleSchulklasse.getSchuljahr());


            CursorVisible = false;
            ConsoleKey Key = Bestätigen("Speichern? [Y/n]");
            if (Key.Equals(ConsoleKey.Enter) || Key.Equals(ConsoleKey.Y))
            {
                FileWriter.saveFile(Program.klassenListe);
            }

            zeichneTextBox(38, 38, '#', Black, Black, NeuerSchülerDialog);


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
               // zeichneObjektInfo(KlassenInfo, 2, false);
              //  zeichneElementListe(KlassenListe, auswahlIndex);
                gedrückteTaste = ReadKey(true).Key;



                if (gedrückteTaste.Equals(ConsoleKey.UpArrow))
                {
                    if (auswahlIndex > 0)
                    {
                        auswahlIndex--;

             //           zeichneObjektInfo(KlassenInfo, 2, true);
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

                     //   zeichneObjektInfo(KlassenInfo, 2, true);
                    }
                    else
                    {
                        auswahlIndex = 0;
                    }
                }
                zeichneElementListe(SchülerListe, auswahlIndex);

                if (gedrückteTaste.Equals(ConsoleKey.Escape))
                {
                    exit = true;
                }

                if (gedrückteTaste.Equals(ConsoleKey.Enter))
                {
                 //   ZeichneKlassenUnterMenu();
                    exit = true;
                }


                SetCursorPosition(0, 0);

                Write(menuIndex + "  " + AktuelleSchulklasse.getName());



            } while (!exit);

       //     zeichneObjektInfo(AktuelleSchulklasse.showInfo(), 2, true);


        }
    }
}
