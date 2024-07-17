namespace EmployeeManagementSystem.Model.Response
{
    /// <summary>
    /// EmployeeAllResponse
    /// </summary>
    public class EmployeeAllResponse
    {
        /// <summary>
        /// Count of total employees
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// List of employee data
        /// </summary>
        public List<Employee> Employees { get; set; }
    }
}
