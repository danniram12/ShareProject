using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Byte[] Logo { get; set; }
        public string WebSite { get; set; }
        public string Phone { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
