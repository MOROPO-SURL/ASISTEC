using Microsoft.EntityFrameworkCore;
using MOROPO.ASISTEC.Web.Persistence.Entities;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class ServiceRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Service, System.Guid>
    {
        public ServiceRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
