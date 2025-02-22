using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using Placements_Model.Models;

namespace DataAccess_Layer.Dataaccess
{
    // all admin database operations

    public class AdminDb
    {
        string connectionString = ConfigurationManager.ConnectionStrings["defaultDb"].ConnectionString;
        MySqlConnection connection;
        MySqlDataReader reader;
        MySqlCommand command;

        // insert student details into appropriate tables
        public bool AddStudent(Student student)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                string query = "insert into student_base Values(@StudentId,@StudentName,@Dob,@Email,@Mobile,@Address,@Branch,@Cgpa,@Percentage,@Backlogs,@IsFeesPaid,@IsPlaced)";
                command = new MySqlCommand(query);
                command.Connection = connection;

                command.Parameters.AddWithValue("@StudentId", student.StudentId);
                command.Parameters.AddWithValue("@StudentName", student.StudentName);
                command.Parameters.AddWithValue("@Dob", student.DoB);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Mobile", student.Mobile);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@Branch", student.Branch);
                command.Parameters.AddWithValue("@Cgpa", student.Cgpa);
                command.Parameters.AddWithValue("@Percentage", student.Percentage);
                command.Parameters.AddWithValue("@Backlogs", student.Backlogs);
                command.Parameters.AddWithValue("@IsFeesPaid", student.IsFessPaid);
                command.Parameters.AddWithValue("@IsPlaced", student.IsPlaced);

                connection.Open();
                int Isinserted = command.ExecuteNonQuery();

                AddStudentLogin(student);

                //if student is placed placed,details will be placed in package and company table
                if (student.IsPlaced == true)
                {

                    AddStudentPlacedDetails(student.StudentId, student.Company, student.Package);
                    //AddStudentPackage(student.StudentId, student.Package);

                }
                return Isinserted > 0;
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
        //add student login credentials
        public bool AddStudentLogin(Student student)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                string login_query = "insert into login_details Values(@StudentEmail,@StudentPassword,@role)";
                command = new MySqlCommand(login_query);

                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentEmail", student.Email);
                command.Parameters.AddWithValue("@StudentPassword", student.StudentPassword);
                command.Parameters.AddWithValue("@role", "Student");
                int Isadded = command.ExecuteNonQuery();

                return Isadded > 0;
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
        //add student comapny details
        public bool AddStudentPlacedDetails(int StudentId, string Company, int package)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                string company_query = "insert into placed_details(StudentId,CompanyName,Package) Values(@StudentId,@Company,@Package)";
                command = new MySqlCommand(company_query);

                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentId", StudentId);
                command.Parameters.AddWithValue("@Company", Company);
                command.Parameters.AddWithValue("@Package", package);

                int Isadded = command.ExecuteNonQuery();

                return Isadded > 0;
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
        ////add student package details
        //public bool AddStudentPackage(int StudentId, int package)
        //{
        //    try
        //    {
        //         connection = new MySqlConnection(connectionString);
        //        string package_query = "insert into package(StudentId,Package) Values(@StudentId,@Package)";
        //        command = new MySqlCommand(package_query);

        //        command.Connection = connection;
        //        connection.Open();
        //        command.Parameters.AddWithValue("@StudentId", StudentId);
        //        command.Parameters.AddWithValue("@Package", package);

        //        int Isadded = command.ExecuteNonQuery();


