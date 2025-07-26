using System.Reflection.Metadata;

namespace EmployeeManagementPro.DTO
{
    public class EmployeeManagementDTO
    {
        public int empId {  get; set; }
       public string empImg { get; set; }
        public string empName { get; set; }
        public string empDob {  get; set; }
        public string empGender {  get; set; }
        public string empEmail { get; set; }
        public string empPhone { get; set; }
        public string empCity {  get; set; }
        public string empAadaarNumber {  get; set; }
        public string empPanCard { get; set; }
        public string empRole {  get; set; }
        public int departId { get; set; }
    }
}
