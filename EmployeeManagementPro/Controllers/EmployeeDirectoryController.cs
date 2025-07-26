using EmployeeManagementPro.BLL;
using EmployeeManagementPro.DTO;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;


namespace EmployeeManagementPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDirectoryController : Controller
    {// This controller handles requests related to the employee directory.
        static EmployeeDirectoryController()
        {
                     QuestPDF.Settings.License = LicenseType.Community;
        }
        //HttpGet method to retrieve the employee directory.
        [HttpGet("GetEmployeeDirectory")]
        public ActionResult<List<EmployeeDirectoryDTO>> GetEmployeeDirectory()
        {
            var data = new EmployeeDirectory().GetEmployeeDirectory();
            return Ok(data);
        }
        // HttpGet method to download the employee directory as a PDF file.
        [HttpGet("DownloadEmployeeDirectoryPdf")]
        public IActionResult DownloadEmployeeDirectoryPdf()
        {
            var data = new EmployeeDirectory().GetEmployeeDirectory();

            var pdfBytes = GenerateEmployeeDirectoryPdf(data);

            return File(pdfBytes, "application/pdf", "EmployeeDirectory.pdf");
        }
        // Generates a PDF document containing the employee directory. 
        private byte[] GenerateEmployeeDirectoryPdf(List<EmployeeDirectoryDTO> employees)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Header().Text("Employee Directory").FontSize(20).Bold().AlignCenter();
                    page.Content().Column(col =>
                    {
                        foreach (var emp in employees)
                        {
                            col.Item().Text(text =>
                            {
                                text.Span($"ID: {emp.EmpId}\n").Bold();
                                text.Span($"Name: {emp.EmployeeName}\n");
                                text.Span($"DOB: {emp.DateOfBirth}\n");
                                text.Span($"Gender: {emp.Gender}\n");
                                text.Span($"Email: {emp.Email}\n");
                                text.Span($"Phone: {emp.Phone}\n");
                                text.Span($"City: {emp.City}\n");
                                text.Span($"Aadhaar: {emp.AadhaarNumber}\n");
                                text.Span($"PAN: {emp.PanCardNumber}\n");
                                text.Span($"Role: {emp.EmployeeRole}\n");
                                text.Span($"Department: {emp.DepartmentName}\n");
                                text.Span($"Recent Activities: {emp.RecentActivities}\n");
                                text.Span("--------------------------------------------------\n");
                            });
                        }
                    });
                });
            });

            using var ms = new MemoryStream();
            document.GeneratePdf(ms);
            return ms.ToArray();
        }
    }
}