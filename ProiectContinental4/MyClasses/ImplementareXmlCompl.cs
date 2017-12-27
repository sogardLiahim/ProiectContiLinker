using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ProiectContinental4.MyClasses
{
   public class ImplementareXmlCompl
    {
       private string cpuId;
       private static List<xmlLinkCompl> mtypesLC = new List<xmlLinkCompl>();
       static List<string> compilerOptions = new List<string>();
       static List<string> linkerOptions = new List<string>();

     public static List<xmlLinkCompl> ReadXML(string path) {
        using (XmlReader reader = XmlReader.Create(path)) // din functia...pick a file
          {

                while (reader.Read())
                {
                           if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "processor":
                                 
                                Console.WriteLine("OBIECTE......");
                                break;
                            case "whatever": 
                                Console.WriteLine("");
                                break;
                          }
                    }


    }
  }
     
     return mtypesLC;
     } 

        xmlLinkCompl linkCompl = new xmlLinkCompl("tes",new List<string>(compilerOptions), new List<string>(linkerOptions));

}

}
}
