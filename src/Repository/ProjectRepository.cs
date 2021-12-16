using Domain;
using Domain.Base;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class ProjectRepository : RepositoryBase<Project>,IProjectRepository
    {
        public ProjectRepository(DbContext context)
            : base(context) { }

        public override IList<Project> GetAll()
        {
            return _entities.Set<Project>().Include(x => x.Equipments).Include(r => r.Resources).ToList();
        }

        public Project GetById(long id)
        {
            return _dbset.Include(x => x.Equipments).Include(r => r.Resources).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
