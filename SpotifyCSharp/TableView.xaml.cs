using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    /// 
    public interface TableViewDelegate
    {
        public double HeightForRow(TableView TableView, IndexPath IndexPath);
        public double SpaceBetweenRows(TableView TableView, int Section);
    }

    public interface TableViewDatasource
    {
        public int NumberOfSections(TableView TableView) { return 1; }
        public int NumberOfRowsInSection(TableView TableView, int Section);
        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath);
    }
    public partial class TableView : UserControl
    {
        private TableViewDelegate delgte;
        private TableViewDatasource datasource;
        // Delegate used to control how cells look on the tableview
        public TableViewDelegate Delegate
        {
            get
            {
                return delgte;
            }

            set
            {
                delgte = value;
            }
        }

        // Delegate used to communicate what data should be dislayed in the tableview
        public TableViewDatasource Datasource
        {
            get
            {
                return datasource;
            }

            set
            {
                datasource = value;
            }
        }
        public TableView()
        {
            InitializeComponent();

            // Sets the Horizontal scroll bar visible.
            this.TableViewScroller.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        // Manually called when developer has received a response and wants to refresh the table with new results.
        public void Refresh()
        {
            Start();
        }
        private void Start()
        {


            // Ask for the number of sections needed (Defaults to 1).
            int Sections = datasource.NumberOfSections(this);
            // Varible to keep track how far we need to offset the next cell
            double TopMargin = 0;
            for (int i = 0; i < Sections; i++)
            {

                // Ask for the number of rows needed.
                int Rows = Datasource.NumberOfRowsInSection(this, i);
                for (int j = 0; j < Rows; j++)
                {
                    // Create the index path, which is just the section and row this tableview cell belongs too.
                    IndexPath IndexPath = new IndexPath(i, j);

                    // Get the cell we want to add.
                    TableViewCell Cell = Datasource.CellForRow(this, IndexPath);

                    // Set the alignments of the cells
                    Cell.HorizontalAlignment = HorizontalAlignment.Left;
                    Cell.VerticalAlignment = VerticalAlignment.Top;

                    // Ask for the height each cell should be.
                    double Height = Delegate.HeightForRow(this, IndexPath);
                    Cell.Height = Height;

                    // Ask for how much space should be from each cell.
                    double Spacing = Delegate.SpaceBetweenRows(this, i);

                    // Set the margins for the cell.
                    Cell.Margin = new Thickness(0, TopMargin, 0, 0);

                    // Add it to the tableview.
                    TableViewGrid.Children.Add(Cell);


                    // Update the TopMargin with the height of the cell with the spaceing to find the next location to add the cell.
                    TopMargin += Height + Spacing;
                }
            }
        }
    }
}
