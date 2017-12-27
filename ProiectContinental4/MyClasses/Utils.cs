using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProiectContinental4.MyClasses
{
    public class Utils
    {
        static string interschimbare;
        static string interschimbare2;
        private static List<Mtype> mtypes = new List<Mtype>();
        static List<string> list1 = new List<string>();
        static List<string> list2 = new List<string>();
        static bool verificaElse = false;
        static string sirVerifica;
        static string CpuType;
        static string Id_Cpu;
        static bool isInParameters;
        static bool hasCPUparams = false;
        //cod nou

        //cod nou
        public string displayText()
        {
            return "helloWorld";
        }


        public static List<Mtype> ReadXML(string path)
        {

            using (XmlReader reader = XmlReader.Create(path)) // din functia...pick a file
            {

                while (reader.Read())
                {

                    if (hasCPUparams && verificaElse)
                    {
  
                        //// AICI SE ADAUGA IN OBIECT !!!!!!!!!!!!!!!!!!!
                        Mtype mtype = new Mtype(new List<string>(list1), new List<string>(list2), interschimbare2, interschimbare);
                        mtypes.Add(mtype);
                        verificaElse = false;
                        hasCPUparams = false;
                        Console.WriteLine("-------+++++---------" + CpuType);
                        Console.WriteLine("Parameter");
                        foreach (string temp in list1)
                        {

                            Console.WriteLine(temp);
                        }

                        Console.WriteLine("Aplications");

                        foreach (string temp in list2)
                        {
                            Console.WriteLine(temp);
                        }

                        list1.Clear();
                        list2.Clear();

                    }

                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {

                            case "processor":
                                if (verificaElse) hasCPUparams = true;
                                else
                                {
                                    list1.Clear();
                                    list2.Clear();
                                }
                                XmlReader inner = reader.ReadSubtree();
                                inner.ReadToDescendant("id");
                                reader.Read();
                                Id_Cpu = reader.Value.Trim();

                                inner.ReadToFollowing("name");
                                reader.Read();
                                CpuType = reader.Value.Trim();

                                break;

                            case "name":

                                reader.Read();
                                sirVerifica = reader.Value.Trim();
                                if (sirVerifica == "Parameter") isInParameters = true;
                                if (sirVerifica == "Application") isInParameters = false;

                                break;



                            case "segmentAddress":

                                if (isInParameters)
                                {
                                    reader.Read();
                                    list1.Add(reader.Value.Trim());
                                }
                                else
                                {
                                    interschimbare = CpuType;
                                    interschimbare2 = Id_Cpu;
                                    reader.Read();
                                    list2.Add(reader.Value.Trim());
                                    verificaElse = true;
                                }


                                break;

                        }
                    }
                }
            }
            Console.WriteLine("OBIECTE......");



            return mtypes;
        }

       
       
    }
}
