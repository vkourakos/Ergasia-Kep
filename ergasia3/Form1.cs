using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ergasia3
{
    public partial class Form1 : Form
    {
        //initializing the sqlite connection
        SQLiteConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //checks if the database file exists. If it doesnt it creates it and the table inside it. In both cases it creates the connection
            if (File.Exists("Aithseis.db"))
            {
                connection = new SQLiteConnection("Data Source=Aithseis.db;Version=3;");
            }
            else
            {

                SQLiteConnection.CreateFile("Aithseis.db");
                connection = new SQLiteConnection("Data Source=Aithseis.db;Version=3;");
                connection.Open();
                string sql = "create table aithseis (ID integer primary key autoincrement, Name char, Surname char, Address char, Birthday char, Phone char, Email char, Choice char, DateAndTime char)";
                SQLiteCommand command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checks if all the fields are filled. 
            if (String.IsNullOrEmpty(txtName.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις όνομα ");
                txtName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtSurname.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις επώνυμο");
                txtSurname.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtAddress.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις διεύθυνση");
                txtAddress.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtBirhDay.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις Ημερομηνία Γέννησης");
                txtBirhDay.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις Email");
                txtEmail.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtPhone.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις αριθμό τηλεφώνου");
                txtPhone.Focus();
                return;
            }
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να επιλέξεις αίτημα");
                comboBox1.Focus();
                return;
            }
            //Then it saves all the values to variables
            string name = txtName.Text;
            string surname = txtSurname.Text;
            string address = txtAddress.Text;
            string birthday =txtBirhDay.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string choice = comboBox1.Text;
            string dateAndTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");
            //finally it inserts them into the database and it clears all the fileds
            connection.Open();
            SQLiteCommand cmd = new SQLiteCommand("INSERT INTO aithseis(Name, Surname, Address, Birthday, Phone, Email, Choice, DateAndTime) VALUES(@nm, @srnm, @addr, @brthd, @phn, @eml, @chc, @dat)", connection);
            cmd.Parameters.Add(new SQLiteParameter("@nm", name));
            cmd.Parameters.Add(new SQLiteParameter("@srnm", surname));
            cmd.Parameters.Add(new SQLiteParameter("@addr", address));
            cmd.Parameters.Add(new SQLiteParameter("@brthd", birthday));
            cmd.Parameters.Add(new SQLiteParameter("@phn", phone));
            cmd.Parameters.Add(new SQLiteParameter("@eml", email));
            cmd.Parameters.Add(new SQLiteParameter("@chc", choice));
            cmd.Parameters.Add(new SQLiteParameter("@dat", dateAndTime));
            cmd.ExecuteNonQuery();
            connection.Close();
            System.Windows.Forms.MessageBox.Show("Επιτυχής υποβολή αίτησης!");
            txtName.Clear();
            txtSurname.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            comboBox1.Text = null;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //checks if all the fields are filled.
            if (String.IsNullOrEmpty(txtName.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις όνομα ");
                txtName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(txtSurname.Text))
            {
                System.Windows.Forms.MessageBox.Show("Πρέπει να εισάγεις επώνυμο");
                txtSurname.Focus();
                return;
            }
            //Then it saves all the values to variables and goes to form 2
            string name = txtName.Text;
            string surname = txtSurname.Text;
            Form2 form2 = new Form2(name, surname);
            this.Hide();
            form2.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //goes to form 3
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //closes the app
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //closes the app
            Application.Exit();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //limits the user to input only numbers, backspace and delete
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //limits the user to input only letters
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
              


        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            //limits the user to input only letters
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
