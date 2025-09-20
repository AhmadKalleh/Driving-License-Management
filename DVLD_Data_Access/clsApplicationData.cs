using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Data_Access
{
    public class clsApplicationData
    {

        public static bool GetapplicationInfoByID(int application_id,ref int person_id, ref int application_type_id,ref int created_by_user_id,
            ref DateTime application_date, ref DateTime last_status_date, ref decimal paid_fees, ref byte application_status)


        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Applications  WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", application_id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    person_id = (int)reader["ApplicantPersonID"];
                    application_type_id = (int)reader["ApplicationTypeID"];
                    created_by_user_id = (int)reader["CreatedByUserID"];
                    application_date = (DateTime)reader["ApplicationDate"];

                    // التعامل مع القيم الممكن تكون NULL
                    last_status_date = reader["LastStatusDate"] == DBNull.Value
                                        ? DateTime.MinValue
                                        : (DateTime)reader["LastStatusDate"];

                    paid_fees = (decimal)reader["PaidFees"];
                    application_status = (byte)reader["ApplicationStatus"];

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

        public static int AddNewApplication(int person_id, int application_type_id, DateTime application_date,
            DateTime last_status_date, int created_by_user_id, decimal paid_fees, byte application_status)

        {
            int ApplicationID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications (ApplicantPersonID,ApplicationDate, ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
                             VALUES (@ApplicantPersonID,@ApplicationDate,@ApplicationTypeID, @ApplicationStatus,@LastStatusDate,@PaidFees,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", person_id);
            command.Parameters.AddWithValue("@ApplicationDate", application_date);
            command.Parameters.AddWithValue("@ApplicationTypeID", application_type_id);
            command.Parameters.AddWithValue("@ApplicationStatus", application_status);
            command.Parameters.AddWithValue("@LastStatusDate", last_status_date);
            command.Parameters.AddWithValue("@PaidFees", paid_fees);
            command.Parameters.AddWithValue("@CreatedByUserID", created_by_user_id);


            

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
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


            return ApplicationID;
        }

        public static bool UpdateApplication(int application_id, byte application_status, DateTime last_status_date)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Applications  
                            set ApplicationStatus = @ApplicationStatus,
                                LastStatusDate = @LastStatusDate

                                WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationStatus", application_status);
            command.Parameters.AddWithValue("@LastStatusDate", last_status_date);

            command.Parameters.AddWithValue("@ApplicationID", application_id);

        



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

        public static bool UpdateLocalDrivingLicenseApplicationsStatus(int local_driving_license_application_id)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Applications
                            SET ApplicationStatus = 3
                            WHERE ApplicationID IN (
                                (SELECT ApplicationID 
                                 FROM LocalDrivingLicenseApplications 
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)

                                UNION

                                -- كل طلبات الريتيك
                                (SELECT RetakeTestApplicationID
                                 FROM TestAppointments
                                 WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                   AND RetakeTestApplicationID IS NOT NULL)
                            );";

            SqlCommand command = new SqlCommand(query, connection);

            

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", local_driving_license_application_id);





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

        public static bool DeleteApplication(int application_id)
        {

            

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Applications 
                                WHERE ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", application_id);



            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }
    }
}
