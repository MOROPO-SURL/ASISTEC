using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Olupin.Models.View.Backend;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Backend.Business
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("business")]
    public class SolutionsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Solution, int, SolutionInputViewModel, SolutionDisplayViewModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;
        private readonly IEntityRepository<Partner, System.Guid> partnerRepository;
        private readonly IEntityRepository<Service, System.Guid> serviceRepository;

        public SolutionsController(IEntityRepository<Service, System.Guid> serviceRepository, IEntityRepository<Partner, System.Guid> partnerRepository, IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Solution, int> repository, Microsoft.Extensions.Localization.IStringLocalizer<SolutionsController> localizer, ILogger<SolutionsController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
            this.partnerRepository = partnerRepository;
            this.serviceRepository = serviceRepository;
        }

        [RequirePermissions(Constants.Authorization.SolutionViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Constants.Authorization.SolutionCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Constants.Authorization.SolutionCreatorPermission)]
        public override IActionResult Create(SolutionInputViewModel modelInput)
        {
            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    ModelState.ClearValidationState("FeatureImageFile");

                    modelInput.FeatureImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(modelInput);

                    updateModelTask.Wait();
                }
            }

            return base.Create(modelInput);
        }

        [RequirePermissions(Constants.Authorization.SolutionEditorPermission)]
        public override IActionResult Edit(int key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Constants.Authorization.SolutionEditorPermission)]
        public override IActionResult Edit(SolutionInputViewModel modelInput)
        {
            ModelState.ClearValidationState("FeatureImageFile");
            ModelState.MarkFieldValid("FeatureImageFile");

            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    modelInput.FeatureImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(modelInput);

                    updateModelTask.Wait();
                }
            }

            return base.Edit(modelInput);
        }

        public override IActionResult Delete(int key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Authorization.SolutionRemoverPermission)]
        public override IActionResult Delete(SolutionDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        protected override void PreCreate(Solution entity, SolutionInputViewModel model)
        {
            base.PreCreate(entity, model);

            if (model.FeatureImageFile == null) return;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                model.FeatureImageFile.CopyTo(memoryStream);

                entity.FeatureImage = new Image
                {
                    ContentType = model.FeatureImageFile.ContentType,
                    Length = model.FeatureImageFile.Length,
                    About = string.Format("Image for Solution: {0}", model.Id)
                };
                entity.FeatureImageId = entity.FeatureImage.Id;

                imageFileManager.SaveImageFileContent(entity.FeatureImageId.Value, memoryStream.ToArray(), entity.FeatureImage.ContentType);
            }
        }

        protected override void PreEdit(Solution entity, SolutionInputViewModel model)
        {
            base.PreEdit(entity, model);

            if (model.FeatureImageFile == null) return;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                model.FeatureImageFile.CopyTo(memoryStream);

                entity.FeatureImage = imageRepository.Add(new Image
                {
                    ContentType = model.FeatureImageFile.ContentType,
                    Length = model.FeatureImageFile.Length,
                    About = string.Format("Image for Solution: {0}", model.Id)
                }, User.Identity.Name, false);
                entity.FeatureImageId = entity.FeatureImage.Id;

                imageFileManager.SaveImageFileContent(entity.FeatureImageId.Value, memoryStream.ToArray(), entity.FeatureImage.ContentType);
            }
        }

        protected override void PostEdit(Solution entity, SolutionInputViewModel model)
        {
            base.PostEdit(entity, model);

            if (model.FeatureImageFile != null)
            {
                var deprecatedImage = imageRepository.Get(model.FeatureImageId.Value);

                imageRepository.Delete(deprecatedImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(deprecatedImage);
            }
        }

        protected override void PostDelete(Solution entity)
        {
            base.PostDelete(entity);

            if (entity.FeatureImageId == null) return;

            var deprecatedImage = entity.FeatureImage;

            imageRepository.Delete(entity.FeatureImage, User.Identity.Name);

            imageFileManager.DeleteImageFile(deprecatedImage);
        }

        protected override void ConfigureCreate(SolutionInputViewModel model)
        {
            PopulateModelInput(model);

            base.ConfigureCreate(model);
        }

        protected override void ConfigurePostFailCreateValidation(SolutionInputViewModel model)
        {
            PopulateModelInput(model);

            base.ConfigurePostFailCreateValidation(model);
        }

        protected override void ConfigureEdit(Solution entity, SolutionInputViewModel model)
        {
            PopulateModelInput(model);

            base.ConfigureEdit(entity, model);
        }

        protected override void ConfigurePostFailEditValidation(Solution entity, SolutionInputViewModel model)
        {
            PopulateModelInput(model);

            base.ConfigurePostFailEditValidation(entity, model);
        }

        private void PopulateModelInput(SolutionInputViewModel model)
        {
            model.AvailablePartnerSelectListItems = partnerRepository.GetAll().ToArray().Select(entity => new SelectListItem { Value = entity.Id.ToString(), Text = entity.Identity.Name }).ToArray();

            model.AvailableServiceSelectListItems = serviceRepository.GetAll().ToArray().Select(entity => new SelectListItem { Value = entity.Id.ToString(), Text = entity.Name }).ToArray();
        }
    }
}
