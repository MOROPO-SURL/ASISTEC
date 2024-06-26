using Microsoft.EntityFrameworkCore;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class RepresentativeRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Web.Persistence.Entities.Representative, System.Guid>
    {
        public RepresentativeRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Web.Persistence.Entities.Representative> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(_entity => _entity.Identity).ThenInclude(_entity => _entity.Image);
        }
    }
}
