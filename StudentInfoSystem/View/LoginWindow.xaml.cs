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
using UserLogin;
using StudentInfoSystem.ViewModel;
using StudentInfoSystem.Model;
using System.Linq;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool tutorial = false;
        public LoginWindow()
        {
            // adding test students (one-time) for example purposes
            if (TestStudentsIfEmpty())
                CopyTestStudents();
            if (TestUsersIfEmpty())
                CopyTestUsers();

            if (tutorial) ShowTutorial();

            InitializeComponent();
            LoginRequest vm = new LoginRequest();
            DataContext = vm;
            if (vm.CloseAction == null)
            {
                // assign closing current window to ViewModel
                vm.CloseAction = new Action(() => this.Close());
            }
        }

        private void ShowTutorial()
        {
            MessageBox.Show("За демонстрация, използвайте потребител - студент:" +
                            "\nПотребителско име: student1 " +
                            "\nПарола: 111111\n" +
                            "\nили потребител - админ" +
                            "\nПотребителско име: admin " +
                            "\nПарола: 12345\n",
                            "DEMO VERSION INFO",
                            MessageBoxButton.OK);
        }



        private bool TestStudentsIfEmpty()
        {
            // creates a connection and table columns required from the class
            StudentInfoContext context = new StudentInfoContext();
            if (context.Students.Count() == 0)
                return true;
            return false;
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
                context.Students.Add(st);
            context.SaveChanges();
        }

        private bool TestUsersIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            if (context.Users.Count() == 0)
                return true;
            return false;
        }

        private void CopyTestUsers()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach(User user in UserData.TestUsers)
                context.Users.Add(user);
            context.SaveChanges();
        }

        private void passwordLoginInput_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
