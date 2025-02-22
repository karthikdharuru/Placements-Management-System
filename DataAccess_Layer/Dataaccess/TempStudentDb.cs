using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Placements_Model.Models;
using System.Configuration;

namespace DataAccess_Layer.Dataaccess
{
    public class TempStudentDb
    {

        string connectionString = ConfigurationManager.ConnectionStrings["defaultDb"].ConnectionString;
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;
        //student who are requested for registration are retrieved
        public List<Student> YettORegister()
        {
            try
            {
                List<Student> students = new List<Student>();

                //establishing connection
                connection = new MySqlConnection(connectionString);
                string query = "SELECT * from tmp_student";
                command = new MySqlCommand(query);

                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();

                //if student details are reded add it to list
                while (reader.Read())

                {
                    Student student = new Student();
                    student.StudentId = int.Parse(reader["StudentId"].ToString());
                    student.StudentPassword = reader["StudentPassword"].ToString();
                    student.StudentName = reader["StudentName"].ToString();
                    student.DoB = DateTime.Parse(reader["Dob"].ToString());
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Branch = reader["Branch"].ToString();
                    student.Address = reader["Address"].ToString();
                    student.Backlogs = int.Parse(reader["BackLogs"].ToString());
                    student.Cgpa = float.Parse(reader["Cgpa"].ToString());
                    student.Percentage = float.Parse(reader["Percentage"].ToString());
                    student.IsFessPaid = false;
                    if (int.Parse(reader["IsFeespaid"].ToString()) == 1)
                    {
                        student.IsFessPaid = true;
                    }
                    student.IsPlaced = false;
                    if (int.Parse(reader["IsPlaced"].ToString()) == 1)
                    {
                        student.IsPlaced = true;
                    }
                    student.Package = int.Parse(reader["Package"].ToString());
                    student.Company = reader["Company"].ToString();
                    students.Add(student);
                }


                return students;
            }
            catch
            {
                return new List<Student>();
            }
            finally
            {
                connection.Close();
            }
        }

        //insert student deatails in temp_student
        public bool RegisterStudent(Student student)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                string query = "Insert into tmp_student Values(@StudentId,@StudentPassword,@StudentName ,@DoB,@Email,@Mobile,@Address,@Branch,@Cgpa,@Percentage,@Backlogs,@IsFeesPaid ,@IsPlaced ,@Package,@Company )";
                command = new MySqlCommand(query);
                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentId", student.StudentId);
                command.Parameters.AddWithValue("@StudentPassword", student.StudentPassword);
                command.Parameters.AddWithValue("@StudentName", student.StudentName);
                command.Parameters.AddWithValue("@DoB", student.DoB);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Mobile", student.Mobile);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@Branch", student.Branch);
                command.Parameters.AddWithValue("@Cgpa", student.Cgpa);
                command.Parameters.AddWithValue("@Percentage", student.Percentage);
                command.Parameters.AddWithValue("@Backlogs", student.Backlogs);
                command.Parameters.AddWithValue("@IsFeesPaid", student.IsFessPaid);
                command.Parameters.AddWithValue("@IsPlaced", student.IsPlaced);
                command.Parameters.AddWithValue("@Package", student.Package);
                command.Parameters.AddWithValue("@Company", student.Company);
                int Isregistered = command.ExecuteNonQuery();
                connection.Close();
                return Isregistered > 0;
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

        //get the student details by student Email
        public Student RetrieveStudent(string Email)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                Student student = new Student();
                string query = "SELECT * from tmp_student where Email=@StudentEmail";
                command = new MySqlCommand(query);
                command.Parameters.AddWithValue("@StudentEmail", Email);
                command.Connection = connection;
                connection.Open();
                reader = command.ExecuteReader();
                //assign student deatilsto student object
                if (reader.Read())
                {
                    student.StudentId = int.Parse(reader["StudentId"].ToString());
                    student.StudentPassword = reader["StudentPassword"].ToString();
                    student.StudentName = reader["StudentName"].ToString();
                    student.DoB = DateTime.Parse(reader["Dob"].ToString());
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Branch = reader["Branch"].ToString();
                    student.Address = reader["Address"].ToString();
                    student.Backlogs = int.Parse(reader["BackLogs"].ToString());
                    student.Cgpa = float.Parse(reader["Cgpa"].ToString());
                    student.Percentage = float.Parse(reader["Percentage"].ToString());
                    student.IsFessPaid = false;
                    if (int.Parse(reader["IsFeespaid"].ToString()) == 1)
                    {
                        student.IsFessPaid = true;
                    }
                    student.IsPlaced = false;
                    if (int.Parse(reader["IsPlaced"].ToString()) == 1)
                    {
                        student.IsPlaced = true;
                    }
                    student.Package = int.Parse(reader["Package"].ToString());
                    student.Company = reader["Company"].ToString();
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


        //delete the student details
        public bool DeleteStudent(string Email)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                Student student = new Student();
                string query = "delete from tmp_student where Email=@StudentEmail";
                command = new MySqlCommand(query);
                command.Parameters.AddWithValue("@StudentEmail", Email);
                command.Connection = connection;
                connection.Open();
                int Isdeleted = command.ExecuteNonQuery();
                connection.Close();
                return Isdeleted > 0;
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

    }
}
