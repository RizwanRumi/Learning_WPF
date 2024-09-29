using System.Data;
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

namespace DemoWPFTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataTable largeDataTable;
        private int currentPage = 1;
        private const int pageSize = 100;

        public MainWindow()
        {
            InitializeComponent();
            LoadLargeDataTable();
            LoadPage(currentPage);

            //Binding binding = new Binding("Text");
            //binding.Source = txtValue;
            //lblValue.SetBinding(TextBlock.TextProperty, binding);
        }

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
        //    {
        //        lstNames.Items.Add(txtName.Text);
        //        txtName.Clear();

        //    }
        //}

        // Generate a large DataTable with 400 columns and 600 rows
        private void LoadLargeDataTable()
        {
            largeDataTable = new DataTable();

            // Add 400 columns
            for (int col = 1; col <= 400; col++)
            {
                largeDataTable.Columns.Add($"Column {col}", typeof(string));
            }

            // Add 600 rows of sample data
            for (int row = 1; row <= 600; row++)
            {
                DataRow dataRow = largeDataTable.NewRow();
                for (int col = 1; col <= 400; col++)
                {
                    dataRow[$"Column {col}"] = $"Data R{row}C{col}";
                }
                largeDataTable.Rows.Add(dataRow);
            }
        }

        // Load a specific page of data into the DataGrid
        private void LoadPage(int pageNumber)
        {
            int startRow = (pageNumber - 1) * pageSize;
            int endRow = Math.Min(startRow + pageSize, largeDataTable.Rows.Count);

            DataTable pageTable = largeDataTable.Clone(); // Create schema copy
            for (int i = startRow; i < endRow; i++)
            {
                pageTable.ImportRow(largeDataTable.Rows[i]);
            }

            dataGrid.ItemsSource = pageTable.DefaultView;
            pageNumberText.Text = pageNumber.ToString();
        }

        // Event handler for the Next button
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage * pageSize < largeDataTable.Rows.Count)
            {
                currentPage++;
                LoadPage(currentPage);
            }
        }

        // Event handler for the Previous button
        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPage(currentPage);
            }
        }
    }
}