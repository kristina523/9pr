using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.WindowsAPICodePack.Dialogs;
using Spire.Doc;
namespace _9
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createWordFile_Click(object sender, RoutedEventArgs e)
        {
            WordWindow wordWindow = new WordWindow("ааа");
            wordWindow.Show();
        }

        private void openWordFile_Click(object sender, RoutedEventArgs e)
        {
            OpenWordFile();
        }

        private void OpenWordFile()
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("Word файл", "*.docx;*.doc"));
            dialog.Title = "Выберите Word-файл";

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = dialog.FileName;
                Document doc = new Document();
                doc.LoadFromFile(dialog.FileName);
                doc.SaveToFile(dialog.FileName, FileFormat.Rtf);

                WordWindow wordWindow = new WordWindow(path);
                wordWindow.LoadRtfFile(dialog.FileName);
                wordWindow.Show();
            }
        }

        private void createExcelFile_Click(object sender, RoutedEventArgs e)
        {
            ExcelWindow excelWindow = new ExcelWindow();
            excelWindow.Show();
        }

        private void openExcelFile_Click(object sender, RoutedEventArgs e)
        {
            ExcelWindow excelWindow = new ExcelWindow();
            excelWindow.Show();
        }
    }
}