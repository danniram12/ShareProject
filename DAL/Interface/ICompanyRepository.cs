using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
  public  interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<Company>> GetCompanyListAsync();
        Task<IEnumerable<Company>> GetCompanyByNameAsync(string CompanyName);
        Task<Company> GetCompanyByIdWithCategoryAsync(int CompanyId);
    }
}
