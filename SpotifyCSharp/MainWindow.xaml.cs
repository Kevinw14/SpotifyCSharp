using SpotifyAPI.Web;
using System.Windows;
using System;
using System.Collections.Generic;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, AuthenticatorDelegate, TableViewDatasource, TableViewDelegate
    {

        private Authenticator Auth;
        private SpotifyClient? Client;
        private Response Response;

    public MainWindow()
        {
            InitializeComponent();
            Auth = new Authenticator("http://localhost:5000/callback", 5000);
            Auth.Delegate = this;
            MainTableView.Datasource = this;
            MainTableView.Delegate = this;
            Start();
            Search();
        }

        public async void Search()
        {
            SearchRequest SpotifyRequest = new SearchRequest(SearchRequest.Types.All, "Metallica");
            SearchResponse SpotifyResponse = await Client.Search.Item(SpotifyRequest);

            Paging<FullTrack, SearchResponse> Songs = SpotifyResponse.Tracks;
            Paging<SimpleAlbum, SearchResponse> Albums = SpotifyResponse.Albums;
            Paging<FullArtist, SearchResponse> Artists = SpotifyResponse.Artists;
            Paging<SimplePlaylist, SearchResponse> Playlists = SpotifyResponse.Playlists;

            Response = new Response(Songs.Items, Albums.Items, Artists.Items, Playlists.Items);

            MainTableView.Refresh();
        }
        public async void Start()
        {
            await Auth.login();
        }

        public void AuthenticatorDidFinishAuthenticating(SpotifyClient Client)
        {
            try
            {
                this.Client = Client;
            }
            catch (APIException e)
            {
                MessageBox.Show(e.Response.StatusCode.ToString());
            }
        }

        public void AuthenticatorDidFinishLoggingOut()
        {

        }

        public int NumberOfSections(TableView TableView)
        {
            return 4;
        }
        public int NumberOfRowsInSection(TableView TableView, int Section)
        {
            switch (Section) {
                case 0:
                    return Response.Songs.Count;
                case 1:
                    return Response.Albums.Count;
                case 2:
                    return Response.Artists.Count;
                case 3:
                    return Response.Playlists.Count;
                default:
                    return 0;
            }
        }

        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath)
        {

            switch (IndexPath.Section)
            {
                case 0:
                    TableViewCell SongCell = new TableViewCell();
                    List <FullTrack> Songs = Response.Songs;
                    FullTrack Song = Songs[IndexPath.Row];
                    SongCell.Content = Song.Name;
                    return SongCell;

                case 1:
                    TableViewCell AlbumCell = new TableViewCell();
                    List<SimpleAlbum> Albums = Response.Albums;
                    SimpleAlbum Album = Albums[IndexPath.Row];
                    AlbumCell.Content = Album.Name;
                    return AlbumCell;

                case 2:
                    TableViewCell ArtistCell = new TableViewCell();
                    List<FullArtist> Artists = Response.Artists;
                    FullArtist Artist = Artists[IndexPath.Row];
                    ArtistCell.Content = Artist.Name;
                    return ArtistCell;

                case 3:
                    TableViewCell PlaylistCell = new TableViewCell();
                    List<SimplePlaylist> Playlists = Response.Playlists;
                    SimplePlaylist Playlist = Playlists[IndexPath.Row];
                    PlaylistCell.Content = Playlist.Name;
                    return PlaylistCell;

                default:
                    return new TableViewCell();
            }
        }

        public bool IsRowEnabled(TableView TableView, IndexPath IndexPath)
        {
            return false;
        }

        public double HeightForRow(TableView TableView, IndexPath IndexPath)
        {
            return 70;
        }

        public double SpaceBetweenRows(TableView TableView, IndexPath IndexPath)
        {
            return 20;
        }
    }
}
