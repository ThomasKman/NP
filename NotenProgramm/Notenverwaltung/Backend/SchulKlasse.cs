using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class SchulKlasse
    {

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
        }



        public List<Schüler> getSchülerListe()
        {
            return schülerListe;
        }



        public void addSchüler(string vorName, string nachName)
        {
            Schüler neuerSchüler = new Schüler(vorName, nachName);
            if (schülerListe.Any() && schülerListe.First().getZeugnisse().Any())
            {
                List<Schulfach> übertrageneFächer = schülerListe.First().getAktuellesZeugnis().getSchulFächer();

                foreach (Schulfach schulfach in übertrageneFächer)
                {
                    neuerSchüler.getAktuellesZeugnis().addSchulfach(schulfach);
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

        public void addSchulfach(string fachRichtung)
        {
            foreach (Schüler schüler in schülerListe)
            {
                schüler.getAktuellesZeugnis().addSchulfach(new Schulfach(fachRichtung, this.semester));
            }
        }

        public void removeSchulfach(string fachRichtung)
        {
            foreach (Schüler schüler in schülerListe)
            {
                schüler.getAktuellesZeugnis().removeSchulfach(fachRichtung);
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
            
            List<string> temp = new List<string>() {"Klasse: "+ name, "Aktuelles Semester: " + semester, "Kalender Jahr     : " + schulJahr, "Schüler: "+schülerListe.Count().ToString(), };
            

            return temp;
    
        }



    }
}
