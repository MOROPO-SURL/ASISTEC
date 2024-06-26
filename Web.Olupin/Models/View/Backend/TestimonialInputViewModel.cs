using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class TestimonialInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Testimonial, System.Guid>
    {
        public System.Guid Id { get ; set ; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [FormFileContentTypes(ContentTypes = ["image/png", "image/jpeg"], ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [Display(Name = "ContextImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ContextImageFile { get; set; }

        public System.Guid ContextImageId { get; set; }

        public string ContextImageExtension { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "InstitutionName")]
        public string InstitutionName { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "RepresentativeName")]
        public string RepresentativeName { get; set; }

        [Display(Name = "RepresentativePosition")]
        public string RepresentativePosition { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [FormFileContentTypes(ContentTypes = ["image/png", "image/jpeg"], ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [Display(Name = "RepresentativeImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile RepresentativeImageFile { get; set; }

        public System.Guid RepresentativeImageId { get; set; }

        public string RepresentativeImageExtension { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Review")]
        public string Review { get; set; }

        public Testimonial Export()
        {
            var entity = new Testimonial();

            Mergue(entity);

            return entity;
        }

        public void Import(Testimonial entity)
        {
            Id = entity.Id;
            ContextImageId = entity.ContextImageId;
            ContextImageExtension = MimeTypes.MimeTypeMap.GetExtension(entity.ContextImage.ContentType);
            InstitutionName = entity.InstitutionName;
            RepresentativeName = entity.RepresentativeName;
            RepresentativePosition = entity.RepresentativePosition;
            RepresentativeImageId = entity.RepresentativeImageId;
            RepresentativeImageExtension = MimeTypes.MimeTypeMap.GetExtension(entity.RepresentativeImage.ContentType);
            Review = entity.Review;
        }

        public void Mergue(Testimonial entity)
        {
            entity.InstitutionName = InstitutionName;
            entity.RepresentativeName = RepresentativeName;
            entity.RepresentativePosition = RepresentativePosition;
            entity.Review = Review;
        }
    }
}
