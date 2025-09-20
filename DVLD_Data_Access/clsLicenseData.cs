using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsLicenseData
    {


        public static bool GetLicenseInfoByDriverLicenseClassID(int driver_id,int license_class_id, ref int license_id, ref int application_id, ref int created_by_user_id, 
            ref DateTime issue_date,ref DateTime expiration_date,ref string notes,ref decimal paid_fees,ref bool is_active,ref byte issue_reason)


        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = @"SELECT *
                            FROM Licenses
                            WHERE DriverID = @DriverID AND IsActive = 1 AND LicenseClass=@LicenseClass";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", driver_id);
            command.Parameters.AddWithValue("@LicenseClass", license_class_id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    license_id = (int)reader["LicenseID"];
                    application_id = (int)reader["ApplicationID"];
                    if (reader["Notes"] != DBNull.Value)
                    {
                        notes = (string)reader["Notes"];
                    }
                    else
                    {
                        notes = "No Notes";
                    }
                    created_by_user_id = (int)reader["CreatedByUserID"];
                    issue_date = (DateTime)reader["IssueDate"];
                    expiration_date = (DateTime)reader["ExpirationDate"];
                    paid_fees = (decimal)reader["PaidFees"];
                    is_active = (bool)reader["IsActive"];
                    issue_reason = (byte)reader["IssueReason"];


                    
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

        public static bool GetLicenseInfoByLicenseDriverID(int driver_id, int license_id, ref int license_class_id, ref int application_id, ref int created_by_user_id,
            ref DateTime issue_date, ref DateTime expiration_date, ref string notes, ref decimal paid_fees, ref bool is_active, ref byte issue_reason)


        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                            FROM Licenses
                            WHERE DriverID = @DriverID  AND LicenseID=@LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DriverID", driver_id);
            command.Parameters.AddWithValue("@LicenseID", license_id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    license_class_id = (int)reader["LicenseClass"];
                    application_id = (int)reader["ApplicationID"];
                    if (reader["Notes"] != DBNull.Value)
                    {
                        notes = (string)reader["Notes"];
                    }
                    else
                    {
                        notes = "No Notes";
                    }
                    created_by_user_id = (int)reader["CreatedByUserID"];
                    issue_date = (DateTime)reader["IssueDate"];
                    expiration_date = (DateTime)reader["ExpirationDate"];
                    paid_fees = (decimal)reader["PaidFees"];
                    is_active = (bool)reader["IsActive"];
                    issue_reason = (byte)reader["IssueReason"];



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

        public static bool GetLicenseInfoByLicenseID(int license_id,ref int driver_id, ref int license_class_id, ref int application_id, ref int created_by_user_id,
            ref DateTime issue_date, ref DateTime expiration_date, ref string notes, ref decimal paid_fees, ref bool is_active, ref byte issue_reason)


        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                            FROM Licenses
                            WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", license_id);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    license_class_id = (int)reader["LicenseClass"];
                    application_id = (int)reader["ApplicationID"];
                    if (reader["Notes"] != DBNull.Value)
                    {
                        notes = (string)reader["Notes"];
                    }
                    else
                    {
                        notes = "No Notes";
                    }
                    created_by_user_id = (int)reader["CreatedByUserID"];
                    issue_date = (DateTime)reader["IssueDate"];
                    expiration_date = (DateTime)reader["ExpirationDate"];
                    paid_fees = (decimal)reader["PaidFees"];
                    is_active = (bool)reader["IsActive"];
                    issue_reason = (byte)reader["IssueReason"];
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

        public static DataTable GetAllLocalLicensesByDriverID(int driver_id)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"
	                        SELECT L.LicenseID,L.ApplicationID,LC.ClassName,L.IssueDate,L.ExpirationDate,L.IsActive FROM Licenses L     
                            INNER JOIN LicenseClasses LC ON LC.LicenseClassID = L.LicenseClass
                            WHERE L.DriverID = @DriverID  ORDER BY L.IssueDate DESC";

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

        public static string IsDetainedLicense(int license_id)
        {
            string value = "";

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {
                string query = @"
            SELECT 
                CASE 
                    WHEN DL.LicenseID is NULL THEN 'No_Detained' 
		            WHEN DL.LicenseID IS NOT NULL AND DL.IsReleased = 0 THEN 'Detained_Not_Released'
		            WHEN DL.LicenseID IS NOT NULL AND DL.IsReleased = 1 THEN 'Detained_Released'
                END AS IsDetained
            FROM Licenses L
            LEFT JOIN DetainedLicenses DL 
                ON DL.LicenseID = L.LicenseID
            WHERE L.LicenseID = @LicenseID ORDER BY DL.DetainDate DESC";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LicenseID", license_id);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar(); // نقرأ القيمة مباشرة

                    if (result != null && result != DBNull.Value)
                    {
                        value = result.ToString();
                        
                    }
                }
                catch (Exception ex)
                {
                    // Log the error if needed
                    value = "";
                }
            }

            return value;
        }

        public static int AddNewLicense(int driver_id,int application_id,int license_class_id, int created_by_user_id, 
            DateTime issue_date,DateTime expiration_date,string notes,decimal paid_fees,bool is_active, byte issue_reason)

        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Licenses (ApplicationID, DriverID,LicenseClass,IssueDate,ExpirationDate,Notes,PaidFees,IsActive,IssueReason,CreatedByUserID)
                             VALUES (@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", application_id);
            command.Parameters.AddWithValue("@DriverID", driver_id);
            command.Parameters.AddWithValue("@LicenseClass", license_class_id);
            command.Parameters.AddWithValue("@IssueDate", issue_date);
            command.Parameters.AddWithValue("@ExpirationDate", expiration_date);

            if(notes != "")
            {
                command.Parameters.AddWithValue("@Notes", notes);
            }
            else
            {
                command.Parameters.AddWithValue("@Notes", DBNull.Value);
            }
            command.Parameters.AddWithValue("@PaidFees", paid_fees);
            command.Parameters.AddWithValue("@IsActive", is_active ? 1 : 0);
            command.Parameters.AddWithValue("@IssueReason", issue_reason);
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

        public static bool UpdateStatus( int license_id, bool is_active)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Licenses  
                            set IsActive = @IsActive                           
                                WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@IsActive", is_active);

            command.Parameters.AddWithValue("@LicenseID", license_id);





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

    }
}
