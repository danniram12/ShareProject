using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetemployeeList(string includeString = null);
        Task<Employee> GetemployeeById(int employeeId);
        Task<Employee> GetemployeeBySlug(string slug);
        Task<IEnumerable<Employee>> GetemployeeByName(string employeeName);
        Task<IEnumerable<Employee>> GetemployeeByCategory(int categoryId);
        Task<Employee> Create(Employee employeeModel);
        Task Update(Employee employeeModel);
        Task Delete(Employee employeeModel);
    }
}
