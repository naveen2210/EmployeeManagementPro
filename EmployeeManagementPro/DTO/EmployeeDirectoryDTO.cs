namespace EmployeeManagementPro.DTO
{
    public class EmployeeDirectoryDTO
    {
        public int EmpId { get; set; }
        public string EmployeeName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string AadhaarNumber { get; set; }
        public string PanCardNumber { get; set; }
        public string EmployeeRole { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string RecentActivities { get; set; }
    }
}