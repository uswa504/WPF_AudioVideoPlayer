using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace AVPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "*.mp4";
            ofd.Filter = "media (*.*)|*.*";
            ofd.ShowDialog();
                media.Source = new Uri(ofd.FileName);
                textview.Text = ofd.FileName;
                media.LoadedBehavior = MediaState.Manual;
                media.Play();
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            if (media.Source != null){
                Status.Content = String.Format("{0} / {1}", media.Position.ToString(@"mm\:ss"), media.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
                else Status.Content = "No file selected...";
        }

        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
                media.Play();
        }

        private void btn_pause_Click(object sender, RoutedEventArgs e)
        {
            if (media.Source != null)
                media.Pause();
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (media.Source != null)
                media.Volume = (double)volumeSlider.Value;
        }
    }
}
