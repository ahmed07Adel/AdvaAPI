using Core.Entitties;
using Core.Interfaces;
using Core.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        private readonly IEmployee employeeRepo;

        public EmployeeController(IEmployee employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        [HttpPost("UpdateEmployee/{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromBody] EmployeeDto employeeModel)
        {
            try
            {
                var Prod = await employeeRepo.GetEmployeeByID(employeeModel.Id);
                if (Prod == null)
                {
                    return NotFound($"this product = {employeeModel.Id} Can not found");
                }
                return await employeeRepo.UpdateEmployee(employeeModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data");
            }
        }
        [HttpPost]
        [Route("CreateEmployee")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromForm] EmployeeDto model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                var entity = new Employee
                {
                    Name = model.Name,
                    Salary = model.Salary,  
                    ManagerName = model.ManagerName,
                    Departement = model.Departement,  
                };
                var res = await employeeRepo.CreateEmployee(entity);
                return res;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Create data");
            }
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var res = await employeeRepo.GetAllEmployees();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Get data");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                return await employeeRepo.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}

