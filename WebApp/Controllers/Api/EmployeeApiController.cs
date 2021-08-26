using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using DAL;
using DAL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Linq.Dynamic;
using DAL.Validator;
using FluentValidation.AspNetCore;

namespace WebApp.Controllers.Api
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService empSrv)
        {
            employeeService = empSrv ?? throw new ArgumentNullException(nameof(empSrv));
        }

        [HttpPost]
        [Route("Update")]
        public async Task Update([FromForm] Employee employee)
        {
            var validator = new EmployeeValidator();
            var results = validator.Validate(employee);

            results.AddToModelState(ModelState, null);
            if (employee.EmployeeId > 0)
                await employeeService.Update(employee);
            else
                await employeeService.Create(employee);
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
            var emp = employeeService.GetemployeeList("Companies").Result;
            List<EmployeeViewModel> resultData = new List<EmployeeViewModel>();
            foreach (var o in emp)
            {
                resultData.Add(new EmployeeViewModel
                {
                    EmployeeId = o.EmployeeId,
                    FirstName = o.FirstName,
                    LastName = o.LastName,
                    Email = o.Email,
                    Phone = o.Phone,
                    CompanyName = o.Companies?.Name
                });
            }
            //Sorting  
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                //resultData = resultData.OrderBy(sortColumn + " " + sortColumnDirection);
            }
            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                resultData = resultData.Where(m => m.FirstName == searchValue).ToList();
            }

            //total number of rows counts   
            recordsTotal = resultData.Count();
            //Paging   
            var data = resultData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data  
            return new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };

            //return result;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task Delete(int id)
        {
            var entityToDelete = await employeeService.GetemployeeById(id);
            await employeeService.Delete(entityToDelete);
        }
    }
}
