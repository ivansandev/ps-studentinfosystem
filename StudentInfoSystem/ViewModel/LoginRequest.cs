using StudentInfoSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UserLogin;
using StudentInfoSystem.View;

namespace StudentInfoSystem.ViewModel
{
    public class LoginRequest : INotifyPropertyChanged
    {
        private string _username = "";
        private string _password = "";

        public Action CloseAction { get; set; }
        public LoginRequest() { }
        public event PropertyChangedEventHandler PropertyChanged;
        private LoginCommand _loginCommand = new LoginCommand();
        public LoginCommand LoginUserCommand { get { return _loginCommand; } }
        public void Validate()
        {
            LoginValidation validator = new LoginValidation(Username, Password, showIncorrectAccount);
            User loginUser = null;
            validator.ValidateUserInput(ref loginUser);
            loginUserRole(LoginValidation.CurrentUserRole, loginUser);
        }

        private void showIncorrectAccount(string err)
        {
            MessageBox.Show(err, "ERROR", MessageBoxButton.OK);
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string Username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private void loginUserRole(UserRoles role, User user)
        {
            InspectorReport inspector;
            switch (role)
            {
                case UserRoles.ANONYMOUS:
                    break;

                case UserRoles.ADMIN:
                    // NOTE: Админ би трябвало да може да създава нови студенти
                    inspector = new InspectorReport(admin: true);
                    inspector.Show();
                    CloseAction();
                    break;

                case UserRoles.INSPECTOR:

                case UserRoles.PROFESSOR:
                    inspector = new InspectorReport();
                    inspector.Show();
                    CloseAction();
                    break;

                case UserRoles.STUDENT:
                    string err = "";
                    StudentValidation studentValidation = new StudentValidation();
                    Student student = studentValidation.GetStudentDataByUser(user, ref err);
                    if (err.Length == 0 && user != null)
                    {
                        MainWindow mainWindow = new MainWindow(student);
                        mainWindow.lastLogin(user);
                        mainWindow.Show();
                        CloseAction();
                    }
                    break;
            }
        }
    }
}
