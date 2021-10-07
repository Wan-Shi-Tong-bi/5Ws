using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PatientVerwaltungWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HashSet<string> listDisease;

       
        public MainWindow()
        {
            listDisease = new HashSet<string>();
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Patient pat = new Patient
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                BedWetter = chbBedWetter.IsChecked == true,
                Birthday = dateBirthday.DisplayDate,
                IsMale = RdBtnMale.IsChecked == true,
                Diseases = listDisease.ToList()
            };
            listPatient.Items.Add(pat);
            Label l = new Label();
            l.Background = new SolidColorBrush(Colors.Red);
            l.Content = pat.ToStringName();
            stpPatients.Children.Add(l);
        }

        private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
        {
            string path = "";
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv";
            if (file.ShowDialog() == true)
            {
                path = file.FileName;
            }
            else return;

            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (Patient pat in listPatient.Items)
                    writer.WriteLine(pat.WriteFileString());
                writer.Close();
            }
        }

        private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv";
            if (file.ShowDialog() == true)
            {
                path = file.FileName;
            }
            else return;

            listPatient.Items.Clear();
            string[] lines = File.ReadAllLines(path);


            foreach (string line in lines)
            {
                Patient p;
                Patient.TryParse(line, out p);
                listPatient.Items.Add(p);
                
                stpPatients.Children.Add(new Label { Content = p.ToStringName(), Background = new SolidColorBrush(Colors.Red) });
            }
        }

        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Remove(object sender, RoutedEventArgs e)
        {
            try
            {

                Patient p = listPatient.Items.GetItemAt(listPatient.SelectedIndex) as Patient;

                
                listPatient.Items.RemoveAt(listPatient.SelectedIndex);

                Label labelToDelete = null;
                foreach (var item in stpPatients.Children)
                {
                    Label l = item as Label;
                    if (l != null)
                    {
                        if(l.Content.Equals(p.ToStringName()))
                        {
                            labelToDelete = l;
                            break;
                        }
                    }
                    
                }
                stpPatients.Children.Remove(labelToDelete);

            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void Button_Click_Remove_All(object sender, RoutedEventArgs e)
        {
            listPatient.Items.Clear();
            stpPatients.Children.Clear();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            listDisease.Add(cboDisease.Text);
        }

        
    }
}
