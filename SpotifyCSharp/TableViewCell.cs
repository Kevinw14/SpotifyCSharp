using System.Windows;
using System.Windows.Controls;

namespace SpotifyCSharp
{
    public interface TableViewCellDelegate
    {
        public void TableViewCellPressed(TableViewCell TableViewCell);
    }
    public class TableViewCell: Button
    {

        public TableViewCell()
        {
            Width = 100;
        }
    }
}
