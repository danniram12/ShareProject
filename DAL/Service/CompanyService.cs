using DAL.Interface;
using DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository companyRepository;
        public CompanyService(ICompanyRepository comRepo)
        {
            companyRepository = comRepo ?? throw new ArgumentNullException(nameof(comRepo));
        }
        public async Task<Company> Create(Company companyModel)
        {
            var comp =await companyRepository.AddAsync(companyModel);
            return comp;
        }

        public async Task Delete(Company CompanyModel)
        {
          await  companyRepository.DeleteAsync(CompanyModel);
        }

        public Task<IEnumerable<Company>> GetCompanyByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetCompanyById(int companyId)
        {
           return await companyRepository.GetByIdAsync(companyId);
        }

        public Task<IEnumerable<Company>> GetCompanyByName(string companyName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetCompanyList()
        {
            return await companyRepository.GetAllAsync();
        }


        public async Task Update(Company CompanyModel)
        {
            await companyRepository.UpdateAsync(CompanyModel);
        }
    }
}
