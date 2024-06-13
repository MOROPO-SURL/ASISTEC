using Microsoft.EntityFrameworkCore;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using System.IO;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class IlustrationRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Ilustration, Web.Persistence.Enumerations.IlustrationId>
    {
        public IlustrationRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Ilustration> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.Image);
        }
    }
}
