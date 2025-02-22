using MySql.Data.MySqlClient;
using Placements_Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Dataaccess
{
    public class LoginDb
    {
        string connectionString = ConfigurationManager.ConnectionStrings["defaultDb"].ConnectionString;
        MySqlConnection connection;
        MySqlDataReader reader;
        MySqlCommand command;

        //checks whether the  credintials provided are valid or not
        public string IsLoginValid(Login login)
        {
            try
            {
                //establishing connection
                connection = new MySqlConnection(connectionString);
                string query = "SELECT  Password,role from login_details where Email=@LoginEmail";
                command = new MySqlCommand(query);
                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@LoginEmail", login.Email);
                //getting the data
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    if (reader["Password"].ToString() == login.Password)
                    {

                        return reader["role"].ToString();
                    }
                    else
                    {

                        return "notValid";
                    }
                }
                else
                {

                    return "notValid";
                }
            }
            catch
            {
                return "notValid";
            }
            finally
            {
                connection.Close();
            }


        }
    }
}
