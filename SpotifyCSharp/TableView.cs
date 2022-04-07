using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace SpotifyCSharp
{

    public interface TableViewDelegate
    {
        public double HeightForRow(TableView TableView, IndexPath IndexPath);
        public double SpaceBetweenRows(TableView TableView, IndexPath IndexPath);
        public bool IsRowEnabled(TableView TableView, IndexPath IndexPath);
    }

    public interface TableViewDatasource
    {
        public int NumberOfSections(TableView TableView) { return 1; }
        public int NumberOfRowsInSection(TableView TableView, int Section);
        public TableViewCell CellForRow(TableView TableView, IndexPath IndexPath);
    }
    public class TableView : ScrollViewer
    {
        private TableViewDelegate delgte;
        private TableViewDatasource datasource;
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
            VerticalAlignment = VerticalAlignment.Top;
            Height = 619;
            Width = 813;
        }
        public void Refresh()
        {
            Start();
        }


        private void Start()
        {
            Grid Grid = (Grid)this.FindName("TableViewGrid");
            int Sections = Datasource.NumberOfSections(this);

            double TopMargin = 0;
            for (int i = 0; i < Sections; i++)
            {
                int Rows = Datasource.NumberOfRowsInSection(this, i);
                for (int j = 0; j < Rows; j++)
                {
                    IndexPath IndexPath = new IndexPath(i, j);
                    bool IsEnabled = Delegate.IsRowEnabled(this, IndexPath);
                    double Height = Delegate.HeightForRow(this, IndexPath);
                    double Spacing = Delegate.SpaceBetweenRows(this, IndexPath);

                    TableViewCell Cell = Datasource.CellForRow(this, IndexPath);
                    Cell.VerticalAlignment = VerticalAlignment.Top;
                    Cell.Height = Height;
                    Cell.IsEnabled = IsEnabled;
                    Cell.Margin = new Thickness(0, TopMargin, 0, 0);
                    TopMargin += Cell.Height + Spacing;
                    Grid.Children.Add(Cell);
                }
            }
        }
    }
}
