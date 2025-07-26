using System.Data;
using EmployeeManagementPro.DTO;
using MySql.Data.MySqlClient;

namespace EmployeeManagementPro.DAL
{
    public class EmployeeManagementDAL
    {// Connection string for MySQL database
        public string ConString = "server=localhost;username=root;password=Naveen@2210;database=employeeManagement;port=3306;";
        //Get Method to get all employee details
        public DataTable GetEmployeeDetails()
        {
            try
            {
                DataTable emp = new DataTable();
                using (MySqlConnection mySqlConnection = new MySqlConnection(ConString))
                {
                    string query = @"SELECT emp_Id empId,emp_Img empImg,emp_Name empName,emp_Dob empDob,emp_Gender empGender,emp_Email empEmail,emp_Phone empPhone,emp_City empCity,emp_AadaarNumber empAadaarNumber,emp_PanCard empPanCard,emp_Role empRole,depart_Id departId FROM employeeDetails";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(emp);
                            if (emp != null && emp.Rows.Count > 0)
                            {
                                return emp;

                            }
                            else
                            {
                                throw new Exception("Data Not found");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Fetching GetEmployeeDetails : " + ex.Message);
            }
        }
        //GetById method to get Employee list based on employee id
        public DataTable GetEmployeeDetailsById(int empId)
        {
            if (empId <= 0)
                throw new ArgumentException("Invalid Employee ID", nameof(empId));

            try
            {
                DataTable emp = new DataTable();
                using (MySqlConnection mySqlConnection = new MySqlConnection(ConString))
                {
                    string query = @"SELECT emp_Id empId,emp_Img empImg,emp_Name empName,emp_Dob empDob,emp_Gender empGender,emp_Email empEmail,emp_Phone empPhone,emp_City empCity,emp_AadaarNumber empAadaarNumber,emp_PanCard empPanCard,emp_Role empRole,depart_Id departId FROM employeeDetails WHERE emp_Id = @empId";
                    using (MySqlCommand cmd = new MySqlCommand(query, mySqlConnection))
                    {
                        cmd.Parameters.AddWithValue("@empId", empId);
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(emp);
                            return emp; // Return DataTable regardless of row count
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Fetching GetEmployeeDetailsById : " + ex.Message, ex);
            }
        }
        //Post Method to send employee details to database
        public int SaveEmployeeDetails(EmployeeManagementDTO employeeManagementDTO)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConString))
                {
                    string query = @"INSERT INTO employeeDetails
                (emp_Id, emp_Img, emp_Name, emp_Dob, emp_Gender, emp_Email, emp_Phone, emp_City, emp_AadaarNumber, emp_PanCard, emp_Role,depart_Id) 
                VALUES 
                (@empId, @empImg, @empName, @empDob, @empGender, @empEmail, @empPhone, @empCity, @empAadaarNumber, @empPanCard, @empRole,@departId)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@empId", employeeManagementDTO.empId);
                        cmd.Parameters.AddWithValue("@empImg", employeeManagementDTO.empImg);
                        cmd.Parameters.AddWithValue("@empName", employeeManagementDTO.empName);
                        if (DateTime.TryParse(employeeManagementDTO.empDob, out DateTime dob))
                            cmd.Parameters.AddWithValue("@empDob", dob);
                        else
                            throw new Exception("Invalid date format for Date of Birth. Expected format: YYYY-MM-DD");

                        cmd.Parameters.AddWithValue("@empGender", employeeManagementDTO.empGender);
                        cmd.Parameters.AddWithValue("@empEmail", employeeManagementDTO.empEmail);
                        cmd.Parameters.AddWithValue("@empPhone", employeeManagementDTO.empPhone);
                        cmd.Parameters.AddWithValue("@empCity", employeeManagementDTO.empCity);
                        cmd.Parameters.AddWithValue("@empAadaarNumber", employeeManagementDTO.empAadaarNumber);
                        cmd.Parameters.AddWithValue("@empPanCard", employeeManagementDTO.empPanCard);
                        cmd.Parameters.AddWithValue("@empRole", employeeManagementDTO.empRole);
                        cmd.Parameters.AddWithValue("@departId", employeeManagementDTO.departId);
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Fetching: " + ex.Message, ex);
            }
        }
        //Update method to update the current employee details
        public int UpdateEmployeeDetails(EmployeeManagementDTO employeeManagementDTO)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConString))
                {
                    string query = @"
                UPDATE employeeDetails SET 
                    emp_Img = @empImg, 
                    emp_Name = @empName, 
                    emp_Dob = @empDob,
                    emp_Gender = @empGender,
                    emp_Email = @empEmail,
                    emp_Phone = @empPhone,
                    emp_City = @empCity,
                    emp_AadaarNumber = @empAadaarNumber,
                    emp_PanCard = @empPanCard,
                    emp_Role = @empRole,
                    depart_Id = @departId
                WHERE emp_Id = @empId";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@empId", employeeManagementDTO.empId);
                        cmd.Parameters.AddWithValue("@empImg", employeeManagementDTO.empImg);
                        cmd.Parameters.AddWithValue("@empName", employeeManagementDTO.empName);

                        if (DateTime.TryParse(employeeManagementDTO.empDob, out DateTime dob))
                        {
                            cmd.Parameters.AddWithValue("@empDob", dob);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid date format for Date of Birth. Expected format: YYYY-MM-DD");
                        }

                        cmd.Parameters.AddWithValue("@empGender", employeeManagementDTO.empGender);
                        cmd.Parameters.AddWithValue("@empEmail", employeeManagementDTO.empEmail);
                        cmd.Parameters.AddWithValue("@empPhone", employeeManagementDTO.empPhone);
                        cmd.Parameters.AddWithValue("@empCity", employeeManagementDTO.empCity);
                        cmd.Parameters.AddWithValue("@empAadaarNumber", employeeManagementDTO.empAadaarNumber);
                        cmd.Parameters.AddWithValue("@empPanCard", employeeManagementDTO.empPanCard);
                        cmd.Parameters.AddWithValue("@empRole", employeeManagementDTO.empRole);
                        cmd.Parameters.AddWithValue("@departId", employeeManagementDTO.departId);

                        con.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating employee details: " + ex.Message, ex);
            }

            return result;
        }
        //Delete Method to delete data from employee details table 
        public int DeleteEmployeeDetails(int empId)
        {
            int result = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConString))
                {
                    string query = @"DELETE FROM employeeDetails WHERE emp_Id = @empId";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@empId", empId);
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Fetching: " + ex.Message, ex);
            }
        }
    }
}
