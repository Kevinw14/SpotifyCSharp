using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for SongPage.xaml
    /// </summary>
    public partial class SongPage : Page, TableViewDelegate, TableViewDatasource, SongTableViewCellDelegate
    {
        private List<FullTrack> songs;
        private SpotifyClient client;
        private SongTableViewCell current_cell;
        private FullTrack current_song;
        private player PlayerController;
        public SongPage(List<FullTrack> Songs, SpotifyClient Client, player PlayerController)
        {
            InitializeComponent();
            this.client = Client;
            this.PlayerController = PlayerController;
            songs = Songs;
            SongTableView.Delegate = this;
            SongTableView.Datasource = this;
            SongTableView.Refresh();
        }

        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath)
        {
            SongTableViewCell Cell = new SongTableViewCell(IndexPath);
            Cell.Delegate = this;
            FullTrack Song = songs[IndexPath.Row];
            Cell.SongLabel.Text = Song.Name;
            Cell.ArtistLabel.Text = Song.Artists[0].Name;
            Cell.AlbumImage.Source = GetImage(Song.Album.Images[0].Url);
            return Cell;
        }

        // Helper method that returns an BitmapImage from a URL. 
        private BitmapImage GetImage(string URL)
        {
            BitmapImage Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            Bitmap.UriSource = new Uri(URL);
            Bitmap.EndInit();
            return Bitmap;
        }
        public int NumberOfRowsInSection(TableView TableView, int Section)
        {
            return songs.Count;
        }

        private async Task PlaySong(FullTrack Song)
        {
            PlayerResumePlaybackRequest SongPlaybackRequest = new PlayerResumePlaybackRequest();
            SongPlaybackRequest.Uris = new List<string> { Song.Uri };
            DeviceResponse DeviceResponse = await client.Player.GetAvailableDevices();
            List<Device> Devices = DeviceResponse.Devices;
            Device Desktop = Devices[0];
            SongPlaybackRequest.DeviceId = Desktop.Id;
            await client.Player.ResumePlayback(SongPlaybackRequest);
        }
        public async void PlayButtonTapped(IndexPath IndexPath, SongTableViewCell SongTableViewCell)
        {

            if (current_cell != null)
                current_cell.PlayButton.Source = GetImage("C:\\Users\\kevin\\source\\repos\\SpotifyCSharp\\SpotifyCSharp\\play.png");

            FullTrack song = songs[IndexPath.Row];

            if (current_song != null)
            {
                if (song.Id == current_song.Id)
                {
                    await client.Player.ResumePlayback();
                }
                else
                {
                    await PlaySong(song);
                }
            }
            else
            {
                await PlaySong(song);
                PlayerController.PlayPauseImg.Source = GetImage("C:\\Users\\kevin\\source\\repos\\SpotifyCSharp\\SpotifyCSharp\\Images\\pause.png");
            }


            current_cell = SongTableViewCell;
            current_song = song;
            SongTableViewCell.PlayButton.Source = null;
        }

        public void LikeButtonTapped(IndexPath IndexPath)
        {
            FullTrack Song = songs[IndexPath.Row];
        }
    }
}
