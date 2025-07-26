using System.Data;
using EmployeeManagementPro.DAL;

namespace EmployeeManagementPro.BLL
{
    public class RecentActivitiesBLL
    {
        // This class handles business logic for recent activities.
        public DataTable GetRecentActivities()
        {
			try
			{
			    return new recentActivitiesDAL().GetRecentActivities();
            }
			catch (Exception ex)
			{

				throw new Exception("Error Fetching Data: " + ex.Message);
			}
        }
    }
}
