using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentInfoSystem.Model;
using StudentInfoSystem.ViewModel;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for InspectorReport.xaml
    /// </summary>
    public partial class InspectorReport : Window
    {
        private InspectorReportVM vm;
        public InspectorReport()
        {
            InitializeComponent();
            vm = new InspectorReportVM();
            DataContext = vm;
        }

        public InspectorReport(bool admin) : this()
        {
            if (admin)
                addStudentButton.IsEnabled = true;
        }

        /*private void groupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            studentsListBox.Items.Clear();
            int groupPicked;
            groupPicked = Int32.Parse((groupListBox.SelectedItem as ListBoxItem).Content.ToString());

            foreach (Student student in _students)
            {
                if (student.Group == groupPicked)
                {
                    ListBoxItem studentItem = new ListBoxItem();
                    studentItem.Content = student.Name + " " + student.FamilyName + " " + student.FacultyNumber;
                    studentItem.DataContext = student;
                    studentsListBox.Items.Add(studentItem);
                }
            }
        }
        */

        private void addStudentButton_Click(object sender, RoutedEventArgs e)
        {
            AddStudentWindow addStudentWindow = new AddStudentWindow();
            addStudentWindow.Show();
            this.Close();
        }

        private void filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.Filter((int?)groupListBox.SelectedItem, (StudentDegrees?)specialtiesComboBox.SelectedItem);
        }

        private void showStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            if (studentsListBox.SelectedItem as Student != null)
            {
                //Student student = (Student)(studentsListBox.SelectedItem as ListBoxItem).DataContext;
                MainWindow studentWindow = new MainWindow(studentsListBox.SelectedItem as Student);
                studentWindow.Show();
            }
        }

        private void studentsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (studentsListBox.SelectedItem != null)
                showStudentInfo.IsEnabled = true;
            else
                showStudentInfo.IsEnabled = false;
        }
    }
}
