using System.Data;
using EmployeeManagementPro.DAL;
using EmployeeManagementPro.DTO;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class recentActivitiesController : Controller
    {
        // HttpGet method to get all recent activities
        [HttpGet("GetRecentActivities")]
        public IActionResult GetRecentActivities()
        {
            try
            {
                DataTable dt = new recentActivitiesDAL().GetRecentActivities();
                if (dt == null || dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }
                string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(jsonResult);
            }
            catch (Exception ex)
            {

                throw new Exception("Error Fetching Data: "+ ex.Message);
            }   
        }
        // HttpGet method to get recent activities by employee id
        [HttpPost("saveRecentActivities")]
        public int saveRecentActivities(recentActivitiesDTO recentactivitiesDTO)
        {
            try
            {
                return new recentActivitiesDAL().saveRecentActivities(recentactivitiesDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
