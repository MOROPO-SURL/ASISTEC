using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class ReferenceInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Reference, System.Guid>
    {
        public Guid Id { get ; set ; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [FormFileContentTypes(ContentTypes = new string[] { "image/png", "image/jpeg" }, ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }

        public System.Guid ImageId { get; set; }

        public string? ImageExtension { get; set; }

        public Reference Export()
        {
            var entity = new Reference();

            Mergue(entity);

            return entity;
        }

        public void Import(Reference entity)
        {
            Id = entity.Id;
            ImageId = entity.Identity.ImageId.Value;
            ImageExtension = MimeTypes.MimeTypeMap.GetExtension(entity.Identity.Image.ContentType);
        }

        public void Mergue(Reference entity)
        {
            
        }
    }
}
