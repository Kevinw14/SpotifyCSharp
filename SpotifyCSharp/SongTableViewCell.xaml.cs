using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for SongTableViewCell.xaml
    /// </summary>
    /// 

    public interface SongTableViewCellDelegate
    {
        void PlayButtonTapped(IndexPath IndexPath, SongTableViewCell SongTableViewCell);
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
    }
}
