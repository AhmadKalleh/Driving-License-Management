using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsAppointmentData
    {

        public static bool GetAppointmentInfoByID(int appointment_id, ref int test_type_id, ref int local_driving_license_applecation_id, ref int created_by_user_id,
           ref int retake_test_application_id, ref DateTime appointment_date, ref decimal paid_fees, ref bool is_locked)


        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM TestAppointments  WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", appointment_id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    test_type_id = (int)reader["TestTypeID"];
                    local_driving_license_applecation_id = (int)reader["LocalDrivingLicenseApplicationID"];
                    created_by_user_id = (int)reader["CreatedByUserID"];
                    appointment_date = (DateTime)reader["AppointmentDate"];

                    if (reader["RetakeTestApplicationID"] != DBNull.Value)
                    {
                        retake_test_application_id = (int)reader["RetakeTestApplicationID"];
                    }
                    else
                    {
                        retake_test_application_id = -1;
                    }


                    paid_fees = (decimal)reader["PaidFees"];
                    is_locked = (bool)reader["IsLocked"];

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

        public static DataTable GetAllAppointments(int local_driving_license_applecation_id,int test_type_id)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TA.TestAppointmentID,TA.AppointmentDate,TA.PaidFees,TA.IsLocked FROM TestAppointments TA
                WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                    AND TA.TestTypeID = @TestTypeID ORDER BY TA.AppointmentDate DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", local_driving_license_applecation_id);

            command.Parameters.AddWithValue("@TestTypeID", test_type_id);

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

        public static bool GetLatestActiveAppointment(int local_driving_license_applecation_id, int test_type_id,ref bool is_locked,ref bool test_result,ref int fail_count)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1 
	                        TA.TestAppointmentID,
                            TA.IsLocked,
	                        T.TestResult,
                            SUM(CASE WHEN T.TestResult = 0 THEN 1 ELSE NULL END) OVER() AS FailCount
                        FROM TestAppointments TA

                        LEFT JOIN Tests T ON T.TestAppointmentID = TA.TestAppointmentID 
                        WHERE TA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                          AND TA.TestTypeID = @TestTypeID
                        ORDER BY TA.AppointmentDate DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", local_driving_license_applecation_id);

            command.Parameters.AddWithValue("@TestTypeID", test_type_id);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    is_locked = (bool)reader["IsLocked"];

                    if (reader["TestResult"] != DBNull.Value)
                    {
                        test_result = (bool)reader["TestResult"];
                        
                    }
                    else
                    {
                        test_result = false; // أو أي قيمة تدل على null
                    }

                    if (reader["FailCount"] != DBNull.Value)
                    {
                        fail_count = (int)reader["FailCount"];
                    }
                    else
                    {
                        fail_count = 0;
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

        public static int AddNewAppointment(int test_type_id, int local_driving_license_applecation_id, int created_by_user_id,
            decimal paid_fees, DateTime appointment_date,int retake_test_application_id)

        {
            int AppointmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO TestAppointments (TestTypeID,LocalDrivingLicenseApplicationID, AppointmentDate,PaidFees,CreatedByUserID,RetakeTestApplicationID)
                             VALUES (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,@PaidFees,@CreatedByUserID,@RetakeTestApplicationID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", test_type_id);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", local_driving_license_applecation_id);
            command.Parameters.AddWithValue("@AppointmentDate", appointment_date);
            command.Parameters.AddWithValue("@PaidFees", paid_fees);
            command.Parameters.AddWithValue("@CreatedByUserID", created_by_user_id);

            if(retake_test_application_id != -1)
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", retake_test_application_id);
            }
            else
            {
                command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);

            }





            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    AppointmentID = insertedID;
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


            return AppointmentID;
        }

        public static bool UpdateAppointment(int appointment_id,DateTime appointment_date, bool is_locked)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  TestAppointments  
                            set AppointmentDate = @AppointmentDate,
                                IsLocked = @IsLocked
                                
                                WHERE TestAppointmentID = @TestAppointmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", appointment_id);
            command.Parameters.AddWithValue("@AppointmentDate", appointment_date);
            command.Parameters.AddWithValue("@IsLocked", is_locked);



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
