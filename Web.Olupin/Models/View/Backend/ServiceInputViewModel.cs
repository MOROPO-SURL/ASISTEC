using MOROPO.ASISTEC.Web.Persistence.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class ServiceInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Service, System.Guid>
    {
        public Guid Id { get ; set ; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public bool Enabled { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public Service Export()
        {
            var entity = new Service();

            Mergue(entity);

            return entity;
        }

        public void Import(Service entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Summary = entity.Summary;
            Description = entity.Description;
        }

        public void Mergue(Service entity)
        {
            entity.Name = Name;
            entity.Enabled = Enabled;
            entity.Summary = Summary;
            entity.Description = Description;
        }
    }
}
