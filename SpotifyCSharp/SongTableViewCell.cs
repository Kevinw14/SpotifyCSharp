using SpotifyAPI.Web;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SpotifyCSharp
{
    public interface SongTableViewCellDelegate
    {
    }
    public class SongTableViewCell: TableViewCell
    {

        private Label name_label;
        private System.Windows.Controls.Image album_image;
        private string album_artwork_url;
        private Grid grid;
        private TableViewCellDelegate delgte;
        public TableViewCellDelegate Delegate
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

        public Label NameLabel
        {
            get
            {
                return name_label;
            }
        }
        public string AlbumArtworkURL
        {
            get
            {
                return album_artwork_url;
            }

            set
            {
                album_artwork_url = value;
                BitmapImage Bitmap = new BitmapImage();
                Bitmap.BeginInit();
                Bitmap.UriSource = new Uri(album_artwork_url, UriKind.Absolute);
                Bitmap.EndInit();
                album_image.Source = Bitmap;
            }
        }
        public SongTableViewCell()
        {
            grid = new Grid();
            this.AddChild(grid);

            album_image = new System.Windows.Controls.Image();
            album_image.Height = 50;
            album_image.Width = album_image.Height;
            album_image.HorizontalAlignment = HorizontalAlignment.Left;
            album_image.Margin = new Thickness(-330, 0, 0, 0);
            grid.Children.Add(album_image);

            name_label = new Label();
            name_label.HorizontalAlignment = HorizontalAlignment.Left;
            name_label.Margin = new Thickness(album_image.Margin.Left + album_image.Height + 10, 10, -this.Width + 200, 0);
            grid.Children.Add(name_label);
        }
    }
}
