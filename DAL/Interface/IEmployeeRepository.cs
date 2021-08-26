using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
   public interface IEmployeeRepository:IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeeListAsync();
        Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string EmployeeName);
        Task<Employee> GetEmployeeByIdWithCategoryAsync(int EmployeeId);
    }
}
