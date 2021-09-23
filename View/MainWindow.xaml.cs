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

namespace ASApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool TipShow = false;
        private int Time = 0;
        private string Hours = String.Empty;
        private string Minutes = String.Empty;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InfoButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.TipShow == false)
            {
                TipBox.Visibility = Visibility.Visible;
                this.TipShow = true;
            }
            else
            {
                TipBox.Visibility = Visibility.Hidden;
                this.TipShow = false;
            }
        }

        private void Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MoveSpace_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            string Command = String.Empty;
            Command = "shutdown -s -t " + Convert.ToString(this.Time * 60);
            System.Diagnostics.Process.Start("CMD.exe", $"/C {Command}");
            MessageBox.Show($"You computer will be shut down in {Hours} hours {Minutes} minutes");
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Time = (int)TimeSlider.Value;
            Hours = Convert.ToString(Math.Floor((decimal)(this.Time / 60)));
            Minutes = Convert.ToString(Math.Floor((decimal)(this.Time - Convert.ToInt32(Hours) * 60)));
            if (Minutes.Length == 1) Minutes = "0" + Minutes;
            TimeSelection.Text = Hours + ":" + Minutes;
        }
    }
}
