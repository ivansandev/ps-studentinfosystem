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
using StudentInfoSystem.ViewModel;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for addStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {

        public AddStudentWindow()
        {
            InitializeComponent();
            joinedOnDP.SelectedDate = DateTime.Now;
            joinedOnDP.DisplayDateStart = new DateTime(2010, 1, 1);
            joinedOnDP.DisplayDateEnd = DateTime.Now;

            AddStudentVM vm = new AddStudentVM();
            DataContext = vm;

            if (vm.CloseAction == null)
            {
                vm.CloseAction = new Action(() => this.Close());
            }

            Closing += vm.OnWindowClosing;
        }
    }
}
