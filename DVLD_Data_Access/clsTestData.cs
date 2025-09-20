using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    public class clsTestData
    {
        public static int AddNewTest(int test_appointment_id, int created_by_user_id,
            string notes, bool test_result)

        {
            int TestID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Tests (TestAppointmentID,TestResult, Notes,CreatedByUserID)
                             VALUES (@TestAppointmentID,@TestResult,@Notes,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", test_appointment_id);
            command.Parameters.AddWithValue("@TestResult", test_result);

            if(notes != string.Empty && notes != null)
            {
                command.Parameters.AddWithValue("@Notes", notes);

            }
            else
            {
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);
            }
            command.Parameters.AddWithValue("@CreatedByUserID", created_by_user_id);





            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;
        }

    }
}
