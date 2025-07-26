using System.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmployeeManagementPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userLoginController : Controller
    {
        //HttpGet method to get user login details
        [HttpGet("GetUserLoginDetails")]
        public IActionResult GetUserLoginDetails()
        {
            try
            {
                DataTable dt = new BLL.userLoginBLL().GetUserLoginDetails();
                if (dt.Rows.Count == 0)
                {
                    return NotFound(new { message = "No Record Found" });
                }
                string JsonResult = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(JsonResult);
            }
            catch (Exception ex)
            {

                throw new Exception("Error Fetching Details:"+ ex.Message);
            }
        }
    }
}
