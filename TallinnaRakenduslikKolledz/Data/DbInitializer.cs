using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student { FirstName = "George", LastName = "Teemus", EnrollmentDate = DateTime.Now, },
                new Student { FirstName = "Abra", LastName = "Kadabra", EnrollmentDate = DateTime.Now, },
                new Student { FirstName = "Nipi", LastName = "Tiri", EnrollmentDate = DateTime.Now, },
                new Student { FirstName = "Ba", LastName = "Zooka", EnrollmentDate = DateTime.Now, },
                new Student { FirstName = "Kuri", LastName = "Muri", EnrollmentDate = DateTime.Now, },
                new Student { FirstName = "Super", LastName = "Mario", EnrollmentDate = DateTime.Now, },
                new Student { FirstName = "Muha", LastName = "Mmed", EnrollmentDate = DateTime.Now, },
                new Student { FirstName = "Karl", LastName = "Suur", EnrollmentDate = DateTime.Now, }
            };
            context.Students.AddRange(students);
            context.SaveChanges();
            
            if (context.Courses.Any()) { return; }
            var courses = new Course[]
            {
                new Course { CourseId=1001, Title = "Programmeerimise alused", Credits=3},
                new Course { CourseId=2002, Title = "Programmeerimine 1", Credits=6},
                new Course { CourseId=3003, Title = "Programmeerimine 2", Credits=9},
                new Course { CourseId=2003, Title = "Tarkvara arendusprotsess", Credits=3},
                new Course { CourseId=1002, Title = "Multimeedia", Credits=3},
                new Course { CourseId=3001, Title = "Hajusrakenduste alused", Credits=3},
                new Course { CourseId=9001, Title = "Cryptobro 101", Credits=0},
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();

            if (context.Enrollments.Any()) { return; }
            var enrollments = new Enrollment[]
            {
                new Enrollment { StudentID=1, CourseID=3003, CurrentGrade=Grade.X},
                new Enrollment { StudentID=1, CourseID=2001, CurrentGrade=Grade.B},
                new Enrollment { StudentID=2, CourseID=1001, CurrentGrade=Grade.A},
                new Enrollment { StudentID=2, CourseID=1002, CurrentGrade=Grade.MA},
                new Enrollment { StudentID=3, CourseID=1001, CurrentGrade=Grade.C},
                new Enrollment { StudentID=3, CourseID=2003, CurrentGrade=Grade.C},
                new Enrollment { StudentID=4, CourseID=1002, CurrentGrade=Grade.D},
                new Enrollment { StudentID=4, CourseID=2003, CurrentGrade=Grade.F},
                new Enrollment { StudentID=5, CourseID=3003, CurrentGrade=Grade.F},
                new Enrollment { StudentID=5, CourseID=3001, CurrentGrade=Grade.X},
                new Enrollment { StudentID=6, CourseID=1001, CurrentGrade=Grade.A},
                new Enrollment { StudentID=6, CourseID=1002, CurrentGrade=Grade.MA},
                new Enrollment { StudentID=7, CourseID=1001, CurrentGrade=Grade.C},
                new Enrollment { StudentID=7, CourseID=2003, CurrentGrade=Grade.C},
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();

            if (context.Instructors.Any()) { return; }
            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Money", LastName = "Boss", HireDate = DateTime.Now, Salary=90000,},
                new Instructor { FirstName = "Hubert", LastName = "Hammas", HireDate = DateTime.Now, Salary=17000,},
                new Instructor { FirstName = "Mihkel", LastName = "Miljon", HireDate = DateTime.Now, Salary=1000000,},
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();
        }
    }
}
