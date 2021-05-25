using StudentInfoSystem.Model;
using StudentInfoSystem.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace StudentInfoSystem.ViewModel
{
    class AddStudentVM : INotifyPropertyChanged
    {
        public List<StudentSpecialty> Specialties { get; set; }
        public List<StudentDegrees> Degrees { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private Student _student;

        public Student student
        {
            get { return _student; }
            set
            {
                if (_student != value)
                {
                    _student = value;
                    OnPropertyChanged("student");
                }
            }
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private AddStudentCommand _addStudentCommand = new AddStudentCommand();
        public AddStudentCommand addStudentCommand { get { return _addStudentCommand; } }

        public AddStudentVM()
        {
            Specialties = Enum.GetValues(typeof(StudentSpecialty)).Cast<StudentSpecialty>().ToList();
            Degrees = Enum.GetValues(typeof(StudentDegrees)).Cast<StudentDegrees>().ToList();
            FillStudStatusChoices();

            student = new Student();
        }

        public List<string> StudStatusChoices { get; set; }

        public Action CloseAction { get; set; }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();

            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                // query (string)
                string sqlquery =
                    @"SELECT StatusDescr
                    FROM StudStatus";
                IDbCommand command = new SqlCommand();
                // connection to DB
                command.Connection = connection;
                connection.Open();

                // adding query string to command
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();

                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)
                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }


        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            InspectorReport inspector = new InspectorReport(admin: true);
            inspector.Show();
        }
    }
}
