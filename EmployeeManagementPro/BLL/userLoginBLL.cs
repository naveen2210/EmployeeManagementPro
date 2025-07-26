using System.Data;

namespace EmployeeManagementPro.BLL
{
    public class userLoginBLL
    {
        // GetUserLoginDetails method retrieves user login details from the DAL layer
        public DataTable GetUserLoginDetails()
        {
            try
            {
                return new DAL.userloginDAL().GetUserLoginDetails();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user login details: " + ex.Message);
            }
        }
    }
}
