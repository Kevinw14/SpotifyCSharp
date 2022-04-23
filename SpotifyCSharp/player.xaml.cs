using SpotifyAPI.Web;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for player.xaml
    /// </summary>
    /// 
    public interface PlayerDelegate
    {

    }

    public partial class player : UserControl
    {
        private SpotifyClient client;
        private FullTrack song;
        public SpotifyClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        public FullTrack Song
        {
            get
            {
                return song;
            }

            set
            {
                song = value;
                AlbumImg.Source = GetImage(song.Album.Images[0].Url);
                TimeSlider.Value = 0;
            }
        }
        public player()
        {
            InitializeComponent();

            VolImg.Source = GetImage("C:\\Users\\kevin\\source\\repos\\SpotifyCSharp\\SpotifyCSharp\\Images\\LowVol.png");
            VolumeSlider.Value = 20;
        }

        private BitmapImage GetImage(string URL)
        {
            BitmapImage Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            Bitmap.UriSource = new Uri(URL);
            Bitmap.EndInit();
            return Bitmap;
        }

        private void PlayPauseImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if source img is play.png
                //change source img to pause.png
                //pause song
            //else
                //change source img to play.png
                //play song
        }

        private void ShuffleImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //boolean to see if shuffle is already on
            //if not turn on shuffle and highlight box?
            //else turn off shuffle and un-highlight box
        }

        private void SkipImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Change to next track
        }

        private void PreviousImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Restart Track for single click

            //not sure how to implement double click
        }

        private void VolImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if song is not muted
                //mute song
            //else
                //unmute song
        }

        private void InfoImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //here we could have a pop up with add to playlist, queue, etc?? Maybe
        }

        private void RepeatImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //again depending on what img is the source on click, will change to other image and change repeat
        }

        private void VolumeSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue >= 66)
                VolImg.Source = GetImage("C:\\Users\\kevin\\source\\repos\\SpotifyCSharp\\SpotifyCSharp\\Images\\HiVol.png");
            else if (e.NewValue >= 33)
                VolImg.Source = GetImage("C:\\Users\\kevin\\source\\repos\\SpotifyCSharp\\SpotifyCSharp\\Images\\MedVol.png");
            else
                VolImg.Source = GetImage("C:\\Users\\kevin\\source\\repos\\SpotifyCSharp\\SpotifyCSharp\\Images\\LowVol.png");
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
    }
}
