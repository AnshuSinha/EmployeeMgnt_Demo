using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.IBusiness;
using EmployeeManagement.Business;
using EmployeeManagement.Model;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Controllers
{
    public class EmployeeController : ApiController
    {
        IEmployeeServices employeeServices = new EmployeeServices();

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                List<Employee> employees = employeeServices.GetAllEmployees();

                if (employees == null)
                {
                    return Content(HttpStatusCode.NotFound, "Employee record not found");
                }
                return Content(HttpStatusCode.OK, employees);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeById(int ID)
        {
            try
            {
                Employee employee = employeeServices.GetEmployeeById(ID);

                if (employee == null)
                {
                    return Content(HttpStatusCode.NotFound, "Employee record not found");
                }
                return Content(HttpStatusCode.OK, employee);
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }

        [HttpPost]
        public IHttpActionResult AddEmployee([FromBody]Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Content(HttpStatusCode.BadRequest, "Bad Request");
                }
                employeeServices.AddEmployee(employee);
                return Content(HttpStatusCode.Created, "Employee record created");
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Internal Server Error");
            }

        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int ID)
        {

            try
            {
                bool result = employeeServices.DeleteEmployee(ID);
                if (result == true)
                {
                    return Content(HttpStatusCode.NoContent, "Employee record deleted");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Employee record not found");
                }
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Internal Server Error");
            }
        }
    }

}