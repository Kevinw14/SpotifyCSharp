using SpotifyAPI.Web;
using System.Collections.Generic;
namespace SpotifyCSharp
{
    public class Response
    {
        private List<FullTrack> songs;
        private List<SimpleAlbum> albums;
        private List<FullArtist> artists; 
        private List<SimplePlaylist> playlists;

        public List<FullTrack> Songs
        {
            get
            {
                return songs;
            }
        }
        public List<SimpleAlbum> Albums
        {
            get
            {
                return albums;
            }
        }
        public List<FullArtist> Artists
        {
            get
            {
                return artists;
            }
        }
        public List<SimplePlaylist> Playlists
        {
            get
            {
                return playlists;
            }
        }

        public Response(List<FullTrack> songs, List<SimpleAlbum> albums, List<FullArtist> artists, List<SimplePlaylist> playlists)
        {
            this.songs = songs;
            this.albums = albums;
            this.artists = artists;
            this.playlists = playlists;
        }

    }
}
