using System;
using System.Collections.Generic;
using System.Linq;
 



using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    abstract public class Menu
    {
        public object MenuPunkte { get; private set; }
        private int menuModifier;         
        public Menu() { }

        abstract public void UpDateMenu();





        public abstract int Navigieren(ConsoleKey gedrückteTaste);



         public abstract ConsoleKey Ausführen();
       

    }
}
