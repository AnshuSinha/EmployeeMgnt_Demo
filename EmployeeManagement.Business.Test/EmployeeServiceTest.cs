using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagement.Business;
using EmployeeManagement.IBusiness;
using EmployeeManagement.Model;

namespace EmployeeManagement.Business.Test
{
    [TestClass]
    public class EmployeeServiceTest
    {
        IEmployeeServices employeeServices = new EmployeeServices();

        
        [TestMethod]
        public void GetAll()
        {
            //Act
            var result = employeeServices.GetAllEmployees();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            Employee employee = new Employee() { ID = 1, First_Name = "Mohan", Last_Name = "Kumar", Designation = "Engineer", Salary = 23000 };

            // Act
            Employee result = employeeServices.GetEmployeeById(1);

            // Assert
            Assert.AreEqual(employee, result);
           
        }

        [TestMethod]
        public void AddEmployee()
        {
            // Arrange
            Employee employee = new Employee() { ID = 10, First_Name = "Ajit", Last_Name = "Singh", Designation = "Senior Engineer", Salary = 35000 };

            // Act
            bool result = employeeServices.AddEmployee(employee);

            // Assert
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void DeleteEmployee()
        {
            // Arrange

            // Act
            bool result = employeeServices.DeleteEmployee(1);

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
