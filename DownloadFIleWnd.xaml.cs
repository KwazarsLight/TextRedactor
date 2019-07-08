using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace Redactor
{
    /// <summary>
    /// Interaction logic for DownloadFIleWnd.xaml
    /// </summary>
    public partial class DownloadFIleWnd : Window
    {
        Loader loader = new Loader();
        TextFile file;

        public DownloadFIleWnd()
        {
            InitializeComponent();
        }

        private async void DataGrid_Initialized(object sender, EventArgs e)
        {
            DataTable table = await loader.ShowTable();
            DbTableDataGrid.ItemsSource = table.DefaultView;
        }

        private void DbTableDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid.SelectedItem != null)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                file = loader.ReadFile(Int32.Parse(((TextBlock)RowColumn.Content).Text));

                this.Close();
            }
            else { MessageBox.Show("Choised wrong value."); }
        }

        public TextFile ShowDialog()
        {
            base.ShowDialog();
            return file;
        }



    }
}
