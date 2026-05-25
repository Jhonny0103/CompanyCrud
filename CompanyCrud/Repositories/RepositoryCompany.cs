using CompanyCrud.Data;
using CompanyCrud.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

#region Script SQL

// View Crear una vista para mostrar toda la información de un empleado.
//CREATE VIEW emp_dept
//AS
//	SELECT 
//		e.EmployeId,
//        e.EmployeName,
//        e.LastName,
//        e.Email,
//        e.PhoneNumber,
//        e.DeptId,
//        d.DeptName,
//        e.CreateDate,
//        e.UpdateDate,
//        e.IsActive
//	FROM Employees as e
//	INNER JOIN Dept as d ON e.DeptId = d.DeptId

#endregion

namespace CompanyCrud.Repositories
{
    public class RepositoryCompany: IRepositoryCompany
    {
        private CompanyContext context;
        public RepositoryCompany( CompanyContext context)
        {
            this.context = context;
        }

        public async Task<Employe> InsertEmployeAsync(Employe employe)
        {
            context.Employees.Add(employe);
            await context.SaveChangesAsync();
            return employe;
        }

        public async Task<List<Employe>> GetEmployeesAsync()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<List<Emp_Dept>> GetEmpDeptAsync()
        {
            return await context.Emp_Depts.ToListAsync();
        }

        public async Task<Employe> GetEmployeByIdAsync(int employeId)
        {
            Employe? employe = await context.Employees.FirstOrDefaultAsync(x => x.EmployeId == employeId);
            if (employe == null)
            {
                throw new Exception($"No existe el empleado con id {employeId}");
            }
            else
            {
                return employe;
            }
        }

        public async Task<Employe> UpdateEmployeAsync(Employe employe)
        {
            Employe? emp = await context.Employees.FirstOrDefaultAsync(x => x.EmployeId == employe.EmployeId);
            if (emp == null)
            {
                throw new Exception($"No existe el empleado con id {employe.EmployeId}");
            }
            else
            {
                emp.EmployeName = employe.EmployeName;
                emp.LastName = employe.LastName;
                emp.Email = employe.Email;
                emp.PhoneNumber = employe.PhoneNumber;
                emp.DeptId = employe.DeptId;
                emp.UpdateDate = DateTime.Now;
                emp.IsActive = employe.IsActive;
                await context.SaveChangesAsync();
                return emp;
            }
        }

        public async Task DeleteEmployeAsync(int employeId)
        {
            Employe? employe = await this.GetEmployeByIdAsync(employeId);
            if (employe == null)
            {
                throw new Exception($"No existe el empleado con id {employeId}");
            }
            context.Employees.Remove(employe);
            await context.SaveChangesAsync();
        }
    }
}
