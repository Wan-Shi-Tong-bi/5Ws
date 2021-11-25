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

namespace UsercontrolTacho
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private double radius;
        private double NEEDLE_LENGTH = 0.75;
        private double TACHO_MIN = 0.80;
        private double TACHO_MAX = 0.85;
        private double BORDER_LENGTH = 0.05;
        private Line needle_line;

        private double tachoVar;

        [Category("TachoValueData"),Description("Value of Tacho")]
        public double TachoValue
        {
            get { return tachoVar; }
            set { tachoVar = value;
                DrawNeedle();
                lblValue.Content = tachoVar;
                PrgBar.Value = tachoVar / 180 * 100;
                SliderTacho.Value = tachoVar;
            }
        }


        public UserControl1()
        {
            InitializeComponent();
        }

        

        private void CanTacho_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanTacho.Children.Clear();
            radius = CanTacho.ActualWidth / 2 <= CanTacho.ActualHeight ? CanTacho.ActualWidth / 2 : CanTacho.ActualHeight;
            DrawTacho();
            DrawNeedle();

        }


        private void SliderTacho_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           TachoValue = SliderTacho.Value;
        }

        private void DrawNeedle()
        {
            //Spline statt Strich
            CanTacho.Children.Remove(needle_line);
            needle_line = new Line();
            needle_line.X1 = 0;
            needle_line.Y1 = 0;
            needle_line.X2 = -radius * NEEDLE_LENGTH;
            needle_line.Y2 = 0;
            needle_line.Stroke = new SolidColorBrush(Colors.Red);

            double val = SliderTacho.Value;

            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new RotateTransform(val));
            tg.Children.Add(new TranslateTransform(0, -radius * BORDER_LENGTH));
            tg.Children.Add(new TranslateTransform(CanTacho.ActualWidth / 2, CanTacho.ActualHeight));

            needle_line.RenderTransform = tg;
            CanTacho.Children.Add(needle_line);
        }

        private void DrawTacho()
        {
            Brush whiteBrush = new SolidColorBrush(Colors.White);
            for (int i = 0; i <= 18; i++)
            {
                Line line = new Line();
                line.X1 = -radius * TACHO_MIN;
                line.Y1 = 0;
                line.X2 = -radius * TACHO_MAX;
                line.Y2 = 0;
                line.Stroke = whiteBrush;

                TransformGroup tg = new TransformGroup();
                tg.Children.Add(new RotateTransform(10 * i));
                tg.Children.Add(new TranslateTransform(0, -radius * BORDER_LENGTH));
                tg.Children.Add(new TranslateTransform(CanTacho.ActualWidth / 2, CanTacho.ActualHeight));

                line.RenderTransform = tg;

                CanTacho.Children.Add(line);

                TextBlock textBlock = new TextBlock();
                textBlock.Text = "" + (i * 10);
                textBlock.Foreground = whiteBrush;
                tg = new TransformGroup();

                tg.Children.Add(new TranslateTransform(-10, -10));
                tg.Children.Add(new RotateTransform(-10 * i));
                tg.Children.Add(new TranslateTransform(-radius * 0.9, 0));
                tg.Children.Add(new RotateTransform(10 * i));
                tg.Children.Add(new TranslateTransform(CanTacho.ActualWidth / 2, CanTacho.ActualHeight));
                tg.Children.Add(new TranslateTransform(0, -radius * BORDER_LENGTH));


                textBlock.RenderTransform = tg;
                CanTacho.Children.Add(textBlock);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            radius = CanTacho.ActualWidth / 2 <= CanTacho.ActualHeight ? CanTacho.ActualWidth / 2 : CanTacho.ActualHeight;
            DrawTacho();
            DrawNeedle();
        }
    }
}

