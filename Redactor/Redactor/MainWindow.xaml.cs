using System;
using System.Collections.Generic;
using System.IO;
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

namespace Redactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UploadloadFileClick(object sender, RoutedEventArgs e)
        {
            

        }

        private void DownloadFileClick(object sender, RoutedEventArgs e)
        {
            DownloadFIleWnd wnd = new DownloadFIleWnd();
            TextFile file = wnd.ShowDialog();

            if (!wnd.IsActive && file != null)
            {
                if (RedactorTextBox.Visibility == Visibility.Hidden)
                {
                    CreateFile_Click(null, null);
                }
                RedactorTextBox.Text = Utils.BinaryToString(file.FileContent, Encoding.Default);
            }
        }

        private void SaveCurrentFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileWND wnd = new SaveFileWND(RedactorTextBox.Text);
            wnd.ShowDialog();
        }


        public void CreateFile_Click(Object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(RedactorTextBox.Text))
            {
                StartInstructionsLabel.Visibility = Visibility.Collapsed;
                RedactorTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                if (MessageBox.Show("There is writed text. Do you really want to clear it?", "Lol", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    RedactorTextBox.Text = "";
                }
            }
        }
    }
}
