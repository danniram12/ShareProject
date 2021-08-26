using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public Company Companies { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}
