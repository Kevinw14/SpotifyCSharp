using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for SongPage.xaml
    /// </summary>
    public partial class SongPage : Page, TableViewDelegate, TableViewDatasource, SongTableViewCellDelegate, PlayerDelegate
    {
        private List<FullTrack> songs;
        private player player_controller;
        private SongTableViewCell current_cell;
        public SongPage(List<FullTrack> Songs, player PlayerController)
        {
            InitializeComponent();
            this.player_controller = PlayerController;
            this.player_controller.Delegate = this;
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
            Cell.AlbumImage.Source = new BitmapImage(new Uri(Song.Album.Images[0].Url));
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
            FullTrack Song = songs[IndexPath.Row];
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
