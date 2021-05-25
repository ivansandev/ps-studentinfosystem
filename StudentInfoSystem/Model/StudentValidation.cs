using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;
using StudentInfoSystem.Model;

namespace StudentInfoSystem.Model
{
    class StudentValidation
    {
        public Student GetStudentDataByUser(User user, ref string errorMessage)
        {
            if (string.IsNullOrEmpty(user.FakNum))
            {
                errorMessage = "Студента които е посочен няма факултетен номер.";
                return null;
            }

            StudentInfoContext context = new StudentInfoContext();

            foreach (Student student in context.Students)
            {
                if (user.FakNum.Equals(student.FacultyNumber))
                {
                    return student;
                }
            }

            errorMessage = "Не е намерен студент с посочения факултетен номер.";
            return null;
        }
    }
}
