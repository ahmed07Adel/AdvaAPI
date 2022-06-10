using Core.Entitties;
using Core.Interfaces;
using Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly AppDBContext context;

        public EmployeeRepository(AppDBContext context)
        {
            this.context  = context;
        }
        public async Task<Employee> CreateEmployee(Employee newEmployee)
        {
            var res = await context.Employees.AddAsync(newEmployee);
            await context.SaveChangesAsync();
            return res.Entity;
        }
        public async Task<Employee> DeleteEmployee(int EmployeeID)
        {
            var res = await context.Employees.FirstOrDefaultAsync(e => e.Id == EmployeeID);
            if (res != null)
            {
                context.Employees.Remove(res);
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }
        public async Task<IEnumerable> GetAllEmployees()
        {
            var res = await context.Employees.ToListAsync();
            return res;
        }
        public async Task<Employee> GetEmployeeByID(int EmployeeID)
        {
            var res = await context.Employees.FirstOrDefaultAsync(x => x.Id == EmployeeID);
            return res;
        }
        public async Task<Employee> UpdateEmployee(EmployeeDto employee)
        {
            var res = await context.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (res != null)
            {
                res.Name = employee.Name;
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }
    }
}
