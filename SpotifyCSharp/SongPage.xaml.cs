using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for SongPage.xaml
    /// </summary>
    public partial class SongPage : Page, TableViewDelegate, TableViewDatasource
    {
        private List<FullTrack> Songs;
        public SongPage(SearchResponse Response)
        {
            InitializeComponent();
            Songs = Response.Tracks.Items;
            SongTableView.Delegate = this;
            SongTableView.Datasource = this;
            SongTableView.Refresh();
        }

        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath)
        {
            SongTableViewCell Cell = new SongTableViewCell(IndexPath);
            FullTrack Song = Songs[IndexPath.Row];
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

        public double HeightForRow(TableView TableView, IndexPath IndexPath)
        {
            return 140;
        }
        public int NumberOfRowsInSection(TableView TableView, int Section)
        {
            return Songs.Count;
        }

        public double SpaceBetweenRows(TableView TableView, int Section)
        {
            return 20;
        }
    }
}
