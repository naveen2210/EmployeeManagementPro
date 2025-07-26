using System.Data;
using EmployeeManagementPro.DTO;
using MySql.Data.MySqlClient;

namespace EmployeeManagementPro.DAL
{
    public class employeeStatsDAL
    {
        public string connstring = "server=localhost;username=root;password=Naveen@2210;database=department;port=3306;";
        // GetEmployeeStats method retrieves employee statistics from the database.
        public DataTable GetEmployeeStats()
        {
            try
            {
                DataTable empStats = new DataTable();
                using (MySqlConnection mySqlConnection = new MySqlConnection(connstring))
                {
                    string query = @"SELECT employeeSNumber, emp_Id empId, emp_Name empName, performance, employeeRole FROM enployeeStats";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(empStats);
                            if (empStats != null && empStats.Rows.Count > 0)
                            {
                                return empStats;
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
                throw new Exception("Error Fetching GetEmployeeStats : " + ex.Message);
            }
        }
        // SaveEmployeeStats method inserts a new employee statistics record into the database.
        public int SaveEmployeeStats(employeeStatsDTO employeestatsDTO)
        {
            try
            {
                using (MySqlConnection cmd = new MySqlConnection(connstring))
                {
                    string query = @"INSERT INTO enployeeStats (employeeSNumber, emp_Id, emp_Name, performance, employeeRole) VALUES (@employeeSNumber, @empId, @empName, @performance, @employeeRole)";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, cmd))
                    {
                        mySqlCommand.Parameters.AddWithValue("@employeeSNumber", employeestatsDTO.employeeSNumber);
                        mySqlCommand.Parameters.AddWithValue("@empId", employeestatsDTO.empId);
                        mySqlCommand.Parameters.AddWithValue("@empName", employeestatsDTO.empName);
                        mySqlCommand.Parameters.AddWithValue("@performance", employeestatsDTO.performance);
                        mySqlCommand.Parameters.AddWithValue("@employeeRole", employeestatsDTO.employeeRole);
                        cmd.Open();
                        return mySqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error inserting data:"+ ex.Message);
            }
        }
        // UpdateEmployeeStats method updates an existing employee statistics record in the database.
        public int UpdateEmployeeStats(employeeStatsDTO employeestatsDTO)
        {
            try
            {
                using (MySqlConnection cmd = new MySqlConnection(connstring))
                {
                    string query = @"UPDATE enployeeStats SET emp_Name = @empName, performance = @performance, employeeRole = @employeeRole WHERE employeeSNumber = @employeeSNumber AND emp_Id = @empId";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, cmd))
                    {
                        mySqlCommand.Parameters.AddWithValue("@employeeSNumber", employeestatsDTO.employeeSNumber);
                        mySqlCommand.Parameters.AddWithValue("@empId", employeestatsDTO.empId);
                        mySqlCommand.Parameters.AddWithValue("@empName", employeestatsDTO.empName);
                        mySqlCommand.Parameters.AddWithValue("@performance", employeestatsDTO.performance);
                        mySqlCommand.Parameters.AddWithValue("@employeeRole", employeestatsDTO.employeeRole);
                        cmd.Open();
                        return mySqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating data: " + ex.Message);
            }
        }
        //DeleteEmployeeStats method deletes an employee statistics record from the database based on employeeSNumber and empId.
        public int DeleteEmployeeStats(int employeeSNumber, int empId)
        {
            if (employeeSNumber <= 0 || empId <= 0)
                throw new ArgumentException("Invalid Employee SNumber or ID", nameof(employeeSNumber));
            try
            {
                using (MySqlConnection cmd = new MySqlConnection(connstring))
                {
                    string query = @"DELETE FROM enployeeStats WHERE employeeSNumber = @employeeSNumber AND emp_Id = @empId";
                    using (MySqlCommand mySqlCommand = new MySqlCommand(query, cmd))
                    {
                        mySqlCommand.Parameters.AddWithValue("@employeeSNumber", employeeSNumber);
                        mySqlCommand.Parameters.AddWithValue("@empId", empId);
                        cmd.Open();
                        return mySqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting data: " + ex.Message);
            }
        }
    }
}
