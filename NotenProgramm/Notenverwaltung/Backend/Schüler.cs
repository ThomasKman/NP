using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class Schüler
    {

        private string vorName;
        private string nachName;
        private List<Zeugnis> zeugnisse;
        


        public Schüler(string vorName, string nachName )
        {
            this.vorName = vorName;
            this.nachName = nachName;
            this.zeugnisse = new List<Zeugnis>();
        }

        

        public string getVorName()
        {
            return this.vorName;
        }

        public string getNachName()
        {
            return this.nachName;
        }

        public List<Zeugnis> getZeugnisse()
        {
            return zeugnisse;
        }

        public void neuesZeugnis(int semester, int schulJahr)
        {
            zeugnisse.Add(new Zeugnis(semester, schulJahr));
        }

        

        public Zeugnis getAktuellesZeugnis()
        {
            return zeugnisse.Last();
        }

        public void versetzen(int semester,int schulJahr)
        {

            List<Schulfach> fachListeFürÜbertragung = getAktuellesZeugnis().getSchulFächer();
            
            
            
            zeugnisse.Add(new Zeugnis(semester,schulJahr));
            foreach (Schulfach schulfach in fachListeFürÜbertragung)
            {
                getAktuellesZeugnis().addSchulfach(new Schulfach(schulfach.getFachrichtung(),semester));
            }
                
        }


        public string serialize()
        {
            string returnString = "Zeugnisübersicht von " + this.vorName + " " + this.nachName + "\n____________________________________________________\n\n";

            foreach (Zeugnis zeugnis in zeugnisse)
            {
                returnString = returnString + zeugnis.serialize();
            }

            return returnString;

        }

    }
}
