using System;
using System.Collections.Generic;
using System.Data.CData.MariaDB;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CData;

namespace ListFootball
{

    public class ConnectionDB
    {
        private MariaDBConnection connection;
        
        public ConnectionDB()
        {
            InitConnexion();
        }

        private void InitConnexion()
        {
            // connection string creation : contact the DB server
            string connectionString = "SERVER=127.0.0.1; DATABASE=foot; UID=admin_foot; PASSWORD=Pa$$w0rd";
            connection = new MariaDBConnection(connectionString);
        }

        public void AddPlayer(Player player)
        {
            try
            {
                connection.Open();

                MariaDBCommand command = connection.CreateCommand();


                command.CommandText = "INSERT INTO players (firstName, lastName, phoneNumber) VALUES (@firstName, @lastName, @phoneNumber)";


                command.Parameters.AddWithValue("@firstName", player.FirstName);
                command.Parameters.AddWithValue("@lastName", player.LastName);
                command.Parameters.AddWithValue("@phoneNumber", player.PhoneNumber);


                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
