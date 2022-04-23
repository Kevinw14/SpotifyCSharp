﻿using SpotifyAPI.Web;
using System.Windows;
using System;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Navigation;
using System.Collections.Generic;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, AuthenticatorDelegate
    {

        private Authenticator auth;
        // Spotify Client.
        private SpotifyClient client;

        private enum SearchType
        {
            Song,
            Album,
            Artist,
            Episode
        }
        public MainWindow()
        {
            InitializeComponent();
            auth = new Authenticator("http://localhost:5000/callback", 5000);
            auth.Delegate = this;
            Start();
        }

        private async void Start()
        {
            if (File.Exists(auth.CredentialPath))
            {
                await auth.Start();
            }
        }
        // Searches everything. We will have to change this later since were only search one category at a time.
        // I think each page (Song, Album, Artist, Podcast) will have their own search function. So this will be moved.
        // For right now it is good to get at least one song to try to play.
        private async Task Search(string request, SearchType type)
        {

            switch (type) {
                case SearchType.Song:
                    SearchRequest SpotifySongRequest = new SearchRequest(SearchRequest.Types.Track, request);
                    SpotifySongRequest.Limit = 10;
                    SearchResponse SongResponse = await client.Search.Item(SpotifySongRequest);
                    List<FullTrack> Songs = SongResponse.Tracks.Items;
                    SongPage SongPage = new SongPage(Songs, client, PlayerController);
                    MainFrame.Content = SongPage;
                    break;
                case SearchType.Album:
                    SearchRequest SpotifyAlbumRequest = new SearchRequest(SearchRequest.Types.Album, request);
                    SpotifyAlbumRequest.Limit = 10;
                    SearchResponse AlbumResponse = await client.Search.Item(SpotifyAlbumRequest);
                    List<SimpleAlbum> Albums = AlbumResponse.Albums.Items;
                    AlbumPage AlbumPage = new AlbumPage(Albums, client, PlayerController);
                    MainFrame.Content = AlbumPage;
                    break;
                case SearchType.Artist:
                    SearchRequest SpotifyArtistRequest = new SearchRequest(SearchRequest.Types.Artist, request);
                    SpotifyArtistRequest.Limit = 10;
                    break;
                case SearchType.Episode:
                    SearchRequest SpotifyEpisodeRequest = new SearchRequest(SearchRequest.Types.Episode, request);
                    SpotifyEpisodeRequest.Limit = 10;
                    break;
            }

            // Searches every category for Metallica. Limits the amount of results back to 7.
        }

        // Delegate method called when user successfully logs into their account.
        public async void AuthenticatorDidFinishAuthenticating(SpotifyClient Client)
        {
            try
            {
                // Set the client to use other functionality of spotify
                this.client = Client;
                SearchButton.IsEnabled = true;
                SearchTextField.IsEnabled = true;
                //PlayerController.Client = Client;
                PrivateUser User = await Client.UserProfile.Current();

                // Login button becomes hidden. I think there is an error thrown here when you log in for the first time.
                // Rerun it again and it should be fine.
                this.Dispatcher.Invoke(() =>
                {
                    LoginButton.Visibility = Visibility.Hidden;
                    LogoutButton.Visibility = Visibility.Visible;

                    // Profile image and name label becomes visible
                    ProfileImage.Visibility = Visibility.Visible;
                    UserGroupBox.Header = User.DisplayName;

                    // Check to see if the user has a profile image
                    if (User.Images.Count > 0)
                    {
                        ProfileImage.Source = GetImage(User.Images[0].Url);
                    }
                });
            }
            catch (APIException e)
            {
                MessageBox.Show(e.Response.StatusCode.ToString());
            }
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

        // Handle logging the user out (Deleting the credentials file) and updating the UI.
        public void AuthenticatorDidFinishLoggingOut()
        {

        }

        // Called when the login button is clicked to open the web browser if they haven't authenticated before.
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            await auth.StartAuthentication();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchTextField.Text;
            if (SongRadioButton.IsChecked == true)
                await Search(query, SearchType.Song);
            else if (AlbumRadioButton.IsChecked == true)
                await Search(query, SearchType.Album);
        }
    }
}
