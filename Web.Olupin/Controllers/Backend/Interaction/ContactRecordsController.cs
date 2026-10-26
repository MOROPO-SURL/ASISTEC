using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Olupin.Models.View.Backend;
using MOROPO.ASISTEC.Web.Olupin.Models.View;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Backend.Interaction
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("interaction")]
    public class ContactRecordsController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<ContactRecord, long, ContactRecordInputViewModel, ContactRecordDisplayViewModel>
    {
        public ContactRecordsController(IEntityRepository<ContactRecord, long> repository, Microsoft.Extensions.Localization.IStringLocalizer<ContactRecordsController> localizer, ILogger<ContactRecordsController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Constants.Authorization.ContactRecordViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(ContactRecordInputViewModel modelInput)
        {
            return NotFound();
        }

        public override IActionResult Edit(long key)
        {
            return NotFound();
        }

        public override IActionResult Edit(ContactRecordInputViewModel modelInput)
        {
            return NotFound();
        }

        public override IActionResult Delete(long key)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Authorization.ContactRecordRemoverPermission)]
        public override IActionResult Delete(ContactRecordDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        [RequirePermissions(Constants.Authorization.ContactRecordViewerPermission)]
        [Route("[action]/{key}")]
        public IActionResult Details(long key)
        {
            var entity = Repository.Get(key);

            if (entity.ReadAt == null)
            {
                entity.ReadAt = System.DateTime.Now;

                Repository.Update(entity, User.Identity.Name);
            }

            var model = new ContactRecordDisplayViewModel();

            model.Import(entity);

            return View(model);
        }
    }
}
