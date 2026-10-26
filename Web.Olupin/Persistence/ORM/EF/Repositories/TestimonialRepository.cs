using Microsoft.EntityFrameworkCore;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class TestimonialRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Web.Persistence.Entities.Testimonial, System.Guid>
    {
        public TestimonialRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override System.Linq.IQueryable<Web.Persistence.Entities.Testimonial> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet()
                .Include(_entity => _entity.ContextImage)
                .Include(_entity => _entity.RepresentativeImage);
        }
    }
}
