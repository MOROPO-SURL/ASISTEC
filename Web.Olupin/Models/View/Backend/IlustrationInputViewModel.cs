using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class IlustrationInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Ilustration, Web.Persistence.Enumerations.IlustrationId>
    {
        public IlustrationId Id { get ; set ; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [FormFileContentTypes(ContentTypes = new string[] { "image/png", "image/jpeg" }, ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }

        public System.Guid ImageId { get; set; }

        public string? ImageExtension { get; set; }


        public Ilustration Export()
        {
            var entity = new Ilustration();

            Mergue(entity);

            return entity;
        }

        public void Import(Ilustration entity)
        {
            Id = entity.Id;
            ImageId = entity.ImageId;
            ImageExtension = MimeTypes.MimeTypeMap.GetExtension(entity.Image.ContentType);
        }

        public void Mergue(Ilustration entity)
        {
            
        }
    }
}
