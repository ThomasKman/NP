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

        static void Main(string[] args)
        {
            //  schwein();
            klassenListe = FileReader.readFiles();
            UI.Start();



        }

        static void joiads()
        {
            klassenListe = FileReader.readFiles();
            Console.Write(klassenListe.ElementAt(0).getSchülerListe().First().showInfo());
            klassenListe.ElementAt(0).versetzen();
            FileWriter.saveFile(klassenListe);
        }

        static void schwein()
        {
            SchulKlasse IA218 = new SchulKlasse("IA218", 2019, 2);

            IA218.AddSchüler("Thomas", "Kindermann");
            IA218.AddSchüler("Arthur", "Kwant");
            IA218.AddSchüler("Jakob", "Kahl");

            IA218.findeSchüler("Kindermann").neuesZeugnis(IA218.getSemester(),IA218.getSchuljahr());

            IA218.findeSchüler("Kwant").neuesZeugnis(IA218.getSemester(), IA218.getSchuljahr());

            IA218.findeSchüler("Kahl").neuesZeugnis(IA218.getSemester(), IA218.getSchuljahr());




            IA218.AddSchulfach("Mathematik");
            IA218.AddSchulfach("Deutsch");
            IA218.AddSchulfach("AWE");

            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Mathematik", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("Mathematik", 50, 100, 06, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("AWE", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Mathematik", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("AWE", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Mathematik", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("Mathematik", 50, 100, 06, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("AWE", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Mathematik", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("AWE", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Mathematik", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("Mathematik", 50, 100, 06, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("AWE", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Mathematik", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("AWE", 80, 100, 09, 05);

            IA218.versetzen();

            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Mathematik", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("AWE", 50, 100, 06, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("Mathematik", 50, 100, 06, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kwant").getAktuellesZeugnis().addNote("AWE", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Mathematik", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("AWE", 80, 100, 09, 05);

            IA218.versetzen();

            IA218.removeSchulfach("AWE");
            IA218.AddSchulfach("Sport");
            IA218.removeSchüler("Arthur", "Kwant");
            IA218.AddSchüler("Jeniver", "KnippzZ");

            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Mathematik", 50, 100, 06, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Deutsch", 80, 100, 09, 05);
            IA218.findeSchüler("Kindermann").getAktuellesZeugnis().addNote("Sport", 80, 100, 09, 05);
            IA218.findeSchüler("KnippzZ").getAktuellesZeugnis().addNote("Mathematik", 50, 100, 06, 05);
            IA218.findeSchüler("KnippzZ").getAktuellesZeugnis().addNote("Deutsch", 60, 100, 07, 05);
            IA218.findeSchüler("KnippzZ").getAktuellesZeugnis().addNote("Sport", 80, 100, 09, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Mathematik", 60, 100, 07, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Deutsch", 50, 100, 06, 05);
            IA218.findeSchüler("Kahl").getAktuellesZeugnis().addNote("Sport", 80, 100, 09, 05);

            SchulKlasse IA219 = IA218;
            List<SchulKlasse> klassenListe = new List<SchulKlasse>();
            klassenListe.Add(IA218);
            FileWriter.saveFile(klassenListe);
            Console.Write("Done");
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

