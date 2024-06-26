using Microsoft.EntityFrameworkCore;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class SolutionRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Web.Persistence.Entities.Solution, int>
    {
        public SolutionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Web.Persistence.Entities.Solution> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(_entity => _entity.FeatureImage)
                .Include(_entity => _entity.Partner).ThenInclude(_entity => _entity.Identity).ThenInclude(_entity => _entity.Image)
                .Include(_entity => _entity.Service).ThenInclude(_entity => _entity.FeatureImage);
        }
    }
}
