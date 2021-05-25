using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;
using StudentInfoSystem.Model;
using StudentInfoSystem.ViewModel;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(Student ob) : this()
        {
            this.DataContext = new MainWindowVM(ob);
        }

        public MainWindow(bool addStudent) : this()
        {
            this.DataContext = new MainWindowVM();
        }

        public void lastLogin(User user)
        {
            IEnumerable<string> log = Logger.GetLogs();
            bool userIsFound = false;
            foreach (string activity in log)
            {
                if (activity.Contains(user.Username))
                {
                    string activityTime = activity.Split(" | ")[0];
                    userIsFound = true;
                    lastactivityTB.Text = activityTime;
                }
            }
            if (!userIsFound)
            {
                lastactivityTB.Text = "Студентът не се е логирал нито веднъш.";
            }
        }
        private void changeTextboxesStatus(bool status)
        {
            foreach (UIElement element in PersonalData.Children)
                if (element is TextBox)
                    ((TextBox)element).IsEnabled = status;
            foreach (UIElement element in StudentInformation.Children)
                if (element is TextBox)
                    ((TextBox)element).IsEnabled = status;
        }

        private void clearTextboxes()
        {
            foreach (UIElement element in PersonalData.Children)
                if (element is TextBox)
                    ((TextBox)element).Text = "";
            foreach (UIElement element in StudentInformation.Children)
                if (element is TextBox)
                    ((TextBox)element).Text = "";
        }
    }
}
