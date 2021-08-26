using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;
        public CompaniesController(ICompanyService comService)
        {
            companyService = comService ?? throw new ArgumentNullException(nameof(comService));
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            Company company = new Company();
            if (id > 0)
                company = await companyService.GetCompanyById(id);
            return PartialView("_Edit", company);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Company company)
        {
            await companyService.Create(company);
            return RedirectToAction("Index");
        }

    }
}
