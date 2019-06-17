using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class Zeugnis
    {

        List<Schulfach> schulfächer;
        int Semester;
        int SchulJahr;

        public Zeugnis(int semester,int schulJahr)
        {
            this.schulfächer = new List<Schulfach>();
            this.Semester = semester;
            this.SchulJahr = schulJahr;
        }

        public int getSemester()
        {
            return Semester;
        }

        public List<Schulfach> getSchulFächer()
        {
            return schulfächer;
        }

        public double getNotenSpiegel()
        {

            double temp=0;
            foreach (Schulfach schulfach in schulfächer)
            {
                temp = temp + schulfach.getNotenspiegel();
            }
            return temp / schulfächer.Count;
        }

        public void AddSchulfach(Schulfach schulfach)
        {
            this.schulfächer.Add(schulfach);
        }


        public void removeSchulfach(string fachRichtung)
        {
            for (int i = 0; i < schulfächer.Count; i++)
            {
                if (schulfächer.ElementAt(i).getFachrichtung() == fachRichtung)
                {
                    schulfächer.RemoveAt(i);
                }
            }
        }

        public Schulfach findeSchulfach(string fachRichtung)
        {
            Schulfach gefundenesSchulFach = new Schulfach("not found Error ", 404);

            for (int i = 0; i < schulfächer.Count; i++)
            {
                if (schulfächer.ElementAt(i).getFachrichtung() == fachRichtung)
                {
                    gefundenesSchulFach = schulfächer.ElementAt(i);
                }
            }

            return gefundenesSchulFach;

        }

        public List<string> showInfo()
        {
            List<string> returnString = new List<string>() { "Semester :" + this.Semester  ,"Kalender Jahr: " + this.SchulJahr  };
            foreach (Schulfach schulfach in schulfächer)
            {
                returnString.Add(schulfach.getFachrichtung());
            }

            return returnString;
        }

        public List<string> SerializeForSave()
        {
            List<string> returnString = new List<string>();
            foreach(Schulfach schulfach in schulfächer)
            {
                foreach(String notenSchnippsle in schulfach.SerializeForSave())
                {
                    returnString.Add(notenSchnippsle);
                }
            }

            return returnString;
        }



        public void addNote(string fachrichtung, double erhaltenePunkte, double möglichePunkte, int tag, int monat)
        {
            foreach (Schulfach schulfach in schulfächer)
            {
                if (schulfach.getFachrichtung().Equals(fachrichtung))
                {
                    schulfach.addNote(new Note(erhaltenePunkte, möglichePunkte,tag,monat,SchulJahr));
                }
            }
        }

        public string getName()
        {
            return "Zeugnis_Halbjahr_" + this.Semester + "_" + this.SchulJahr;
        }

       

       
    }
}
