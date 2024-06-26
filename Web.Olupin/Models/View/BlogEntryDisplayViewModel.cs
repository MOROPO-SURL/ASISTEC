namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class BlogEntryDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Web.Persistence.Entities.BlogEntry, long>
    {
        public long Id { get; set; }

        public System.DateTime CreatedAt { get; set; }

        public bool Enabled { get; set; }

        public string Title { get; set; }

        public string Label { get; set; }

        public string Context { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public ImageDisplayViewModel FeatureImage { get; set; }

        public void Import(Web.Persistence.Entities.BlogEntry entity)
        {
            Id = entity.Id;
            CreatedAt = entity.CreatedAt;
            Enabled = entity.Enabled;
            Title = entity.Title;
            Label = entity.Label;
            Context = entity.Context;
            Summary = entity.Summary;
            Content = entity.Content;

            if (entity.FeatureImage == null) return;

            FeatureImage = new ImageDisplayViewModel();

            FeatureImage.Import(entity.FeatureImage);
        }
    }
}
