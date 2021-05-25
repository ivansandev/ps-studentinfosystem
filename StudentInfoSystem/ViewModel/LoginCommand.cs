using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using UserLogin;

namespace StudentInfoSystem.ViewModel
{
    public class LoginCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var loginRequest = parameter as LoginRequest;
            loginRequest.Validate();
        }
    }
}
