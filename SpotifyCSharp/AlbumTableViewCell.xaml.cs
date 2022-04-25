using System.Windows.Input;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for AlbumTableViewCell.xaml
    /// </summary>
    /// 

    public interface AlbumTableViewCellDelegate {
        void AlbumCellTapped(IndexPath IndexPath);
    }

    public partial class AlbumTableViewCell : TableViewCell
    {

        private AlbumTableViewCellDelegate delgate;

        public AlbumTableViewCellDelegate Delegate
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
        public AlbumTableViewCell(IndexPath index_path): base(index_path)
        {
            InitializeComponent();
        }

        private void TableViewCell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.delgate.AlbumCellTapped(this.IndexPath);
        }
    }
}
