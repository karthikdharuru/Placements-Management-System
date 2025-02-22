using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Placements
{
    public class RoleManager : RoleProvider
    {
        string connectionString = @"server=localhost;userid=root;password=root123;database=mxradon_Placements";

        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;
        string query;
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        //assign roles to the user name
        public override string[] GetRolesForUser(string EmailAddress)
        {
            List<string> roles = new List<string>();
            try
            {
                connection = new MySqlConnection(connectionString);

                // if user  name is student assign student role


                query = "SELECT role from login_details where Email=@Email";
                command = new MySqlCommand(query);
                command.Connection = connection;
                command.Parameters.AddWithValue("@Email", EmailAddress);
                connection.Open();
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    roles.Add(reader["role"].ToString());

                }


            }
            finally
            {
                connection.Close();
            }
    

            //return roles
            return roles.ToArray();
        
            
        
            
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        //check whether particular user is in the role or not
        public override bool IsUserInRole(string Email, string roleName)
        {
            try
            {



                connection = new MySqlConnection(connectionString);


                query = "SELECT role from login_details where Email=@EmailAddress";
                command = new MySqlCommand(query);

                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@EmailAddress", Email);
                MySqlDataReader sdr = command.ExecuteReader();
                {
                    if (sdr.Read())
                    {
                        if(roleName==sdr["role"].ToString())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }


        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}