using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace WpfExample
{
    public class InfoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            // throw new NotImplementedException();
            return true;
        }

        public void Execute(object parameter)
        {
            // throw new NotImplementedException();
            // MessageBox.Show("Hello, world!");
            NamesWindow namesWindow = new NamesWindow();
            namesWindow.Show();
        }
    }
}
