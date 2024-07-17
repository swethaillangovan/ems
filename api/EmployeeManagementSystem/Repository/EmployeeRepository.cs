using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Model.Response;

namespace EmployeeManagementSystem.Repository
{
    /// <summary>
    /// EmployeeRepository
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        public Task<bool> AddAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete employee data by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all the employee data
        /// </summary>
        /// <returns>EmployeeAllResponse: total employee count and List of Employee info</returns>
        public Task<EmployeeAllResponse> GetAllAsync(int page, int pageSize)
        {
            return Task.FromResult(new EmployeeAllResponse
            {
                TotalCount = 10,
                Employees = new List<Employee>
                {
                    new Employee
                    {
                        Id = 1,
                        Name = "Test"
                    }
                }
            });
        }


        /// <summary>
        /// Get the employee data by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee data</returns>
        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update employee data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        public Task<bool> UpdateAsync(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
