namespace MOROPO.ASISTEC.Web.Persistence.Entities
{
    public class BlogEntry : Framework.Guama.Core.Persistence.Entities.Contract.IHabilitableEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public bool Enabled { get; set; }

        public System.DateTime CreatedAt { get; set; } = System.DateTime.Now;

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Label { get; set; }

        public string Context { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Summary { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Content { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FeatureImageId))]
        public Framework.Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid? FeatureImageId { get; set; }
    }
}
