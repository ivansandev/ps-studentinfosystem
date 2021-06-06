using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInfoSystem.Model;

namespace StudentInfoSystem.Model
{
    public class Student
    {
        public int? StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FamilyName { get; set; }
        public string Faculty { get; set; }
        public StudentSpecialty? Specialty { get; set; }
        public StudentDegrees? QualificationDegree { get; set; }
        public string Status { get; set; }
        public string FacultyNumber { get; set; }
        public short? CourseYear { get; set; }
        public int? Stream { get; set; } // поток
        public int? Group { get; set; }
        public byte?[] Photo { get; set; }
        public DateTime JoinedDate { get; set; }

        public Student(string name, string surname, string lastname, string faculty, StudentSpecialty specialty, StudentDegrees qualificationDegree, string status, string facultyNumber, short courseYear, int stream, int group, DateTime joinedDate)
        {
            this.Name = name;
            this.Surname = surname;
            this.FamilyName = lastname;
            this.Faculty = faculty;
            this.Specialty = specialty;
            this.QualificationDegree = qualificationDegree;
            this.Status = status;
            this.FacultyNumber = facultyNumber;
            this.CourseYear = courseYear;
            this.Stream = stream;
            this.Group = group;
            this.JoinedDate = joinedDate;
        }

        public Student() {
            this.JoinedDate = DateTime.Now;
        }

        public override string ToString()
        {
            return this.Name + " " + this.FamilyName + " " + this.FacultyNumber;
        }
    }
}
