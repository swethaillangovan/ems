using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Model.Response;
using EmployeeManagementSystem.Model.Request;
using System.Data;
using Microsoft.Data.SqlClient;

namespace EmployeeManagementSystem.Repository
{
    /// <summary>
    /// EmployeeRepository
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DBConnection");
        }

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        public async Task<bool> AddAsync(EmployeeRequest employee)
        {
            try
            {
                int newId;

                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("AddEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Name", employee.Name);
                        command.Parameters.AddWithValue("@Position", employee.Position);
                        command.Parameters.AddWithValue("@Department", employee.Department);
                        command.Parameters.AddWithValue("@Salary", employee.Salary);
                        await connection.OpenAsync();
                        newId = Convert.ToInt32(await command.ExecuteScalarAsync());
                    }
                }

                return newId > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Delete employee data by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("DeleteEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Get all the employee data
        /// </summary>
        /// <returns>EmployeeAllResponse: total employee count and List of Employee info</returns>
        public async Task<EmployeeAllResponse> GetAllAsync(int page, int pageSize)
        {
            var employeeAllResponse = new EmployeeAllResponse
            {
                Employees = new List<Employee>()
            };
            
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("GetAllEmployees", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Page", page);
                        command.Parameters.AddWithValue("@PageSize", pageSize);

                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                employeeAllResponse.Employees.Add(new Employee
                                {
                                    Id = (int)reader["Id"],
                                    Name = reader["Name"].ToString(),
                                    Position = reader["Position"].ToString(),
                                    Department = reader["Department"].ToString(),
                                    Salary = (decimal)reader["Salary"]
                                });
                            }

                            if (await reader.NextResultAsync() && await reader.ReadAsync())
                            {
                                employeeAllResponse.TotalCount = (int)reader["TotalCount"];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return employeeAllResponse;
        }


        /// <summary>
        /// Get the employee data by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee data</returns>
        public async Task<Employee> GetByIdAsync(int id)
        {
            Employee? employee = null;
            try
            {               
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("GetEmployeeById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);
                        await connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                employee = new Employee
                                {
                                    Id = (int)reader["Id"],
                                    Name = reader["Name"].ToString(),
                                    Position = reader["Position"].ToString(),
                                    Department = reader["Department"].ToString(),
                                    Salary = (decimal)reader["Salary"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return employee;
        }

        /// <summary>
        /// Update employee data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        public async Task<bool> UpdateAsync(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("UpdateEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", employee.Id);
                        command.Parameters.AddWithValue("@Name", employee.Name);
                        command.Parameters.AddWithValue("@Position", employee.Position);
                        command.Parameters.AddWithValue("@Department", employee.Department);
                        command.Parameters.AddWithValue("@Salary", employee.Salary);
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }
                return true;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<EmployeeAllResponse> GetBySearchText(string text)
        {
            var employeeAllResponse = new EmployeeAllResponse
            {
                Employees = new List<Employee>()
            };

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = new SqlCommand("GetEmployeeBySearch", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Text", text);
                        

                        await connection.OpenAsync();

                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                employeeAllResponse.Employees.Add(new Employee
                                {
                                    Id = (int)reader["Id"],
                                    Name = reader["Name"].ToString(),
                                    Position = reader["Position"].ToString(),
                                    Department = reader["Department"].ToString(),
                                    Salary = (decimal)reader["Salary"]
                                });
                            }
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return employeeAllResponse;
        }
    }
}
