using CompanyCrud.Models;
using CompanyCrud.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private RepositoryCompany repo;
        public EmployeesController(RepositoryCompany repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employe>>> GetEMployees()
        {
            List<Employe> employees = await this.repo.GetEmployeesAsync();
            return employees;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmployeById(int employeId)
        {
            Employe employe = await this.repo.GetEmployeByIdAsync(employeId);
            return employe;
        }

        [HttpPost]
        public async Task<ActionResult<Employe>> InsertEmployeAsync(Employe employe)
        {
            await this.repo.InsertEmployeAsync(employe);
            return employe;
        }

        [HttpPut]
        public async Task<ActionResult<Employe>> UpdateEmployeAsync(Employe employe)
        {
            try
            {
                Employe emp = await this.repo.UpdateEmployeAsync(employe);
                return emp;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployeAsync(int empoyeId)
        {
            try
            {
                this.repo.DeleteEmployeAsync(empoyeId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
