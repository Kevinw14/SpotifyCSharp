using SpotifyAPI.Web;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, AuthenticatorDelegate
    {

        private Authenticator Auth;
        //Used to control the playback of songs requested.
        private IPlayerClient Player;
        // Spotify Client. When this is set, we also set the Player object
        private SpotifyClient Client
        {
            get
            {
                return Client;
            }
            set
            {
                Client = value;
                Player = Client.Player;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Auth = new Authenticator("http://localhost:5000/callback", 5000);
            Auth.Delegate = this;
        }

        // Searches everything. We will have to change this later since were only search one category at a time.
        // I think each page (Song, Album, Artist, Podcast) will have their own search function. So this will be moved.
        // For right now it is good to get at least one song to try to play.
        public async void Search()
        {
            // Searches every category for Metallica. Limits the amount of results back to 7.
            SearchRequest SpotifyRequest = new SearchRequest(SearchRequest.Types.All, "Metallica");
            SpotifyRequest.Limit = 7;

            // The Response back from spotify. Has Songs, Albums, Artists that best match the search query.
            SearchResponse SpotifyResponse = await Client.Search.Item(SpotifyRequest);

            Paging<FullTrack, SearchResponse> Songs = SpotifyResponse.Tracks;
            Paging<SimpleAlbum, SearchResponse> Albums = SpotifyResponse.Albums;
            Paging<FullArtist, SearchResponse> Artists = SpotifyResponse.Artists;
            Paging<SimplePlaylist, SearchResponse> Playlists = SpotifyResponse.Playlists;

            // I created a Response object to encapsulate all the categories. After new redesign this will probably cease to exist.
            Response Response = new Response(Songs.Items, Albums.Items, Artists.Items, Playlists.Items);



            // This attempts to play the first song. It needs a active device and I don't know how to get this desktop to be
            // the active device. Earlier when it played, your phone was the active device. It chose that device to play the song.

                //PlayerResumePlaybackRequest PlayRequest = new PlayerResumePlaybackRequest();
            
            // Create a List to hold the Uri's of songs.
                //List<string> S = new List<string>();
                //S.Add(Songs.Items[0].Uri);

            //Give the PlayRequest the Uri's
                //PlayRequest.Uris = S;

            //Play
             //await Player.ResumePlayback(PlayRequest);
        }

        // Delegate method called when user successfully logs into their account.
        public async void AuthenticatorDidFinishAuthenticating(SpotifyClient Client)
        {
            try
            {
                // Set the client to use other functionality of spotify
                this.Client = Client;

                // Get the current users information
                PrivateUser User = await Client.UserProfile.Current();

                // Login button becomes hidden. I think there is an error thrown here when you log in for the first time.
                // Rerun it again and it should be fine.
                LoginButton.Visibility = Visibility.Hidden;


                // Profile image and name label becomes visible
                ProfileImage.Visibility = Visibility.Visible;
                NameLabel.Visibility = Visibility.Visible;

                // Check to see if the user has a profile image
                if (User.Images.Count > 0)
                {
                    ProfileImage.Source = GetImage(User.Images[0].Url);
                }

                // Set the NameLabel the value of their display name.
                NameLabel.Text = User.DisplayName;

                // Search is called here so it doesn't throw an error. We have to be authenticated and Client has to be set.
                Search();
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
            await Auth.login();
        }
    }
}
