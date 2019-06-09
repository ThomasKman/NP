using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

using static System.ConsoleColor;
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
            SetCursorPosition(0, 0);
            int top = 0;
            Clear();
            Write(title);
            top = CursorTop+1;
            zeichneRahmen(0, top, WindowWidth - 1, 3, '-', Gray, Black);
            top +=6;
            zeichneRahmen(0, top, WindowWidth / 4, WindowHeight-(top+3), '#', Gray, Black);
            zeichneRahmen(WindowWidth / 4 + 2, top, ((WindowWidth / 4) * 3) - 3 ,WindowHeight - (top + 3), '+', Gray, Black);
            SetCursorPosition(0, 0);

        }

        public static void ZeichneMenuPunkte(int left,int top, int breite, int activeElement,  List<string> MenuPunkte)
        {
            int ElementBreite;
            int i;
            SetCursorPosition(left, top);
             
            foreach (string menuPunkt in MenuPunkte)
            {
                i= MenuPunkte.IndexOf(menuPunkt);
                ElementBreite = breite / MenuPunkte.Count();
                if (i == activeElement)
                {
                    BackgroundColor = Gray;
                    ForegroundColor = Black;
                }

                if(i == 0) {

                zeichneTextBox(CursorLeft, CursorTop,ElementBreite +=(breite%ElementBreite),1, ' ', BackgroundColor,ForegroundColor, menuPunkt);
                }
                else
                {

                    zeichneTextBox(CursorLeft, CursorTop, ElementBreite, 1, ' ', BackgroundColor,ForegroundColor, menuPunkt);
                }
                 
                
                BackgroundColor = Black;
                ForegroundColor = Gray;
            }
            SetCursorPosition(0, 0);
        }

        public static void zeichneElementListe(List<string> Elemente,int NavIndex)
        {
            int top = 21;
            for(int i = 0;i<Elemente.Count;i++)
            { 
                if(i == NavIndex)
                {
                    BackgroundColor = Gray;
                    ForegroundColor = Black;

                }
                SetCursorPosition(2, top);
                top++;
                Write(Elemente.ElementAt(i));
                ResetColor();
            }
        }
        

        public static void zeichneObjektInfo(List<string> ObjectInfo,int anzahlFelder,bool hide)
        {
            ConsoleColor Bg;
            ConsoleColor fg;
            int top = 23;
            int left = (WindowWidth / 4) + 3;
            int breite = (((WindowWidth / 4) * 3)/2)-3;
            if (hide)
            {
                Bg = Black;
                 fg = Black;

            }
            else
            {
                 Bg = Gray;
                 fg = Black;
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
            int left = (WindowWidth / 4) + 3;
            int breite = (((WindowWidth / 4) * 3) / 2) - 3;


            for (int i = 1; i < EingabeFelder.Count(); i++)
            {

                if (EingabeFelder.Count>2)
                {
                    zeichneTextBox(left, top + (5 * (i/2)), breite, 3, '#', BackgroundColor, ForegroundColor, EingabeFelder.ElementAt(i));

                    SetCursorPosition(left +1 + (breite + EingabeFelder.ElementAt(i).Length) / 2, top + (5 * (i / 2))+2);
                }
                else
                {

                    zeichneTextBox(left + breite + 1, top, breite, 3, '*', BackgroundColor, ForegroundColor, EingabeFelder.ElementAt(i));

                    SetCursorPosition(left + breite + 2 + (breite + EingabeFelder.ElementAt(i).Length) / 2, top + 2);
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
            return zeichneDialog(nachricht, DarkGreen, Green);
        }

        public static ConsoleKey zeichneDialog(  string nachricht, ConsoleColor background, ConsoleColor schriftFarbe)
        {
            int top = 30;
            int left = WindowWidth / 2;
            int breite = 30;
            ConsoleKey key;
            BackgroundColor = background;
            ForegroundColor = schriftFarbe;

            zeichneTextBox(left, top, breite, 5, '#', background,schriftFarbe, nachricht);
            ResetColor();


            key = ReadKey().Key;
            zeichneBox(left, top, breite, 5,' ',Black,Black,false);
            return key;
        }

        public static void zeichneRahmen(int left, int top, int breite, int anzahlZeilen, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe)
        {
            BackgroundColor = hintergrundFarbe;
            ForegroundColor = schriftFarbe;

            SetCursorPosition(left, top);
            for(int i =left; i <left+breite;i++)
            {
                Write(symb);
            }
            for(int i = top;  i<=(top+anzahlZeilen);i++)
            {
                SetCursorPosition(left, i);
                Write(symb);

                SetCursorPosition(left+breite, i);
                Write(symb);
            }
            SetCursorPosition(left, top + anzahlZeilen+1);
            for (int i = left; i <=left + breite; i++)
            {
                Write(symb);
            }
        }


        public static void zeichneBox(int left, int top, int breite, int anzahlZeilen, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe, bool borderInverted)
        {
            ConsoleColor borderColor = BackgroundColor;
            SetCursorPosition(left, top);
            ForegroundColor = schriftFarbe;
            if (borderInverted)
            {
                borderColor = schriftFarbe;
                BackgroundColor = borderColor;
                ForegroundColor = hintergrundFarbe;
            }

            Write(symb);
            for (int i = 1; i < breite; i++)
            {
                Write(symb);
            }
            WriteLine(symb);
            for (int i = 1; i <= anzahlZeilen; i++)
            {
                SetCursorPosition(left, top + i);
                Write(symb);
                for (int j = 1; j < breite; j++)
                {
                    BackgroundColor = hintergrundFarbe;
                    Write(" ");
                }

                BackgroundColor = borderColor;
                WriteLine(symb);
            }

            SetCursorPosition(left, top + anzahlZeilen + 1);
            Write(symb);
            for (int i = 1; i < breite; i++)
            {
                Write(symb);
            }
            Write(symb);
            ResetColor();
        }

        public static void zeichneBox(int left, int top, int breite, int anzahlZeilen, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe)
        {
            zeichneBox(left, top, breite, anzahlZeilen, symb, hintergrundFarbe, schriftFarbe, false);
        }



        public static void zeichneTextBox(int left, int top, int breite,  char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe, List<string>Inhalt)
        {
            int AktuelleZeile = top;
            if (Inhalt.Any())
            {
                foreach (string textzeile in Inhalt)
                {
                    
                }
                zeichneBox(left, top, breite, Inhalt.Count(), symb, hintergrundFarbe, schriftFarbe);
                BackgroundColor = hintergrundFarbe;
                ForegroundColor = schriftFarbe;
                SetCursorPosition(left + 1, AktuelleZeile++);
                foreach (String textzeile in Inhalt)
                {
                    SetCursorPosition(left + 1, AktuelleZeile++);
                    Write(textzeile);
                }


                ResetColor();

            }

        }

            public static void zeichneTextBox(int left, int top,int breite ,int AnzahlZeilen, char symb, ConsoleColor hintergrundFarbe, ConsoleColor schriftFarbe, string Inhalt)
        {
            int AktuelleZeile = top +1+ (AnzahlZeilen/2);
            int AanzahlZeichen = Inhalt.Length;


            zeichneBox(left, top, breite-1, AnzahlZeilen, symb, hintergrundFarbe, schriftFarbe);
            BackgroundColor = hintergrundFarbe;
            ForegroundColor = schriftFarbe;
            SetCursorPosition(left + (((breite-Inhalt.Length) / 2)), AktuelleZeile);
            Write(Inhalt);
            SetCursorPosition(left+breite, top);
            CursorVisible = false;



            ResetColor();


        }

        public static void zeichneTextBox(int left, int top, int AnzahlZeilen, char symb, string Inhalt)
        {
            zeichneTextBox(left, top,1, AnzahlZeilen, symb, BackgroundColor, ForegroundColor, Inhalt);
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
                BackgroundColor = hintergrundFarbe;
                ForegroundColor = schriftFarbe;
                SetCursorPosition(left + 1, AktuelleZeile++);
                foreach (String textzeile in Inhalt)
                {
                    SetCursorPosition(left + 1, AktuelleZeile++);
                    Write(textzeile);
                }


                ResetColor();

            }
        }

        public static void zeichneTextBox(int left, int top, char symb, List<string> Inhalt)
        {
            zeichneTextBox(left, top, symb, BackgroundColor, ForegroundColor, Inhalt);
        }


    }


}



