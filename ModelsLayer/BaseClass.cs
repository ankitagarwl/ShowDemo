using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class BaseClass
    {
        public Int16 Status { get; set; }
        public Int32 InsertedBy { get; set; }
        public string InsertedOn { get; set; }
        public Int32 ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }

    }
}
