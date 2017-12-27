using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectContinental4.MyClasses
{
   public class MtypeReturned
    {
        private string ramApl;
        private string ramParam;
        private int id;
        private int xml_id;
        private string mcuName;

        public MtypeReturned(
                    string ramApl,
                    string ramParam,
                    int id,
                    int xml_id,
                    string mcuName) //cons
        {
            this.ramApl = ramApl;
            this.ramParam = ramParam;
            this.id = id;
            this.Xml_id = xml_id;
            this.McuName = mcuName;
        }


        public string McuName { get; set; }


        
        public string RamApl
        {
            get { return ramApl; }
            set { ramApl = value; }
        }



        public string RamParam
        {
            get { return ramParam; }
            set { ramParam = value; }
        }

        public int Id { get; set; }
        public int Xml_id { get; set; }
    }
}
