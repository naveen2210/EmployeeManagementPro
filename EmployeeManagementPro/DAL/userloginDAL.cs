using System.Data;
using MySql.Data.MySqlClient;

namespace EmployeeManagementPro.DAL
{
    public class userloginDAL
    {
        public string connecString = "server=localhost;username=root;password=Naveen@2210;database=usersLogin;port=3306;";
        // GetUserLoginDetails method retrieves user login details from the database.
        public DataTable GetUserLoginDetails()
        {
            try
            { 
                    DataTable usersLogin = new DataTable();
                    using (MySqlConnection mySqlConnection = new MySqlConnection(connecString))
                    {
                        string query = @"SELECT  userId,  uName, username, userPwd FROM userDetails";
                        MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(usersLogin);
                            if (usersLogin != null && usersLogin.Rows.Count > 0)
                            {
                                return usersLogin;
                            }
                            else
                            {
                                throw new Exception("Data Not found");
                            }
                        }
                    }
                  
            }
            catch (Exception ex)
            {

                throw new Exception("Error Fetching Details: "+ ex.Message);
            }
        }
    }
}
