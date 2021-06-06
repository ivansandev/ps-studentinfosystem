using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfoSystem.Model
{
    public class StudentDetailed :  Student
    {
        public override string ToString()
        {
            return this.Name + " " + this.FamilyName + " " + this.FacultyNumber + " | " + this.Faculty + " | " + this.Specialty + " | " + this.Group;
        }
    }
}
