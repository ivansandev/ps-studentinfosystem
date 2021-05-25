using StudentInfoSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace StudentInfoSystem.ViewModel
{
    public class MainWindowVM: INotifyPropertyChanged
    {
        private Student _student;

        public event PropertyChangedEventHandler PropertyChanged;
        public List<StudentSpecialty> Specialties { get; set; }
        public List<StudentDegrees> Degrees { get; set; }

        public MainWindowVM() { }
        public MainWindowVM(Student ob)
        {
            _student = ob;
            FillStudStatusChoices();
            FillStudSpecialtyChoices();
            FillStudDegreeChoices();
        }

        private void FillStudSpecialtyChoices()
        {
            Specialties = Enum.GetValues(typeof(StudentSpecialty)).Cast<StudentSpecialty>().ToList();
        }

        private void FillStudDegreeChoices()
        {
            Degrees = Enum.GetValues(typeof(StudentDegrees)).Cast<StudentDegrees>().ToList();
        }

        public Student student
        {
            get { return _student; }
            set
            {
                _student = value;
                PropChanged("Student");
            }
        }

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        // NOTE: Added database use
        public List<string> StudStatusChoices { get; set; }
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
    }
}
