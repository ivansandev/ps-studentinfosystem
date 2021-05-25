using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfExample
{
    public class RemoveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var nameList = parameter as NamesList;
            return nameList != null && nameList.SelectedName != null;
        }
        public void Execute(object parameter)
        {
            var nameList = parameter as NamesList; 
            var oldName = nameList.SelectedName; nameList.Names.Remove(oldName);
        }
    }
}
