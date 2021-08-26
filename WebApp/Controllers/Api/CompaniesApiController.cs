using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService companyService;
        public CompaniesController(ICompanyService compService)
        {
            companyService = compService ?? throw new ArgumentNullException(nameof(compService));
        }

        [HttpPost]
        [Route("DataTable")]
        public Object GetEmployeeAsync()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
            // Skip number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();

            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();

            // Sort Column Name  
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            // Sort Column Direction (asc, desc)  
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            // Search Value from (Search box)  
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10, 20, 50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            int recordsTotal = 0;

            // getting all Customer data  
            var customerData = companyService.GetCompanyList().Result;
            //Sorting  
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                //customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
            }
            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerData = customerData.Where(m => m.Name == searchValue);
            }

            //total number of rows counts   
            recordsTotal = customerData.Count();
            //Paging   
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data  
            return new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };

            //return result;
        }

        [HttpPost]
        [Route("Update")]
        public async Task Update([FromForm] Company company)
        {
            if (company.CompanyId > 0)
                await companyService.Update(company);
            else
                await companyService.Create(company);

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            var entityToDelete = companyService.GetCompanyById(id).Result;
            await companyService.Delete(entityToDelete);
        }
    }
}
