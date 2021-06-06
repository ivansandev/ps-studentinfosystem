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

        // Binding to ComboBox for filtering
        public List<StudentDegrees> Degrees { get; set; }

        public Dictionary<int, List<Student>> Students { get; private set; }

        // CurrGroupStudents is used for filtering students from selected group
        public IEnumerable<Student> _filteredStudents;
        public IEnumerable<Student> FilteredStudents
        {
            get { return _filteredStudents; }
            set
            {
                if (_filteredStudents != value)
                {
                    _filteredStudents = value;
                    OnPropertyChanged("FilteredStudents");
                }
            }
        }

        // Binding to ListBox
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
            Students = new Dictionary<int, List<Student>>();

            InitializeStudents();
            InitializeDegrees();
        }

        private void InitializeStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student student in context.Students)
            {
                if (!Students.ContainsKey((int)student.Group))
                    Students.Add((int)student.Group, new List<Student>());
                Students[(int)student.Group].Add(student);
            }

        }

        private void InitializeDegrees()
        {
            Degrees = Enum.GetValues(typeof(StudentDegrees)).Cast<StudentDegrees>().ToList();
        }

        public void Filter(int? groupQuery, StudentDegrees? degreeQuery, bool? onlyFulltimeStudents)
        {
            // Show students only from selected group and selected degree type
            
            // Validate that group is selected
            if (groupQuery == null)
                return;
            
            // Apply filtering to QualificationDegree only if its selected
            if (degreeQuery != null)
                FilteredStudents = from student in Students[(int)groupQuery] where student.QualificationDegree == degreeQuery select student;
            else
                FilteredStudents = from student in Students[(int)groupQuery] select student;

            if (onlyFulltimeStudents == true)
                FilteredStudents = from student in FilteredStudents where student.Status == "Редовен" select student;
        }
    }
}
