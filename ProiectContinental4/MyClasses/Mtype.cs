using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectContinental4.MyClasses
{
    public class Mtype
    {
        private List<string> ram_adr;
        private List<string> ram_param;
        private string cpuId;
        private string cpuNume;

        public int addNumbers(int a, int b)
        {
            return a + b;
        }

        public int addNumbers(int a, int b, int c)
        {
            return a + b + c;
        }



        public Mtype(List<string> ram_adrr, List<string> ram_params, string cpuId, string cpuNume)
        {
            ram_adr = new List<string>();
            ram_param = new List<string>();
            this.CpuId = cpuId;
            this.CpuNume = cpuNume;

            ram_adr = ram_adrr;
            ram_param = ram_params;
        }
        public string CpuId { get; set; }
        public string CpuNume { get; set; } 

        public List<string> getRam_adr()
        {
            return ram_adr;
        }

        public void setRam_adr(List<String> list)
        {
            ram_adr = list;
        }


        public List<string> getRam_param()
        {
            return ram_param;
        }

        public void setRam_param(List<String> list)
        {
            ram_param = list;
        }


    }
}
