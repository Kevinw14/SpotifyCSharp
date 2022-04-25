using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for AlbumPage.xaml
    /// </summary>
    public partial class AlbumPage : Page, TableViewDatasource, TableViewDelegate, AlbumTableViewCellDelegate
    {
        private List<SimpleAlbum> albums;
        private player player_controller;
        private Frame main_frame;
        private AlbumTableViewCell current_cell;
        public AlbumPage(List<SimpleAlbum> Albums, player PlayerController, Frame MainFrame)
        {
            InitializeComponent();
            this.player_controller = PlayerController;
            this.main_frame = MainFrame;
            this.albums = Albums;
            this.AlbumTableView.Datasource = this;
            this.AlbumTableView.Delegate = this;
            AlbumTableView.Refresh();
        }

        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath)
        {
            AlbumTableViewCell Cell = new AlbumTableViewCell(IndexPath);
            Cell.Delegate = this;
            SimpleAlbum Album = albums[IndexPath.Row];
            Cell.AlbumLabel.Text = Album.Name;
            Cell.ArtistLabel.Text = Album.Artists[0].Name;
            Cell.AlbumImage.Source = GetImage(Album.Images[0].Url);
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
            return albums.Count;
        }

        public async void AlbumCellTapped(IndexPath IndexPath)
        {
            SimpleAlbum album = albums[IndexPath.Row];
            Paging<SimpleTrack> songs = await player_controller.Client.Albums.GetTracks(album.Id);
            SimpleTrackPage simple_track_page = new SimpleTrackPage(songs.Items, player_controller, album.Images[0].Url);
            main_frame.Content = simple_track_page;
        }
    }
}
