using System.Windows;
using System.Windows.Controls;

namespace SpotifyCSharp
{

    public interface TableViewDelegate
    {
        public double HeightForRow(TableView TableView, IndexPath IndexPath);
        public double SpaceBetweenRows(TableView TableView, IndexPath IndexPath);
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

        public void Refresh()
        {
            Start();
        }


        private void Start()
        {
            int Sections = Datasource.NumberOfSections(this);

            for (int i = 0; i < Sections; i++)
            {
                int Rows = Datasource.NumberOfRowsInSection(this, i);
                for (int j = 0; j < Rows; j++)
                {
                    IndexPath IndexPath = new IndexPath(i, j);
                    TableViewCell Cell = Datasource.CellForRow(this, IndexPath);
                }
            }
        }
    }
}
