using SpotifyAPI.Web;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpotifyCSharp
{
    public interface SongTableViewCellDelegate
    {
        public void QueueButtonPressed();
        public void PlayButtonPressed();
    }
    public class SongTableViewCell: TableViewCell
    {

        private Label name_label;
        private System.Windows.Controls.Image album_image;
        private Grid grid;
        private SongTableViewCellDelegate delgte;
        public SongTableViewCellDelegate Delegate
        {
            get
            {
                return Delegate;
            }

            set
            {
                delgte = value;
            }
        }
        public SongTableViewCell(FullTrack Song)
        {
            grid = new Grid();
            this.AddChild(grid);

            album_image = new System.Windows.Controls.Image();
            album_image.Height = 50;
            album_image.Width = album_image.Height;
            album_image.HorizontalAlignment = HorizontalAlignment.Left;
            album_image.Margin = new Thickness(-330, 0, 0, 0);
            string AlbumImageURL = Song.Album.Images[0].Url;
            BitmapImage Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            Bitmap.UriSource = new Uri(AlbumImageURL, UriKind.Absolute);
            Bitmap.EndInit();
            album_image.Source = Bitmap;
            grid.Children.Add(album_image);

            name_label = new Label();
            name_label.HorizontalAlignment = HorizontalAlignment.Left;
            name_label.Margin = new Thickness(album_image.Margin.Left + album_image.Height + 10, 10, -this.Width + 200, 0);
            name_label.Content = Song.Name;
            grid.Children.Add(name_label);
        }
    }
}
