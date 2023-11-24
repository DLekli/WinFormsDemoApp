using OfficeOpenXml; // This is for EPPlus functionality
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExcelForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open file dialog to select Excel file
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx|All Files|*.*",
                Title = "Select an Excel file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Import data from Excel to the database
                ImportDataFromExcel(filePath);
            }
        }

        private void ImportDataFromExcel(string filePath)
        {
            try
            {
                // Create a database connection
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2179KCJ\\SQLEXPRESS;Initial Catalog=Exel;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    // Read data from Excel
                    FileInfo fileInfo = new FileInfo(filePath);
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage package = new ExcelPackage(fileInfo))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                        // Loop through rows and columns to get data
                        for (int row = 2; row <= worksheet.Dimension.Rows; row++)
                        {
                            // Assuming your Excel columns are in order: Col1, Col2, Col3, ...
                            string idValue = worksheet.Cells[row, 1].Value.ToString();
                            string nameValue = worksheet.Cells[row, 2].Value.ToString();

                            // Insert data into the database
                            InsertDataIntoDatabase(conn, idValue, nameValue);
                        }
                    }
                }

                MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertDataIntoDatabase(SqlConnection conn, string id, string name)
        {
            // Use SqlCommand to insert data into the database
            using (SqlCommand command = new SqlCommand("INSERT INTO Name (id, name) VALUES (@id, @name)", conn))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);

                command.ExecuteNonQuery();
            }
        }

     
       /* private void button2_Click_1(object sender, EventArgs e)
        {
            // Specify the file path for the exported Excel file
            string exportFilePath = "C:\\Users\\Denis\\Downloads\\TestDataBase.xlsx";

            try
            {
                // Create a database connection
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2179KCJ\\SQLEXPRESS;Initial Catalog=Exel;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    // Query data from the database
                    DataTable dataTable = GetDataFromDatabase(conn);

                    // Export data to Excel
                    ExportDataToExcel(dataTable, exportFilePath);
                }

                MessageBox.Show("Data exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Create a database connection
                using (SqlConnection conn = new SqlConnection("Data Source=DESKTOP-2179KCJ\\SQLEXPRESS;Initial Catalog=Exel;Integrated Security=True;TrustServerCertificate=True"))
                {
                    conn.Open();

                    // Query data from the database
                    DataTable dataTable = GetDataFromDatabase(conn);

                    // Create a SaveFileDialog to let the user choose where to save the file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = "ExportedData";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string exportFilePath = saveFileDialog.FileName;

                            // Export data to Excel
                            ExportDataToExcel(dataTable, exportFilePath);

                            MessageBox.Show($"Excel file created and saved at: {exportFilePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetDataFromDatabase(SqlConnection conn)
        {
            // Use SqlCommand to query data from the database
            using (SqlCommand command = new SqlCommand("SELECT * FROM Name", conn))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        /*private void ExportDataToExcel(DataTable dataTable, string filePath)
        {
            try
            {
                // Create a new Excel package
                using (ExcelPackage package = new ExcelPackage())
                {
                    // Add a worksheet
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    // Write column headers to the Excel file
                    for (int col = 1; col <= dataTable.Columns.Count; col++)
                    {
                        worksheet.Cells[1, col].Value = dataTable.Columns[col - 1].ColumnName;
                    }

                    // Write data to the Excel file
                    for (int row = 0; row < dataTable.Rows.Count; row++)
                    {
                        for (int col = 0; col < dataTable.Columns.Count; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col];
                        }
                    }

                    // Save the Excel package to a file
                    package.SaveAs(new FileInfo(filePath));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting data to Excel: {ex.Message}");
            }
        }*/

        private void ExportDataToExcel(DataTable dataTable, string filePath)
        {
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Create a new Excel package
                    using (ExcelPackage package = new ExcelPackage(memoryStream))
                    {
                        // Add a worksheet
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                        // Write column headers to the Excel file
                        for (int col = 1; col <= dataTable.Columns.Count; col++)
                        {
                            worksheet.Cells[1, col].Value = dataTable.Columns[col - 1].ColumnName;
                        }

                        // Write data to the Excel file
                        for (int row = 0; row < dataTable.Rows.Count; row++)
                        {
                            for (int col = 0; col < dataTable.Columns.Count; col++)
                            {
                                worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col];
                            }
                        }

                        // Save the Excel package to the memory stream
                        package.Save();
                    }

                    // Save the memory stream to a file
                    File.WriteAllBytes(filePath, memoryStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error exporting data to Excel: {ex.Message}");
            }
        }



    }
}
