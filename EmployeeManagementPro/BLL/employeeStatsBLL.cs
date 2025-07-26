using System.Data;
using EmployeeManagementPro.DTO;

namespace EmployeeManagementPro.BLL
{
    public class employeeStatsBLL
    {
        // This class handles business logic for employee statistics.
        public DataTable GetEmployeeStats()
        {
            try
            {
                return new DAL.employeeStatsDAL().GetEmployeeStats();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Fetching Data: " + ex.Message);
            }
        }
        // This method retrieves employee statistics from the database.
        public int SaveEmployeeStats(employeeStatsDTO employeestatsDTO)
        {
            try
            {
                return new DAL.employeeStatsDAL().SaveEmployeeStats(employeestatsDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting data: " + ex.Message);
            }
        }
        // This method updates employee statistics in the database.
        public int UpdateEmployeeStats(employeeStatsDTO employeestatsDTO)
        {
            try
            {
                return new DAL.employeeStatsDAL().UpdateEmployeeStats(employeestatsDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating data: " + ex.Message);
            }
        }
        // This method deletes employee statistics from the database.
        public int DeleteEmployeeStats(int employeeSNumber, int empId)
        {
            try
            {
                return new DAL.employeeStatsDAL().DeleteEmployeeStats(employeeSNumber, empId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting data: " + ex.Message);
            }
        }
    }
}