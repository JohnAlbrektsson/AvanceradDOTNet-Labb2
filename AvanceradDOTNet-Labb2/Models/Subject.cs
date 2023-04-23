using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDOTNet_Labb2.Models
{
    internal class Subject
    {
        public int ID { get; set; }
        public string SubjectName { get; set; }
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
