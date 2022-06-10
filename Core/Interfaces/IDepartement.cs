using Core.Entitties;
using Core.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDepartement
    {
        Task<Departement> CreateDepartement(Departement newdepartement);
        Task<IEnumerable> GetAllDepartement();
        Task<Departement> GetDepartementByID(int DepartementID);
        Task<Departement> UpdateDepartement(DepartementDto departement);
        Task<Departement> DeleteDepartement(int DepartementID);
    }
}
