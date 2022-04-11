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
    /// Interaction logic for SongTableViewCell.xaml
    /// </summary>
    /// 


    // SongTableViewCell is used to visualize song objects.
    public partial class SongTableViewCell : TableViewCell
    {
        public SongTableViewCell(IndexPath index_path):base(index_path)
        {
            InitializeComponent();
        }
    }
}
