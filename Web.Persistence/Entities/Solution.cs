namespace MOROPO.ASISTEC.Web.Persistence.Entities
{
    public class Solution : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<int>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public System.DateTime At { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.MaxLength(255)]
        public string Summary { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Description { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FeatureImageId))]
        public Framework.Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid? FeatureImageId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }
        public System.Guid ServiceId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(PartnerId))]
        public Partner Partner { get; set; }
        public System.Guid PartnerId { get; set; }
    }
}
