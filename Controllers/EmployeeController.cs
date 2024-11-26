using AspNetCoreWebApiDapper.Interface;
using AspNetCoreWebApiDapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWebApiDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rec = await _employeeRepository.GetEmpList();

            return Ok(rec);
        }

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetEmpbyId(string Name)
        {
            var rec = await _employeeRepository.GetEmpbyId(Name);

            return Ok(rec);
        }


        [HttpPost("AddNewEmployee")]
        public async Task<IActionResult> Addnew(EmployeeModel employeeModel)
        {
            var res = await _employeeRepository.AddEmp(employeeModel);

            return Ok(res);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmp(int Id, EmployeeModel employeeModel)
        {
            var res = await _employeeRepository.UpdateEmp(Id, employeeModel);

            return Ok(res);
        }

        [HttpDelete("DeleteRec")]
        public async Task<IActionResult> Delete(int Id)
        {
            var res = await _employeeRepository.Delete(Id);

            return Ok(res);
        }
    }
}
