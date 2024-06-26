using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Persistence.Entities
{
    public class Service : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<System.Guid>, Framework.Guama.Core.Persistence.Entities.Contract.IHabilitableEntity<System.Guid>
    {
        [Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        [Required]
        [MaxLength(255)]
        public string Summary { get; set; }

        [Required]
        public string Description { get; set; }

        public int Priority { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(FeatureImageId))]
        public Framework.Guama.Media.Persistence.Entities.Image FeatureImage { get; set; }
        public System.Guid FeatureImageId { get; set; }
    }
}
