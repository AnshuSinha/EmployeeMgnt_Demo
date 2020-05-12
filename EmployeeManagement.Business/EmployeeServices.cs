using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.IBusiness;
using EmployeeManagement.DAL;
using EmployeeManagement.Model;

namespace EmployeeManagement.Business
{
    public class EmployeeServices : IEmployeeServices
    {
        EmployeeDatabaseEntities employeeDatabaseEntities = new EmployeeDatabaseEntities();

        public bool AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return false;
                }
                employeeDatabaseEntities.Employees.Add(employee);
                employeeDatabaseEntities.SaveChanges();
                return true; ;
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }

        public bool DeleteEmployee(int empId)
        {
            try
            {
                if (employeeDatabaseEntities.Employees.FirstOrDefault(a => a.ID == empId) != null)
                {
                    employeeDatabaseEntities.Employees.Remove(employeeDatabaseEntities.Employees.FirstOrDefault(a => a.ID == empId));
                    employeeDatabaseEntities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                employees = employeeDatabaseEntities.Employees.AsEnumerable().ToList();
                return employees;
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }

        public Employee GetEmployeeById(int empId)
        {
            try
            {
                Employee employee = new Employee();
                employee = employeeDatabaseEntities.Employees.FirstOrDefault(a => a.ID == empId);
                return employee;
            }
            catch (Exception)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }


   
   
}
