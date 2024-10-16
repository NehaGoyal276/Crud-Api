using Crud_Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmpRepo _empRepo;
        public EmployeeController(EmpRepo empRepo)
        {
            _empRepo = empRepo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllEmp()
        {
            var AllEmp = await _empRepo.GetAllEmp();
            return Ok(AllEmp);

        }


        [HttpGet("getEmpById/{id}")]
        public async Task<IActionResult> GetEmpById(int id)
        {
            var emp = await _empRepo.GetEmpById(id);
            return Ok(emp);
        }


        [HttpPost]
        public async Task<IActionResult> AddEmp([FromBody] Employee employee)
        {
            await _empRepo.AddEmp(employee);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            await _empRepo.DeleteEmp(id);
             return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmp(int id, Employee emp)
        {
            await _empRepo.UpdateaEmp(id, emp);
            return Ok();
        }
    }
}

