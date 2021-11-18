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

namespace Tacho
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private double radius = 0;
        private const double BORDERS = 0.05;
        private const double TACHO_LENGTH = 0.79;
        private const int SCALA = 180;
        private const int STEP_COUNT = 10;
        Line lineTacho;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetRad()
        {
            if (cavTacho.ActualWidth > cavTacho.ActualHeight)
                radius = cavTacho.ActualHeight / 2;
            else
                radius = cavTacho.ActualWidth / 2;
        }

        private void DrawTacho(double grad)
        {
            lineTacho = new Line
            {
                StrokeThickness = 1,
                Stroke = new SolidColorBrush { Color = Colors.Yellow },
                X1 = 0,
                Y1 = 0,
                X2 = 0,
                Y2 = -radius * TACHO_LENGTH
            };
            TransformGroup tg3 = new TransformGroup();

            tg3.Children.Add(new RotateTransform(grad - 90));
            tg3.Children.Add(new TranslateTransform(cavTacho.ActualWidth / 2, cavTacho.ActualHeight - (cavTacho.ActualHeight * BORDERS)));


            lineTacho.RenderTransform = tg3;
            cavTacho.Children.Add(lineTacho);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (cavTacho != null)
            {
                cavTacho.Children.Remove(lineTacho);
                DrawTacho(sliderValue.Value);
            }
        }

        private void Draw_Scala()
        {

            for (int i = 0; i < SCALA + 1; i += STEP_COUNT)
            {
                double gradCalc = -180 + i;
                TextBlock tb5 = new TextBlock
                {
                    Text = $"{i}",
                    Width = 25,
                    Height = 20,
                    TextAlignment = TextAlignment.Left,
                    Foreground = new SolidColorBrush(Colors.White)
                };

                Line lb5 = new Line
                {
                    X1 = -7,
                    X2 = 7,
                    Stroke = new SolidColorBrush { Color = Colors.White },
                };

                TransformGroup tg5 = new TransformGroup();
                tg5.Children.Add(new TranslateTransform(radius * 0.85, 0));
                tg5.Children.Add(new RotateTransform(gradCalc));
                tg5.Children.Add(new TranslateTransform((cavTacho.ActualWidth / 2), cavTacho.ActualHeight - (cavTacho.ActualHeight * BORDERS)));
                lb5.RenderTransform = tg5;

                cavTacho.Children.Add(lb5);

                TransformGroup tg3 = new TransformGroup();



                tg3.Children.Add(new RotateTransform(gradCalc * -1));
                tg3.Children.Add(new TranslateTransform(radius, 0));
                tg3.Children.Add(new RotateTransform(gradCalc));
                tg3.Children.Add(new TranslateTransform((cavTacho.ActualWidth / 2) - 6, cavTacho.ActualHeight - (cavTacho.ActualHeight * BORDERS * 1.5)));

                tb5.RenderTransform = tg3;

                cavTacho.Children.Add(tb5);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> a = new List<int> { 2, 3, 4, 5 };
            var z = a.Count;
        }

        private void cavTacho_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cavTacho.Children.Clear();
            SetRad();
            Draw_Scala();
            DrawTacho(sliderValue.Value);
        }
    }
}
