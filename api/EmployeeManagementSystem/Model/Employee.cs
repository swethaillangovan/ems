using EmployeeManagementSystem.Model.Request;

namespace EmployeeManagementSystem.Model
{
    /// <summary>
    /// Employee
    /// </summary>
    public class Employee : EmployeeRequest
    {
        /// <summary>
        /// Id of the Employee
        /// </summary>
        public int Id { get; set; }
    }
}
