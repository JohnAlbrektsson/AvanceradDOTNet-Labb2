using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDOTNet_Labb2.Models
{
    internal class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual List<Subject> Subjects { get; set; }
    }
}
