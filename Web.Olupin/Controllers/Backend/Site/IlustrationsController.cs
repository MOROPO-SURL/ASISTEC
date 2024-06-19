using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Olupin.Models.View.Backend;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Managers.Facade;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Backend.Site
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("site")]
    public class IlustrationsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<Ilustration, IlustrationId, IlustrationInputViewModel, IlustrationDisplayViewModel>
    {
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IImageFileManagerFacade imageFileManager;

        public IlustrationsController(IImageFileManagerFacade imageFileManager, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Ilustration, IlustrationId> repository, Microsoft.Extensions.Localization.IStringLocalizer<IlustrationsController> localizer, ILogger<IlustrationsController> logger) : base(repository, localizer, logger)
        {
            this.imageRepository = imageRepository;
            this.imageFileManager = imageFileManager;
        }

        [RequirePermissions(Constants.Authorization.IlustrationViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 1000)
        {
            return base.Index(sheet, limit);
        }

        [RequirePermissions(Constants.Authorization.IlustrationCreatorPermission)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequirePermissions(Constants.Authorization.IlustrationCreatorPermission)]
        public override IActionResult Create(IlustrationInputViewModel modelInput)
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

        [RequirePermissions(Constants.Authorization.IlustrationEditorPermission)]
        public override IActionResult Edit(IlustrationId key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Constants.Authorization.IlustrationEditorPermission)]
        public override IActionResult Edit(IlustrationInputViewModel modelInput)
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

        public override IActionResult Delete(IlustrationId key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Authorization.IlustrationRemoverPermission)]
        public override IActionResult Delete(IlustrationDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        protected override void PreCreate(Ilustration entity, IlustrationInputViewModel model)
        {
            base.PreCreate(entity, model);

            using (var memoryStream = new System.IO.MemoryStream())
            {
                model.ImageFile.CopyTo(memoryStream);

                entity.Image = new Image
                {
                    ContentType = model.ImageFile.ContentType,
                    Length = model.ImageFile.Length,
                    About = string.Format("Image for Ilustration: {0}", model.Id)
                };
                entity.ImageId = entity.Image.Id;

                imageFileManager.SaveImageFileContent(entity.ImageId, memoryStream.ToArray(), entity.Image.ContentType);
            }
        }

        protected override void PreEdit(Ilustration entity, IlustrationInputViewModel model)
        {
            base.PreEdit(entity, model);

            if (model.ImageFile == null) return;

            using (var memoryStream = new System.IO.MemoryStream())
            {
                model.ImageFile.CopyTo(memoryStream);

                entity.Image = imageRepository.Add(new Image
                {
                    ContentType = model.ImageFile.ContentType,
                    Length = model.ImageFile.Length,
                    About = string.Format("Image for Ilustration: {0}", model.Id)
                }, User.Identity.Name, false);
                entity.ImageId = entity.Image.Id;

                imageFileManager.SaveImageFileContent(entity.ImageId, memoryStream.ToArray(), entity.Image.ContentType);
            }
        }

        protected override void PostEdit(Ilustration entity, IlustrationInputViewModel model)
        {
            base.PostEdit(entity, model);

            if (model.ImageFile != null)
            {
                var deprecatedImage = imageRepository.Get(model.ImageId);

                imageRepository.Delete(deprecatedImage, User.Identity.Name);

                imageFileManager.DeleteImageFile(deprecatedImage);
            }
        }

        protected override void PostDelete(Ilustration entity)
        {
            base.PostDelete(entity);

            var deprecatedImage = entity.Image;

            imageRepository.Delete(entity.Image, User.Identity.Name);
            imageFileManager.DeleteImageFile(deprecatedImage);
        }

        protected override void ConfigureCreate(IlustrationInputViewModel model)
        {
            base.ConfigureCreate(model);

            PopulateInputViewModel(model);
        }

        protected override void ConfigurePostFailCreateValidation(IlustrationInputViewModel model)
        {
            base.ConfigurePostFailCreateValidation(model);
            PopulateInputViewModel(model);
        }

        private void PopulateInputViewModel(IlustrationInputViewModel model)
        {
            model.AvailableIdSelectListItems = ((IlustrationId[])System.Enum.GetValues(typeof(IlustrationId))).Except(Repository.GetAll().Select(_entity => _entity.Id).ToArray()).Select(_item => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = ((int)_item).ToString(),
                Text = _item.ToString()
            }).ToArray();
        }
    }
}
