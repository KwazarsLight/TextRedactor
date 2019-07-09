using System;
using System.Linq;
using System.Text;
using System.Windows;

namespace Redactor
{
    /// <summary>
    /// Interaction logic for SaveFileWND.xaml
    /// </summary>
    public partial class SaveFileWND : Window
    {

        string fileText;
        DbAssistant loader;

        public SaveFileWND(string text)
        {
            loader = new DbAssistant();
            InitializeComponent();
            fileText = text;
            ExtensionComboBox.ItemsSource = Enum.GetValues(typeof(eExtensions)).Cast<eExtensions>();
        }

        private async void OkButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] binaryFile = Utils.StringToByteArray(fileText, Encoding.Default);

            TextFile file = new TextFile(FileNameTextBox.Text, (eExtensions)ExtensionComboBox.SelectedValue, binaryFile);

            MessageBox.Show("Done!");
            await loader.InsertFileAsync(file);
            this.Close();
            loader.Dispose();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            loader.Dispose();
            this.Close();
        }
    }
}
