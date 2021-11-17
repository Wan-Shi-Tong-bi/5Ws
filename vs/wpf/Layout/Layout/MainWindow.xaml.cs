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

namespace Layout
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //<!--<Button Grid.Row="0" Grid.Column="0" Content="Button 0 0"/>
            //<Button Grid.Row="0" Grid.Column="1" Content="Button 0 1"/>
            //<Button Grid.Row="1" Grid.Column="0" Content="Button 1 0"/>
            //<Button Grid.Row="1" Grid.Column="1" Content="Button 1 1"/>
            //<Button Grid.Row="2" Grid.Column="0" Content="Button 2 0"/>
            //<Button Grid.Row="2" Grid.Column="1" Content="Button 2 1"/>
            //<Button Grid.Row="3" Grid.Column="0" Content="Button 3 0"/>
            //<Button Grid.Row="3" Grid.Column="1" Content="Button 3 1"/>
            //<Button Grid.Row="4" Grid.Column="0" Content="Button 4 0"/>
            //<Button Grid.Row="4" Grid.Column="1" Content="Button 4 1"/>
            //<Button Grid.Row="5" Grid.Column="0" Content="Button 5 0"/>
            //<Button Grid.Row="5" Grid.Column="1" Content="Button 5 1"/>
            //<Button Grid.Row="2" Grid.Column="1" Content="Button 2 1"/>-->

            for (int r = 0; r< 6; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    Button btn = new Button { Content = $"btn {r} {c}" };
                    Grid.SetColumn(btn, c);
                    Grid.SetRow(btn, r);
                    GridLeft.Children.Add(btn);
                }
            }
            
            ListBoxTab.
            
        }
    }
}
