using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChartWriter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        private Random random = new Random();

        DispatcherTimer tmrSampling;

        private const double MAX_VAL = 35;
        private const float BORDER_LEFT = 0.06f;
        private const float BORDER_RIGHT = 0.03f;
        private const float BORDER_TOP = 0.05f;
        private const float BORDER_BOTTOM = 0.1f;
        private const float LINE_SIZE = 0.02f;
        private const double SCALA = 20;

        private List<double> MvList = new List<double>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tmrSampling = new DispatcherTimer();
            tmrSampling.Interval = TimeSpan.FromMilliseconds(50);
            tmrSampling.Tick += TmrSampling_Tick;
            var lgb = new LinearGradientBrush(
                Color.FromRgb(0, 255, 0),
                Color.FromRgb(255, 0, 0),
                new Point(0, 0.5),
                new Point(1, 0.5));
            prbValue.Foreground = lgb;
            DrawCoordinateSystem();
        }

        private void TmrSampling_Tick(object sender, EventArgs e)
        {
            tmrSampling.Interval = TimeSpan.FromMilliseconds(sliInterval.Value);
            DrawCoordinateSystem();

            if (rbtnRandom.IsChecked == true)
                MvList.Add(random.NextDouble());
            else
                MvList.Add(sliConst.Value);
            DrawValues();

        }
        private void DrawCoordinateSystem()
        {
            cavChart.Children.Clear();

            var left_bottom = new Point(BORDER_LEFT * cavChart.ActualWidth, (1 - BORDER_BOTTOM) * cavChart.ActualHeight);
            var right_bottom = new Point((1 - BORDER_RIGHT) * cavChart.ActualWidth, (1 - BORDER_BOTTOM) * cavChart.ActualHeight);
            var left_top = new Point(BORDER_LEFT * cavChart.ActualWidth, BORDER_TOP * cavChart.ActualHeight);

            cavChart.Children.Add(new Polyline
            {
                StrokeThickness = 2,
                Stroke = new SolidColorBrush { Color = Colors.White },
                Points = { right_bottom, left_bottom, left_top }

            });

            var diffLen = (LINE_SIZE * cavChart.ActualWidth);
            var diffWid = (LINE_SIZE * cavChart.ActualHeight);
            cavChart.Children.Add(new Polyline
            {
                StrokeThickness = 2,
                Stroke = new SolidColorBrush { Color = Colors.White },
                Points = {
                    new Point(right_bottom.X - diffLen, right_bottom.Y + diffWid),
                    right_bottom,
                    new Point(right_bottom.X - diffLen, right_bottom.Y - diffWid) }

            });

            cavChart.Children.Add(new Polyline
            {
                StrokeThickness = 2,
                Stroke = new SolidColorBrush { Color = Colors.White },
                Points = {
                    new Point(left_top.X + diffWid, left_top.Y + diffLen),
                    left_top,
                    new Point(left_top.X -diffWid, left_top.Y + diffLen) }
            });

            DrawScala();

        }

        private void DrawScala()
        {
            for (int i = 0; i < SCALA; i++)
            {
                var lines = new Polyline
                {
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush { Color = Colors.White },
                };
                lines.Points.Add(new Point(X2Pixel(i, SCALA), Y2Pixel(0.02)));

                if (i % 2 == 0)
                {
                    lines.Points.Add(new Point(X2Pixel(i, SCALA), Y2Pixel(-0.02)));
                    SetTextBoxX(i);
                }
                else
                    lines.Points.Add(new Point(X2Pixel(i, SCALA), Y2Pixel(0)));

                cavChart.Children.Add(lines);


                lines = new Polyline
                {
                    StrokeThickness = 1,
                    Stroke = new SolidColorBrush { Color = Colors.White },
                };
                lines.Points.Add(new Point(X2Pixel(-0.3, SCALA), Y2Pixel(i / SCALA)));

                if (i % 2 == 0)
                {
                    lines.Points.Add(new Point(X2Pixel(0.3, SCALA), Y2Pixel(i / SCALA)));
                    SetTextBoxY(i);
                }
                else
                    lines.Points.Add(new Point(X2Pixel(0, SCALA), Y2Pixel(i / SCALA)));

                cavChart.Children.Add(lines);

            }

            SetTextBoxX((int)SCALA);
            SetTextBoxY((int)SCALA);
        }

        private void SetTextBoxX(int i)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = $"{i * 15}",
                Foreground = new SolidColorBrush(Colors.White)
            };

            Canvas.SetTop(textBlock, Y2Pixel(-0.04));
            Canvas.SetLeft(textBlock, X2Pixel(i, SCALA));
            cavChart.Children.Add(textBlock);
        }

        private void SetTextBoxY(int i)
        {
            TextBlock textBlock = new TextBlock
            {
                Text = $"{i * 5}",
                Foreground = new SolidColorBrush(Colors.White)
            };

            Canvas.SetTop(textBlock, Y2Pixel(i / SCALA));
            Canvas.SetLeft(textBlock, X2Pixel(-1, SCALA));
            cavChart.Children.Add(textBlock);
        }

        private void DrawValues()
        {
            if (MvList.Count >= MAX_VAL)
                MvList.RemoveAt(0);

            var lines = new Polyline
            {
                StrokeThickness = 1,
                Stroke = new SolidColorBrush { Color = Colors.Yellow },
            };

            for (int i = 0; i < MvList.Count; i++)
                lines.Points.Add(new Point(X2Pixel(i, MAX_VAL), Y2Pixel(MvList[i])));

            cavChart.Children.Add(lines);
        }

        private float X2Pixel(double i, double maxValue)
        {
            return (float)(i / maxValue * cavChart.ActualWidth * (1.0 - BORDER_LEFT - BORDER_RIGHT)
                    + cavChart.ActualWidth * BORDER_LEFT);
        }

        private float Y2Pixel(double percent)
        {
            return (float)(cavChart.ActualHeight
                    - (percent * cavChart.ActualHeight * (1.0 - BORDER_TOP - BORDER_BOTTOM)
                    + cavChart.ActualHeight * BORDER_BOTTOM));
        }

        private void tbtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (tbtnStart.IsChecked == true)
            {
                tbtnStart.Content = "Stop Timer";
                tmrSampling.Start();
            }
            else
            {
                tbtnStart.Content = "Start Timer";
                tmrSampling.Stop();
            }
        }

        private void cavChart_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawCoordinateSystem();
            DrawValues();
        }

    }
}
