using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class TextBlockInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<TextBlock, Web.Persistence.Enumerations.TextBlockId>
    {
        public TextBlockId Id { get ; set ; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public TextBlock Export()
        {
            var entity = new TextBlock { Id = Id };

            Mergue(entity);

            return entity;
        }

        public void Import(TextBlock entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;
        }

        public void Mergue(TextBlock entity)
        {
            entity.Title = Title;
            entity.Description = Description;
        }
    }
}
