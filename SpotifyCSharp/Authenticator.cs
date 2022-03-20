using System.IO;
using System.Threading.Tasks;
using System;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web;
using System.Collections.Generic;
using Newtonsoft.Json;
using static SpotifyAPI.Web.Scopes;

namespace SpotifyCSharp
{

    interface AuthenticatorDelegate
    {
        void AuthenticatorDidFinishAuthenticating(SpotifyClient Client);
        void AuthenticatorDidFinishLoggingOut();
    }

    class Authenticator
    {

        private string credentials_path;
        private string client_id;
        private EmbedIOAuthServer server;
        private AuthenticatorDelegate del;
        public AuthenticatorDelegate Delegate
        {
            get
            {
                return del;
            }

            set
            {
                del = value;
            }
        }

        public Authenticator(string host, int port)
        {
            credentials_path = "credentials.json";
            client_id = Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID");
            server = new EmbedIOAuthServer(new Uri(host), port);
        }

        private async Task<SpotifyClient> Start()
        {
            var json = await File.ReadAllTextAsync(credentials_path);
            var token = JsonConvert.DeserializeObject<PKCETokenResponse>(json);

            var authenticator = new PKCEAuthenticator(client_id, token);
            authenticator.TokenRefreshed += (sender, token) => File.WriteAllText(credentials_path, JsonConvert.SerializeObject(token));

            var config = SpotifyClientConfig.CreateDefault()
              .WithAuthenticator(authenticator);

            SpotifyClient client = new SpotifyClient(config);
            server.Dispose();
            return client;
        }

        private async Task StartAuthentication()
        {
            var (verifier, challenge) = PKCEUtil.GenerateCodes();
            await server.Start();

            server.AuthorizationCodeReceived += async (sender, response) =>
            {
                await server.Stop();
                PKCETokenResponse token = await new OAuthClient().RequestToken(
                  new PKCETokenRequest(client_id, response.Code, server.BaseUri, verifier)
                );

                await File.WriteAllTextAsync(credentials_path, JsonConvert.SerializeObject(token));
                SpotifyClient client = await Start();
                del.AuthenticatorDidFinishAuthenticating(client);
            };

            var request = new LoginRequest(server.BaseUri, client_id, LoginRequest.ResponseType.Code)
            {
                CodeChallenge = challenge,
                CodeChallengeMethod = "S256",
                Scope = new List<string> { UserReadEmail, UserReadPrivate, PlaylistReadPrivate, PlaylistReadCollaborative }
            };

            Uri uri = request.ToUri();

            try
            {
                BrowserUtil.Open(uri);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to open URL, manually open: {0}", uri);
            }
        }

        public async Task login()
        {
            if (string.IsNullOrEmpty(client_id))
            {
                throw new NullReferenceException("Please set SPOTIFY_CLIENT_ID via environment variables before starting the program");
            }

            if (File.Exists(credentials_path))
            {
                await Start();
            }
            else
            {
                await StartAuthentication();
            }
        }

        public void logout()
        {
            File.Delete(credentials_path);
        }
    }
}
