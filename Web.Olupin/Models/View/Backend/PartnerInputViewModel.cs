using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class PartnerInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Partner, System.Guid>
    {
        public System.Guid Id { get ; set ; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "About")]
        public string About { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [FormFileContentTypes(ContentTypes = ["image/png", "image/jpeg"], ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }

        public System.Guid ImageId { get; set; }

        public string? ImageExtension { get; set; }

        public Partner Export()
        {
            var entity = new Partner
            {
                Identity = new Framework.Guama.Identity.Persistence.Entities.OrganizationIdentity()
            };

            Mergue(entity);

            return entity;
        }

        public void Import(Partner entity)
        {
            Id = entity.Id;
            Name = entity.Identity.Name;
            About = entity.Identity.About;
            ImageId = entity.Identity.ImageId.Value;
            ImageExtension = MimeTypes.MimeTypeMap.GetExtension(entity.Identity.Image.ContentType);
        }

        public void Mergue(Partner entity)
        {
            entity.Identity.Name = Name;
            entity.Identity.About = About;
        }
    }
}
