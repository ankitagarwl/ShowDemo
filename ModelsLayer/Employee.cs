using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Employee : BaseClass
    {
        public int Id { get; set; }
        public int Action { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Id { get; set; }
        public string Worker_Id { get; set; }
        public int Role_Id { get; set; }
        public string RoleName { get; set; }


    }
}
