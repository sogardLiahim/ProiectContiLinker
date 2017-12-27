using ProiectContinental4.MyClasses;
using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace ProiectContinental4.MyClasses
{
    public class UsefulMethods
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);
        //  SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\SpireaM\Desktop\ProiectContinental4\ProiectContinental4\Database1.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        SqlTransaction transaction;
        List<MCU_TYPES> mcs = new List<MCU_TYPES>();
        List<Mtype> mtypes = new List<Mtype>();
        public List<MtypeReturned> mRet = new List<MtypeReturned>();



        public static string getPerfectString(string x)
        {

            int m2 = 0;
            Int32.TryParse(x, out m2);
            x = m2.ToString();
            return x;

        }

        public static int getListElements(List<string> eval)
         {
             
           int i=0;
           foreach (string temp in eval) i++;              
           return i;
        
         }

        public static string[] conversieArray(int n, List<string>eval)
        {
           string[] numbers; // declare numbers as an int array of any size
           numbers = new string[n];  // numbers is a 10-element array
            int i=0;
           foreach (string temp in eval) 
           {                 
               numbers[i] = temp;
               i++;
               if (i == n) break;
           }
           return numbers;
       }

        public static void generareTxt(string mcuName, string flashParam, string flashApl) {


            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\SpireaM\Desktop\ProiectContinental4\FiserTxT\Test2.h"))
            {
                mcuName = mcuName.ToUpper();

               file.WriteLine("#ifndef __"+mcuName+"_H");   //pentru include microsdconfig.h
               file.WriteLine("#define __"+mcuName+"_H");
               file.WriteLine("#define VARIABLE_PARAMETER_START "+flashParam);
               file.WriteLine("#define VAR_PARM_SIZE " + flashApl);


               file.WriteLine("#if (VARIABLE_PARAMETER_START != 0)");
               file.WriteLine("PARAMETER_SECTION : org = VARIABLE_PARAMETER_START   len = (VAR_PARM_SIZE )");
               file.WriteLine("#   endif");

               file.WriteLine("#endif /* __"+mcuName+"_H */");


 


                //List<string> lines = new List<string>();
                ////foreach (string line in lines)
                ////    if (!line.Contains("Second")) file.WriteLine(line);




            }
        
        }

    }
}

