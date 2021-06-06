using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInfoSystem.Model;

namespace StudentInfoSystem.Model
{
    class StudentData
    {
        private static List<Student> _testStudents = new List<Student>();

        public static List<Student> TestStudents
        {
            get
            {
                ResetTestStudentData();
                return _testStudents;
            }
            private set { }
        }

        static private void ResetTestStudentData()
        {
            _testStudents.Clear();
            _testStudents.Add(new Student
            {
                Name = "Boyan",
                Surname = "Vladimirov",
                FamilyName = "Stoyanov",
                Faculty = "FKST",
                Specialty = StudentSpecialty.KSI,
                QualificationDegree = StudentDegrees.BACHELOR,
                Status = "Редовен",
                FacultyNumber = "121218000",
                CourseYear = 3,
                Stream = 9,
                Group = 51,
                JoinedDate = new DateTime(2018, 8, 1)
            });
            _testStudents.Add(new Student
            {
                Name = "Ivan",
                Surname = "Stoyanov",
                FamilyName = "Mihailov",
                Faculty = "FKST",
                Specialty = StudentSpecialty.ITI,
                QualificationDegree = StudentDegrees.BACHELOR,
                Status = "Редовен",
                FacultyNumber = "7654321",
                CourseYear = 2,
                Stream = 9,
                Group = 52,
                JoinedDate = new DateTime(2018, 8, 1)
            });
            _testStudents.Add(new Student
            {
                Name = "Radoslav",
                Surname = "Ivanov",
                FamilyName = "Mihailov",
                Faculty = "FKST",
                Specialty = StudentSpecialty.KSI,
                QualificationDegree = StudentDegrees.BACHELOR,
                Status = "Редовен",
                FacultyNumber = "121218557",
                CourseYear = 4,
                Stream = 9,
                Group = 52,
                JoinedDate = new DateTime(2018, 8, 1)
            });
        }
    }
}
