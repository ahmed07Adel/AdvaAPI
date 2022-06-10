using Core.Entitties;
using Core.Interfaces;
using Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class DepartementRepository : IDepartement
    {
        private readonly AppDBContext context;

        public DepartementRepository(AppDBContext context)
        {
            this.context  = context;
        }
        public async Task<Departement> CreateDepartement(Departement newdepartement)
        {
            var res = await context.Departements.AddAsync(newdepartement);
            await context.SaveChangesAsync();
            return res.Entity;
        }
        public async Task<Departement> DeleteDepartement(int DepartementID)
        {
            var res = await context.Departements.FirstOrDefaultAsync(e => e.Id == DepartementID);
            if (res != null)
            {
                context.Departements.Remove(res);
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }
        public async Task<IEnumerable> GetAllDepartement()
        {
            var res = await context.Departements.ToListAsync();
            return res;
        }
        public async Task<Departement> GetDepartementByID(int DepartementID)
        {
            var res = await context.Departements.FirstOrDefaultAsync(x => x.Id == DepartementID);
            return res;
        }
        public async Task<Departement> UpdateDepartement(DepartementDto departement)
        {
            var res = await context.Departements.FirstOrDefaultAsync(x => x.Id == departement.Id);
            if (res != null)
            {
                res.Name = departement.Name;
                await context.SaveChangesAsync();
                return res;
            }
            return null;
        }
    }
}
