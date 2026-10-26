namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class SolutionDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Web.Persistence.Entities.Solution, int>
    {
        public int Id { get ; set ; }

        public string Title { get; set ; }

        public string Description { get; set ; }

        public bool Enabled { get; set; }

        public string Summary { get; set; }

        public ImageDisplayViewModel FeatureImage { get; set; }

        public System.DateTime At { get; set; }

        public PartnerDisplayViewModel Partner { get; set; }

        public ServiceDisplayViewModel Service { get; set; }

        public void Import(Web.Persistence.Entities.Solution entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            At = entity.At;
            Summary = entity.Summary;
            Description = entity.Description;
            Partner = new PartnerDisplayViewModel();
            Service = new ServiceDisplayViewModel();

            Partner.Import(entity.Partner);
            Service.Import(entity.Service);

            if (entity.FeatureImage != null)
            {
                FeatureImage = new ImageDisplayViewModel();

                FeatureImage.Import(entity.FeatureImage);
            }
        }
    }
}
