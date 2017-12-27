using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectContinental4.MyClasses
{
    class MCU_TYPES
    {

        private int id;
        private string type;
        private string ramApl;
        private string ramParam;

      

        public MCU_TYPES(int id,string type,string ramLength,string ramOrg)
        {
            this.id = id;
            this.Type = type;
            this.RamLength = ramLength;
            this.RamOrg = ramOrg;
        }

        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public string RamLength
        {
            get
            {
                return ramApl;
            }

            set
            {
                ramApl = value;
            }
        }

        public string RamOrg
        {
            get
            {
                return ramParam;
            }

            set
            {
                ramParam = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }

    }

