using MOROPO.Framework.Guama.Media.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Persistence.Entities
{
    public class Testimonial : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<System.Guid>
    {
        [Key]
        public System.Guid Id { get; set; } = System.Guid.NewGuid();

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ContextImageId))]
        public Image ContextImage { get; set; }
        public System.Guid ContextImageId { get; set; }

        [Required]
        public string InstitutionName { get; set; }

        [Required]
        public string RepresentativeName {  get; set; }

        public string RepresentativePosition { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(RepresentativeImageId))]
        public Image RepresentativeImage { get; set; }
        public System.Guid RepresentativeImageId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Review {  get; set; }
    }
}
