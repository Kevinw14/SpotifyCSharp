using System.Windows.Controls;

namespace SpotifyCSharp
{

    // Blueprint of a table view cell used to populate the tableview
    public class TableViewCell: UserControl
    {

        private IndexPath index_path;

        // Stores the indexpath to better help determining which item in the array we need to get when
        // a tableviewcell is interacted with.
        public IndexPath IndexPath
        {
            get
            {
                return index_path;
            }
        }
        public TableViewCell(IndexPath index_path)
        {
            this.index_path = index_path;
        }
    }
}
