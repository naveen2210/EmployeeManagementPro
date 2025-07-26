using System.Data;
using EmployeeManagementPro.BLL;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementPro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    public class departmentDistributionController : Controller
    {
        //Http Method to get department details
        [HttpGet("GetDepartmentDetails")]
        public IActionResult GetDepartmentDetails()
        {
			try
			{
                DataTable dt = new departmentDistributionBll().GetDepartmentDetails();
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
    }
}
