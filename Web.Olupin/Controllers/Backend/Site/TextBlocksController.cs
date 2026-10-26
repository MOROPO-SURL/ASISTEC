using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.Framework.Guama.Core.Presentation.Web.Security.Attributes;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Olupin.Models.View.Backend;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Backend.Site
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Area("site")]
    public class TextBlocksController : Framework.Guama.Core.Presentation.Web.Backend.Controllers.AbstractEntityManagementController<TextBlock, TextBlockId, TextBlockInputViewModel, TextBlockDisplayViewModel>
    {
        public TextBlocksController(Framework.Guama.Core.Persistence.Repositories.IEntityRepository<TextBlock, TextBlockId> repository, Microsoft.Extensions.Localization.IStringLocalizer<TextBlocksController> localizer, ILogger<TextBlocksController> logger) : base(repository, localizer, logger)
        {
        }

        [RequirePermissions(Constants.Authorization.TextBlockViewerPermission)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        public override IActionResult Create()
        {
            return NotFound();
        }

        public override IActionResult Create(TextBlockInputViewModel modelInput)
        {
            return NotFound();
        }

        [RequirePermissions(Constants.Authorization.TextBlockViewerPermission)]
        public override IActionResult Edit(TextBlockId key)
        {
            return base.Edit(key);
        }

        [RequirePermissions(Constants.Authorization.TextBlockViewerPermission)]
        public override IActionResult Edit(TextBlockInputViewModel modelInput)
        {
            return base.Edit(modelInput);
        }

        public override IActionResult Delete(TextBlockId key)
        {
            return NotFound();
        }

        public override IActionResult Delete(TextBlockDisplayViewModel displayModel)
        {
            return NotFound();
        }
    }
}
