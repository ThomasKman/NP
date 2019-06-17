using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notenverwaltung
{
    class FileWriter
    {
        
        static string path;
        static List<string> pathList = new List<string>();


        public static ConsoleKey saveFile(List<SchulKlasse> klassen)
        {
            pathList = new List<string>();
            foreach (SchulKlasse klasse in klassen)
            {
                pathList.Add(klasse.getName() + "{");
                pathList.Add(klasse.getSchuljahr().ToString());
                pathList.Add(klasse.getSemester().ToString());
                foreach(Schulfach fach in klasse.getSchulfaecher())
                {
                    pathList.Add(fach.getFachrichtung() + "]");
                }

                foreach (Schüler schüler in klasse.getSchülerListe())
                {
                    pathList.Add(schüler.getNachName() + "_" + schüler.getVorName());
                    foreach (Zeugnis zeugnis in schüler.getZeugnisse())
                    {
                       
                        path = "../../out/" + klasse.getName() + "/" + schüler.getNachName() + "_" + schüler.getVorName() + "/" + zeugnis.getName() + ".txt";
                        prüfeOrdner(path);

                        using (StreamWriter sw = new StreamWriter(path))
                        {

                            foreach (String output in zeugnis.SerializeForSave())
                            {
                                sw.WriteLine(output);
                                
                            }
                            sw.Close();
                        }
                    }
                }
            }
                using (StreamWriter sw = new StreamWriter("../../out/paths.txt"))
                {
                    foreach (string path in pathList)
                    {
                        sw.WriteLine(path);
                    }
                    sw.Close();
                }

            return Grafiken.Bestätigen("Speichern Erfolgreich");
        }
        


        private static void prüfeOrdner(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (!fi.Directory.Exists)
            {
                System.IO.Directory.CreateDirectory(fi.DirectoryName);
            }
        }

       
    }





    }

