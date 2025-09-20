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
    public class clsDetainLicenseData
    {

        public static bool GetDetainLicenseInfoByLicenseID(int license_id, ref int? released_by_user_id, ref int detain_id, ref int ? release_app_id, ref int created_by_user_id,
            ref DateTime detain_date, ref DateTime? release_date, ref decimal fine_fees, ref bool is_released)


        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 *
                            FROM DetainedLicenses
                            WHERE LicenseID = @LicenseID ORDER BY DetainDate DESC";

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

                    detain_id = (int)reader["DetainID"];
                    detain_date = (DateTime)reader["DetainDate"];
                    fine_fees = (decimal)reader["FineFees"];
                    created_by_user_id = (int)reader["CreatedByUserID"];                
                    is_released = (bool)reader["IsReleased"];
                    

                    if (reader["ReleaseDate"] != DBNull.Value)
                    {
                        release_date = (DateTime)reader["ReleaseDate"];
                    }
                    else
                    {
                        release_date = null;
                    }

                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                    {
                        release_app_id = (int)reader["ReleaseApplicationID"];
                    }
                    else
                    {
                        release_app_id = null;
                    }

                    if (reader["ReleasedByUserID"] != DBNull.Value)
                    {
                        released_by_user_id = (int)reader["ReleasedByUserID"];
                    }
                    else
                    {
                        released_by_user_id = null;
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

        public static DataTable GetAllDetainLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM vDetainedLicensesSummary  ORDER BY DetainDate DESC";

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

        public static int AddNewDetainLicense(int license_id, int created_by_user_id, int? released_by_user_id,
            int ? release_app_id, bool is_released, DateTime? release_date,DateTime detain_date,decimal fine_fees)

        {
            int DetainID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses (LicenseID,DetainDate, FineFees,IsReleased,CreatedByUserID,ReleaseDate,ReleasedByUserID,ReleaseApplicationID)
                             VALUES (@LicenseID,@DetainDate,@FineFees,@IsReleased,@CreatedByUserID,@ReleaseDate,@ReleasedByUserID,@ReleaseApplicationID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", license_id);
            command.Parameters.AddWithValue("@DetainDate", detain_date);
            command.Parameters.AddWithValue("@FineFees", fine_fees);
            command.Parameters.AddWithValue("@IsReleased", is_released);
            command.Parameters.AddWithValue("@CreatedByUserID", created_by_user_id);

            if (release_date != null)
            {
                command.Parameters.AddWithValue("@ReleaseDate", release_date);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);

            }

            if (released_by_user_id != -1)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", released_by_user_id);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);

            }

            if (release_app_id != -1)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", release_app_id);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);

            }





            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DetainID = insertedID;
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


            return DetainID;
        }

        public static bool UpdateDetainLicense(int detain_license_id,int license_id, int created_by_user_id, int ? released_by_user_id,
            int? release_app_id, bool is_released, DateTime ? release_date, DateTime detain_date,  decimal fine_fees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  DetainedLicenses  
                            set LicenseID = @LicenseID,
                                DetainDate = @DetainDate,
                                FineFees = @FineFees,
                                CreatedByUserID = @CreatedByUserID,
                                IsReleased = @IsReleased,
                                ReleaseDate = @ReleaseDate,
                                ReleasedByUserID = @ReleasedByUserID,
                                ReleaseApplicationID = @ReleaseApplicationID
                                
                                WHERE DetainID = @DetainID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DetainID", detain_license_id);
            command.Parameters.AddWithValue("@LicenseID", license_id);
            command.Parameters.AddWithValue("@DetainDate", detain_date);
            command.Parameters.AddWithValue("@FineFees", fine_fees);
            command.Parameters.AddWithValue("@IsReleased", is_released);
            command.Parameters.AddWithValue("@CreatedByUserID", created_by_user_id);

            if (release_date != null)
            {
                command.Parameters.AddWithValue("@ReleaseDate", release_date);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);

            }

            if (released_by_user_id != -1)
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", released_by_user_id);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);

            }

            if (release_app_id != -1)
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", release_app_id);
            }
            else
            {
                command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);

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

    }
}
