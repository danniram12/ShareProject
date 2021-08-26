using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class EmployeeRepository : Repository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(Context context) : base(context)
        {
        }

        public Task<IEnumerable<Employee>> GetEmployeeListAsync() {
            throw new Exception();
        }
        public Task<IEnumerable<Employee>> GetEmployeeByNameAsync(string EmployeeName) {
            throw new Exception();
        }
        public Task<Employee> GetEmployeeByIdWithCategoryAsync(int EmployeeId) {
            throw new Exception();
        }
    }
}
