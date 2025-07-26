using System.Data;
using EmployeeManagementPro.DAL;

namespace EmployeeManagementPro.BLL
{
    public class departmentDistributionBll
    {
        // GetDepartmentDetails method retrieves department details from the database.
        public DataTable GetDepartmentDetails()
        {
            try
            {
                return new DepartmentDistributionDAL().GetDepartmentDetails();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching department details: " + ex.Message, ex);
            }
        }
    }
}
