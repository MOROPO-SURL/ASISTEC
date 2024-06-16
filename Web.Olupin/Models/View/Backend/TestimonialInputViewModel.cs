using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class TestimonialInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Testimonial, System.Guid>
    {
        public Guid Id { get ; set ; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [FormFileContentTypes(ContentTypes = new string[] { "image/png", "image/jpeg" }, ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile ImageFile { get; set; }

        public System.Guid ImageId { get; set; }

        public string? ImageExtension { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "InstitutionName")]
        public string InstitutionName { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "RepresentativeName")]
        public string RepresentativeName { get; set; }

        [Display(Name = "RepresentativePosition")]
        public string RepresentativePosition { get; set; }

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
            ImageId = entity.ContextImageId;
            ImageExtension = MimeTypes.MimeTypeMap.GetExtension(entity.ContextImage.ContentType);
            InstitutionName = entity.InstitutionName;
            RepresentativeName = entity.RepresentativeName;
            RepresentativePosition = entity.RepresentativePosition;
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
