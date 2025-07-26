using System.Data;
using System.Globalization;
using EmployeeManagementPro.DAL;
using EmployeeManagementPro.DTO;


namespace EmployeeManagementPro.BLL
{
    public class EmployeeManagement
    {
        // Method to get all employee details
        public DataTable GetEmployeeDetails()
        {
            try
            {
                return new EmployeeManagementDAL().GetEmployeeDetails();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching while GetEmployeeDetails: " + ex.Message);
            }
        }
        // Method to get employee details by employee ID
        public DataTable GetEmployeeDetailsById(int empId)
        {
            try
            {
                if (empId <= 0)
                    throw new ArgumentException("Employee ID must be greater than zero.", nameof(empId));
                return new EmployeeManagementDAL().GetEmployeeDetailsById(empId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching employee details by ID: " + ex.Message, ex);
            }
        }
        // Method to save employee details
        public int SaveEmployeeDetails(EmployeeManagementDTO employeeManagementDTO)
        {
            try
            {
                // Basic Validations
                if (employeeManagementDTO.empId == 0)
                    throw new Exception("Employee ID is not mentioned.");

                if (employeeManagementDTO.empImg == null || employeeManagementDTO.empImg.Length == 0)
                    throw new Exception("Upload your image.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empName))
                    throw new Exception("Enter the name, please.");

                if (!DateTime.TryParseExact(employeeManagementDTO.empDob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
                    throw new Exception("Date of birth must be in YYYY-MM-DD format.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empGender))
                    throw new Exception("Enter the Gender please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empEmail))
                    throw new Exception("Enter the Email, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empPhone))
                    throw new Exception("Enter the Phone number, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empCity))
                    throw new Exception("Enter the City, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empAadaarNumber))
                    throw new Exception("Enter the Aadaar Number, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empPanCard))
                    throw new Exception("Enter the PAN Number, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empRole))
                    throw new Exception("Enter your Role, please.");
                var dal = new EmployeeManagementDAL();// Create an instance of the DAL class
                return dal.SaveEmployeeDetails(employeeManagementDTO);
            }
            catch (Exception ex)
            {

                throw new Exception("Error while Saving the details: " + ex.Message, ex);
            }
        }
        // Method to update employee details
        public int UpdateEmployeeDetails(EmployeeManagementDTO employeeManagementDTO)
        {
            try
            {
                if (employeeManagementDTO.empId == 0)
                    throw new Exception("Employee ID is not mentioned.");

                if (employeeManagementDTO.empImg == null || employeeManagementDTO.empImg.Length == 0)
                    throw new Exception("Upload your image.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empName))
                    throw new Exception("Enter the name, please.");

                if (!DateTime.TryParseExact(employeeManagementDTO.empDob, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
                    throw new Exception("Date of birth must be in YYYY-MM-DD format.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empGender))
                    throw new Exception("Enter the Gender please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empEmail))
                    throw new Exception("Enter the Email, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empPhone))
                    throw new Exception("Enter the Phone number, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empCity))
                    throw new Exception("Enter the City, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empAadaarNumber))
                    throw new Exception("Enter the AadaarNumber, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empPanCard))
                    throw new Exception("Enter the PAN Number, please.");

                if (string.IsNullOrWhiteSpace(employeeManagementDTO.empRole))
                    throw new Exception("Enter your Role, please.");
                var dal = new EmployeeManagementDAL();
                return dal.UpdateEmployeeDetails(employeeManagementDTO);
            }
            catch (Exception ex)
            {

                throw new Exception("Error while Saving the details: " + ex.Message, ex);
            }
        }
        // Method to delete employee details by employee ID
        public int DeleteEmployeeDetails(int empId)
        {
            try
            {
                if (empId == 0)
                    throw new Exception("Employee ID is not mentioned.");
                var dal = new EmployeeManagementDAL();
                return dal.DeleteEmployeeDetails(empId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while Deleting the details: " + ex.Message, ex);
            }
        }
    }
}
