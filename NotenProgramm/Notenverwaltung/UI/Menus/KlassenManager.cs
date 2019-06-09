using System;
using System.Collections.Generic;
using System.Linq;
using static Notenverwaltung.Grafiken;
using static Notenverwaltung.UI;
using static System.Console;
using static System.ConsoleColor;

namespace Notenverwaltung
{
    public class KlassenManager : Menu
    {
        private int navIndex;
        private int menuModifier;

        private List<string> KlassenInfo;
        private List<string> Menupunkte;
        private List<string> KlassenListe;
        public KlassenManager()
        {
            this.navIndex = 0;
            this.menuModifier = 0;
            this.Menupunkte = new List<string>() { "Klasse Auswählen", "Neue Klasse", "Zurück zum Hauptmenü", "Beenden" };
            this.KlassenListe = new List<string>();
            this.KlassenInfo = new List<string>() {"Keine Daten"};
            generiereKlassenListe();
            generiereKlassenInfo();
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
                NavigiereKlassenAuswahl(-1);
            }


            if (navIndex == 1)
            {
                neueKlasse();
            }

            if (navIndex == 2)
            {
                menuModifier--;


            }

            if (navIndex == 3)
            {
                ConsoleKey key = zeichneDialog("wirklich beenden? [Y/n]", DarkRed, Red);
                if (key.Equals(ConsoleKey.Enter) || key.Equals(ConsoleKey.Y))
                {
                    menuModifier = -2;
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

            if (menuIndex.Equals(2))
            {
                zeichneElementListe(KlassenListe, -1);
            }
            else
            {

                zeichneBox(1, 21, (WindowWidth / 4) - 2, 25, ' ', Black, Black, false);
            }

        }
        private void generiereKlassenListe()
        {
            KlassenListe.Clear();
            foreach (SchulKlasse klasse in Program.klassenListe)
            {

                KlassenListe.Add(klasse.getName());
            }

        }
        public void NavigiereKlassenAuswahl(int index)
        {

            bool exit = false;
            int auswahlIndex = 0;
            ZeichneMenuPunkte(33, 20, 86, -1, new List<string>() { "SchülerManager", "Neues Schulfach", "Versetzen", "klasse Löschen" });

            ConsoleKey gedrückteTaste;
            do
            {
                if (!Program.klassenListe.Any())
                {
                    neueKlasse();
                }
                UI.AktuelleSchulklasse = Program.klassenListe.ElementAt(auswahlIndex);

                SetCursorPosition(0, 0);

                Write(menuIndex + "  " + AktuelleSchulklasse.getName());
                generiereKlassenInfo();
                zeichneObjektInfo(KlassenInfo, 3, false);
                zeichneElementListe(KlassenListe, auswahlIndex);
                gedrückteTaste = ReadKey(true).Key;
                


                    if (gedrückteTaste.Equals(ConsoleKey.UpArrow))
                    {
                        if (auswahlIndex > 0)
                        {
                            auswahlIndex--;

                        zeichneObjektInfo(KlassenInfo, 3, true);
                    }
                        else
                        {
                            exit = true;
                        }
                    }
                    if (gedrückteTaste.Equals(ConsoleKey.DownArrow))
                    {
                        if (auswahlIndex < KlassenListe.Count() - 1)
                        {
                            auswahlIndex++;

                        zeichneObjektInfo(KlassenInfo, 3, true);
                    }
                        else
                        {
                            auswahlIndex = 0;
                        }
                    }
                    zeichneElementListe(KlassenListe, auswahlIndex);

                    if (gedrückteTaste.Equals(ConsoleKey.Escape))
                    {
                        exit = true;
                    }

                if (gedrückteTaste.Equals(ConsoleKey.Enter) || gedrückteTaste.Equals(ConsoleKey.RightArrow)) 
                {
                    ZeichneKlassenUnterMenu(0);
                    
                }





                } while (!exit) ;

                zeichneObjektInfo(AktuelleSchulklasse.showInfo(), 3, true);

            
        }
    

            private void ZeichneKlassenUnterMenu(int index)
            {

                int KlassenUntermenuIndex = index;
                bool unterExit = false;
                do
                {
                    ZeichneMenuPunkte(33, 20,86, KlassenUntermenuIndex, new List<string>() { "SchülerManager","Neues Schulfach","Versetzen","klasse Löschen"});

                zeichneObjektInfo(AktuelleSchulklasse.showInfo(), 3, false);

                ConsoleKey gedrückteTaste = ReadKey(true).Key;

                    if (gedrückteTaste.Equals(ConsoleKey.LeftArrow))
                    {
                        if (KlassenUntermenuIndex > 0)
                        {
                            KlassenUntermenuIndex--;
                        }
                        
                    }
                if (gedrückteTaste.Equals(ConsoleKey.DownArrow))
                {
                    if (KlassenUntermenuIndex <4)
                    {
                        KlassenUntermenuIndex+=2;
                        if (KlassenUntermenuIndex > 3)
                        {
                            KlassenUntermenuIndex = 3;
                        }
                    }
                   
                }
                if (gedrückteTaste.Equals(ConsoleKey.UpArrow))
                {
                    if (KlassenUntermenuIndex > 1)
                    {
                        KlassenUntermenuIndex -= 2;
                    }

                }
                if (gedrückteTaste.Equals(ConsoleKey.RightArrow))
                    {
                        if (KlassenUntermenuIndex <3)
                        {
                       
                            KlassenUntermenuIndex++;
                        }
                       
                    }
                if(gedrückteTaste.Equals(ConsoleKey.Enter))
                    {
                    if (KlassenUntermenuIndex ==3)
                    {
                        zeichneObjektInfo(AktuelleSchulklasse.showInfo(), 3, true);
                        KlasseLöschen();
                    }
                   


                    if (KlassenUntermenuIndex == 1)
                    {

                       neuesSchulfach();
                    }
                    if (KlassenUntermenuIndex == 2)
                    {
                        ConsoleKey key = Bestätigen("Klasse versetzen? [Y/n]");
                    if ( key.Equals(ConsoleKey.Enter));
                        AktuelleSchulklasse.versetzen();
                    }
                    if (KlassenUntermenuIndex ==0)
                    {
                        menuModifier++;
                        navIndex = 0;
                        KlassenUntermenuIndex = 0;
                        unterExit = true;
                        
                    }

                }
                if (gedrückteTaste.Equals(ConsoleKey.Escape))
                {

                    unterExit = true;
                   

                }


            } while (!unterExit);

                zeichneBox(40, 40, 40, 8, ' ', Black, Black);
            }
        


        private  void generiereKlassenInfo()
        {
            KlassenInfo.Clear();
            KlassenInfo = AktuelleSchulklasse.showInfo();
            if (AktuelleSchulklasse.getSchülerListe().Any() && AktuelleSchulklasse.getSchülerListe().First().getZeugnisse().Any()&& AktuelleSchulklasse.getSchülerListe().First().getZeugnisse().First().getSchulFächer().Any())
            {

                KlassenInfo.Add("Fächer: " + AktuelleSchulklasse.getSchülerListe().First().getAktuellesZeugnis().getSchulFächer().Count().ToString());
                foreach (Schüler schüler in AktuelleSchulklasse.getSchülerListe())
                {
                    foreach(Zeugnis zeugnis in schüler.getZeugnisse())
                    {
                        foreach(Schulfach schulfach in zeugnis.getSchulFächer())
                        {
                            if (!KlassenInfo.Contains(schulfach.getFachrichtung())){


                                KlassenInfo.Add(schulfach.getFachrichtung());
                                
                            }
                        }
                    }
                }
            }
        }





        private void neueKlasse()
        {
            List<string> temp = new List<string>();

            int top = 40;
            int left = 40;
            // zeichneTextBox(left+1, top, '+',DarkGray ,White , NeueKlasseDialog);
            temp=zeichneEingabeMenü(new List<string>() {"string","Name :","int","Kalenderjahr: ","int","Semester: " });


            Program.klassenListe.Add(new SchulKlasse(temp.ElementAt(0),Int32.Parse(temp.ElementAt(1)),Int32.Parse(temp.ElementAt(2))));

            zeichneTextBox(left+1, top+1, '!', Gray, Black, KlasseSpeichernDialog);

            CursorVisible = false;
            if (ReadKey().Key.Equals(ConsoleKey.Enter) || ReadKey().Key.Equals(ConsoleKey.Y))
            {
                FileWriter.saveFile(Program.klassenListe);
                FileReader.readFiles();
                
            }

            zeichneBox(left, top, 51, 5, ' ', Black, Black, false);
            generiereKlassenListe();

            NavigiereKlassenAuswahl(Program.klassenListe.Count());
        }


        private void KlasseLöschen()
        {
            ConsoleKey key = zeichneDialog("wirklich Löschen? [Y/n]", DarkRed, Red);
           
            if (key.Equals(ConsoleKey.Enter) || key.Equals(ConsoleKey.Y))
            {
                Program.klassenListe.Remove(AktuelleSchulklasse);
                menuIndex--;
                navIndex = 0;

               
                key = zeichneDialog("Gelöscht. Speichern? [Y/n]", DarkGreen, Green);
                if (key.Equals(ConsoleKey.Enter) || key.Equals(ConsoleKey.Y))
                {
                    FileWriter.saveFile(Program.klassenListe);
                }
               


               



            }

        }
        private void neuesSchulfach()
        {
          List<string> fachName = zeichneEingabeMenü(new List<string>() { "string", "Name  : ", "" });

            AktuelleSchulklasse.addSchulfach( fachName.First());
            ConsoleKey Key = Bestätigen("Speichern? [Y/n]");
            if (Key.Equals(ConsoleKey.Enter) || Key.Equals(ConsoleKey.Y))
            {
                FileWriter.saveFile(Program.klassenListe);
                FileReader.readFiles();
            }



            generiereKlassenInfo();
            zeichneObjektInfo(KlassenInfo,3,false);
        }

       
    }
}
