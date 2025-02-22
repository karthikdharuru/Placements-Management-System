using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Placements
{
    public class RoleManager : RoleProvider
    {
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
        public override string[] GetRolesForUser(string username)
        {
            List<string> roles = new List<string>();
            string connectionString = @"server=localhost;userid=root;password=root123;database=mxradon_Placements";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                // if user  name is student assign student role
                try
                {


                    string query = "SELECT * from student_login where StudentId=" + int.Parse(username);
                    using (MySqlCommand command = new MySqlCommand(query))
                    {
                        command.Connection = connection;
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                roles.Add("Student");

                            }
                            //not student
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }
                   

                }

                // add admin role
                catch {
                    string query1 = "SELECT * from admin_login where AdminId=@AdminId";
                    using (MySqlCommand command = new MySqlCommand(query1))
                    {
                        command.Connection = connection;
                        connection.Open();
                        command.Parameters.AddWithValue("@AdminId", username);
                        using (MySqlDataReader reader1 = command.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                roles.Add("Admin");
                            }
                            else
                            {
                                roles.Add("Anonymous");
                            }
                        }
                    }

                }
            }
        //return roles
            return roles.ToArray();
            
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        //check whether particular user is in the role or not
        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                string cs = @"server=localhost;userid=root;password=root123;database=mxradon_Placements";


                using (MySqlConnection con = new MySqlConnection(cs))
                {
                    if (roleName == "Admin")
                    {
                        string query1 = "SELECT * from admin_login where AdminId=@AdminId";
                        using (MySqlCommand cmd = new MySqlCommand(query1))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@AdminId", username);
                            using (MySqlDataReader sdr1 = cmd.ExecuteReader())
                            {
                                if (sdr1.Read())
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }

                    }
                    else if (roleName == "Student")
                    {

                        string query = "SELECT * from student_login where StudentId=" + int.Parse(username);
                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {

                                if (sdr.Read())
                                {
                                    return true;

                                }
                                else
                                {
                                    return false;
                                }
                            }
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