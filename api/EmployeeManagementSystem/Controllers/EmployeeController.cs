using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Model.Response;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    /// <summary>
    /// EmployeeController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// variable for repository
        /// </summary>
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Constructor for EmployeeController
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Api to get all the employee details
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<EmployeeAllResponse>> GetEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _employeeRepository.GetAllAsync(page, pageSize).ConfigureAwait(false);           
            return Ok(result);
        }

        /// <summary>
        /// Api to get employee based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id).ConfigureAwait(false);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        /// <summary>
        /// Api to add employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>HttpStatusCode</returns>

        [HttpPost]
        public async Task<ActionResult<bool>> PostEmployee(Employee employee)
        {
            var result = await _employeeRepository.AddAsync(employee).ConfigureAwait(false);
            if (result)
            {
                return Ok(true);
            }
            else 
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Api to update existing employee data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            var result = await _employeeRepository.UpdateAsync(employee).ConfigureAwait(false);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Api to delete employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HttpStatusCode</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _employeeRepository.DeleteAsync(id).ConfigureAwait(false);
            if (result)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
