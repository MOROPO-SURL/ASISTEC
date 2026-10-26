using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Olupin.Models.View.Backend;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Backend.Business
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("business")]
    public class TestimonialsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Testimonial, System.Guid, TestimonialInputViewModel, TestimonialDisplayViewModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public TestimonialsController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Testimonial, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<TestimonialsController> localizer, ILogger<TestimonialsController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Constants.Authorization.TestimonialViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Constants.Authorization.TestimonialCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Constants.Authorization.TestimonialCreatorPermission)]
        public override IActionResult Create(TestimonialInputViewModel modelInput)
        {
            if (Request.Form.Files.Count > 0)
            {
                var contextImageFile = Request.Form.Files.FirstOrDefault(_item => _item.Name == "ContextImageFile");
                var representatinveImageFile = Request.Form.Files.FirstOrDefault(_item => _item.Name == "RepresentativeImageFile");

                if (contextImageFile != null)
                {
                    ModelState.ClearValidationState("ContextImageFile");

                    modelInput.ContextImageFile = contextImageFile;
                }

                if (representatinveImageFile != null)
                {
                    ModelState.ClearValidationState("RepresentativeImageFile");

                    modelInput.RepresentativeImageFile = representatinveImageFile;
                }

                var updateModelTask = TryUpdateModelAsync(modelInput);

                updateModelTask.Wait();
            }

            return base.Create(modelInput);
        }

        [RequirePermissions(Constants.Authorization.TestimonialEditorPermission)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Constants.Authorization.TestimonialEditorPermission)]
        public override IActionResult Edit(TestimonialInputViewModel modelInput)
        {
            ModelState.ClearValidationState("ContextImageFile");
            ModelState.ClearValidationState("RepresentativeImageFile");
            ModelState.MarkFieldValid("ContextImageFile");
            ModelState.MarkFieldValid("RepresentativeImageFile");

            if (Request.Form.Files.Count > 0)
            {
                var contextImageFile = Request.Form.Files.FirstOrDefault(_item => _item.Name == "ContextImageFile");
                var representatinveImageFile = Request.Form.Files.FirstOrDefault(_item => _item.Name == "RepresentativeImageFile");

                if (contextImageFile != null)
                {
                    ModelState.ClearValidationState("ContextImageFile");

                    modelInput.ContextImageFile = contextImageFile;
                }

                if (representatinveImageFile != null)
                {
                    ModelState.ClearValidationState("RepresentativeImageFile");

                    modelInput.RepresentativeImageFile = representatinveImageFile;
                }

                var updateModelTask = TryUpdateModelAsync(modelInput);

                updateModelTask.Wait();
            }

            return base.Edit(modelInput);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Authorization.TestimonialRemoverPermission)]
        public override IActionResult Delete(TestimonialDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        protected override void PreCreate(Testimonial entity, TestimonialInputViewModel model)
        {
            base.PreCreate(entity, model);

            if (model.ContextImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    model.ContextImageFile.CopyTo(memoryStream);

                    entity.ContextImage = new Image
                    {
                        ContentType = model.ContextImageFile.ContentType,
                        Length = model.ContextImageFile.Length,
                        About = string.Format("Image for Testimonial Context: {0}", model.Id)
                    };
                    entity.ContextImageId = entity.ContextImage.Id;

                    imageFileManager.SaveImageFileContent(entity.ContextImageId, memoryStream.ToArray(), entity.ContextImage.ContentType);
                }
            }

            if (model.RepresentativeImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    model.RepresentativeImageFile.CopyTo(memoryStream);

                    entity.RepresentativeImage = new Image
                    {
                        ContentType = model.RepresentativeImageFile.ContentType,
                        Length = model.RepresentativeImageFile.Length,
                        About = string.Format("Image for Testimonial Representative: {0}", model.Id)
                    };
                    entity.RepresentativeImageId = entity.RepresentativeImage.Id;

                    imageFileManager.SaveImageFileContent(entity.RepresentativeImageId, memoryStream.ToArray(), entity.RepresentativeImage.ContentType);
                }
            }
        }

        protected override void PreEdit(Testimonial entity, TestimonialInputViewModel model)
        {
            base.PreEdit(entity, model);

            if (model.ContextImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    model.ContextImageFile.CopyTo(memoryStream);

                    entity.ContextImage = new Image
                    {
                        ContentType = model.ContextImageFile.ContentType,
                        Length = model.ContextImageFile.Length,
                        About = string.Format("Image for Testimonial Context: {0}", model.Id)
                    };
                    entity.ContextImageId = entity.ContextImage.Id;

                    imageFileManager.SaveImageFileContent(entity.ContextImageId, memoryStream.ToArray(), entity.ContextImage.ContentType);
                }
            }

            if (model.RepresentativeImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    model.RepresentativeImageFile.CopyTo(memoryStream);

                    entity.RepresentativeImage = new Image
                    {
                        ContentType = model.RepresentativeImageFile.ContentType,
                        Length = model.RepresentativeImageFile.Length,
                        About = string.Format("Image for Testimonial Representative: {0}", model.Id)
                    };
                    entity.RepresentativeImageId = entity.RepresentativeImage.Id;

                    imageFileManager.SaveImageFileContent(entity.RepresentativeImageId, memoryStream.ToArray(), entity.RepresentativeImage.ContentType);
                }
            }
        }

        protected override void PostEdit(Testimonial entity, TestimonialInputViewModel model)
        {
            base.PostEdit(entity, model);

            if (model.ContextImageFile != null)
            {
                var deprecatedContextImage = imageRepository.Get(model.ContextImageId);

                imageRepository.Delete(deprecatedContextImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(deprecatedContextImage);
            }

            if (model.RepresentativeImageFile != null)
            {
                var deprecatedRepresentativeImage = imageRepository.Get(model.RepresentativeImageId);

                imageRepository.Delete(deprecatedRepresentativeImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(deprecatedRepresentativeImage);
            }
        }

        protected override void PostDelete(Testimonial entity)
        {
            base.PostDelete(entity);

            var deprecatedContextImage = entity.ContextImage;

            imageRepository.Delete(entity.ContextImage, User.Identity.Name);

            imageFileManager.DeleteImageFile(deprecatedContextImage);

            var deprecatedRepresentativeImage = entity.RepresentativeImage;

            imageRepository.Delete(entity.RepresentativeImage, User.Identity.Name);

            imageFileManager.DeleteImageFile(deprecatedRepresentativeImage);
        }
    }
}
