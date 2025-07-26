using System.Data;
using MySql.Data.MySqlClient;

namespace EmployeeManagementPro.DAL
{
    public class DepartmentDistributionDAL
    {
        public string ConnectionString = "server=localhost;username=root;password=Naveen@2210;database=department;port=3306;";

        // GetDepartmentDetails method retrieves department details along with the count of employees in each department.
        public DataTable GetDepartmentDetails()
        {
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString))
                {
                    string query = "SELECT d.depart_Id AS departmentId, d.dapart_name AS departmentName, COUNT(e.emp_Id) AS totalEmployees " +
                                   "FROM department.departments d " +
                                   "LEFT JOIN employeemanagement.employeedetails e ON d.depart_Id = e.depart_Id " +
                                   "GROUP BY d.depart_Id, d.dapart_name;";

                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        // Open the connection before filling the data adapter
                        mySqlConnection.Open();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                // Check if dt is not null and has rows after filling
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    // Throw a more specific exception or return an empty DataTable
                    throw new Exception("No department data found.");
                }
            }

            catch (Exception ex)
            {

                throw new Exception("Error while Fetching Data: "+ex.Message);
            }

}
    }
}
