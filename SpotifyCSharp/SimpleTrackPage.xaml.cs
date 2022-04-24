using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for SimpleTrackPage.xaml
    /// </summary>
    public partial class SimpleTrackPage : Page, TableViewDelegate, TableViewDatasource, SongTableViewCellDelegate
    {
        private List<SimpleTrack> songs;
        private string AlbumUrl;
        private player player_controller;
        public SimpleTrackPage(List<SimpleTrack> Songs, player PlayerController, string AlbumUrl)
        {
            InitializeComponent();
            this.player_controller = PlayerController;
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
            Cell.AlbumImage.Source = GetImage(AlbumUrl);
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

        public void PlayButtonTapped(IndexPath IndexPath, SongTableViewCell SongTableViewCell)
        {
            SimpleTrack Song = songs[IndexPath.Row];
            player_controller.Play(Song);
        }

        public void LikeButtonTapped(IndexPath IndexPath)
        {
            throw new NotImplementedException();
        }
    }
}
