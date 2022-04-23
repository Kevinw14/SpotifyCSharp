using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for AlbumPage.xaml
    /// </summary>
    public partial class AlbumPage : Page, TableViewDatasource, TableViewDelegate
    {
        private List<SimpleAlbum> albums;
        public AlbumPage(List<SimpleAlbum> Albums, SpotifyClient Client, player PlayerController)
        {
            InitializeComponent();
            this.albums = Albums;
            this.AlbumTableView.Datasource = this;
            this.AlbumTableView.Delegate = this;
            AlbumTableView.Refresh();
        }

        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath)
        {
            AlbumTableViewCell Cell = new AlbumTableViewCell(IndexPath);
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
    }
}
