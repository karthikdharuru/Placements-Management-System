using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Placements_Model.Models;
using System.Configuration;

namespace DataAccess_Layer.Dataaccess
{
    public class StudentDb
    {
        string connectionString = ConfigurationManager.ConnectionStrings["defaultDb"].ConnectionString;
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;

        //get the student details by student id
        public Student RetrieveStudent(int Id)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                Student student = new Student();
                string query = "SELECT * from student_base join login_details on student_base.Email=login_details.Email where student_base.StudentId=@StudentId";

                command = new MySqlCommand(query);

                command.Parameters.AddWithValue("@StudentId", Id);
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                //assign retreived data to student object
                if (reader.Read())
                {
                    student.StudentId = int.Parse(reader["StudentId"].ToString());
                    student.StudentPassword = reader["Password"].ToString();
                    student.StudentName = reader["StudentName"].ToString();
                    student.DoB = DateTime.Parse(reader["Dob"].ToString());
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Backlogs = int.Parse(reader["BackLogs"].ToString());
                    student.Branch = reader["Branch"].ToString();
                    student.Address = reader["Address"].ToString();
                    student.Cgpa = float.Parse(reader["Cgpa"].ToString());
                    student.Percentage = float.Parse(reader["Percentage"].ToString());
                    if (int.Parse(reader["IsFeespaid"].ToString()) == 1)
                    {
                        student.IsFessPaid = true;
                    }
                    student.IsPlaced = false;
                    if (int.Parse(reader["IsPlaced"].ToString()) == 1)
                    {
                        student.IsPlaced = true;
                    }

                    if (student.IsPlaced == true)
                    {
                        student = RetrievePlacedDetails(student.StudentId, student);
                    }


                    return student;
                }
                else
                {
                    return (Student)null;
                }
            }
            catch
            {
                return (Student)null;

            }
            finally
            {
                connection.Close();
            }


        }
        public Student RetrieveStudent(string StudentEmail)
        {

            try
            {
                connection = new MySqlConnection(connectionString);


                Student student = new Student();
                string query = "SELECT * from student_base join login_details on student_base.Email=login_details.Email where student_base.Email=@StudentEmail";
                command = new MySqlCommand(query);

                command.Parameters.AddWithValue("@StudentEmail", StudentEmail);
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                //assign retreived data to student object
                if (reader.Read())
                {
                    student.StudentId = int.Parse(reader["StudentId"].ToString());
                    student.StudentPassword = reader["Password"].ToString();
                    student.StudentName = reader["StudentName"].ToString();
                    student.DoB = DateTime.Parse(reader["Dob"].ToString());
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Backlogs = int.Parse(reader["BackLogs"].ToString());
                    student.Branch = reader["Branch"].ToString();
                    student.Address = reader["Address"].ToString();
                    student.Cgpa = float.Parse(reader["Cgpa"].ToString());
                    student.Percentage = float.Parse(reader["Percentage"].ToString());
                    if (int.Parse(reader["IsFeespaid"].ToString()) == 1)
                    {
                        student.IsFessPaid = true;
                    }
                    student.IsPlaced = false;
                    if (int.Parse(reader["IsPlaced"].ToString()) == 1)
                    {
                        student.IsPlaced = true;
                    }

                    if (student.IsPlaced == true)
                    {
                        student = RetrievePlacedDetails(student.StudentId, student);
                    }


                    return student;
                }
                else
                {
                    return (Student)null;
                }
            }
            catch
            {
                return (Student)null;
            }
            finally
            {
                connection.Close();
            }
        }
        // retrieve details of company and package
        public Student RetrievePlacedDetails(int Id, Student student)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                string company_query = "SELECT Package,CompanyName from placed_details  where StudentId=@StudentId ";
                command = new MySqlCommand(company_query);

                command.Parameters.AddWithValue("@StudentId", Id);
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    student.Package = int.Parse(reader["Package"].ToString());
                    student.Company = reader["CompanyName"].ToString();
                    return student;
                }
                return (Student)null;

            }
            catch
            {
                return (Student)null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}


