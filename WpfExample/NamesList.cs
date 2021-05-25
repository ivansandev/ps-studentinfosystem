using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace WpfExample
{
    public class NamesList : INotifyPropertyChanged
    {
        private string _firstName = "";
        private string _lastName = "";
        private string _selectedName;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<string> Names { get; private set; }
        private AddCommand _addNameCommand = new AddCommand();
        public AddCommand AddNameCommand
        {
            get { return _addNameCommand; }
        }
        private RemoveCommand _removeNameCommand = new RemoveCommand();
        public RemoveCommand RemoveNameCommand
        {
            get { return _removeNameCommand; }
        }

        public NamesList()
        {
            Names = new ObservableCollection<string>();
        }

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public string SelectedName
        {
            get { return _selectedName; }
            set
            {
                if (_selectedName != value)
                {
                    _selectedName = value;
                    OnPropertyChanged("_selectedName");
                }
            }
        }
    }
}
