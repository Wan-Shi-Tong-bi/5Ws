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

namespace Test1Uebung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Patient> patienten;
        private const int IMG_WIDTH = 452;
        private const int IMG_HEIGHT = 800;

        public MainWindow()
        {
            InitializeComponent();
            patienten = new List<Patient>();
        }

        private void mLaden_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == true)
            {
                patientBox.Items.Clear();

                StreamReader sr = new StreamReader(openFileDialog.FileName);

                while (!sr.EndOfStream)
                {
                    Patient p = null;
                    if(Patient.TryParse(sr.ReadLine(), out p))
                    {
                        patientBox.Items.Add(p);
                        patienten.Add(p);
                    }
                }
                sr.Close();
            }
        }

        private void mSpeichern_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == true)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                for (int i = 0; i < patienten.Count; i++)
                {
                    Patient p = patienten[i];
                    sw.WriteLine(p.ToCSVString());
                }
                sw.Close();
            }
        }

        private void patientBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (patientBox.SelectedItem is Patient)
            {
                DrawCoordinates(patientBox.SelectedItem as Patient);
            }
        }

        private void DrawCoordinates(Patient p) {
            CanvasDraw.Children.Clear();
            if (p.Krankheiten.Count > 0)
            {


                foreach (Krankheit k in p.Krankheiten)
                {
                    Ellipse circle = new Ellipse();
                    circle.Height = CanvasDraw.ActualWidth * 0.05;
                    circle.Width = CanvasDraw.ActualWidth * 0.05;
                    circle.Stroke = new SolidColorBrush(Colors.Red);

                    TransformGroup tg = new TransformGroup();
                    tg.Children.Add(new TranslateTransform(CanvasDraw.ActualWidth * k.X, CanvasDraw.ActualHeight * k.Y));

                    circle.RenderTransform = tg;
                    CanvasDraw.Children.Add(circle);
                }       
            }
        }

        private void CanvasDraw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(CanvasDraw);
            
            if (patientBox.SelectedItem is Patient)
            {
                int selected = patientBox.SelectedIndex;

                Patient patient = patientBox.SelectedItem as Patient;
                double x = p.X / CanvasDraw.ActualWidth;
                double y = p.Y / CanvasDraw.ActualHeight;
                string name = diseaseBox.SelectedItem as string;

                patienten[selected].Krankheiten.Add(
                        new Krankheit()
                        {
                            X = x,
                            Y = y,
                            Name = name
                        }
                    );

                patientBox.Items.Clear();

                DrawCoordinates(patienten[selected]);


                patientBox.Items.Clear();
                foreach (Patient tempP in patienten)
                {
                    patientBox.Items.Add(tempP);
                }

                patientBox.SelectedIndex = selected;

            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void CanvasDraw_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (patientBox.SelectedItem is Patient)
            {
                DrawCoordinates(patientBox.SelectedItem as Patient);
            }
        }
    }
}
