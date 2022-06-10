using Core.Entitties;
using Core.Interfaces;
using Core.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly IDepartement departementRepo;

        public DepartementController(IDepartement departementRepo)
        {
            this.departementRepo = departementRepo;
        }
        [HttpPost("UpdateDepartement/{id:int}")]
        public async Task<ActionResult<Departement>> UpdateDepartement([FromBody] DepartementDto DepartementModel)
        {
            try
            {
                var Prod = await departementRepo.GetDepartementByID(DepartementModel.Id);                                                   
                if (Prod == null)
                {
                    return NotFound($"this product = {DepartementModel.Id} Can not found");
                }
                return await departementRepo.UpdateDepartement(DepartementModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating data");
            }
        }
        [HttpPost]
        [Route("CreateDepartement")]
        public async Task<ActionResult<Departement>> CreateDepartement([FromForm] DepartementDto model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                              
                var entity = new Departement
                {
                    Name = model.Name,
                };
                var res = await departementRepo.CreateDepartement(entity);
                return res;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Create data");
            }
        }
        [HttpGet]
        [Route("GetllDepartement")]
        public async Task<IActionResult> GetllDepartement()
        {
            try
            {              
                var res = await departementRepo.GetAllDepartement();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Get data");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Departement>> DeleteDepartement(int id)
        {
            try
            {
                return await departementRepo.DeleteDepartement(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
            }
        }
    }
}
