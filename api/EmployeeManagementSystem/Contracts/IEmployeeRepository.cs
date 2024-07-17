using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Model.Response;

namespace EmployeeManagementSystem.Contracts
{
    /// <summary>
    /// Interface for employee repository
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Get all the employee data
        /// </summary>
        /// <returns>EmployeeAllResponse: total employee count and List of Employee info</returns>
        Task<EmployeeAllResponse> GetAllAsync(int page, int pageSize);

        /// <summary>
        /// Get the employee data by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Employee data</returns>
        Task<Employee> GetByIdAsync(int id);

        /// <summary>
        /// Add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        Task<bool> AddAsync(Employee employee);

        /// <summary>
        /// Update employee data
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        Task<bool> UpdateAsync(Employee employee);

        /// <summary>
        /// Delete employee data by employee id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean indicates the staus of the operation</returns>
        Task<bool> DeleteAsync(int id);
    }
}
