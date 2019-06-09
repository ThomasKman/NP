using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class Note
    {

        private double erhaltenePunkte;
        private double gesamtPunkte;
        private double noteInProzent;
        private double note;
        private DateTime date;

        public Note(double erhaltenePunkte, double gesamtPunkte, int day, int month, int year ){
            this.gesamtPunkte = gesamtPunkte;
            this.erhaltenePunkte = erhaltenePunkte;
            this.noteInProzent = (erhaltenePunkte / gesamtPunkte);
            this.note = Werkzeuge.notenSpiegelAusrechnen(noteInProzent);
            this.date = new DateTime(year, month, day);
        }

        public double getNoteInProzent()
        {
            return this.noteInProzent;
        }

        public double getErhaltenePunkte()
        {
            return this.erhaltenePunkte;
        }

        public double getGesamtePunkte()
        {
            return this.gesamtPunkte;
        }

        public double getNote()
        {
            return this.note;
        }

        public DateTime getDate()
        {
            return this.date;
        }

        
        public void setNote(double note)
        {
            this.note = note;
        }

    }
}
