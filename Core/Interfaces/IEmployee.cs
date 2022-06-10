using Core.Entitties;
using Core.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmployee
    {
        Task<Employee> CreateEmployee(Employee newemployee);
        Task<IEnumerable> GetAllEmployees();
        Task<Employee> GetEmployeeByID(int EmployeeID);
        Task<Employee> UpdateEmployee(EmployeeDto employee);
        Task<Employee> DeleteEmployee(int EmployeeID);
    }
}
