namespace EmployeeManagementSystem.Model
{
    /// <summary>
    /// Model for Employee
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id of the Employee
        /// </summary>
        public int Id { get; set; }

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
