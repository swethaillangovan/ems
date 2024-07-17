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
    }
}
