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
    /// Interaction logic for ArtistsPage.xaml
    /// </summary>
    public partial class ArtistsPage : Page, TableViewDatasource, TableViewDelegate, ArtistTableViewCellDelegate
    {
        private List<FullArtist> artists;
        private player player_controller;
        private Frame main_frame;
        public ArtistsPage(List<FullArtist> Artists, player PlayerController, Frame MainFrame)
        {
            InitializeComponent();
            this.player_controller = PlayerController;
            this.main_frame = MainFrame;
            this.artists = Artists;
            this.ArtistsTableView.Datasource = this;
            this.ArtistsTableView.Delegate = this;
            this.ArtistsTableView.Refresh();
        }

        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath)
        {
            ArtistTableViewCell Cell = new ArtistTableViewCell(IndexPath);
            Cell.Delegate = this;
            FullArtist Artist = artists[IndexPath.Row];
            Cell.ArtistLabel.Text = Artist.Name;
            if (Artist.Images.Count > 0)
            {
                Cell.ArtistImage.Source = new BitmapImage(new Uri(Artist.Images[0].Url));
            }
            return Cell;
        }
        public int NumberOfRowsInSection(TableView TableView, int Section)
        {
            return artists.Count;
        }

        public async void ArtistCellTapped(IndexPath IndexPath)
        {
            FullArtist artist = artists[IndexPath.Row];
            ArtistsAlbumsRequest AARequest = new ArtistsAlbumsRequest();
            Paging<SimpleAlbum> albums = await player_controller.Client.Artists.GetAlbums(artist.Id);
            AlbumPage AlbumPage = new AlbumPage(albums.Items, player_controller, main_frame);
            main_frame.Content = AlbumPage;
        }
    }
}
