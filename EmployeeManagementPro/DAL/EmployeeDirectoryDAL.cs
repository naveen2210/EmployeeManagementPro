using System.Collections.Generic;
using System.Data;
using EmployeeManagementPro.DTO;
using MySql.Data.MySqlClient;

namespace EmployeeManagementPro.DAL
{
    public class EmployeeDirectoryDAL
    {
        public string ConString = "server=localhost;username=root;password=Naveen@2210;database=employeeManagement;port=3306;";
        // GetEmployeeDirectory method retrieves a list of employee details along with their department and recent activities.
        public List<EmployeeDirectoryDTO> GetEmployeeDirectory()
        {
            var list = new List<EmployeeDirectoryDTO>();
            using (MySqlConnection con = new MySqlConnection(ConString))
            {
                string query = @"SELECT ed.emp_Id as empId, ed.emp_Name As EmployeeName, ed.emp_Dob AS DateOfBirth, ed.emp_Gender As Gender,
                                 ed.emp_Email AS Email, ed.emp_Phone AS phone, ed.emp_City AS city,
                                 ed.emp_AadaarNumber AS aadhaarNumber, ed.emp_PanCard AS PanCardNumber, ed.emp_Role AS employeeRole,
                                 d.depart_Id AS departmentId, d.dapart_name AS departmentName, RA.recent_activities AS RecentActivities
                                 FROM employeemanagement.employeedetails AS ed 
                                 LEFT JOIN department.departments AS d ON ed.depart_Id = d.depart_Id
                                 LEFT JOIN department.emoloyeeActivites AS RA ON ed.emp_Id = ra.emp_Id
                                 LEFT JOIN department.enployeeStats AS ES ON ed.emp_Id = ES.emp_Id;";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new EmployeeDirectoryDTO
                            {
                                EmpId = reader.GetInt32("empId"),
                                EmployeeName = reader["EmployeeName"]?.ToString(),
                                DateOfBirth = reader["DateOfBirth"]?.ToString(),
                                Gender = reader["Gender"]?.ToString(),
                                Email = reader["Email"]?.ToString(),
                                Phone = reader["phone"]?.ToString(),
                                City = reader["city"]?.ToString(),
                                AadhaarNumber = reader["aadhaarNumber"]?.ToString(),
                                PanCardNumber = reader["PanCardNumber"]?.ToString(),
                                EmployeeRole = reader["employeeRole"]?.ToString(),
                                DepartmentId = reader["departmentId"] as int?,
                                DepartmentName = reader["departmentName"]?.ToString(),
                                RecentActivities = reader["RecentActivities"]?.ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }
    }
}