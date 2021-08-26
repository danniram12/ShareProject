using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mapper
{
  public  class EmployeeViewModel
    {
            public int EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int CompanyId { get; set; }
            public CompanyViewModel Companies { get; set; }
            public string Email { get; set; }
            public int Phone { get; set; }
        
    }
}
