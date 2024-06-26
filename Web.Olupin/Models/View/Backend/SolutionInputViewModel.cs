using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class SolutionInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<Solution, int>
    {
        public int Id { get ; set ; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        public System.DateTime At { get; set; } = System.DateTime.Now;

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Service")]
        public System.Guid ServiceId { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Partner")]
        public System.Guid PartnerId { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [FormFileContentTypes(ContentTypes = ["image/png", "image/jpeg"], ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile FeatureImageFile { get; set; }

        public System.Guid? FeatureImageId { get; set; }

        public string FeatureImageExtension { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] AvailableServiceSelectListItems { get; set; }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectListItem[] AvailablePartnerSelectListItems { get; set; }

        public Solution Export()
        {
            var entity = new Solution();

            Mergue(entity);

            return entity;
        }

        public void Import(Solution entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            At = entity.At;
            Summary = entity.Summary;
            Description = entity.Description;
            FeatureImageId = entity.FeatureImageId;
            FeatureImageExtension = MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
        }

        public void Mergue(Solution entity)
        {
            entity.Title = Title;
            entity.At = At;
            entity.Summary = Summary;
            entity.Description = Description;
            entity.PartnerId = PartnerId;
            entity.ServiceId = ServiceId;
        }
    }
}
