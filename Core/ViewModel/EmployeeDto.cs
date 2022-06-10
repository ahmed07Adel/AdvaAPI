using Core.Entitties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Salary { get; set; }
        public string? ManagerName { get; set; }
        //public int? DepartementId { get; set; }
        public Departement Departement { get; set; }

    }
}
