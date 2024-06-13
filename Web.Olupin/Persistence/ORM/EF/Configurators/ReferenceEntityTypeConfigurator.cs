using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MOROPO.ASISTEC.Web.Persistence.Entities;

namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Configurators
{
    public class ReferenceEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<Reference>
    {
        protected override void ApplayRules(EntityTypeBuilder<Reference> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(_entity => _entity.Identity).WithOne().HasForeignKey<Reference>(_entity => _entity.IdentityId).IsRequired();
        }
    }
}
