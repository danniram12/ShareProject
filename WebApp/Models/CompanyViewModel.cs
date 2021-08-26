using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Byte[] Logo { get; set; }
        public int Phone { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
