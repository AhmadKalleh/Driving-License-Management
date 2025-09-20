using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Input;



namespace DVLD_Data_Access
{
    public class clsPersonData
    {

        private static string folderPath = @"C:\DVLD-People-Images";
        public static bool GetPersonInfoByID(int id,ref string first_name, ref string second_name, ref string third_name, ref string last_name,
            ref string email, ref string phone, ref string address, ref DateTime date_of_birht,
            ref string image_path, ref string national_number, ref byte gendor,ref int country_id
            )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    first_name = (string)reader["FirstName"];

                    second_name = (string)reader["SecondName"];

                    country_id = (int)reader["NationalityCountryID"];

                    if(reader["ThirdName"] != DBNull.Value)
                    {
                        third_name = (string)reader["ThirdName"];
                    }
                    else
                    {
                        third_name = "";
                    }

                    last_name = (string)reader["LastName"];

                    if(reader["Email"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    else
                    {
                        email = "";
                    }

                    national_number = (string)reader["NationalNo"];
                    
                    phone = (string)reader["Phone"];

                    address= (string)reader["Address"];

                    date_of_birht = (DateTime)reader["DateOfBirth"];

                    gendor = (byte)reader["Gendor"];
                  
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        image_path = (string)reader["ImagePath"];
                    }
                    else
                    {
                        image_path = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        
        public static bool GetPersonInfoByNationalNumber(string national_number, ref string first_name, ref string second_name, ref string third_name, ref string last_name,
            ref string email, ref string phone, ref string address, ref DateTime date_of_birht,
            ref string image_path, ref byte gendor,ref int id, ref int country_id
            )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", national_number);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    id = (int)reader["PersonID"];

                    first_name = (string)reader["FirstName"];

                    second_name = (string)reader["SecondName"];

                    country_id = (int)reader["NationalityCountryID"];

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        third_name = (string)reader["ThirdName"];
                    }
                    else
                    {
                        third_name = "";
                    }

                    last_name = (string)reader["LastName"];

                    if (reader["Email"] != DBNull.Value)
                    {
                        email = (string)reader["Email"];
                    }
                    else
                    {
                        email = "";
                    }

                    phone = (string)reader["Phone"];

                    address = (string)reader["Address"];

                    date_of_birht = (DateTime)reader["DateOfBirth"];



                    gendor = (byte)reader["Gendor"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        image_path = (string)reader["ImagePath"];
                    }
                    else
                    {
                        image_path = "";
                    }

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewPerson(string national_number,string first_name,  string second_name,  string third_name, string last_name,
             string email,  string phone,  string address,  DateTime date_of_birht,
             int country_id,  string image_path,  byte gendor
            )
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (FirstName,SecondName, ThirdName,LastName, Email,NationalNo, Phone, Address,DateOfBirth,Gendor,NationalityCountryID,ImagePath)
                             VALUES (@FirstName,@SecondName,@ThirdName, @LastName, @Email,@NationalNo, @Phone, @Address,@DateOfBirth,@Gendor,@NationalityCountryID,@ImagePath);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", first_name);
            command.Parameters.AddWithValue("@SecondName", second_name);

            command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(third_name) ? (object)DBNull.Value : third_name);


            command.Parameters.AddWithValue("@LastName", last_name);
            command.Parameters.AddWithValue("@NationalNo", national_number);
            command.Parameters.AddWithValue("@Gendor", gendor);

            command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);


            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@DateOfBirth", date_of_birht);
            command.Parameters.AddWithValue("@NationalityCountryID",country_id );

            if (image_path != "" && image_path != null)
            {
                string extension = Path.GetExtension(image_path);
                string fileName = $"{Guid.NewGuid()}{extension}";
                string fullPath = Path.Combine(folderPath, fileName);
                File.Copy(image_path, fullPath);
                command.Parameters.AddWithValue("@ImagePath", fullPath);
            }
                
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return PersonID;
        }


        private static string GetOldImageFileName(int id)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT ImagePath FROM People WHERE PersonID = @id";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@id", id);

            string old_image_file_name = "";
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    old_image_file_name = result.ToString();
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return "";
            }

            finally
            {
                connection.Close();
            }

            return old_image_file_name;
        }

        public static bool UpdatePerson(int id,string national_number, string first_name, string second_name, string third_name, string last_name,
             string email, string phone, string address, DateTime date_of_birht,
             int country_id, string image_path, byte gendor)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  People  
                            set FirstName = @FirstName,
                                SecondName = @SecondName,
                                ThirdName = @ThirdName,
                                Gendor=@Gendor,            
                                LastName = @LastName, 
                                Email = @Email, 
                                Phone = @Phone, 
                                Address = @Address, 
                                DateOfBirth = @DateOfBirth,
                                NationalNo = @NationalNo,
                                NationalityCountryID = @NationalityCountryID,
                                ImagePath =@ImagePath
                                where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", id);

            command.Parameters.AddWithValue("@FirstName", first_name);
            command.Parameters.AddWithValue("@SecondName", second_name);
            command.Parameters.AddWithValue("@ThirdName", string.IsNullOrEmpty(third_name)? (object)DBNull.Value : third_name);
           
            command.Parameters.AddWithValue("@LastName", last_name);
            command.Parameters.AddWithValue("@NationalNo", national_number);
            command.Parameters.AddWithValue("@Gendor", gendor);
            command.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
            

            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@DateOfBirth", date_of_birht);
            command.Parameters.AddWithValue("@NationalityCountryID", country_id);

            string oldImageFileName = GetOldImageFileName(id);
            
            if(!oldImageFileName.Equals(image_path))
            {
                if (!string.IsNullOrEmpty(oldImageFileName))
                {
                    try
                    {
                        if (File.Exists(oldImageFileName))
                        {
                            File.Delete(oldImageFileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        // سجل الخطأ أو تجاهله حسب الحاجة
                        Console.WriteLine("Couldn't delete old image: " + ex.Message);
                    }
                }

                if (image_path != "" && image_path != null)
                {

                    string extension = Path.GetExtension(image_path);
                    string fileName = $"{Guid.NewGuid()}{extension}";
                    string fullPath = Path.Combine(folderPath, fileName);
                    File.Copy(image_path, fullPath);
                    command.Parameters.AddWithValue("@ImagePath", fullPath);
                }

                else
                    command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            }
            else

            {
                command.Parameters.AddWithValue("@ImagePath", image_path);
            }



            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }


        public static bool DeletePerson(int id)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete People 
                                WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", id);

            string oldImageFileName = GetOldImageFileName(id);
            if (!string.IsNullOrEmpty(oldImageFileName))
            {
                try
                {
                    if (File.Exists(oldImageFileName))
                    {
                        File.Delete(oldImageFileName);
                    }
                }
                catch (Exception ex)
                {
                    // سجل الخطأ أو تجاهله حسب الحاجة
                    Console.WriteLine("Couldn't delete old image: " + ex.Message);
                }
            }

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                
                Console.WriteLine("SQL Error: " + ex.Message);
                return false;
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsPersonExist(int id)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsPersonExist(string national_number)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM People WHERE NationalNo = @NationalNo";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", national_number);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllPersons()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Countries.CountryName,People.* FROM People 
                           INNER JOIN Countries ON Countries.CountryID = People.NationalityCountryID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static DataTable filter(string query,object filterValue)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string paramName = Regex.Match(query, @"@([a-zA-Z]+)").Groups[1].Value;
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@" + paramName, filterValue);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int Count()
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT COUNT(PersonID) as TotalPeople FROM People ";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(),out int total))
                {
                    count = total; 
                }
                
            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return count;
        }

    }
}
