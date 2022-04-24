using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for AlbumTableViewCell.xaml
    /// </summary>
    /// 

    public interface AlbumTableViewCellDelegate {
        void PlayButtonTapped(IndexPath IndexPath);
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

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.delgate.PlayButtonTapped(this.IndexPath);
        }

        private void TableViewCell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.delgate.AlbumCellTapped(this.IndexPath);
        }
    }
}
