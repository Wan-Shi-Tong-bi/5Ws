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
using System.Windows.Threading;

namespace TachoAnaloguhr
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Line lineSec;
        private Line lineMin;
        private Line lineHou;
        private DispatcherTimer tmrSampling;
        private double radius;

        public MainWindow()
        {
            lineSec = new Line
            {
                StrokeThickness = 1,
                Stroke = new SolidColorBrush { Color = Colors.White }
            };
            lineMin = new Line
            {
                StrokeThickness = 1,
                Stroke = new SolidColorBrush { Color = Colors.Yellow }
            };
            lineHou = new Line
            {
                StrokeThickness = 1,
                Stroke = new SolidColorBrush { Color = Colors.Aqua }
            };
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            radius = 0;
            tmrSampling = new DispatcherTimer();
            tmrSampling.Interval = TimeSpan.FromMilliseconds(1000);
            tmrSampling.Tick += TmrSampling_Tick;
            tmrSampling.Start();
        }

        private void TmrSampling_Tick(object sender, EventArgs e)
        {
            cavClock.Children.Clear();
            SetRad();
            NumBorder();

            DrawZeiger();
        }

        private void SetRad()
        {
            if (cavClock.ActualWidth > cavClock.ActualHeight)
                radius = cavClock.ActualHeight / 2;
            else
                radius = cavClock.ActualWidth / 2;
        }

        private void cavClock_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cavClock.Children.Clear();
            SetRad();
            NumBorder();
            DrawZeiger();
        }

        private void DrawZeiger()
        {
            DateTime time = DateTime.Now;

            lineSec.X1 = 0;
            lineSec.Y1 = 0;
            lineSec.X2 = 0;
            lineSec.Y2 = -radius * 0.65;

            TransformGroup tg3 = new TransformGroup();

            tg3.Children.Add(new RotateTransform(time.Second * 6));
            tg3.Children.Add(new TranslateTransform(cavClock.ActualWidth / 2, cavClock.ActualHeight / 2));

            lineSec.RenderTransform = tg3;
            cavClock.Children.Add(lineSec);


            lineMin.X1 = 0;
            lineMin.Y1 = 0;
            lineMin.X2 = 0;
            lineMin.Y2 = -radius * 0.45;

            tg3 = new TransformGroup();

            tg3.Children.Add(new RotateTransform(time.Minute * 6));
            tg3.Children.Add(new TranslateTransform(cavClock.ActualWidth / 2, cavClock.ActualHeight / 2));

            lineMin.RenderTransform = tg3;
            cavClock.Children.Add(lineMin);

            lineHou.X1 = 0;
            lineHou.Y1 = 0;
            lineHou.X2 = 0;
            lineHou.Y2 = -radius * 0.45;

            tg3 = new TransformGroup();

            tg3.Children.Add(new RotateTransform(time.Hour * 30));
            tg3.Children.Add(new TranslateTransform(cavClock.ActualWidth / 2, cavClock.ActualHeight / 2));

            lineHou.RenderTransform = tg3;
            cavClock.Children.Add(lineHou);
        }

        private void NumBorder()
        {

            for (int i = 0; i < 12; i++)
            {
                TextBlock tb5 = new TextBlock
                {
                    Width = 30,
                    Height = 20,
                    Foreground = new SolidColorBrush(Colors.White),
                };

                tb5.Text = $"{i}";
                if (i == 0)
                    tb5.Text = "12";
                TransformGroup tg3 = new TransformGroup();
                tg3.Children.Add(new TranslateTransform(-7 , -7));
                tg3.Children.Add(new RotateTransform((-i * 30) + 90));
                tg3.Children.Add(new TranslateTransform(radius * 0.9, 0));
                tg3.Children.Add(new RotateTransform((i * 30) - 90));
                tg3.Children.Add(new TranslateTransform(cavClock.ActualWidth / 2, cavClock.ActualHeight / 2));

                tb5.RenderTransform = tg3;

                cavClock.Children.Add(tb5);

                Line line = new Line { X1 = 0, X2 = 10, Y1 = 0, Y2 = 0, Stroke = new SolidColorBrush { Color = Colors.White } };

                tg3 = new TransformGroup();
                
                tg3.Children.Add(new TranslateTransform(radius * 0.7, 0));
                tg3.Children.Add(new RotateTransform(i * 30));
                tg3.Children.Add(new TranslateTransform(cavClock.ActualWidth / 2, cavClock.ActualHeight / 2));

                line.RenderTransform = tg3;
                    cavClock.Children.Add(line);



            }


        }
    }
}
