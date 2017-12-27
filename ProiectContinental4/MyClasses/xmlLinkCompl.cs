using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProiectContinental4.MyClasses
{
    public class xmlLinkCompl
    {
        private string cpuId;
        private List<string> compilerOptions;
        private List<string> linkerOptions;



        public xmlLinkCompl(string cpuId, List<string> CompilerOptions, List<string> LinkerOptions)
        {
            this.CpuId = cpuId;
            CompilerOptions = compilerOptions;
            LinkerOptions = linkerOptions;
        }

        public List<string> LinkerOption()
        {
            return linkerOptions;
        }

        public void LinkerOption(List<String> list)
        {
            linkerOptions = list;
        }


        public List<string> getCompilerOption()
        {
            return compilerOptions;
        }

        public void setCompilerOption(List<String> list)
        {
            compilerOptions = list;
        }

        public string CpuId { get; set; }

      
       

    }
}
