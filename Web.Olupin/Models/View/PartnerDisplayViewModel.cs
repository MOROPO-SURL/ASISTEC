namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class PartnerDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Web.Persistence.Entities.Partner, System.Guid>
    {
        public System.Guid Id { get ; set ; }

        public string Name { get; set; }

        public string About { get; set; }

        public ImageDisplayViewModel Image { get; set; }

        public void Import(Web.Persistence.Entities.Partner entity)
        {
            Id = entity.Id;
            Name = entity.Identity.Name;
            About = entity.Identity.About;
            Image = new ImageDisplayViewModel();

            Image.Import(entity.Identity.Image);
        }
    }
}
