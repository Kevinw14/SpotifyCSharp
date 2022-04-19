using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for SongTableViewCell.xaml
    /// </summary>
    /// 

    public interface SongTableViewCellDelegate
    {
        void PlayButtonTapped(IndexPath IndexPath, SongTableViewCell SongTableViewCell); 
        void LikeButtonTapped(IndexPath IndexPath);
    }
    // SongTableViewCell is used to visualize song objects.
    public partial class SongTableViewCell : TableViewCell
    {

        private SongTableViewCellDelegate delgate;
        public SongTableViewCellDelegate Delegate
        {
            get
            {
                return delgate;
            }

            set
            {
                delgate = value;
            }
        }
        public SongTableViewCell(IndexPath index_path):base(index_path)
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            delgate.PlayButtonTapped(this.IndexPath, this);
        }

        private void LikeButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            delgate.LikeButtonTapped(this.IndexPath);
        }

        private BitmapImage GetImage(string URL)
        {
            BitmapImage Bitmap = new BitmapImage();
            Bitmap.BeginInit();
            Bitmap.UriSource = new Uri(URL);
            Bitmap.EndInit();
            return Bitmap;
        }
    }
}
