using System.Data;
using System.Text.Json.Serialization;
using EmployeeManagementPro.BLL;
using EmployeeManagementPro.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeManagementPro.Controllers
{// Route attribute to define the base URL for the controller
    [Route("api/Controller")]
    [ApiController]

    public class EmployeeManagementController : Controller
    {
        //Http Get method to get all employee details
        [HttpGet("GetEmployeeDetails")]
        public IActionResult GetEmployeeDetails()
        {
            try
            {
                DataTable dt = new EmployeeManagement().GetEmployeeDetails();
                if (dt.Rows.Count > 0 && dt == null)
                {
                    return NotFound(new { message = "No Record Found" });
                }
                // Serialize DataTable to JSON format
                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);

            }
            catch (Exception ex)
            {

                throw new Exception("Error Fetching GetEmployeeDetails : " + ex.Message);
            }
        }
        // Http Get method to get employee details by employee id
        [HttpGet("GetEmployeeDetailsById")]
        public IActionResult GetEmployeeDetails(int empId)
        {
            try
            {
                if (empId == 0)
                {
                    return BadRequest(new { message = "Employee ID is not mentioned." });
                }
                DataTable dt = new EmployeeManagement().GetEmployeeDetailsById(empId);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }
                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Fetching GetEmployeeDetailsById : " + ex.Message);
            }
        }
        // Http Post method to save employee details
        [HttpPost("SaveEmployeeDetails")]
        public int SaveEmployeeDetails(EmployeeManagementDTO employeeManagementDTO)
        {
            try
            {
                return new EmployeeManagement().SaveEmployeeDetails(employeeManagementDTO);
            }
            catch (Exception ex)
            {

                throw new Exception("Error While Saving Details:" + ex.Message);
            }
        }
        // Http Put method to update employee details
        [HttpPut("UpdateEmployeeDetails")]
        public int UpdateEmployeeDetails(EmployeeManagementDTO employeeManagementDTO)
        {
            try
            {
                return new EmployeeManagement().UpdateEmployeeDetails(employeeManagementDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Error While Updating Details:" + ex.Message);
            }
        }
        // Http Delete method to delete employee details
        [HttpDelete("DeleteEmployeeDetails")]
        public int DeleteEmployeeDetails(int empId)
        {
            try
            {
                if (empId == 0)
                {
                    throw new Exception("Employee ID is not mentioned.");
                }
                return new EmployeeManagement().DeleteEmployeeDetails(empId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error While Deleting Details:" + ex.Message);
            }
        }
    }

}
