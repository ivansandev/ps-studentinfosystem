using System;
using System.Collections.Generic;
using System.Text;

namespace WpfExample
{
    public class AddCommand
    {

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var nameList = parameter as NamesList;
            var newName = string.Format("{0} {1}", nameList.FirstName, nameList.LastName);
            Console.WriteLine(newName);
            nameList.Names.Add(newName);
            nameList.FirstName = nameList.LastName = "";
        }

        public bool CanExecute(object parameter) { return true; }

    }
}
