using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);

            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Сигурни ли сте, че искате изход?", "Изход?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length > 2)
            {
                MessageBox.Show("Здравей, " + tbName.Text + "! Това е Visual Studio 2012!");
            }
            else
            {
                MessageBox.Show("Полето [име] трябва да съдържа поне 2 символа!");
            }
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string errMsg = "";
            int n = 0, y = 0;

            if (String.IsNullOrEmpty(tbN.Text))
            {
                errMsg += "[N] must not be empty!\n";
            }
            else
            {
                try
                {
                    n = Convert.ToInt32(tbN.Text);
                }
                catch (FormatException)
                {
                    //MessageBox.Show("Invalid input for N field!\n" + fe.Message, "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                    errMsg += "Invalid input for [N] field!\n";
                }
            }

            if (String.IsNullOrEmpty(tbY.Text))
            {
                errMsg += "[Y] must not be empty!\n";
            }
            else
            {
                try
                {
                    y = Convert.ToInt32(tbY.Text);
                }
                catch (FormatException)
                {
                    //MessageBox.Show("Invalid input for Y field!\n" + fe.Message, "Invalid input", MessageBoxButton.OK, MessageBoxImage.Error);
                    errMsg += "Invalid input for [Y] field!\n";
                }
            }

            if (errMsg.Length <= 0)
            {
                double pow = Math.Pow(n, y);

                long fact = 1;
                for (int i = 1; i <= n; i++)
                {
                    fact *= i;
                }

                lblResult.Content = fact.ToString() + "\n";
                lblResult.Content += pow.ToString() + "\n";
            }
            else
            {
                MessageBox.Show(errMsg);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("This is Windows Presentation Foundation!");
            //textBlock1.Text = DateTime.Now.ToString();
            MyMessage anotherWindow = new MyMessage();
            anotherWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string greetingMsg;
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }
    }
}
