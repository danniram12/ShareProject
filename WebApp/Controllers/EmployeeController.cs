using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Interface;
using DAL.Service;
using DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;
        private ICompanyService companyService;

        public EmployeeController(IEmployeeService empService, ICompanyService compService)
        {
            employeeService = empService ?? throw new ArgumentNullException(nameof(empService));
            companyService = compService ?? throw new ArgumentNullException(nameof(compService));
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            PopulateSelect();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = new Employee();
            if (id > 0)
                employee = await employeeService.GetemployeeById(id);

            return PartialView("_Edit", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Employee employee)
        {
            await employeeService.Create(employee);
            return RedirectToAction("Index");
        }

        private void PopulateSelect()
        {

            List<SelectListItem> selectItems = new List<SelectListItem>();
            var company = companyService.GetCompanyList().Result;
            foreach (var o in company)
            {
                selectItems.Add(new SelectListItem { Text = o.Name, Value = o.CompanyId.ToString(), Selected = false });
            }
            ViewBag.Company = selectItems;
        }
    }
}
