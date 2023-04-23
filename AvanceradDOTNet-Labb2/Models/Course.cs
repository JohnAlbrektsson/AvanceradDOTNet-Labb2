using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDOTNet_Labb2.Models
{
    internal class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }

        public virtual List<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
        public virtual List<Subject> Subjects { get; set; }
    }
}
