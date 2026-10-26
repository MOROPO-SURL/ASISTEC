namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class ServiceDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Web.Persistence.Entities.Service, System.Guid>
    {
        public System.Guid Id { get ; set ; }

        public string Name { get; set ; }

        public string Description { get; set ; }

        public bool Enabled { get; set; }

        public string Summary { get; set; }

        public ImageDisplayViewModel FeatureImage { get; set; }

        public int Priority { get; set; }

        public void Import(Web.Persistence.Entities.Service entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Summary = entity.Summary;
            Description = entity.Description;
            Priority = entity.Priority;
            FeatureImage = new ImageDisplayViewModel();

            FeatureImage.Import(entity.FeatureImage);
        }
    }
}
