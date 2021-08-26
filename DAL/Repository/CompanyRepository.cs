using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(Context context) : base(context)
        {
        }

        public Task<Company> GetCompanyByIdWithCategoryAsync(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetCompanyByNameAsync(string CompanyName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetCompanyListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
