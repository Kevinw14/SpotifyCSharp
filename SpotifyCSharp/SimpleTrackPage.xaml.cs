using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for SimpleTrackPage.xaml
    /// </summary>
    public partial class SimpleTrackPage : Page, TableViewDelegate, TableViewDatasource, SongTableViewCellDelegate, PlayerDelegate
    {
        private List<SimpleTrack> songs;
        private string AlbumUrl;
        private player player_controller;
        private SongTableViewCell current_cell;
        public SimpleTrackPage(List<SimpleTrack> Songs, player PlayerController, string AlbumUrl)
        {
            InitializeComponent();
            this.player_controller = PlayerController;
            this.player_controller.Delegate = this;
            songs = Songs;
            this.AlbumUrl = AlbumUrl;
            SongTableView.Delegate = this;
            SongTableView.Datasource = this;
            SongTableView.Refresh();
        }

        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath)
        {
            SongTableViewCell Cell = new SongTableViewCell(IndexPath);
            Cell.Delegate = this;
            SimpleTrack Song = songs[IndexPath.Row];
            Cell.SongLabel.Text = Song.Name;
            Cell.ArtistLabel.Text = Song.Artists[0].Name;
            Cell.AlbumImage.Source = new BitmapImage(new Uri(AlbumUrl));
            return Cell;
        }
        public int NumberOfRowsInSection(TableView TableView, int Section)
        {
            return songs.Count;
        }

        public async void PlayButtonTapped(IndexPath IndexPath, SongTableViewCell SongTableViewCell)
        {
            if (current_cell != null)
            {
                BitmapImage play_image = new BitmapImage(new Uri("/Images/play.png", UriKind.Relative));
                ImageBehavior.SetAnimatedSource(current_cell.PlayButton, play_image);
            }
            SimpleTrack Song = songs[IndexPath.Row];
            BitmapImage wave_gif = new BitmapImage(new Uri("/Images/audio-wave.gif", UriKind.Relative));
            ImageBehavior.SetAnimatedSource(SongTableViewCell.PlayButton, wave_gif);
            await player_controller.Play(Song);
            current_cell = SongTableViewCell;
        }

        public void PlayerPauseButtonTapped(player Player)
        {
            BitmapImage play_image = new BitmapImage(new Uri("/Images/play.png", UriKind.Relative));
            ImageBehavior.SetAnimatedSource(current_cell.PlayButton, play_image);
        }

        public void PlayerPlayButtonTapped(player Player)
        {
            BitmapImage play_image = new BitmapImage(new Uri("/Images/audio-wave.gif", UriKind.Relative));
            ImageBehavior.SetAnimatedSource(current_cell.PlayButton, play_image);
        }
    }
}
