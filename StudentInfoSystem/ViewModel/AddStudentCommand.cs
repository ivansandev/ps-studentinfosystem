using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using StudentInfoSystem.Model;
using StudentInfoSystem.View;
using UserLogin;

namespace StudentInfoSystem.ViewModel
{
    class AddStudentCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var addStudent = parameter as AddStudentVM;
            Student student = addStudent.student;
            bool validated = ValidateInput(student);
            if (validated)
            {
                // e.g. Student named Иван Стоянов Иванов will have username of иванстоянов and password of <current_year>+<faculty_number>
                string studentUsername = (student.Name + student.FamilyName).ToLower();
                User user = new User(studentUsername, DateTime.Now.Year.ToString() + student.FacultyNumber, student.FacultyNumber, (int)UserRoles.STUDENT);

                StudentInfoContext context = new StudentInfoContext();
                context.Students.Add(student);
                context.Users.Add(user);

                context.SaveChanges();
                MessageBox.Show("Студентът " + student.Name + " " + student.FamilyName + " е добавен!");
                
                addStudent.CloseAction();
                // InspectorReport inspector = new InspectorReport(admin: true);
                // inspector.Show();
            }
            else
            {
                MessageBox.Show("Моля попълнете всички полета!");
            }
        }

        private bool ValidateInput(Student student)
        {
            if (student.Name == null || student.Name.Length < 2)
                return false;
            if (student.FamilyName == null || student.FamilyName.Length < 2)
                return false;
            if (student.Faculty == null || student.Faculty.Length == 0)
                return false;
            if (student.Specialty == null)
                return false;
            if (student.QualificationDegree == null)
                return false;
            if (student.Status == null)
                return false;
            if (student.FacultyNumber == null || student.FacultyNumber.Length == 0)
                return false;
            if (student.CourseYear == null || student.CourseYear == 0)
                return false;
            if (student.Stream == null || student.Stream == 0)
                return false;
            if (student.Group == null || student.Group == 0)
                return false;

            return true;
        }
    }
}
