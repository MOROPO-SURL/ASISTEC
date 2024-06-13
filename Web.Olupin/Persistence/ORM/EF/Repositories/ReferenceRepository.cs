using Microsoft.EntityFrameworkCore;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class ReferenceRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Reference, System.Guid>
    {
        public ReferenceRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Reference> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(_entity => _entity.Identity).ThenInclude(__entity => __entity.Image);
        }
    }
}
