using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository empRepo)
        {
            employeeRepository = empRepo ?? throw new ArgumentNullException(nameof(empRepo));

        }
        public async Task<Employee> Create(Employee employeeModel)
        {
            var emmp = await employeeRepository.AddAsync(employeeModel);
            return emmp;
        }

        public async Task Delete(Employee employeeModel)
        {
            await employeeRepository.DeleteAsync(employeeModel);
        }

        public async Task<IEnumerable<Employee>> GetemployeeByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetemployeeById(int employeeId)
        {
            return await employeeRepository.GetByIdAsync(employeeId);
        }

        public Task<IEnumerable<Employee>> GetemployeeByName(string employeeName)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetemployeeBySlug(string slug)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetemployeeList(string includeString = null)
        {
            var result = await employeeRepository.GetAllAsync(includeString);
            return result;
        }

        public async Task Update(Employee employeeModel)
        {
            await employeeRepository.UpdateAsync(employeeModel);
        }
    }
}
