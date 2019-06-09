using System;
using System.Collections.Generic;
using System.Linq;
using static Notenverwaltung.Grafiken;
using static System.Console;
using static System.ConsoleColor;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class UI
    {





        public static int menuIndex = 1;
        static bool exit = false;
        public static SchulKlasse AktuelleSchulklasse=new SchulKlasse("test",123,456);
        public static Schüler AktuellerSchüler;
        public static Zeugnis AktuellesZeugnis;
        public static Schulfach AktuellesSchulfach;
        static Menu menu;

        public static void Start()

        {

            SetBufferSize(120, 60);
            SetWindowSize(120,60);

            CursorVisible = false;
            TreatControlCAsInput = true;
            ZeichneMenu();
            HauptMenu hauptMenu = new HauptMenu();
            menu = hauptMenu;
            AktuelleSchulklasse.addSchüler("test","123");
            AktuellerSchüler = AktuelleSchulklasse.findeSchüler("123");
            AktuellerSchüler.neuesZeugnis(1, 1);
            AktuellesZeugnis = AktuellerSchüler.getAktuellesZeugnis();
            AktuellesZeugnis.addSchulfach(new Schulfach("test",1));
            AktuellesSchulfach = AktuellesZeugnis.getSchulFächer().First();
            AktuellesSchulfach.addNote(new Note(1, 1, 1, 1, 1));
            KlassenManager klassenManager = new KlassenManager();
            Schülermanager schülermanager = new Schülermanager();
            do
            {
                SetCursorPosition(0, 0);
                Write(menuIndex + "  " + AktuelleSchulklasse.getName()); 
                menu.UpDateMenu();
                menuIndex += menu.Navigieren(ReadKey().Key);
                menu.UpDateMenu();

                switch (menuIndex)
                {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        menu = hauptMenu;
                        break;
                    case 2:
                        menu = klassenManager;
                        break;

                    case 3:
                        menu = schülermanager;
                        break;

                    default:
                        exit = true;
                        break;
                        
                    
                }
            } while (!exit);

        }


  





     





        public static int readInt()
        {
            ConsoleKeyInfo key;
            int Zahl = 0;
            do
            {

                key = ReadKey();
                if (Char.IsDigit(key.KeyChar))
                {
                    Zahl *= 10;
                    Zahl += Int16.Parse(key.KeyChar.ToString());
                }
                else if (key.Key != ConsoleKey.Enter)
                {

                    SetCursorPosition(CursorLeft - 1, CursorTop);
                    Write(" ");
                    SetCursorPosition(CursorLeft - 1, CursorTop);
                }

            } while (key.Key != ConsoleKey.Enter);

            return Zahl;

        }

        public static string readString()
        {
            ConsoleKeyInfo key;
            string Zeichenkette = "";
            do
            {

                key = ReadKey();
                if (char.IsLetterOrDigit(key.KeyChar))
                {
                    Zeichenkette += key.KeyChar;
                }
                else if (key.Key != ConsoleKey.Enter)
                {

                    SetCursorPosition(CursorLeft - 1, CursorTop);
                    Write(" ");
                    SetCursorPosition(CursorLeft - 1, CursorTop);
                }

            } while (key.Key != ConsoleKey.Enter);

            return Zeichenkette;

        }


    }
}
