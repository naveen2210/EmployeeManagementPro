using System.Data;
using EmployeeManagementPro.DAL;
using EmployeeManagementPro.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeStatsController : Controller
    {
        // HttpGet method to get all employee stats
        [HttpGet("GetEmployeeStats")]
        public IActionResult GetEmployeeStats()
        {
            try
            {
                DataTable dt = new employeeStatsDAL().GetEmployeeStats();
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }
                string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {

                throw new Exception("Error Fetching the data: " + ex.Message);
            }
        }
        // HttpGet method to get employee stats by employee number and employee id
        [HttpPost("SaveEmployeeStats")]
        public int SaveEmployeeStats(employeeStatsDTO employeestatsDTO)
        {
            try
            {
                return new employeeStatsDAL().SaveEmployeeStats(employeestatsDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting data: " + ex.Message);
            }
        }
        // HttpGet method to get employee stats by employee number and employee id
        [HttpPut("UpdateEmployeeStats")]
        public int UpdateEmployeeStats(employeeStatsDTO employeestatsDTO)
        {
            try
            {
                return new employeeStatsDAL().UpdateEmployeeStats(employeestatsDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating data: " + ex.Message);
            }
        }
        // HttpDelete method to delete employee stats by employee number and employee id
        [HttpDelete("DeleteEmployeeStats")]
        public int DeleteEmployeeStats(int employeeSNumber, int empId)
        {
            try
            {
                return new employeeStatsDAL().DeleteEmployeeStats(employeeSNumber,empId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting data: " + ex.Message);
            }
        }
    }
}
