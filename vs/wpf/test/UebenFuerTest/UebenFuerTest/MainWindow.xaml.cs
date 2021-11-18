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

namespace UebenFuerTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Point> points = new List<Point>();
        private double origWidth = 0;
        private double origHigh = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void patOpenMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void patSaveMI_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(krankCanv);
            points.Add(p);
            Line line = new Line();
            if(points.Count > 1)
            {
                line = new Line
                {
                    X1 = points[points.Count - 2].X,
                    X2 = points[points.Count - 1].X,
                    Y1 = points[points.Count - 2].Y,
                    Y2 = points[points.Count - 1].Y,
                    Stroke = new SolidColorBrush(Colors.Red)
                };
                Panel.SetZIndex(line, points.Count);
                krankCanv.Children.Add(line);
            }
            origHigh = krankCanv.ActualHeight;
            origWidth = krankCanv.ActualWidth;
            
        }

        private void drawLine()
        {
            
            krankCanv.Children.Clear();
            
            List<Point> pointlist = new List<Point>();
            foreach(var point in points)
            {
                Point p = new Point
                {
                    X = point.X * krankCanv.ActualWidth / origWidth,
                    Y = point.Y * krankCanv.ActualHeight / origHigh
                };
                pointlist.Add(p);
            }
            for(int i = 1; i < pointlist.Count; i++)
            {
                Line line = new Line
                {
                    X1 = pointlist[i - 1].X,
                    X2 = pointlist[i].X,
                    Y1 = pointlist[i-1].Y,
                    Y2 = pointlist[i].Y,
                    Stroke = new SolidColorBrush(Colors.Red)
                };
                Panel.SetZIndex(line, points.Count);
                krankCanv.Children.Add(line);
            }
            points = pointlist;
            origHigh = krankCanv.ActualHeight;
            origWidth = krankCanv.ActualWidth;


        }

        private void krankCanv_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            drawLine();
        }

        
    }
}
