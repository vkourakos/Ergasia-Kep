using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia3
{
    public partial class Form3 : Form
    {
        //initializing the sqlite connection
        SQLiteConnection connection;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //connects to the database, reads all the data, puts them in a datatable and then gives that datatable as a data source for the dataGridView
            connection = new SQLiteConnection("Data Source=Aithseis.db;Version=3;");
            connection.Open();

            SQLiteDataReader reader;
            SQLiteCommand command;
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM aithseis";
            reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Surname");
            dataTable.Columns.Add("Address");
            dataTable.Columns.Add("Birthday");
            dataTable.Columns.Add("Choice");
            dataTable.Columns.Add("Email");
            dataTable.Columns.Add("Phone");
            dataTable.Columns.Add("DateAndTime");
            while (reader.Read())
            {
                DataRow row = dataTable.NewRow();
                row["ID"] = reader["ID"];
                row["Name"] = reader["Name"];
                row["Surname"] = reader["Surname"];
                row["Address"] = reader["Address"];
                row["Birthday"] = reader["Birthday"];
                row["Choice"] = reader["Choice"];
                row["Email"] = reader["Email"];
                row["Phone"] = reader["Phone"];
                row["DateAndTime"] = reader["DateAndTime"];
                dataTable.Rows.Add(row);
            }
            dataGridView1.DataSource = dataTable;



            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //returns to form 1
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //closes the app
            Application.Exit();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //closes the app
            Application.Exit();
        }
    }
}
