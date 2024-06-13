using Microsoft.EntityFrameworkCore;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class TestimonialRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<Testimonial, System.Guid>
    {
        public TestimonialRepository(DbContext dbContext) : base(dbContext)
        {
        }

        protected override IQueryable<Testimonial> GetQueryableDbSet()
        {
            return base.GetQueryableDbSet().Include(entity => entity.ContextImage);
        }
    }
}
