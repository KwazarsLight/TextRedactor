using System;
using System.Text;
using System.Windows;


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

        private void DownloadFileClick(object sender, RoutedEventArgs e)
        {
            DownloadFileWnd wnd = new DownloadFileWnd();                                                     //
            TextFile file = wnd.ShowDialog();                                                                //Open new window and wait for choise

            if (!wnd.IsActive && file != null)
            {
                if (RedactorTextBox.Visibility == Visibility.Hidden)                                         //Set redactor field visible if it hidden from begining
                {                                                                                            //
                    CreateFile_Click(null, null);                                                            //
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
            {                                                                                                                                               //If text exist in field but user tries to create new file
                if (MessageBox.Show("There is writed text. Do you really want to clear it?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)    //
                {
                    RedactorTextBox.Text = "";
                }
            }
        }

        private void QuitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
