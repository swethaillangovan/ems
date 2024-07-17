namespace EmployeeManagementSystem.Model.Request
{
    /// <summary>
    /// Request model used for post
    /// </summary>
    public class EmployeeRequest
    {
        /// <summary>
        /// EmployeeName: Name of the employee, it includes firstname and lastname
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Designation of the employee
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Current Department of the employee
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Salary, amount repersent in local currency
        /// </summary>
        public decimal Salary { get; set; }
    }
}
