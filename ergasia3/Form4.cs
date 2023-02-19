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
    public partial class Form4 : Form
    {
        //initializing the sqlite connection and id variable
        SQLiteConnection connection;
        int id;
        public Form4(int i)
        {
            //passing the value to the id variable
            InitializeComponent();
            id = i;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

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
            string birthday = txtBirhDay.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string choice = comboBox1.Text;
            string dateAndTime = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss");

            //connects to the database, updates the field with the id that was given.(if id doesnt exists the database remains the same)
            connection = new SQLiteConnection("Data Source = Aithseis.db; Version = 3;");
            connection.Open();
            SQLiteCommand cmd = new SQLiteCommand("UPDATE aithseis set Address = @addr, Birthday = @brthd, Choice = @chc, Email = @eml, Phone = @phn, DateAndTime = @dat WHERE ID = @id", connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nm", name);
            cmd.Parameters.AddWithValue("@srnm", surname);
            cmd.Parameters.AddWithValue("@addr", address);
            cmd.Parameters.AddWithValue("@brthd", birthday);
            cmd.Parameters.AddWithValue("@chc", choice);
            cmd.Parameters.AddWithValue("@eml", email);
            cmd.Parameters.AddWithValue("@phn", phone);
            cmd.Parameters.AddWithValue("@dat", dateAndTime);
            cmd.ExecuteNonQuery();
            connection.Close();
            System.Windows.Forms.MessageBox.Show("Επιτυχής αλλαγή στοιχείων. Θα επιστρέψετε στο αρχικο μενού ");
            Form1 form1 = new Form1();
            this.Hide();
            form1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
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