        //        return Isadded > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        //checks whether the exists or not
        public bool IsStudentExists(int StudentId)
        {
            try
            {

                //establishing connection
                connection = new MySqlConnection(connectionString);
                string query = "SELECT  Email from student_base where StudentId=@StudentId";
                command = new MySqlCommand(query);
                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentId", StudentId);
                //getting the data
                reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                else
                {

                    return false;
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
        //update the student details
        public bool UpdateStudent(Student student)
        {
            try
            {

                connection = new MySqlConnection(connectionString);
                string query = "update student_base set StudentName=@StudentName,Dob=@Dob,Email=@Email,Mobile=@Mobile,Address=@Address,Branch=@Branch,Cgpa=@Cgpa,Percentage=@Percentage,Backlogs=@Backlogs,IsFeesPaid=@IsFeesPaid,IsPlaced=@IsPlaced where StudentId=@StudentId";
                //student_base details
                MySqlCommand command = new MySqlCommand(query);

                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentId", student.StudentId);
                command.Parameters.AddWithValue("@StudentName", student.StudentName);
                command.Parameters.AddWithValue("@Dob", student.DoB);
                command.Parameters.AddWithValue("@Email", student.Email);
                command.Parameters.AddWithValue("@Mobile", student.Mobile);
                command.Parameters.AddWithValue("@Address", student.Address);
                command.Parameters.AddWithValue("@Branch", student.Branch);
                command.Parameters.AddWithValue("@Cgpa", student.Cgpa);
                command.Parameters.AddWithValue("@Percentage", student.Percentage);
                command.Parameters.AddWithValue("@Backlogs", student.Backlogs);
                command.Parameters.AddWithValue("@IsFeesPaid", student.IsFessPaid);
                command.Parameters.AddWithValue("@IsPlaced", student.IsPlaced);
                command.ExecuteNonQuery();
                connection.Close();


                //student_login
                UpdateStudentLogin(student.Email, student.StudentPassword);

                //if student is placed update placed details
                if (student.IsPlaced == true)
                {

                    //try inserting the student comapany details if student company details is already present update the company details
                    try
                    {
                        AddStudentPlacedDetails(student.StudentId, student.Company, student.Package);


                    }
                    //update comapany details
                    catch
                    {
                        connection.Close();
                        UpdateStudentPlacedDetails(student.StudentId, student.Company, student.Package);


                    }

                }
                //if student is unplaced remove the comapny details from database
                else
                {
                    string company_query = "select CompanyName from  placed_details where StudentId=@StudentId";

                    command = new MySqlCommand(company_query);

                    command.Connection = connection;
                    connection.Open();
                    command.Parameters.AddWithValue("@StudentId", student.StudentId);

                    reader = command.ExecuteReader();
                    //if company details already there remove company details
                    if (reader.Read())
                    {
                        connection.Close();
                        DeletePlacedDetails(student.StudentId);

                    }
                    connection.Close();
                    //string package_query = "select Package from package where StudentId=@StudentId";
                    //command = new MySqlCommand(package_query);

                    //command.Connection = connection;
                    //connection.Open();
                    //command.Parameters.AddWithValue("@StudentId", student.StudentId);

                    //reader = command.ExecuteReader();
                    ////if package details already there remove package details
                    //if (reader.Read())
                    //{

                    //    DeletePackage(student.StudentId);
                    //}


                }
                return true;
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
        //update student login details
        public bool UpdateStudentLogin(string Email, string password)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                string login_query = "update login_details set Password=@StudentPassword where Email=@StudentEmail";
                command = new MySqlCommand(login_query);

                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentEmail", Email);
                command.Parameters.AddWithValue("@StudentPassword", password);

                int Isupdated = command.ExecuteNonQuery();

                return Isupdated > 0;
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
        // update company details
        public bool UpdateStudentPlacedDetails(int StudentId, string company, int package)
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                string company_query = "update placed_details set CompanyName=@Company,Package=@Package where StudentId=@StudentId";
                command = new MySqlCommand(company_query);

                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentId", StudentId);
                command.Parameters.AddWithValue("@Company", company);
                command.Parameters.AddWithValue("@Package", package);

                int Isupdated = command.ExecuteNonQuery();

                return Isupdated > 0;
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
        //update package details
        //public bool UpdateStudentPackage(int StudentId, int package)
        //{
        //    try
        //    {

        //        connection = new MySqlConnection(connectionString);
        //        string package_query = "update Package set Package=@Package where StudentId=@StudentId";
        //        command = new MySqlCommand(package_query);

        //        command.Connection = connection;
        //        connection.Open();
        //        command.Parameters.AddWithValue("@StudentId", StudentId);
        //        command.Parameters.AddWithValue("@Package", package);

        //        int Isupdated = command.ExecuteNonQuery();

        //        return Isupdated > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}
        //delete student from database
        public bool DeleteStudent(Student student)
        {

            try
            {
                connection = new MySqlConnection(connectionString);



                string query = "delete from student_base  where StudentId=" + student.StudentId;
                string package_query = "delete from placed_details  where StudentId=" + student.StudentId;


                command = new MySqlCommand(query);

                command.Connection = connection;
                connection.Open();
                int Isdeleted = command.ExecuteNonQuery();
                if (student.IsPlaced == true)
                {

                    bool Isdeletedplaceddetails = DeletePlacedDetails(student.StudentId);
                    bool Islogindeleted = Deletelogin(student.Email);


                    return (Isdeleted > 0 && Isdeletedplaceddetails);
                }
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

        //delete company details
        public bool DeletePlacedDetails(int StudentId)
        {
            try
            {

                connection = new MySqlConnection(connectionString);
                string delete_query = "delete from placed_details where StudentId=@StudentId";
                command = new MySqlCommand(delete_query);

                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentId", StudentId);
                int Isdeleted = command.ExecuteNonQuery();
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
        //delete login details
        public bool Deletelogin(string StudentEmail)
        {
            try
            {

                connection = new MySqlConnection(connectionString);
                string delete_query = "delete from login_details where Email=@StudentEmail";
                command = new MySqlCommand(delete_query);

                command.Connection = connection;
                connection.Open();
                command.Parameters.AddWithValue("@StudentEmail", StudentEmail);
                int Isdeleted = command.ExecuteNonQuery();
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
        //delete package details

        //public bool DeletePackage(int StudentId)
        //{
        //    try
        //    {
        //        connection = new MySqlConnection(connectionString);
        //        string delete_query = "delete from package where StudentId=@StudentId";
        //        command = new MySqlCommand(delete_query);

        //        command.Connection = connection;
        //        connection.Open();
        //        command.Parameters.AddWithValue("@StudentId", StudentId);
        //        int Isdeleted = command.ExecuteNonQuery();
        //        return Isdeleted > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //}

        // return students who satisfies the given criteria
        public List<Student> FilterPercentage(string operation, float percentage)
        {
            try
            {
                List<Student> students = new List<Student>();
                connection = new MySqlConnection(connectionString);
                string query = "select * from mxradon_placements.student_base left join placed_details on student_base.StudentId=placed_details.StudentId where Percentage" + operation + percentage + " order by Percentage desc";
                command = new MySqlCommand(query);

                command.Connection = connection;
                connection.Open();

                reader = command.ExecuteReader();

                // add students to list 
                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentId = int.Parse(reader["StudentId"].ToString());

                    student.StudentName = reader["StudentName"].ToString();
                    student.DoB = DateTime.Parse(reader["Dob"].ToString());
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Branch = reader["Branch"].ToString();
                    student.Backlogs = int.Parse(reader["BackLogs"].ToString());
                    student.Address = reader["Address"].ToString();
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
                    if (student.IsPlaced == true)
                    {
                        student.Company = reader["CompanyName"].ToString();
                        student.Package = int.Parse(reader["Package"].ToString());
                    }
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

        // return students who satisfies the given criteria
        public List<Student> FilterCgpa(string operation, float cgpa)
        {
            try
            {
                List<Student> students = new List<Student>();

                connection = new MySqlConnection(connectionString);

                string query = "select * from mxradon_placements.student_base left join placed_details on student_base.StudentId=placed_details.StudentId where Cgpa" + operation + cgpa + " order by Cgpa desc";
                command = new MySqlCommand(query);

                command.Connection = connection;
                connection.Open();

                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentId = int.Parse(reader["StudentId"].ToString());

                    student.StudentName = reader["StudentName"].ToString();
                    student.DoB = DateTime.Parse(reader["Dob"].ToString());
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Branch = reader["Branch"].ToString();
                    student.Address = reader["Address"].ToString();
                    student.Cgpa = float.Parse(reader["Cgpa"].ToString());
                    student.Backlogs = int.Parse(reader["BackLogs"].ToString());
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
                    if (student.IsPlaced == true)
                    {
                        student.Company = reader["CompanyName"].ToString();
                        student.Package = int.Parse(reader["Package"].ToString());
                    }
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

        //filter students who are placed in the given company
        public List<Student> FilterCompany(string company)
        {
            try
            {
                List<Student> students = new List<Student>();

                connection = new MySqlConnection(connectionString);

                string query = "select * from mxradon_placements.student_base left join placed_details on student_base.StudentId=placed_details.StudentId where CompanyName=@company";
                command = new MySqlCommand(query);
                command.Parameters.AddWithValue("@company", company);
                command.Connection = connection;
                connection.Open();

                reader = command.ExecuteReader();

                //add all student details to list
                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentId = int.Parse(reader["StudentId"].ToString());

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
                    //convert from tinyint to bool
                    if (int.Parse(reader["IsPlaced"].ToString()) == 1)
                    {
                        student.IsPlaced = true;
                    }
                    if (student.IsPlaced == true)
                    {
                        student.Company = reader["CompanyName"].ToString();
                        student.Package = int.Parse(reader["Package"].ToString());
                    }
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
    }
}