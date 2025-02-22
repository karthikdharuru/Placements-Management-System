using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace Placements.Models
{
    public class AdminDb
    {
        public bool IsAdmin(AdminLogin admin)
        {
            string cs = @"server=localhost;userid=root;password=root123;database=Placements";

            using (MySqlConnection con = new MySqlConnection(cs))
            {


                string query = "SELECT * from Admin where AdminId=@AdminId";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@AdminId", admin.AdminId);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            if (sdr["AdminId"].ToString() == admin.AdminId && sdr["AdminPassword"].ToString() == admin.AdminPassword)
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

        public void AddStudent(Student student)
        {
            string cs = @"server=localhost;userid=root;password=root123;database=Placements";

            using (MySqlConnection con = new MySqlConnection(cs))
            {


                string query = "insert into student Values(@StudentId,@StudentName,@Email,@Mobile,@Address,@Branch,@Cgpa,@Percentage,@Backlogs,@IsPlaced,@Package)";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                    cmd.Parameters.AddWithValue("@Address", student.Address);
                    cmd.Parameters.AddWithValue("@Branch", student.Branch);
                    cmd.Parameters.AddWithValue("@Cgpa", student.Cgpa);
                    cmd.Parameters.AddWithValue("@Percentage", student.Percentage);
                    cmd.Parameters.AddWithValue("@Backlogs", student.Backlogs);
                    cmd.Parameters.AddWithValue("@IsPlaced", student.IsPlaced);
                    cmd.Parameters.AddWithValue("@Package", student.Package);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                string query1 = "insert into studentlogin Values(@StudentId,@StudentPassword)";
                using (MySqlCommand cmd = new MySqlCommand(query1))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.Parameters.AddWithValue("@StudentPassword", student.StudentPassword);
                   
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
           }

    }
}