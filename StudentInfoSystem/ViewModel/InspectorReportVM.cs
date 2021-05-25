using StudentInfoSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudentInfoSystem.ViewModel
{
    class InspectorReportVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public List<StudentDegrees> Degrees { get; set; }
        public List<Student> Students { get; private set; }
        public IEnumerable<Student> _currGroupStudents;
        public IEnumerable<Student> CurrGroupStudents
        {
            get { return _currGroupStudents; }
            set
            {
                if (_currGroupStudents != value)
                {
                    _currGroupStudents = value;
                    OnPropertyChanged("CurrGroupStudents");
                }
            }
        }
        public List<int> Groups { get; private set; }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                if (_selectedStudent != value)
                {
                    _selectedStudent = value;
                    OnPropertyChanged("SelectedStudent");
                }
            }
        }


        public InspectorReportVM()
        {
            Groups = new List<int>();
            Students = new List<Student>();
            // CurrGroupStudents = new List<Student>();

            InitializeStudents();
            InitializeGroups();
            InitializeDegrees();
        }

        private void InitializeStudents()
        {
            Students = new List<Student>();
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student student in context.Students)
                Students.Add(student);
        }

        private void InitializeGroups()
        {
            // проверява да няма дублиране на групи
            foreach (Student student in Students)
                if (!Groups.Contains((int)student.Group))
                    Groups.Add((int)student.Group);

            Groups.Sort();
        }

        private void InitializeDegrees()
        {
            Degrees = Enum.GetValues(typeof(StudentDegrees)).Cast<StudentDegrees>().ToList();
        }

        public void Filter(int? groupQuery, StudentDegrees? degreeQuery)
        {
            // Show students only from selected group
            if (groupQuery != null && degreeQuery != null)
                CurrGroupStudents = from student in Students where student.Group == groupQuery && student.QualificationDegree == degreeQuery select student;
            else if (groupQuery == null)
                CurrGroupStudents = from student in Students where student.QualificationDegree == degreeQuery select student;
            else if (degreeQuery == null)
                CurrGroupStudents = from student in Students where student.Group == groupQuery select student;
        }
    }
}
