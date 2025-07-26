using System.Collections.Generic;
using EmployeeManagementPro.DAL;
using EmployeeManagementPro.DTO;
using QuestPDF;
using QuestPDF.Infrastructure;

namespace EmployeeManagementPro.BLL
{
    public class EmployeeDirectory
    {
        // GetEmployeeDirectory method retrieves the employee directory from the database.
        public List<EmployeeDirectoryDTO> GetEmployeeDirectory()
        {
            return new EmployeeDirectoryDAL().GetEmployeeDirectory();
        }

        static EmployeeDirectory()
        {
            Settings.License = LicenseType.Community;
        }
    }
}
