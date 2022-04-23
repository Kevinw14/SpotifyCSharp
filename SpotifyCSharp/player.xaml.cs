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
        private bool isPlaying = false;
        private bool shuffle = false;
        private string repeat = "off";
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

            VolImg.Source = GetImage("C:\\Users\\natha\\\\repos\\SpotifyCSharp\\SpotifyCSharp\\Images\\LowVol.png");
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

        private async void PlayPauseImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if source img is play.png
            //change source img to pause.png
            //pause song
            if (isPlaying)
            {
                await Client.Player.PausePlayback();
                isPlaying = false;
            }
            //else
            //change source img to play.png
            //play song
            else
            {
                await Client.Player.ResumePlayback();
                isPlaying = true;
            }
        }

        private async void ShuffleImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //boolean to see if shuffle is already on
            //if not turn on shuffle and highlight box? !!!!!!!!!!!!!!!!!!!!!!!!!!!
            //else turn off shuffle and un-highlight box
            
            if (shuffle)
            {
                PlayerShuffleRequest sh = new PlayerShuffleRequest(false);
                await Client.Player.SetShuffle(sh);
                shuffle = false;
            }
            else
            {
                PlayerShuffleRequest sh = new PlayerShuffleRequest(true);
                await Client.Player.SetShuffle(sh);
                shuffle = true;
            }
        }

        private async void SkipImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Change to next track
            await Client.Player.SkipNext();
        }

        private async void PreviousImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Restart Track for single click
            PlayerSeekToRequest seek = new PlayerSeekToRequest(0);
            await Client.Player.SeekTo(seek);
            //not sure how to implement double click
        }

        private void VolImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void InfoImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //here we could have a pop up with add to playlist, queue, etc?? Maybe
        }

        private async void RepeatImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (repeat.Equals("off"))
            {
                PlayerSetRepeatRequest rep = new PlayerSetRepeatRequest(PlayerSetRepeatRequest.State.Track);
                await Client.Player.SetRepeat(rep);
                repeat = "track";
            }
            else if (repeat.Equals("track"))
            {
                PlayerSetRepeatRequest rep = new PlayerSetRepeatRequest(PlayerSetRepeatRequest.State.Context);
                await Client.Player.SetRepeat(rep);
                repeat = "context";
            }
            else
            {
                PlayerSetRepeatRequest rep = new PlayerSetRepeatRequest(PlayerSetRepeatRequest.State.Off);
                await Client.Player.SetRepeat(rep);
                repeat = "off";
            }
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
            PlayerVolumeRequest vol = new PlayerVolumeRequest(Convert.ToInt32(e.NewValue));
            Client.Player.SetVolume(vol);
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FullTrack track = new FullTrack();
            double duration = Convert.ToDouble(track.DurationMs);
            double place = TimeSlider.Value;

            long time = Convert.ToInt64(duration / place);

            PlayerSeekToRequest seek = new PlayerSeekToRequest(time);
            Client.Player.SeekTo(seek);
        }
    }
}
