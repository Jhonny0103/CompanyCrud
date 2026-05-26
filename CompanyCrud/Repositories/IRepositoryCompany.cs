using CompanyCrud.Models;

namespace CompanyCrud.Repositories
{
    public interface IRepositoryCompany
    {
        public Task<Employe> InsertEmployeAsync(Employe employe);
        public Task<Employe> UpdateEmployeAsync(Employe employe);
        public Task<List<Employe>> GetEmployeesAsync();
        public Task<List<Emp_Dept>> GetEmpDeptAsync();

        public Task<List<Dept>> GetDeptsAsync();
        public Task<Employe> GetEmployeByIdAsync(int employeId);
        public Task DeleteEmployeAsync(int employeId);
    }
}
