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
    public partial class Form2 : Form
    {
        //initializing the sqlite connection and other variables
        string name;
        string surname;
        SQLiteConnection connection;
        
        public Form2(string nm, string srnm)
        {
            //pass the values to the variables
            InitializeComponent();
            name = nm;
            surname = srnm;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //connects to the database, reads all the data with the name and surname that was given , puts them in a datatable and then gives that datatable as a data source for the dataGridView
            connection = new SQLiteConnection("Data Source=Aithseis.db;Version=3;");
            connection.Open();

            SQLiteDataReader reader;
            SQLiteCommand command;
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM aithseis WHERE Name = @nm AND Surname = @srnm";
            command.Parameters.AddWithValue("@nm", name);
            command.Parameters.AddWithValue("@srnm", surname);
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

        private void button3_Click(object sender, EventArgs e)
        {
            //closes the app
            Application.Exit();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //closes the app
            Application.Exit();
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
            label1.Show();
            textBox1.Show();
            button6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Show();
            textBox1.Show();
            button7.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label2.Show();
            comboBox1.Show();
            button8.Show();
            button9.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {


            //checks if all the fields are filled. Then it goes to form 4.
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις εγκυρο id ");
                textBox1.Focus();
                return;
            }
            Form4 form4 = new Form4(Int32.Parse(textBox1.Text));
            this.Hide();
            form4.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //checks if all the fields are filled. Then it creates an object of the delclass and calls the delete funcion that returns a datatable. Finaly it gives that datatable as a datasource to the datagridview
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις εγκυρο id ");
                textBox1.Focus();
                return;
            }           
            Delclass delclass = new Delclass();
            DataTable dataTable = delclass.Delete(textBox1.Text, name, surname);
            dataGridView1.DataSource = dataTable;
            textBox1.Clear();
            textBox1.Hide();
            label1.Hide();
            button7.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //checks if all the fields are filled. Then it creates an object of the searchclass and calls the search funcion that returns a datatable. Finaly it gives that datatable as a datasource to the datagridview
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να επιλέξεις αίτημα");
                comboBox1.Focus();
                return;
            }
            
            Searchclass searchclass = new Searchclass();
            DataTable dataTable = searchclass.Search(comboBox1.Text, name, surname);
            dataGridView1.DataSource = dataTable;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //connects to the database, reads all the data with the name and surname that was given , puts them in a datatable and then gives that datatable as a data source for the dataGridView
            connection = new SQLiteConnection("Data Source=Aithseis.db;Version=3;");
            connection.Open();

            SQLiteDataReader reader;
            SQLiteCommand command;
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM aithseis WHERE Name = @nm AND Surname = @srnm";
            command.Parameters.AddWithValue("@nm", name);
            command.Parameters.AddWithValue("@srnm", surname);
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
    }
}
