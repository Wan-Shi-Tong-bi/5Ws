using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace krankenhausverwaltung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Doctor> listDoctors;
        private List<Patient> listPatients;

        public MainWindow()
        {
            listDoctors = new List<Doctor>();
            listPatients = new List<Patient>();
            InitializeComponent();
        }

        private void Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Click_Save_Doctor(object sender, RoutedEventArgs e)
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
                foreach (var item in listDoctors)
                    writer.WriteLine(item.ToCsvString());
                writer.Close();
            }

        }

        private void Click_Open_Doctor(object sender, RoutedEventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv";
            if (file.ShowDialog() == true)
                path = file.FileName;
            else
                return;

            string[] lines = File.ReadAllLines(path);
            listDoctors.Clear();


            foreach (string line in lines)
                listDoctors.Add(Doctor.TryParse(line));

            Doctors_Into_Graph(new List<Branch>());

        }

        private void Click_Save_Patient(object sender, RoutedEventArgs e)
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
                foreach (var item in listPatients)
                    writer.WriteLine(item.ToCsvString());
                writer.Close();
            }


        }

        private void Click_Open_Patient(object sender, RoutedEventArgs e)
        {
            string path = "";
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|csv files (*.csv)|*.csv";
            if (file.ShowDialog() == true)
                path = file.FileName;
            else
                return;

            string[] lines = File.ReadAllLines(path);
            listPatients.Clear();

            foreach (string line in lines)
                listPatients.Add(Patient.TryParse(line));

            Patient_Into_Graph();
        }

        private void Doctors_Into_Graph(List<Branch> filter)
        {
            TreeViewItem eye = new TreeViewItem { Header = "Augen" };
            TreeViewItem innere = new TreeViewItem { Header = "Innere" };
            TreeViewItem hno = new TreeViewItem { Header = "HNO" };
            int count = 0;

            try
            {
                lblAbtCount.Content = $"Abteilungen: {3 - filter.Count()}";

                foreach (var item in listDoctors)
                {
                    if (filter.Contains(item.Branch))
                        continue;
                    count++;
                    switch (item.Branch)
                    {
                        case Branch.AUGEN:
                            eye.Items.Add(new TreeViewItem { Header = item });
                            break;
                        case Branch.HNO:
                            hno.Items.Add(new TreeViewItem { Header = item });
                            break;
                        case Branch.INNERE:
                            innere.Items.Add(new TreeViewItem { Header = item });
                            break;
                    }
                }
                lblDocCount.Content = $"Ärzte {count}";
                tvDoctor.Items.Clear();
                if (!filter.Contains(Branch.AUGEN))
                    tvDoctor.Items.Add(eye);
                if (!filter.Contains(Branch.INNERE))
                    tvDoctor.Items.Add(innere);
                if (!filter.Contains(Branch.HNO))
                    tvDoctor.Items.Add(hno);
            }
            catch (NullReferenceException) { }
        }

        private void Patient_Into_Graph()
        {
            int lastIndexGrid = 1;

            try
            {

                foreach (var item in listPatients)
                {

                    switch (item.Branch)
                    {
                        case Branch.INNERE:
                            lvPatients.Items.Add(item);
                            break;
                        case Branch.AUGEN:
                            lbPatients.Items.Add(
                                new ListBoxItem { Content = item });
                            break;
                        case Branch.HNO:
                            Label svlbl = new Label { Content = item.SVNr };
                            Label fnlbl = new Label { Content = item.FirstName };
                            Label lnlbl = new Label { Content = item.LastName };
                            ComboBox cb = new ComboBox { ItemsSource = item.Disease, SelectedIndex = 0 };

                            Grid.SetColumn(svlbl, 0);
                            Grid.SetColumn(fnlbl, 1);
                            Grid.SetColumn(lnlbl, 2);
                            Grid.SetColumn(cb, 3);

                            RowDefinition rd = new RowDefinition();
                            rd.Height = GridLength.Auto;
                            gridHno.RowDefinitions.Add(rd);

                            Grid.SetRow(svlbl, lastIndexGrid);
                            Grid.SetRow(fnlbl, lastIndexGrid);
                            Grid.SetRow(lnlbl, lastIndexGrid);
                            Grid.SetRow(cb, lastIndexGrid);

                            gridHno.Children.Add(svlbl);
                            gridHno.Children.Add(fnlbl);
                            gridHno.Children.Add(lnlbl);
                            gridHno.Children.Add(cb);

                            lastIndexGrid++;
                            break;
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var value = ((ComboBoxItem)cbFilter.SelectedItem).Content.ToString();
            try
            {
                switch (value.ToLower())
                {
                    case "alle":
                        Doctors_Into_Graph(new List<Branch>());
                        break;

                    default:
                        var listFilter = new List<Branch> { Branch.AUGEN, Branch.HNO, Branch.INNERE };
                        listFilter.Remove(BranchClass.StringToBranch(value));
                        Doctors_Into_Graph(listFilter);
                        break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void tbClick(object sender, RoutedEventArgs e)
        {
            var listFilter = new List<Branch> {
                tbAugen.IsChecked == false ? Branch.AUGEN : Branch.UNDIFINED,
                tbInnere.IsChecked == false ? Branch.INNERE : Branch.UNDIFINED,
                tbHno.IsChecked == false ? Branch.HNO : Branch.UNDIFINED,
            };

            listFilter.RemoveAll(item => item == Branch.UNDIFINED);

            Doctors_Into_Graph(listFilter);
        }

        private void onLoaded(object sender, RoutedEventArgs e)
        {
            Doctors_Into_Graph(new List<Branch>());
            Patient_Into_Graph();
        }
    }

}