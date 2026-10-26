using Microsoft.EntityFrameworkCore;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class PartnerRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Partner, System.Guid>
    {
        public PartnerRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Partner> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(_entity => _entity.Identity).ThenInclude(__entity => __entity.Image);
        }
    }
}
