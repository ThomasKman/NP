using System;
using System.Collections.Generic;
using System.Linq;
 




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
            if (gedrückteTaste.Equals(ConsoleKey.DownArrow))
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
                ConsoleKey key =Grafiken.zeichneDialog("wirklich beenden? [Y/n]", ConsoleColor.DarkRed,ConsoleColor.Red);
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




           Grafiken.ZeichneMenuPunkte(1, 14, Console.WindowWidth - 2, navIndex, Menupunkte);

            if (UI.menuIndex.Equals(2))
            {
                Grafiken.zeichneElementListe(KlassenListe, -1);
            }
            else
            {

                Grafiken.zeichneBox(1, 21, (Console.WindowWidth / 4) - 2, 25, ' ', ConsoleColor.Black, ConsoleColor.Black, false);
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
           Grafiken.ZeichneMenuPunkte(33, 20, 86, -1, new List<string>() { "SchülerManager", "Neues Schulfach", "Versetzen", "klasse Löschen" });

            ConsoleKey gedrückteTaste;
            do
            {
                if (!Program.klassenListe.Any())
                {
                    neueKlasse();
                }
                UI.AktuelleSchulklasse = Program.klassenListe.ElementAt(auswahlIndex);

                Console.SetCursorPosition(0, 0);

                Console.Write(UI.menuIndex + "  " + UI.AktuelleSchulklasse.getName());
                UpDateMenu();
                generiereKlassenInfo();
                Grafiken.zeichneObjektInfo(KlassenInfo, 3, false);
                Grafiken.zeichneElementListe(KlassenListe, auswahlIndex);
                gedrückteTaste = Console.ReadKey(true).Key;
                


                    if (gedrückteTaste.Equals(ConsoleKey.UpArrow))
                    {
                        if (auswahlIndex > 0)
                        {
                            auswahlIndex--;

                        Grafiken.zeichneObjektInfo(KlassenInfo, 3, true);
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

                        Grafiken.zeichneObjektInfo(KlassenInfo, 3, true);
                    }
                        else
                        {
                            auswahlIndex = 0;
                        }
                    }
                    Grafiken.zeichneElementListe(KlassenListe, auswahlIndex);

                    if (gedrückteTaste.Equals(ConsoleKey.Escape))
                    {
                        exit = true;
                    }

                if (gedrückteTaste.Equals(ConsoleKey.Enter) || gedrückteTaste.Equals(ConsoleKey.RightArrow)) 
                {
                    exit=NavigiereKlassenUnterMenu(0);
                    auswahlIndex = 0;
                    generiereKlassenListe();
                    Grafiken.zeichneElementListe(KlassenListe, auswahlIndex);
                    Grafiken.zeichneObjektInfo(KlassenInfo, 3, true);
                }




            } while (!exit) ;
            
            
            
               
            
            
        }
    

            private bool NavigiereKlassenUnterMenu(int index)
            {

                int KlassenUntermenuIndex = index;
                bool unterExit = false;
                do
                {
                   Grafiken.ZeichneMenuPunkte(33, 20,86, KlassenUntermenuIndex, new List<string>() { "SchülerManager","Neues Schulfach","Versetzen","klasse Löschen"});

                Grafiken.zeichneObjektInfo(KlassenInfo, 3, false);

                ConsoleKey gedrückteTaste = Console.ReadKey(true).Key;

                    if (gedrückteTaste.Equals(ConsoleKey.LeftArrow))
                    {
                    if (KlassenUntermenuIndex > 0)
                    {
                    KlassenUntermenuIndex--;
                    }
                    else
                    {
                        Grafiken.ZeichneMenuPunkte(33, 20, 86, -1, new List<string>() { "SchülerManager", "Neues Schulfach", "Versetzen", "klasse Löschen" });
                        return false;
                    }
                        
                    }
               
                if (gedrückteTaste.Equals(ConsoleKey.UpArrow))
                {

                    Grafiken.zeichneBox((Console.WindowWidth/4)+3, 20, ((Console.WindowWidth /4)*3)-5, 1, ' ', ConsoleColor.Black, ConsoleColor.Black);
                    return true;

                }
                if (gedrückteTaste.Equals(ConsoleKey.RightArrow))
                    {
                        if (KlassenUntermenuIndex <3)
                        {
                       
                            KlassenUntermenuIndex++;
                        }
                       
                    }
                if (gedrückteTaste.Equals(ConsoleKey.Enter) || gedrückteTaste.Equals(ConsoleKey.DownArrow))
                    {
                    if (KlassenUntermenuIndex ==3)
                    {
                        Grafiken.zeichneObjektInfo(KlassenInfo, 3, true);
                        KlasseLöschen();
                        Grafiken.ZeichneMenuPunkte(33, 20, 86, -1, new List<string>() { "SchülerManager", "Neues Schulfach", "Versetzen", "klasse Löschen" });
                        return false;
                    }
                   


                    if (KlassenUntermenuIndex == 1)
                    {

                       neuesSchulfach();
                    }
                    if (KlassenUntermenuIndex == 2)
                    {
                        ConsoleKey key = Grafiken.Bestätigen("Klasse versetzen? [Y/n]");
                    if ( key.Equals(ConsoleKey.Enter))
                        {

                            UI.AktuelleSchulklasse.versetzen();

                            Grafiken.ZeichneMenuPunkte(33, 20, 86, -1, new List<string>() { "SchülerManager", "Neues Schulfach", "Versetzen", "klasse Löschen" });
                            return false;
                            
                        }

                    }
                    if (KlassenUntermenuIndex ==0)
                    {
                        menuModifier++;
                        navIndex = 0;
                        unterExit = true;

                        Grafiken.ZeichneMenuPunkte(33, 20, 86, -1, new List<string>() { "SchülerManager", "Neues Schulfach", "Versetzen", "klasse Löschen" });
                    }

                }
                if (gedrückteTaste.Equals(ConsoleKey.Escape))
                {

                    Grafiken.ZeichneMenuPunkte(33, 20, 86, -1, new List<string>() { "SchülerManager", "Neues Schulfach", "Versetzen", "klasse Löschen" });
                    return true;
                   

                }

                
            } while (!unterExit);

            return unterExit;


            }
        


        private  void generiereKlassenInfo()
        {
            KlassenInfo.Clear();
            KlassenInfo = UI.AktuelleSchulklasse.showInfo();
            if (KlassenInfo.Count() > 11)
            {
                KlassenInfo.RemoveRange(11, KlassenInfo.Count - 11);
            }
        }





        private void neueKlasse()
        {
            List<string> temp = new List<string>();

            int top = 40;
            int left = 40;
            // Grafiken.zeichneTextBox(left+1, top, '+',DarkConsoleColor.Gray ,White , NeueKlasseDialog);
            temp=Grafiken.zeichneEingabeMenü(new List<string>() {"string","Name :","int","Kalenderjahr: ","int","Semester: " });


            Program.klassenListe.Add(new SchulKlasse(temp.ElementAt(0),Int32.Parse(temp.ElementAt(1)),Int32.Parse(temp.ElementAt(2))));

            Grafiken.zeichneTextBox(left+1, top+1, '!', ConsoleColor.Gray, ConsoleColor.Black, Grafiken.KlasseSpeichernDialog);

            Console.CursorVisible = false;
            if (Console.ReadKey().Key.Equals(ConsoleKey.Enter) || Console.ReadKey().Key.Equals(ConsoleKey.Y))
            {
                FileWriter.saveFile(Program.klassenListe);
                FileReader.readFiles();
                
            }

            Grafiken.zeichneBox(left, top, 51, 5, ' ', ConsoleColor.Black, ConsoleColor.Black, false);
            generiereKlassenListe();

            NavigiereKlassenAuswahl(Program.klassenListe.Count());
        }


        private void KlasseLöschen()
        {
            ConsoleKey key =Grafiken.zeichneDialog("wirklich Löschen? [Y/n]", ConsoleColor.DarkRed,ConsoleColor.Red);
           
            if (key.Equals(ConsoleKey.Enter) || key.Equals(ConsoleKey.Y))
            {
                Program.klassenListe.Remove(UI.AktuelleSchulklasse);
                UI.menuIndex--;
                navIndex = 0;

               
                key =Grafiken.zeichneDialog("Gelöscht. Speichern? [Y/n]", ConsoleColor.DarkGreen,ConsoleColor.Green);
                if (key.Equals(ConsoleKey.Enter) || key.Equals(ConsoleKey.Y))
                {
                    FileWriter.saveFile(Program.klassenListe);
                }
               


               



            }

        }

        private void neuesSchulfach()
        {
          List<string> fachName = Grafiken.zeichneEingabeMenü(new List<string>() { "string", "Name  : " });

            UI.AktuelleSchulklasse.AddSchulfach( fachName.First());
            ConsoleKey Key = Grafiken.Bestätigen("Speichern? [Y/n]");
            if (Key.Equals(ConsoleKey.Enter) || Key.Equals(ConsoleKey.Y))
            {
                FileWriter.saveFile(Program.klassenListe);
                FileReader.readFiles();
            }



            generiereKlassenInfo();
            Grafiken.zeichneObjektInfo(KlassenInfo,3,false);
        }

       
    }
}
