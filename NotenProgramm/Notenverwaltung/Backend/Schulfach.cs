using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class Schulfach
    {

        private string fachRichtung;
        private List<Note> notenListe;
        private int semester;

        public Schulfach(string fachRichtung, int semester)
        {
            this.notenListe = new List<Note>();
            this.fachRichtung = fachRichtung;
            this.semester = semester;
        }

        public string getFachrichtung()
        {
            return fachRichtung;
        }

        public List<Note> getNotenListe()
        {
            return notenListe;
        }

        public double getNotenspiegel()
        {
            double temp = 0;
            foreach (Note note in notenListe)
            {
                temp = temp + note.getNoteInProzent();
            }
            return Werkzeuge.notenSpiegelAusrechnen(temp / notenListe.Count);
        }

        public int getSemester()
        {
            return semester;
        }


        public void addNote(Note note)
        {
            this.notenListe.Add(note);
        }

        

        public string serialize()
        {
            string rückgabeString = getFachrichtung()+": "+getNotenspiegel()+" \n\nKlausuren:\n\n";
            for(int i = 1; i<= notenListe.Count;i++)
            {

                rückgabeString += "Datum: " + notenListe.ElementAt(i - 1).getDate().ToString("dd/MM/yyyy") + "   % der Punkte: " + String.Format("{0:0.00}",  notenListe.ElementAt(i - 1).getNoteInProzent()) + "     Note: " + notenListe.ElementAt(i - 1).getNote() + "\n";
            }

       

            return rückgabeString;
        }

        public List<string> SerializeForSave()
        {
            List<string> rückgabeString =  new List<string>() { this.fachRichtung + "{" };
            foreach(Note note in notenListe)
            {
                rückgabeString.Add("[");
                rückgabeString.Add(note.getErhaltenePunkte().ToString());
                rückgabeString.Add(note.getGesamtePunkte().ToString());
                rückgabeString.Add(note.getDate().ToString("dd/MM/yyyy"));
                
            }
            rückgabeString.Add("]");
            return rückgabeString;
        }




        
        
    }
}
