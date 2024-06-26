namespace MOROPO.ASISTEC.Web.Olupin.Persistence.ORM.EF.Configurators
{
    public class RepresentativeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.AbstractEntityTypeConfigurator<Web.Persistence.Entities.Representative>
    {
        protected override void ApplayRules(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Web.Persistence.Entities.Representative> entityTypeBuilder)
        {
            base.ApplayRules(entityTypeBuilder);

            entityTypeBuilder.HasOne(entity => entity.Identity).WithOne().HasForeignKey<Web.Persistence.Entities.Representative>(entity => entity.IdentityId).IsRequired();
        }
    }
}
