using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DVLD_Data_Access
{
    public class clsInternationalLicenseData
    {
        public static DataTable GetAllInternationalLicensesByDriverID(int driver_id)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalLicenses IL WHERE DriverID = @DriverID  ORDER BY IL.IssueDate DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", driver_id);


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

        public static bool GetInternationalLicenseInfoByID(int int_license_id, ref int application_id, ref int driver_id,ref int issued_using_local_license_id,
            
            ref DateTime issue_date, ref DateTime expiration_date, ref bool is_active, ref int created_by_user_id)


        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                            FROM InternationalLicenses
                            WHERE InternationalLicenseID = @InternationalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@InternationalLicenseID", int_license_id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    issued_using_local_license_id = (int)reader["IssuedUsingLocalLicenseID"];
                    application_id = (int)reader["ApplicationID"];
                    created_by_user_id = (int)reader["CreatedByUserID"];
                    issue_date = (DateTime)reader["IssueDate"];
                    expiration_date = (DateTime)reader["ExpirationDate"];                   
                    is_active = (bool)reader["IsActive"];
                
                    driver_id = (int)reader["DriverID"];



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

        public static DataTable filter(string query, object filterValue)
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

        public static DataTable GetAllInternationalLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM InternationalLicenses IL  ORDER BY IL.IssueDate DESC";

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

        public static bool IsInternationalLicensesAvailable(int driver_id, int licsnese_id)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM InternationalLicenses WHERE DriverID = @DriverID AND IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@DriverID", driver_id);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", licsnese_id);

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

        public static int AddNewInternational(int application_id,int driver_id, int issued_using_local_license_id,
            DateTime issue_date, DateTime expiration_date, bool is_active, int created_by_user_id)

        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO InternationalLicenses (ApplicationID, DriverID,IssuedUsingLocalLicenseID,IssueDate,ExpirationDate,IsActive,CreatedByUserID)
                             VALUES (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,@IsActive,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", application_id);
            command.Parameters.AddWithValue("@DriverID", driver_id);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issued_using_local_license_id);
            command.Parameters.AddWithValue("@IssueDate", issue_date);
            command.Parameters.AddWithValue("@ExpirationDate", expiration_date);
            command.Parameters.AddWithValue("@IsActive", is_active ? 1 : 0);
            command.Parameters.AddWithValue("@CreatedByUserID", created_by_user_id);


           

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseID = insertedID;
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


            return LicenseID;
        }

    }
}
