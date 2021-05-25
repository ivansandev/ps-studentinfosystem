using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private ObservableCollection<string> _BackingProperty;
        // This is the publically viewable Property for this class
        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set
            {
                _BackingProperty = value;
                PropChanged("BoundProperty");
            }
        }
        // PropertyChanged event is fired to notify any listeners of a change in property value
        public event PropertyChangedEventHandler PropertyChanged;

        // Tell WPF binding that this property value has changed
        public void PropChanged(String propertyName)
        {
            // Did WPF regirered to listen to this event
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }
    }
}
