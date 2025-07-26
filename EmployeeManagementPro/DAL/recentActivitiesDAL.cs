using System.Data;
using EmployeeManagementPro.DTO;
using MySql.Data.MySqlClient;

namespace EmployeeManagementPro.DAL
{
    public class recentActivitiesDAL
    {
        public string constr= "server=localhost;username=root;password=Naveen@2210;database=department;port=3306;";
        // GetRecentActivities method retrieves recent activities of employees from the database.
        public DataTable GetRecentActivities()
        {
            try
            {
                DataTable dt = new DataTable();
                using (MySqlConnection mySqlConnection = new MySqlConnection(constr))
                {
                    string query = @"SELECT SerialNumber, emp_Id empId, emp_Name empName, recent_activities recentActivities, emp_role empRole FROM emoloyeeActivites";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                return dt;
                            }
                            else
                            {
                                throw new Exception("Data Not found");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Fetching GetRecentActivities : " + ex.Message);
            }
        }
        // SaveRecentActivities method inserts a new record of recent activities into the database.
        public int saveRecentActivities(recentActivitiesDTO recentactivitiesDTO)
        {
            
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(constr))
                {
                    string query = @"INSERT INTO emoloyeeActivites (SerialNumber, emp_Id, emp_Name, recent_activities, emp_role) VALUES (@SerialNumber,@empId, @empName, @recentActivities, @empRole)";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@SerialNumber", recentactivitiesDTO.SerialNumber);
                        cmd.Parameters.AddWithValue("@empId", recentactivitiesDTO.empId);
                        cmd.Parameters.AddWithValue("@empName", recentactivitiesDTO.empName);
                        cmd.Parameters.AddWithValue("@recentActivities", recentactivitiesDTO.recentActivities);
                        cmd.Parameters.AddWithValue("@empRole", recentactivitiesDTO.emprole);
                        mySqlConnection.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Saving Recent Activities: " + ex.Message);
            }
        }
    }
}
