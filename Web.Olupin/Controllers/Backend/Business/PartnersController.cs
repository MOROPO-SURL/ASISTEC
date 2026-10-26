using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Olupin.Models.View.Backend;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Backend.Business
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("business")]
    public class PartnersController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Partner, System.Guid, PartnerInputViewModel, PartnerDisplayViewModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public PartnersController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Partner, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<PartnersController> localizer, ILogger<PartnersController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Constants.Authorization.PartnerViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Constants.Authorization.PartnerCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Constants.Authorization.PartnerCreatorPermission)]
        public override IActionResult Create(PartnerInputViewModel modelInput)
        {
            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    ModelState.ClearValidationState("ImageFile");

                    modelInput.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(modelInput);

                    updateModelTask.Wait();
                }
            }

            return base.Create(modelInput);
        }

        [RequirePermissions(Constants.Authorization.PartnerEditorPermission)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Constants.Authorization.PartnerEditorPermission)]
        public override IActionResult Edit(PartnerInputViewModel modelInput)
        {
            ModelState.ClearValidationState("ImageFile");
            ModelState.MarkFieldValid("ImageFile");

            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    modelInput.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(modelInput);

                    updateModelTask.Wait();
                }
            }

            return base.Edit(modelInput);
        }

        public override IActionResult Delete(System.Guid key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Authorization.PartnerRemoverPermission)]
        public override IActionResult Delete(PartnerDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        protected override void PreCreate(Partner entity, PartnerInputViewModel model)
        {
            base.PreCreate(entity, model);

            if (model.ImageFile == null) return;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                model.ImageFile.CopyTo(memoryStream);

                entity.Identity.Image = new Image
                {
                    ContentType = model.ImageFile.ContentType,
                    Length = model.ImageFile.Length,
                    About = string.Format("Image for Partner: {0}", model.Id)
                };
                entity.Identity.ImageId = entity.Identity.Image.Id;

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, memoryStream.ToArray(), entity.Identity.Image.ContentType);
            }
        }

        protected override void PreEdit(Partner entity, PartnerInputViewModel model)
        {
            base.PreEdit(entity, model);

            if (model.ImageFile == null) return;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                model.ImageFile.CopyTo(memoryStream);

                entity.Identity.Image = imageRepository.Add(new Image
                {
                    ContentType = model.ImageFile.ContentType,
                    Length = model.ImageFile.Length,
                    About = string.Format("Image for Partner: {0}", model.Id)
                }, User.Identity.Name, false);
                entity.Identity.ImageId = entity.Identity.Image.Id;

                imageFileManager.SaveImageFileContent(entity.Identity.Image.Id, memoryStream.ToArray(), entity.Identity.Image.ContentType);
            }
        }

        protected override void PostEdit(Partner entity, PartnerInputViewModel model)
        {
            base.PostEdit(entity, model);

            if (model.ImageFile != null)
            {
                var deprecatedImage = imageRepository.Get(model.ImageId);

                imageRepository.Delete(deprecatedImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(deprecatedImage);
            }
        }

        protected override void PostDelete(Partner entity)
        {
            base.PostDelete(entity);

            var deprecatedImage = entity.Identity.Image;

            imageRepository.Delete(entity.Identity.Image, User.Identity.Name);

            imageFileManager.DeleteImageFile(deprecatedImage);
        }
    }
}
