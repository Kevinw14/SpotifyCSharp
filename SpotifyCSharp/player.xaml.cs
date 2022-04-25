using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for player.xaml
    /// </summary>
    /// 
    public interface PlayerDelegate
    {
        //FullTrack SongToPlay(player Player);
        void PlayerPlayButtonTapped(player Player);
        void PlayerPauseButtonTapped(player Player);
        void PlayerPreviousButtonTapped(player Player) { }
        void PlayerSkipButtonTapped(player Player) { }
        void PlayerShuffleButtonTapped(player Player, bool State) { }
        void PlayerRepeatButtonTapped(player Player, PlayerSetRepeatRequest.State State) { }
    }

    public partial class player : UserControl
    {
        private SpotifyClient client;
        private int time;
        private FullTrack song;
        private bool is_playing = false;
        private bool shuffle = false;
        private PlayerSetRepeatRequest.State repeat_state = PlayerSetRepeatRequest.State.Off;
        private Device device;
        private PlayerDelegate delgate;
        private DispatcherTimer dispatcher_timer;
        private bool is_muted = false;

        public PlayerDelegate Delegate
        {
            get
            {
                return delgate;
            }

            set
            {
                delgate = value;
            }
        }
        public Device Device
        {
            get
            {
                return device;
            }

            set
            {
                device = value;
            }
        }
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
        public player()
        {
            InitializeComponent();
            VolumeSlider.Value = 100;
            dispatcher_timer = new DispatcherTimer();
            dispatcher_timer.Tick += dispatcherTimer_tick;
            dispatcher_timer.Interval = new TimeSpan(0, 0, 1);
            time = 0;
        }

        private string Timestamp(int time)
        {
            int minute = time / 60;
            int second = time % 60;
            return $"{minute.ToString("00")}:{second.ToString("00")}";
        }

        private string TrackLength(FullTrack Song)
        {
            int duration = Song.DurationMs / 1000;
            int min = duration / 60;
            int sec = duration % 60;
            return $"{min.ToString("00")}:{sec.ToString("00")}";
        }
        private void dispatcherTimer_tick(object sender, EventArgs e)
        {
            time++;
            LblStartTime.Content = Timestamp(time);
            TimeSlider.Value = time;
        }

        public async Task Play(SimpleAlbum Album)
        {
            Paging<SimpleTrack> songs = await Client.Albums.GetTracks(Album.Id);
            PlayerResumePlaybackRequest resume_playback = new PlayerResumePlaybackRequest();
            resume_playback.DeviceId = device.Id;
            List<string> song_ids = new List<string>();
            for (int i = 0; i < songs.Items.Count; i++)
            {
                song_ids.Add(songs.Items[i].Uri);
            }
            resume_playback.Uris = song_ids;
            await Client.Player.ResumePlayback(resume_playback);
            is_playing = true;
            if (songs.Items.Count > 0)
            {
                song = await Client.Tracks.Get(songs.Items[0].Id);
                PlayPauseImg.Source = new BitmapImage(new Uri("/Images/pause.png", UriKind.Relative));
                this.AlbumImg.Source = new BitmapImage(new Uri(song.Album.Images[0].Url));
                this.LblSong.Text = song.Name;
                this.LblArtist.Content = song.Artists[0].Name;
                this.LblEndTime.Content = TrackLength(song);
                TimeSlider.Maximum = song.DurationMs / 1000;
                dispatcher_timer.Start();
            }
        }
        public async Task Play(SimpleTrack Song)
        {
            FullTrack FullSong = await Client.Tracks.Get(Song.Id);
            await Play(FullSong);
        }
        public async Task Play(FullTrack Song)
        {
            this.song = Song;
            PlayerResumePlaybackRequest PBRequest = new PlayerResumePlaybackRequest();
            PBRequest.DeviceId = device.Id;
            PBRequest.Uris = new List<string> { song.Uri };
            is_playing = true;
            PlayPauseImg.Source = new BitmapImage(new Uri("/Images/pause.png", UriKind.Relative));
            this.AlbumImg.Source = new BitmapImage(new Uri(song.Album.Images[0].Url));
            this.LblSong.Text = song.Name;
            this.LblArtist.Content = song.Artists[0].Name;
            this.LblEndTime.Content = TrackLength(Song);
            TimeSlider.Maximum = Song.DurationMs / 1000;
            await client.Player.ResumePlayback(PBRequest);
            time = 0;
            TimeSlider.Value = 0;
            LblStartTime.Content = Timestamp(time);
            LblEndTime.Content = TrackLength(song);
            dispatcher_timer.Start();
        }
        public async Task Play()
        {
            if (song != null)
            {
                await client.Player.ResumePlayback();
                PlayPauseImg.Source = new BitmapImage(new Uri("/Images/pause.png", UriKind.Relative));
                this.delgate.PlayerPlayButtonTapped(this);
                is_playing = true;
                dispatcher_timer.Start();
            }
        }

        public async Task Pause()
        {
            PlayPauseImg.Source = new BitmapImage(new Uri("/Images/play.png", UriKind.Relative));
            is_playing = false;
            this.delgate.PlayerPauseButtonTapped(this);
            await Client.Player.PausePlayback();
            dispatcher_timer.Stop();
        }
        private async void PlayPauseImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if source img is play.png
            //change source img to pause.png
            //pause song
            if (is_playing)
            {
                await Pause();
            }
            //else
            //change source img to play.png
            //play song
            else
            {
                await Play();
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


        }

        private async void SkipImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Change to next track
            await Client.Player.SkipNext();
            time = 0;
            TimeSlider.Value = 0;
            PlayerCurrentPlaybackRequest current_playback_request = new PlayerCurrentPlaybackRequest(PlayerCurrentPlaybackRequest.AdditionalTypes.All);
            CurrentlyPlayingContext currently_playing_context = await Client.Player.GetCurrentPlayback(current_playback_request);
        }

        private async void PreviousImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Restart Track for single click
            PlayerSeekToRequest seek = new PlayerSeekToRequest(0);
            seek.DeviceId = device.Id;
            await Client.Player.SeekTo(seek);
            time = 0;
            LblStartTime.Content = Timestamp(time);
            TimeSlider.Value = 0;
            //not sure how to implement double click
        }

        private void VolImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (is_muted)
            {
                VolumeSlider.Value = 100;
                PlayerVolumeRequest vol = new PlayerVolumeRequest(0);
                Client.Player.SetVolume(vol);
            } else
            {
                VolumeSlider.Value = 0;
                PlayerVolumeRequest vol = new PlayerVolumeRequest(0);
                Client.Player.SetVolume(vol);
            }

            is_muted = !is_muted;
        }

        private async void RepeatImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
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
            else if (e.NewValue > 0)
                VolImg.Source = new BitmapImage(new Uri("/Images/low_vol.png", UriKind.Relative));
            else
                VolImg.Source = new BitmapImage(new Uri("/Images/mute.png", UriKind.Relative));
            if (Client != null)
            {
                PlayerVolumeRequest vol = new PlayerVolumeRequest(Convert.ToInt32(e.NewValue));
                Client.Player.SetVolume(vol);
            }
        }
        private void TimeSlider_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            Slider time_slider = sender as Slider;
            double place = time_slider.Value;
            if (Client != null)
            {
                PlayerSeekToRequest seek = new PlayerSeekToRequest((long)place * 1000);
                seek.DeviceId = device.Id;
                Client.Player.SeekTo(seek);
                int track_position = (int)place;
                LblStartTime.Content = Timestamp(track_position);
                time = track_position;
            }
        }
    }
}
