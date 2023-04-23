using AvanceradDOTNet_Labb2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvanceradDOTNet_Labb2.Data
{
    internal class Data
    {
        public static void AddCourse()
        {
            using Context context = new Context();

            Course course = new Course()
            {
                CourseName = "SUT24",
                Teacher = context.Teachers.FirstOrDefault(t => t.ID == 3)
            };
            context.Add(course);
            context.SaveChanges();
        }
        public static void AddStudents()
        {
            using Context context = new Context();
            List<Student> students = new List<Student>
            {
                new Student() {Name = "John"},
                new Student() {Name = "Bertil"},
                new Student() {Name = "Nina"},
                new Student() {Name = "Oskar"},
                new Student() {Name = "Fredrik"},
                new Student() {Name = "Sara"},
                new Student() {Name = "Henrik"},


            };
            context.Students.AddRange(students);
            context.SaveChanges();
        }
        public static void AddTeachers()
        {
            using Context context = new Context();
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher() {Name = "Anas"},
                new Teacher() {Name = "Reidar"},
                new Teacher() {Name = "Bengt"},
            };
            context.Teachers.AddRange(teachers);
            context.SaveChanges();
        }
        public static void SetCourseForStudent()
        {
            using Context context = new Context();
            var course = context.Courses.FirstOrDefault(c => c.CourseID == 3);

            course.Students = new List<Student>()
            {
                context.Students.FirstOrDefault(s => s.ID == 5),
                context.Students.FirstOrDefault(s => s.ID == 6),
                context.Students.FirstOrDefault(s => s.ID == 7),
            };
            context.SaveChanges();
        }
        public static void AddSubject()
        {
            using Context context = new Context();
            List<Subject> subjects = new List<Subject>
            {
                new Subject(){ SubjectName = "matte"},
                new Subject(){ SubjectName = "Programmering2"},
                new Subject(){ SubjectName = "Programmering"},
            };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();
        }
        public static void AddSubjecttoCourse()
        {
            using Context context = new Context();

            var course = context.Courses.FirstOrDefault(c => c.CourseID == 3);
            var subject1 = context.Subjects.FirstOrDefault(s => s.ID == 2);
            var subject2 = context.Subjects.FirstOrDefault(s => s.ID == 3);
            course.Subjects = new List<Subject>() { subject1, subject2 };
            context.SaveChanges();
        }
        public static void AddTeachertoSubject()
        {
            using Context context = new Context();

            var subject = context.Subjects.FirstOrDefault(s => s.ID == 3);
            var teacher = context.Teachers.FirstOrDefault(t => t.ID == 2);
            var teacher2 = context.Teachers.FirstOrDefault(t => t.ID == 3);
            subject.Teachers = new List<Teacher>() { teacher, teacher2 };
            context.SaveChanges();
        }
    }
}
