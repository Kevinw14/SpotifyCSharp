using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
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
        private PlayerSetRepeatRequest.State repeat_state = PlayerSetRepeatRequest.State.Off;
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
            VolumeSlider.Value = 100;
        }

        private BitmapImage GetImage(string URL)
        {
            BitmapImage Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            Bitmap.UriSource = new Uri(URL);
            Bitmap.EndInit();
            return Bitmap;
        }

        public async void Play(SimpleTrack Song)
        {

        }

        public async void Play(FullTrack Song)
        {

        }

        public async void Play(SimpleAlbum Album)
        {

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
                shuffle = false;
                PlayerShuffleRequest shoff = new PlayerShuffleRequest(shuffle);
                await Client.Player.SetShuffle(shoff);
                ShuffleImg.Source = new BitmapImage(new Uri("/Images/shuffle-off.png", UriKind.Relative));
            }
            else
            {
                shuffle = true;
                PlayerShuffleRequest shon = new PlayerShuffleRequest(shuffle);
                await Client.Player.SetShuffle(shon);
                ShuffleImg.Source = new BitmapImage(new Uri("/Images/shuffle-on.png", UriKind.Relative));
            }

            PlayerShuffleRequest sh = new PlayerShuffleRequest(shuffle);
            await Client.Player.SetShuffle(sh);
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
            DeviceResponse device_response = await client.Player.GetAvailableDevices();
            List<Device> devices = device_response.Devices;
            Device device = devices[0];

            switch (repeat_state)
            {
                case PlayerSetRepeatRequest.State.Off:
                    repeat_state = PlayerSetRepeatRequest.State.Context;
                    PlayerSetRepeatRequest context_rep = new PlayerSetRepeatRequest(repeat_state);
                    context_rep.DeviceId = device.Id;
                    await Client.Player.SetRepeat(context_rep);
                    RepeatImg.Source = new BitmapImage(new Uri("/Images/repeat-context.png", UriKind.Relative));
                    break;
                case PlayerSetRepeatRequest.State.Track:
                    repeat_state = PlayerSetRepeatRequest.State.Off;
                    PlayerSetRepeatRequest off_rep = new PlayerSetRepeatRequest(repeat_state);
                    off_rep.DeviceId = device.Id;
                    await Client.Player.SetRepeat(off_rep);
                    RepeatImg.Source = new BitmapImage(new Uri("/Images/repeat-off.png", UriKind.Relative));
                    break;
                case PlayerSetRepeatRequest.State.Context:
                    repeat_state = PlayerSetRepeatRequest.State.Track;
                    PlayerSetRepeatRequest track_rep = new PlayerSetRepeatRequest(repeat_state);
                    track_rep.DeviceId = device.Id;
                    await Client.Player.SetRepeat(track_rep);
                    RepeatImg.Source = new BitmapImage(new Uri("/Images/repeat-track.png", UriKind.Relative));
                    break;
            }
        }

        private void VolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (e.NewValue >= 66)
                VolImg.Source = new BitmapImage(new Uri("/Images/hi_vol.png", UriKind.Relative));
            else if (e.NewValue >= 33)
                VolImg.Source = new BitmapImage(new Uri("/Images/med_vol.png", UriKind.Relative));
            else
                VolImg.Source = new BitmapImage(new Uri("/Images/low_vol.png", UriKind.Relative));
            if (Client != null)
            {
                PlayerVolumeRequest vol = new PlayerVolumeRequest(Convert.ToInt32(e.NewValue));
                Client.Player.SetVolume(vol);
            }
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FullTrack track = new FullTrack();
            double duration = Convert.ToDouble(track.DurationMs);
            double place = TimeSlider.Value;

            long time = Convert.ToInt64(duration / place);

            if (Client != null)
            {
                PlayerSeekToRequest seek = new PlayerSeekToRequest(time);
                Client.Player.SeekTo(seek);
            }
        }
    }
}
