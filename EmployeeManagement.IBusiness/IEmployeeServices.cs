using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Model;

namespace EmployeeManagement.IBusiness
{
    public interface IEmployeeServices
    {
        Employee GetEmployeeById(int empId);
        List<Employee> GetAllEmployees();
        bool AddEmployee(Employee employee);
        bool DeleteEmployee(int empId);
                     
    }
}
