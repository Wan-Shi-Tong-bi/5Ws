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

namespace MobileRobotCon
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        private string groupHead;
        [Category("MyUserControlData"), Description("Vlaue of the thing")]
        public string GroupHeader
        {
            get { return groupHead; }
            set
            {
                groupHead = value;
                gbHeader.Header = groupHead;
            }
        }

        private double sliVal;

        public double SliVal
        {
            get { return sliVal; }
            set
            {
                sliVal = value;
                proForward.Value = sliVal;
                proBack.Value = sliVal * -1;
                sliBackFor.Value = sliVal;
            }
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            SliVal = sliBackFor.Maximum;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            SliVal = sliBackFor.Minimum;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            SliVal = 0;
        }

        private void sliBackFor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliVal = sliBackFor.Value;
        }

        private void proBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SliVal = (e.GetPosition(proBack).Y / proBack.ActualHeight) - 1;
        }

        private void proForward_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SliVal = 1 - e.GetPosition(proForward).Y / proBack.ActualHeight;
        }
    }
}
