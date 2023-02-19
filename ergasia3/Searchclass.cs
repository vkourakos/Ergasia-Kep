using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ergasia3
{
    class Searchclass
    {
        //initializing the sqlite connection
        SQLiteConnection connection;
        public DataTable Search(string choice, string name, string surname)
        {
            //connects to the database, finds all the data with the choice, name and surname that was given , puts them in a datatable and then returns that datatable 
            connection = new SQLiteConnection("Data Source=Aithseis.db;Version=3;");
            connection.Open();

            SQLiteDataReader reader;
            SQLiteCommand command;
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM aithseis WHERE Choice = @ch AND Name = @nm AND Surname = @srnm";
            command.Parameters.AddWithValue("@ch", choice);
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
            return dataTable;
        }
    }
}
