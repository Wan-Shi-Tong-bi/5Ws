using DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace CodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KHContext KHDB;
        bool isCoolapsed = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseAlways<KHContext>());
            KHDB = new KHContext();
            InitData();
            List<Doctor> doctors = KHDB.Doctors.ToList();
            TrvHospital.ItemsSource = doctors;
        }

        private void InitData()
        {
            Doctor primar = new Doctor { Firstname = "Günther", Lastname = "Zeidler", Title = "Prim. Dr." };
            Doctor oberarzt = new Doctor { Firstname = "Irmgard", Lastname = "Berger", Title = "OA Dr." };
            Doctor assarzt = new Doctor { Firstname = "Alexander", Lastname = "Herr", Title = "Ass Dr." };

            Patient p1 = new Patient { Firstname = "Bert", Lastname = "Bauer", Born = new DateTime(1981, 12, 17) };
            Patient p2 = new Patient { Firstname = "Mizzi", Lastname = "Mayer", Born = new DateTime(1956, 2, 8) };
            Patient p3 = new Patient { Firstname = "Josef", Lastname = "Huber", Born = new DateTime(1961, 11, 11) };
            Patient p4 = new Patient { Firstname = "Berta", Lastname = "Bauer", Born = new DateTime(1986, 5, 3) };
            Patient p5 = new Patient { Firstname = "Lara", Lastname = "Schmidt", Born = new DateTime(1991, 6, 23) };
            Patient p6 = new Patient { Firstname = "Anton", Lastname = "Mayer", Born = new DateTime(1987, 8, 8) };

            KHDB.Doctors.Add(primar);
            KHDB.Doctors.Add(oberarzt);
            KHDB.Doctors.Add(assarzt);

            p1.Doctor = oberarzt;
            p2.Doctor = primar;
            p3.Doctor = primar;
            p4.Doctor = assarzt;
            p5.Doctor = oberarzt;
            p6.Doctor = primar;

            KHDB.Patients.Add(p1);
            KHDB.Patients.Add(p2);
            KHDB.Patients.Add(p3);
            KHDB.Patients.Add(p4);
            KHDB.Patients.Add(p5);
            KHDB.Patients.Add(p6);

            Measurment m1 = new Measurment { MeasureType = "Temp", SampleRate = 3600000, Start = new DateTime(2016, 02, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m2 = new Measurment { MeasureType = "Pulse", SampleRate = 10, Start = new DateTime(2016, 03, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m3 = new Measurment { MeasureType = "Temp", SampleRate = 3600000, Start = new DateTime(2015, 011, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m4 = new Measurment { MeasureType = "Pulse", SampleRate = 10, Start = new DateTime(2016, 02, 10, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m5 = new Measurment { MeasureType = "Pulse", SampleRate = 10, Start = new DateTime(2016, 02, 17, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m6 = new Measurment { MeasureType = "Temp", SampleRate = 3600000, Start = new DateTime(2016, 02, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m7 = new Measurment { MeasureType = "Pulse", SampleRate = 10, Start = new DateTime(2016, 02, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m8 = new Measurment { MeasureType = "Pulse", SampleRate = 10, Start = new DateTime(2016, 02, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m9 = new Measurment { MeasureType = "Temp", SampleRate = 3600000, Start = new DateTime(2016, 02, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m10 = new Measurment { MeasureType = "Temp", SampleRate = 3600000, Start = new DateTime(2016, 02, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m11 = new Measurment { MeasureType = "Pulse", SampleRate = 10, Start = new DateTime(2016, 02, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };
            Measurment m12 = new Measurment { MeasureType = "Pulse", SampleRate = 10, Start = new DateTime(2016, 02, 18, 12, 0, 0), MeasureValues = new List<MeasureValue>() };


            p1.Measurments.Add(m1);
            p1.Measurments.Add(m2);
            p2.Measurments.Add(m3);
            p2.Measurments.Add(m4);
            p3.Measurments.Add(m5);
            p4.Measurments.Add(m6);
            p4.Measurments.Add(m7);
            p5.Measurments.Add(m8);
            p5.Measurments.Add(m9);
            p6.Measurments.Add(m10);
            p5.Measurments.Add(m11);
            p6.Measurments.Add(m12);

            KHDB.Measurments.Add(m1);
            KHDB.Measurments.Add(m2);
            KHDB.Measurments.Add(m3);
            KHDB.Measurments.Add(m4);
            KHDB.Measurments.Add(m5);
            KHDB.Measurments.Add(m6);
            KHDB.Measurments.Add(m7);
            KHDB.Measurments.Add(m8);
            KHDB.Measurments.Add(m9);
            KHDB.Measurments.Add(m10);
            KHDB.Measurments.Add(m11);
            KHDB.Measurments.Add(m12);

            KHDB.SaveChanges();
        }

        private TreeViewItem GetTreeViewItem(MouseButtonEventArgs e)
        {
            var elem = e.OriginalSource as DependencyObject;

            while (elem != null && !(elem is TreeViewItem))
            {
                elem = VisualTreeHelper.GetParent(elem);
            }

            if (elem == null) return null;
            return elem as TreeViewItem;
        }

        private void TrvHospital_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem ClickedTV = GetTreeViewItem(e);

            Doctor doc;
            if (Doctor.TryParse(ClickedTV.DataContext, out doc))
            {
                ClickedTV.ItemsSource = doc.Patients.ToList();
            }
            Patient p;
            if (Patient.TryParse(ClickedTV.DataContext, out p))
            {
                Random rnd = new Random();
                for (int i = 0; i < p.Measurments.Count; i++)
                {
                    List<MeasureValue> measurments = new List<MeasureValue>();
                    for (int y = 0; y < 21; y++)
                        measurments.Add(new MeasureValue { MValue = rnd.Next(), SamplePosition = y });
                    p.Measurments[i].MeasureValues = measurments;
                }
                ClickedTV.ItemsSource = p.Measurments;
            }
            Measurment mes;
            if (Measurment.TryParse(ClickedTV.DataContext, out mes))
            {

            }

            //Doctor doctor = (Doctor)ClickedTV.DataContext;
            //Patient patient = (Patient)ClickedTV.DataContext;

        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (isCoolapsed)
            {
                lbCoolapsed.Background = new SolidColorBrush(Colors.Red);
                lbCoolapsed.Content = "TreeView all Items loaded";
                trvSetAllItems();
            }
            else
            {
                lbCoolapsed.Background = new SolidColorBrush(Colors.Green);
                lbCoolapsed.Content = "Only base items loaded";
                trvSetBaseItems();
            }
            isCoolapsed = !isCoolapsed;
        }
    }
}
