using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManagement.API;
using EmployeeManagement.API.Controllers;
using EmployeeManagement.Model;
using System.Net;
using System.Web.Http.Results;

namespace EmployeeManagement.API.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        EmployeeController controller = new EmployeeController();

        [TestMethod]
        public void Get()
        {
            // Arrange            

            // Act
            var result = (NegotiatedContentResult<string>)controller.GetAll();

            // Assert
            Assert.IsNotNull(result.Content.AsEnumerable());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            Employee employee = new Employee() { ID = 1, First_Name = "Mohan", Last_Name = "Kumar", Designation = "Engineer", Salary = 23000 };

            // Act
            var result = (NegotiatedContentResult<string>)controller.GetEmployeeById(1);

            // Assert
            Assert.AreEqual(employee, result.Content.FirstOrDefault());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            Employee employee = new Employee() { ID = 10, First_Name = "Ajit", Last_Name = "Singh", Designation = "Senior Engineer", Salary = 35000 };

            // Act
             var result = (NegotiatedContentResult<string>)controller.AddEmployee(employee);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);

        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            
            // Act
            var result = (NegotiatedContentResult<string>)controller.DeleteEmployee(1);

            // Assert
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }
    }
}
