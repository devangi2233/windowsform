
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "CSV Files (*.csv)|*.csv";
            dialog.ShowDialog();

            // If the user selected a file, then import the data from the file into the DataGridView.
            if (dialog.FileName != "")
            {
                // Create a DataTable object to store the data from the CSV file.
                DataTable table = new DataTable();


                string selectedCsvFilePath = dialog.FileName;
                txtcsvfilepath.Text = selectedCsvFilePath;

                // Read the data from the CSV file into the DataTable object.
                using (StreamReader reader = new StreamReader(dialog.FileName))
                {
                    string[] headers = reader.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        table.Columns.Add(header);
                    }

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] rowData = line.Split(',');

                        DataRow row = table.NewRow();

                        for (int i = 0; i < rowData.Length; i++)
                        {
                            row[i] = rowData[i];
                        }

                        table.Rows.Add(row);
                    }
                }

                // Bind the DataTable object to the DataGridView control.
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
