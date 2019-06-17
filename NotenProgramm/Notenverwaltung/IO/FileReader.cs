using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Notenverwaltung
{
    class FileReader
    {
        static List<SchulKlasse> klassenListe = new List<SchulKlasse>();



        public static List<SchulKlasse> readFiles()
        {

            klassenListe =  new List<SchulKlasse>();
            ReadPaths();
            ReadZeugnisse();


            return klassenListe;
        }

        

        private static void ReadZeugnisse()
        {
            foreach (SchulKlasse klasse in klassenListe)
            {
                foreach (Schüler schüler in klasse.getSchülerListe())
                {
                    string path = "../../out/" + klasse.getName() + "/" + schüler.getNachName() + "_" + schüler.getVorName()+"/";
                    prüfeOrdner(path);
                    
                    for (int i =0; i < klasse.getSemester(); i++)
                    {
                        path = "../../out/" + klasse.getName() + "/" + schüler.getNachName() + "_" + schüler.getVorName() + "/Zeugnis_Halbjahr_" + (klasse.getSemester() - i) + "_" + (klasse.getSchuljahr()-i) + ".txt";
                        if (prüfeDatei(path))
                        {
                            schüler.neuesZeugnis((klasse.getSemester() - i), (klasse.getSchuljahr() - i));
                            ReadNoten(schüler.getZeugnisse().Last(),path);
                        }
                        
                    }

                }
            }
        }

        private static void ReadNoten(Zeugnis zeugnis,string path)
        {
            using (StreamReader fr = new StreamReader(path))
            {
                string temp = "";
                while (!fr.EndOfStream) {
                    temp = fr.ReadLine();
                    if (temp.Contains("{"))
                    {
                        zeugnis.AddSchulfach(new Schulfach(temp.Substring(0, temp.Length - 1), zeugnis.getSemester()));
                        bool x;
                        do
                        {
                             x = false;
                            if (fr.ReadLine().Equals("["))
                            {
                                x = true;
                                double erhaltenePunkte = Double.Parse(fr.ReadLine());                          
                                double gesamtePunkte = Double.Parse(fr.ReadLine());
                                string[] date = fr.ReadLine().Split('-');
                                zeugnis.getSchulFächer().Last().addNote(new Note(erhaltenePunkte, gesamtePunkte, Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2])));
                            }

                        } while (x==true);
                    }
                }
            }
        }

        


        private static void ReadPaths()
        {
           if(! prüfeDatei("../../out/paths.txt")){
                StreamWriter sw = new StreamWriter("../../out/paths.txt");
                sw.Write("");
                sw.Close();
            }
            using (StreamReader fr = new StreamReader("../../out/paths.txt"))
            {
                string temp;
                while (!fr.EndOfStream)
                {
                    temp = fr.ReadLine();
                    if (temp.Contains("{"))
                    {
                        klassenListe.Add(new SchulKlasse(temp.Substring(0, temp.Length - 1), Int32.Parse(fr.ReadLine()), Int32.Parse(fr.ReadLine())));
                    }
                    if (temp.Contains("_"))
                    {
                        string vorName = temp.Substring(temp.IndexOf("_") + 1, temp.Length - 1 - temp.IndexOf("_"));
                        string nachName = temp.Substring(0, temp.IndexOf("_"));
                        klassenListe.Last().AddSchüler(vorName, nachName);
                        
                    }
                    if (temp.Contains("]"))
                    {
                        
                        string fachRichtung = temp.Substring(0, temp.Length-1);
                        klassenListe.Last().AddSchulfach(fachRichtung);

                    }

                }
            }

        }

        private static bool prüfeDatei(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void prüfeOrdner(string path)
        {
            FileInfo fi = new FileInfo(path);
            if (!fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }
        }



    }
}
