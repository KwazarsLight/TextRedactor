﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Redactor
{
    /// <summary>
    /// Interaction logic for DownloadFIleWnd.xaml
    /// </summary>
    public partial class DownloadFileWnd : Window
    {
        DbAssistant loader;
        TextFile file;

        public DownloadFileWnd()
        {
            loader = new DbAssistant();
            InitializeComponent();
        }

        private void DataGrid_Initialized(object sender, EventArgs e)
        {
            DbTableDataGrid.ItemsSource = loader.ShowTable().DefaultView;                                                   //Load data from db when grid initializing,   
        }                                                                                                                   //cause it have to be initialized earlier then window

        private async void DbTableDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid.SelectedItem != null)
            {
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;

                file = await loader.ReadFile(Int32.Parse(((TextBlock)RowColumn.Content).Text));                             //Heap of type castings needs to take value of id_file to take right file 

                this.Close();
            }
            else { MessageBox.Show("Choised wrong row!"); }
        }

        public TextFile ShowDialog()
        {
            base.ShowDialog();
            loader.Dispose();
            return file;
        }



    }
}
