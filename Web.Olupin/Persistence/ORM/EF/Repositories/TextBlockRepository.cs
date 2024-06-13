using Microsoft.EntityFrameworkCore;
using MOROPO.ASISTEC.Web.Persistence.Entities;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Repositories
{
    public class TextBlockRepository : Framework.Guama.Core.Persistence.ORM.EF.Repositories.Contract.AbstractEntityRepository<TextBlock, Web.Persistence.Enumerations.TextBlockId>
    {
        public TextBlockRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
