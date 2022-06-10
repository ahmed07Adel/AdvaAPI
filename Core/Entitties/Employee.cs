using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitties
{
    public class Employee : BaseEntity
    {
        public string? Name { get; set; }
        public decimal? Salary { get; set; }
        public string? ManagerName { get; set; }
        //public int? DepartementId { get; set; }
        public Departement Departement { get; set; }
    }
}
