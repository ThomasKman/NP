using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class SchulKlasse
    {
        List<Schulfach> schulfaecher;
        private string name;
        private List<Schüler> schülerListe;
        int schulJahr;
        int semester;

        public SchulKlasse(string name, int schulJahr, int semester)
        {
            this.name = name;
            this.schulJahr = schulJahr;
            if (semester > 0)
            {
                this.semester = semester;
            }
            else
            {
                this.semester = 1;
            }
            this.schülerListe = new List<Schüler>();
            this.schulfaecher = new List<Schulfach>();
        }



        public List<Schüler> getSchülerListe()
        {
            return schülerListe;
        }



        public void AddSchüler(string vorName, string nachName)
        {
            Schüler neuerSchüler = new Schüler(vorName, nachName);
            neuerSchüler.neuesZeugnis(semester, schulJahr);
            if (schulfaecher.Any())
            {
               

                foreach (Schulfach schulfach in schulfaecher)
                {
                    neuerSchüler.getAktuellesZeugnis().AddSchulfach(schulfach);
                }

            }
            schülerListe.Add(neuerSchüler);
        }

        public void removeSchüler(string vorName, string nachname)
        {
            for (int i = 0; i < schülerListe.Count; i++) {
                if ((vorName == schülerListe.ElementAt(i).getVorName() && nachname == schülerListe.ElementAt(i).getNachName()))
                {
                    schülerListe.RemoveAt(i);
                }
            }
        }

        public void removeSchüler(string nachName)
        {
            removeSchüler("", nachName);
        }

        public Schüler findeSchüler(string vorName, string nachName)
        {
            Schüler gefundenerSchüler = new Schüler("Error", "Error");
            for (int i = 0; i < schülerListe.Count; i++)
            {
                if ((vorName == schülerListe.ElementAt(i).getVorName() || nachName == schülerListe.ElementAt(i).getNachName()))
                {
                    gefundenerSchüler = schülerListe.ElementAt(i);
                }
            }

            return gefundenerSchüler;
        }

        public Schüler findeSchüler(string nachName)
        {
            return findeSchüler("", nachName);
        }



        public void removeSchulfach(string fachRichtung)
        {
            foreach (Schüler schüler in schülerListe)
            {
                schüler.getAktuellesZeugnis().removeSchulfach(fachRichtung);
            }
        }

        public List<Schulfach> getSchulfaecher()
        {
            return this.schulfaecher;
        }

        public void AddSchulfach(string fachRichtung)
        {
            schulfaecher.Add(new Schulfach(fachRichtung, semester));
            if (schülerListe.Any())
            {
                foreach (Schüler schüler in schülerListe)
                {
                    schüler.getAktuellesZeugnis().AddSchulfach(new Schulfach(fachRichtung, this.semester));
                }
            }
        }

        public void versetzen()
        {
            semester++;
            schulJahr++;
            foreach (Schüler schüler in schülerListe)
            {
                schüler.versetzen(semester, schulJahr);
            }
            schulfaecher.Clear();
        }

        public string getName()
        {
            return this.name;
        }

        public int getSchuljahr()
        {
            return this.schulJahr;
        }

        public int getSemester()
        {
            return this.semester;
        }

        public string serializeSchülerListe()
        {
            string returnString = "";
            foreach (Schüler schüler in schülerListe)
            {
                returnString += schüler.getVorName() + " " + schüler.getNachName() + "\n";
            }

            return returnString;
        }


        public List<string> showInfo()
        {
            
            List<string> temp = new List<string>() {"Klasse: "+ name, "Aktuelles Semester: " + semester, "Kalender Jahr     : " + schulJahr, "Schüler: "+schülerListe.Count().ToString() ,"Schulfächer: "+schulfaecher.Count().ToString()};

            foreach (Schulfach schulfach in schulfaecher)
            {
                temp.Add(schulfach.getFachrichtung());
            }

            return temp;
    
        }



    }
}
