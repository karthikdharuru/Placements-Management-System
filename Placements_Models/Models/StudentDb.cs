using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace Placements_Models.Models
{
    public class StudentDb
    {
        public bool IsStudent(int id, string pass)
        {
            string cs = @"server=localhost;userid=root;password=root123;database=Placements";

            using (MySqlConnection con = new MySqlConnection(cs))
            {


                string query = "SELECT * from studentlogin where StudentId=" + id;
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            if (int.Parse(sdr["StudentId"].ToString()) == id && sdr["StudentPassword"].ToString() == pass)
                            {
                                con.Close();
                                return true;
                            }
                            else
                            {
                                con.Close();
                                return false;
                            }
                        }
                        else
                        {
                            con.Close();
                            return false;
                        }

                    }

                }
            }
        }
    }
}