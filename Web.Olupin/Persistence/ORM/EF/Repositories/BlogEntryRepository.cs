using Microsoft.EntityFrameworkCore;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class BlogEntryRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Web.Persistence.Entities.BlogEntry, long>
    {
        public BlogEntryRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Web.Persistence.Entities.BlogEntry> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(_entity => _entity.FeatureImage);
        }
    }
}
