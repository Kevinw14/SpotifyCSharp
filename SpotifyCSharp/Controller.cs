using SpotifyAPI.Web;
using System.Threading.Tasks;
using System.Windows;

namespace SpotifyCSharp
{
    class Controller : AuthenticatorDelegate
    {

        private Authenticator Auth;
        private SpotifyClient Client;

        public Controller()
        {
            Auth = new Authenticator("http://localhost:5000/callback", 5000);
            Auth.Delegate = this;
        }

        public async void Start()
        {
            await Auth.login();
        }

        public async void DidFinishAuthenticating(SpotifyClient Client)
        {
            this.Client = Client;
            PrivateUser me = await Client.UserProfile.Current();
            MessageBox.Show(me.DisplayName);
        }
    }


}
