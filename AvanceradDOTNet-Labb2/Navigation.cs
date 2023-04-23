using AvanceradDOTNet_Labb2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDOTNet_Labb2
{
    internal class Navigation
    {
        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("-------Menu-------");
            Console.WriteLine("1. Get math teachers");
            Console.WriteLine("2. Get students with their teachers");
            Console.WriteLine("3. Check if subjects Contains programmering");
            Console.WriteLine("4. Edit programmering2");
            Console.WriteLine("5. Update student record");
            

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GetMathTeachers();
                    break;
                case 2:
                    GetStudentswithTeacher();
                    break;
                case 3:
                    ContainsSubject();
                    break;
                case 4:
                    EditSubject();
                    break;
                case 5:
                    UpdateTeacher();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }
        }
        public static void GetMathTeachers()
        {
            using Context context = new Context();

            var mathTeachers = context.Teachers.Where(t => t.Subjects.Any(s => s.SubjectName == "matte"));

            Console.WriteLine("Math teachers");
            foreach(var item in mathTeachers)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
            Menu();
        }
        public static void GetStudentswithTeacher()
        {
            using Context context = new Context();

            var StudandTeach = context.Courses
                .Include(c => c.Teacher)
                .Include(c => c.Students)
                .SelectMany(c => c.Students
                .Select(s => new
                {
                    Student = s.Name,
                    Teacher = c.Teacher.Name
                }));

            foreach(var item in StudandTeach)
            {
                Console.WriteLine("Student: {0} Teacher: {1}",item.Student,item.Teacher);
            }
            Console.ReadKey();
            Menu();
        }
        public static void ContainsSubject()
        {
            using Context context = new Context();
            if(context.Subjects.Contains(context.Subjects.FirstOrDefault(s=>s.SubjectName == "Programmering")))
            {
                Console.WriteLine("Programmering exists in the database");
            }
            else
            {
                Console.WriteLine("Programmering doesn't exist in the database");
            }
            Console.ReadKey();
            Menu();
        }
        public static void EditSubject()
        {
            using Context context = new Context();
            
            context.Subjects.FirstOrDefault(s => s.SubjectName == "Programmering2").SubjectName = "OOP";
            context.SaveChanges();
            Console.WriteLine("Programmering2 has been changed to OOP");

            Console.ReadKey();
            Menu();
        }
        public static void UpdateTeacher()
        {
            using Context context = new Context();

            var course = context.Courses.FirstOrDefault(c => c.CourseID == 2);
            var teacher1 = context.Teachers.FirstOrDefault(t => t.ID == 1);
            var teacher2 = context.Teachers.FirstOrDefault(t => t.ID == 2);

            if (course.Teacher == teacher1)
            {
                course.Teacher = teacher2;
            }
            context.SaveChanges();
            Console.ReadKey();
            Menu();
        }
    }
}
