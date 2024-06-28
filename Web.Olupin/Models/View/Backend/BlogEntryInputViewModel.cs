using MOROPO.Framework.Guama.Core.Presentation.Web.Common.ComponentModel.DataAnnotations;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class BlogEntryInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<BlogEntry, long>
    {
        public long Id { get; set; }

        [Display(Name = "Enabled")]
        public bool Enabled { get; set; } = true;

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Date")]
        public System.DateTime CreatedAt { get; set; } = System.DateTime.Now;

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Label")]
        public string Label { get; set; }

        [Display(Name = "Context")]
        public string Context { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [MaxLength(255)]
        [Display(Name = "Summary")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [FormFileContentTypes(ContentTypes = new string[] { "image/png", "image/jpeg" }, ErrorMessage = "PNG_JPEG_FileAllowedOnlyMessage")]
        [Display(Name = "ImageFile")]
        public Microsoft.AspNetCore.Http.IFormFile FeatureImageFile { get; set; }

        public System.Guid? FeatureImageId { get; set; }

        public string FeatureImageExtension { get; set; }

        public BlogEntry Export()
        {
            var entity = new BlogEntry();

            Mergue(entity);

            return entity;
        }

        public void Import(BlogEntry entity)
        {
            Id = entity.Id;
            Enabled = entity.Enabled;
            Title = entity.Title;
            Label = entity.Label;
            Context = entity.Context;
            Summary = entity.Summary;
            Content = entity.Content;
            CreatedAt = entity.CreatedAt;
            FeatureImageId = entity.FeatureImageId;
            FeatureImageExtension = entity.FeatureImageId == null ? null : MimeTypes.MimeTypeMap.GetExtension(entity.FeatureImage.ContentType);
        }

        public void Mergue(BlogEntry entity)
        {
            entity.Enabled = Enabled;
            entity.CreatedAt = CreatedAt;
            entity.Title = Title;
            entity.Label = Label;
            entity.Context = Context;
            entity.Summary = Summary;
            entity.Content = Content;
        }
    }
}
