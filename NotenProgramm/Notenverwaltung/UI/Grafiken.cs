using System;
using System.Collections.Generic;
using System.Linq;



using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class Grafiken
    {

            public static string title = @"
________________________________________________________________________________________________________________________
             _   _       _               __  __                                     ____   ___   ___   ___  
            | \ | |     | |             |  \/  |                                   |___ \ / _ \ / _ \ / _ \ 
            |  \| | ___ | |_ ___ _ __   | \  / | __ _ _ __   __ _  __ _  ___ _ __    __) | | | | | | | | | |
            | . ` |/ _ \| __/ _ \ '_ \  | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ '__|  |__ <| | | | | | | | | |
            | |\  | (_) | ||  __/ | | | | |  | | (_| | | | | (_| | (_| |  __/ |     ___) | |_| | |_| | |_| |
            |_| \_|\___/ \__\___|_| |_| |_|  |_|\__,_|_| |_|\__,_|\__, |\___|_|    |____/ \___/ \___/ \___/ 
                                                                   __/ |                                    
                                                                  |___/                                      
________________________________________________________________________________________________________________________";



        public static List<string> NeueKlasseDialog = new List<string>()
        {
            "Name der Klasse        :      ",
            "Aktuelles Semester     :                    ",
            "Aktuelles Kalender Jahr:                    "
        };
        public static List<string> NeuerSchülerDialog = new List<string>()
        {
            "              Neuer  Schüler                ",
            " Vorname :                                  ",
            " Nachname:                                  "
            
        };

        public static List<string> KlasseSpeichernDialog = new List<string>()
        {
            "        Klasse Erstellen Erfolgreich        ",
            "         Auf der Platte speichern?          ",
            "                    Y / n                   "
        };



        public static List<string> KlasseLöschenDialog = new List<string>()
        {
            "         Klasse wirklich löschen?           ",
            "                    Y / n                   ",
            "                                            "
        };



        public static List<string> LöschenErfolgDialog = new List<string>()
        {
            "         Klasse Löschen Erfolgreich         ",
            "         Auf der Platte speichern?          ",
            "                    Y / n                   "
        };



        public static void ZeichneMenu()  //, auto generieren mit auto abständen zwischen MenüPunkten. Überschrift über box! 
        {
            Console.SetCursorPosition(0, 0);
            int top = 0;
           Console.Clear();
            Console.Write(title);
            top =Console.CursorTop+1;
            zeichneRahmen(0, top, Console.WindowWidth - 1, 3, '-', ConsoleColor.Gray, ConsoleColor.Black);
            top +=6;
            zeichneRahmen(0, top, Console.WindowWidth / 4, Console.WindowHeight-(top+3), '#', ConsoleColor.Gray, ConsoleColor.Black);
            zeichneRahmen(Console.WindowWidth / 4 + 2, top, ((Console.WindowWidth / 4) * 3) - 3 , Console.WindowHeight - (top + 3), '+', ConsoleColor.Gray, ConsoleColor.Black);
            Console.SetCursorPosition(0, 0);

        }

        public static void ZeichneMenuPunkte(int left,int top, int breite, int activeElement,  List<string> MenuPunkte)
        {
            int ElementBreite;
            int i;
            Console.SetCursorPosition(left, top);
             
            foreach (string menuPunkt in MenuPunkte)
            {
                i= MenuPunkte.IndexOf(menuPunkt);
                ElementBreite = breite / MenuPunkte.Count();
                if (i == activeElement)
                {
                    if (i == MenuPunkte.Count() - 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;


                    }
                }

                if(i == 0) {

                zeichneTextBox( Console.CursorLeft,Console.CursorTop,ElementBreite +=(breite%ElementBreite),1, ' ', Console.BackgroundColor, Console.ForegroundColor, menuPunkt);
                }
                else
                {

                    zeichneTextBox( Console.CursorLeft,Console.CursorTop, ElementBreite, 1, ' ', Console.BackgroundColor, Console.ForegroundColor, menuPunkt);
                }
                 
                
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            Console.SetCursorPosition(0, 0);
        }

        public static void zeichneElementListe(List<string> Elemente,int NavIndex)
        {
            int top = 21;
            for(int i = 0;i<Elemente.Count;i++)
            { 
                if(i == NavIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;

                }
                Console.SetCursorPosition(2, top);
                top++;
                Console.Write(Elemente.ElementAt(i));
                Console.ResetColor();
            }
        }
        

        public static void zeichneObjektInfo(List<string> ObjectInfo,int anzahlFelder,bool hide)
        {
            ConsoleColor Bg;
            ConsoleColor fg;
            int top = 23;
            int left = (Console.WindowWidth / 4) + 3;
            int breite = (((Console.WindowWidth / 4) * 3)/2)-3;
            if (hide)
            {
                Bg = ConsoleColor.Black;
                 fg = ConsoleColor.Black;

            }
            else
            {
                 Bg = ConsoleColor.Gray;
                 fg = ConsoleColor.Black;
            }
            zeichneTextBox(left, top, breite, 3, '*', fg, Bg, ObjectInfo.First());
            for (int i = 1; i < ObjectInfo.Count; i++)
            {
                if (i <= anzahlFelder)
                {
                    zeichneTextBox(left, top + (5 * i), breite, 3, '#', fg, Bg, ObjectInfo.ElementAt(i));
                }
                else
                {

                    zeichneTextBox(left+breite+1, top + (5 * (i - anzahlFelder-1)), breite, 3, '*', fg, Bg, ObjectInfo.ElementAt(i));
                }

            }


            

        }


        public static List<string> zeichneEingabeMenü(List<string> EingabeFelder)  //Reihenfolge = datentyp, eingabefeld
        {
            List<string> temp = new List<string>();
            int top = 23;
            int left = (Console.WindowWidth / 4) + 3;
            int breite = (((Console.WindowWidth / 4) * 3) / 2) - 3;
            

            for (int i = 1; i < EingabeFelder.Count(); i++)
            {

                if (EingabeFelder.Count==2)
                {
                    zeichneTextBox(left + breite + 1, top, breite, 3, '*', Console.BackgroundColor, ConsoleColor.Cyan, EingabeFelder.ElementAt(i));

                    Console.SetCursorPosition(left + breite + 2 + (breite + EingabeFelder.ElementAt(i).Length) / 2, top + 2);
                }
                else
                {

                    zeichneTextBox(left, top + (5 * (i/2)), breite, 3, '#', Console.BackgroundColor, ConsoleColor.Green, EingabeFelder.ElementAt(i));

                    Console.SetCursorPosition(left +1 + (breite + EingabeFelder.ElementAt(i).Length) / 2, top + (5 * (i / 2))+2);
                   
                }

                
                if (EingabeFelder.ElementAt(i-1).Equals("string"))
                {
                    temp.Add(UI.readString());
                   
                }
                if (EingabeFelder.ElementAt(i-1).Equals("int"))
                {
                    temp.Add(UI.readInt().ToString());
                }
                if (i < EingabeFelder.Count())
                {
                    i++;
                }
            }
            
            return temp;
        }


        public static ConsoleKey Bestätigen(string nachricht)
        {
            return zeichneDialog(nachricht, ConsoleColor.DarkGreen,ConsoleColor.Green);
        }

        public static ConsoleKey zeichneDialog(  string nachricht, ConsoleColor background, ConsoleColor schriftFarbe)
        {
            int top = 30;
            int left = Console.WindowWidth / 2;
            int breite = 30;
            ConsoleKey key;
            Console.BackgroundColor = background;
            Console.ForegroundColor = schriftFarbe;

            zeichneTextBox(left, top, breite, 5, '#', background,schriftFarbe, nachricht);
            Console.ResetColor();


            key = Console.ReadKey().Key;
            zeichneBox(left, top, breite, 5,' ',ConsoleColor.Black,ConsoleColor.Black,false);
            return key;
        }

        public static void zeichneRahmen(int left, int top, int breite, int anzahlZeilen, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe)
        {
            Console.BackgroundColor = hintergrundFarbe;
            Console.ForegroundColor = schriftFarbe;

            Console.SetCursorPosition(left, top);
            for(int i =left; i <left+breite;i++)
            {
                Console.Write(symb);
            }
            for(int i = top;  i<=(top+anzahlZeilen);i++)
            {
                Console.SetCursorPosition(left, i);
                Console.Write(symb);

                Console.SetCursorPosition(left+breite, i);
                Console.Write(symb);
            }
            Console.SetCursorPosition(left, top + anzahlZeilen+1);
            for (int i = left; i <=left + breite; i++)
            {
                Console.Write(symb);
            }
        }


        public static void zeichneBox(int left, int top, int breite, int anzahlZeilen, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe, bool borderInverted)
        {
            ConsoleColor borderColor = Console.BackgroundColor;
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = schriftFarbe;
            if (borderInverted)
            {
                borderColor = schriftFarbe;
                Console.BackgroundColor = borderColor;
                Console.ForegroundColor = hintergrundFarbe;
            }

            Console.Write(symb);
            for (int i = 1; i < breite; i++)
            {
                Console.Write(symb);
            }
            Console.WriteLine(symb);
            for (int i = 1; i <= anzahlZeilen; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(symb);
                for (int j = 1; j < breite; j++)
                {
                    Console.BackgroundColor = hintergrundFarbe;
                    Console.Write(" ");
                }

                Console.BackgroundColor = borderColor;
                Console.WriteLine(symb);
            }

            Console.SetCursorPosition(left, top + anzahlZeilen + 1);
            Console.Write(symb);
            for (int i = 1; i < breite; i++)
            {
                Console.Write(symb);
            }
            Console.Write(symb);
            Console.ResetColor();
        }

        public static void zeichneBox(int left, int top, int breite, int anzahlZeilen, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe)
        {
            Grafiken.zeichneBox(left, top, breite, anzahlZeilen, symb, hintergrundFarbe, schriftFarbe, false);
        }



        public static void zeichneTextBox(int left, int top, int breite,  char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe, List<string>Inhalt)
        {
            int AktuelleZeile = top;
            if (Inhalt.Any())
            {
                foreach (string textzeile in Inhalt)
                {
                    
                }
                Grafiken.zeichneBox(left, top, breite, Inhalt.Count(), symb, hintergrundFarbe, schriftFarbe);
                Console.BackgroundColor = hintergrundFarbe;
               Console.ForegroundColor = schriftFarbe;
                Console.SetCursorPosition(left + 1, AktuelleZeile++);
                foreach (String textzeile in Inhalt)
                {
                    Console.SetCursorPosition(left + 1, AktuelleZeile++);
                    Console.Write(textzeile);
                }


                Console.ResetColor();

            }

        }

            public static void zeichneTextBox(int left, int top,int breite ,int AnzahlZeilen, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe, string Inhalt)
        {
            int AktuelleZeile = top +1+ (AnzahlZeilen/2);
            int AanzahlZeichen = Inhalt.Length;


            zeichneBox(left, top, breite-1, AnzahlZeilen, symb, hintergrundFarbe, schriftFarbe);
            Console.BackgroundColor = hintergrundFarbe;
           Console.ForegroundColor = schriftFarbe;
            Console.SetCursorPosition(left + (((breite-Inhalt.Length) / 2)), AktuelleZeile);
            Console.Write(Inhalt);
            Console.SetCursorPosition(left+breite, top);
            Console.CursorVisible = false;



            Console.ResetColor();


        }

        public static void zeichneTextBox(int left, int top, int AnzahlZeilen, char symb, string Inhalt)
        {
            zeichneTextBox(left, top,1, AnzahlZeilen, symb, Console.BackgroundColor,Console.ForegroundColor, Inhalt);
        }



        public static void zeichneTextBox(int left, int top, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe, List<string> Inhalt)
        {
            int AktuelleZeile = top;
            int AanzahlZeichen = 0;
            if (Inhalt.Any())
            {
                foreach (string textzeile in Inhalt)
                {
                    if (textzeile.Length > AanzahlZeichen)
                    {
                        AanzahlZeichen = textzeile.Length;
                    }
                }
                zeichneBox(left, top, AanzahlZeichen + 2, Inhalt.Count(), symb, hintergrundFarbe, schriftFarbe);
                Console.BackgroundColor = hintergrundFarbe;
               Console.ForegroundColor = schriftFarbe;
                Console.SetCursorPosition(left + 1, AktuelleZeile++);
                foreach (string textzeile in Inhalt)
                {
                    Console.SetCursorPosition(left + 1, AktuelleZeile++);
                    Console.Write(textzeile);
                }


                Console.ResetColor();

            }
        }

        public static void zeichneTextBox(int left, int top, char symb, List<string> Inhalt)
        {
            zeichneTextBox(left, top, symb, Console.BackgroundColor,Console.ForegroundColor, Inhalt);
        }


    }


}



