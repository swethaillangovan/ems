using EmployeeManagementSystem.Contracts;
using EmployeeManagementSystem.Controllers;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Model.Response;
using EmployeeManagementSystem.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagementSystem.Tests
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeRepository> _mockRepo;
        private readonly EmployeeController _controller;

        public EmployeeControllerTests()
        {
            _mockRepo = new Mock<IEmployeeRepository>();
            _controller = new EmployeeController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetEmployees_ReturnsOkResult_WithListOfEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "John Doe", Position = "Developer", Department = "IT", Salary = 60000 },
                new Employee { Id = 2, Name = "Jane Smith", Position = "Manager", Department = "HR", Salary = 80000 }
            };
            var response = new EmployeeAllResponse
            {
                Employees = employees,
                TotalCount = employees.Count
            };

            _mockRepo.Setup(repo => repo.GetAllAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetEmployees(1, 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<EmployeeAllResponse>(okResult.Value);
            Assert.Equal(2, returnValue.Employees.Count);
        }

        [Fact]
        public async Task GetEmployees_ReturnsNotFoundResult_WhenNoEmployees()
        {
            // Arrange
            var response = new EmployeeAllResponse
            {
                Employees = new List<Employee>(),
                TotalCount = 0
            };

            _mockRepo.Setup(repo => repo.GetAllAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetEmployees(1, 10);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetEmployee_ReturnsOkResult_WithEmployee()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "John Doe", Position = "Developer", Department = "IT", Salary = 60000 };

            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(employee);

            // Act
            var result = await _controller.GetEmployee(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task GetEmployee_ReturnsNotFoundResult_WhenEmployeeNotFound()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Employee)null);

            // Act
            var result = await _controller.GetEmployee(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task PostEmployee_ReturnsOkResult_WhenEmployeeAdded()
        {
            // Arrange
            var employeeRequest = new EmployeeRequest { Name = "John Doe", Position = "Developer", Department = "IT", Salary = 60000 };

            _mockRepo.Setup(repo => repo.AddAsync(employeeRequest)).ReturnsAsync(true);

            // Act
            var result = await _controller.PostEmployee(employeeRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task PostEmployee_ReturnsStatusCode500_WhenEmployeeNotAdded()
        {
            // Arrange
            var employeeRequest = new EmployeeRequest { Name = "John Doe", Position = "Developer", Department = "IT", Salary = 60000 };

            _mockRepo.Setup(repo => repo.AddAsync(employeeRequest)).ReturnsAsync(false);

            // Act
            var result = await _controller.PostEmployee(employeeRequest);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task PutEmployee_ReturnsOkResult_WhenEmployeeUpdated()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "John Doe", Position = "Developer", Department = "IT", Salary = 60000 };

            _mockRepo.Setup(repo => repo.UpdateAsync(employee)).ReturnsAsync(true);

            // Act
            var result = await _controller.PutEmployee(1, employee);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task PutEmployee_ReturnsBadRequestResult_WhenIdMismatch()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "John Doe", Position = "Developer", Department = "IT", Salary = 60000 };

            // Act
            var result = await _controller.PutEmployee(2, employee);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PutEmployee_ReturnsStatusCode500_WhenEmployeeNotUpdated()
        {
            // Arrange
            var employee = new Employee { Id = 1, Name = "John Doe", Position = "Developer", Department = "IT", Salary = 60000 };

            _mockRepo.Setup(repo => repo.UpdateAsync(employee)).ReturnsAsync(false);

            // Act
            var result = await _controller.PutEmployee(1, employee);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsOkResult_WhenEmployeeDeleted()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteEmployee(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<bool>(okResult.Value);
            Assert.True(returnValue);
        }

        [Fact]
        public async Task DeleteEmployee_ReturnsStatusCode500_WhenEmployeeNotDeleted()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.DeleteAsync(1)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteEmployee(1);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }
    }
}
