using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service.Interface
{
   public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetCompanyList();
        Task<Company> GetCompanyById(int companyId);
        Task<IEnumerable<Company>> GetCompanyByName(string companyName);
        Task<IEnumerable<Company>> GetCompanyByCategory(int categoryId);
        Task<Company> Create(Company companyModel);
        Task Update(Company companyModel);
        Task Delete(Company companyModel);
    }
}
