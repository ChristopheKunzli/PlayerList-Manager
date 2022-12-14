using System;
using System.Collections.Generic;
using System.Data;
using System.Data.CData.MariaDB;
using System.Data.Common;
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

        /// <summary>
        /// Method used to create a connection to the DataBase
        /// </summary>
        private void InitConnexion()
        {
            // connection string creation : contact the DB server
            string connectionString = "SERVER=127.0.0.1; DATABASE=foot; UID=admin_foot; PASSWORD=Pa$$w0rd";
            connection = new MariaDBConnection(connectionString);
        }

        /// <summary>
        /// Method useed to add a new player into the database
        /// </summary>
        /// <param name="player">The player to add</param>
        public void AddPlayer(Player player)
        {
            try
            {
                connection.Open();

                MariaDBCommand cmdAdd = connection.CreateCommand();

                cmdAdd.CommandText = "INSERT INTO players (firstName, lastName, phoneNumber) VALUES (@firstName, @lastName, @phoneNumber)";


                cmdAdd.Parameters.AddWithValue("@firstName", player.FirstName);
                cmdAdd.Parameters.AddWithValue("@lastName", player.LastName);
                cmdAdd.Parameters.AddWithValue("@phoneNumber", player.PhoneNumber);


                cmdAdd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Method used to remove a specific player from the DB
        /// </summary>
        /// <param name="player"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemovePlayer(Player player)
        {
            try
            {
                connection.Open();

                MariaDBCommand cmdDelete = connection.CreateCommand();

                cmdDelete.CommandText = "DELETE FROM players WHERE firstName = @firstName AND lastName = @lastName AND phoneNumber = @phoneNumber";

                cmdDelete.Parameters.AddWithValue("@firstName", player.FirstName);
                cmdDelete.Parameters.AddWithValue("@lastName", player.LastName);
                cmdDelete.Parameters.AddWithValue("@phoneNumber", player.PhoneNumber);

                cmdDelete.ExecuteNonQuery();

                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Method used to retrieve the entire player list stored in the DB
        /// </summary>
        public List<Player> GetPlayersList()
        {
            List<Player> list = new List<Player>();

            try
            {
                MariaDBCommand commandGet = connection.CreateCommand();

                commandGet.CommandText = "SELECT firstName, lastName, phoneNumber FROM players";

                MariaDBDataReader dataReader = commandGet.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(new Player(dataReader["firstName"].ToString(), dataReader["LastName"].ToString(), dataReader["phoneNumber"].ToString()));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return list;
        }
    }
}
