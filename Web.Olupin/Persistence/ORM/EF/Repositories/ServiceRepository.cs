using System;
using Microsoft.EntityFrameworkCore;
using MOROPO.ASISTEC.Web.Persistence.Entities;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class ServiceRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Web.Persistence.Entities.Service, System.Guid>
    {
        public ServiceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Web.Persistence.Entities.Service> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(_entity => _entity.FeatureImage);
        }

        public override Func<Service, object> GetPagingOrderSelector()
        {
            return entity => entity.Priority;
        }
    }
}
