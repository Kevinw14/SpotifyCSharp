using System.Windows.Input;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for ArtistTableViewCell.xaml
    /// </summary>
    /// 
    public interface ArtistTableViewCellDelegate
    {
        void ArtistCellTapped(IndexPath IndexPath);
    }
    public partial class ArtistTableViewCell : TableViewCell
    {
        private ArtistTableViewCellDelegate delgate;
        public ArtistTableViewCellDelegate Delegate
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
        public ArtistTableViewCell(IndexPath index_path): base(index_path)
        {
            InitializeComponent();
        }

        private void ArtistCell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.delgate.ArtistCellTapped(this.IndexPath);
        }
    }
}
