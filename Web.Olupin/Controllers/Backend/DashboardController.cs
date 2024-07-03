using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MOROPO.ASISTEC.Web.Olupin.Extensions;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.RequirePermissions(Framework.Guama.Core.Security.Presentation.Constants.Permissions.ShellManager)]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [Framework.Guama.Core.Presentation.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    [Route("[area]/[controller]")]
    [Area("management")]
    public class DashboardController : Framework.Guama.Core.Presentation.Web.Common.Controllers.BaseWebController
    {
        private readonly IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders;
        private readonly IEntityRepository<PageVisit, long> pageVisitRepository;
        private readonly IEntityRepository<ContactRecord, long> contactRecordRepository;

        public DashboardController(IEntityRepository<ContactRecord, long> contactRecordRepository, IEntityRepository<PageVisit, long> pageVisitRepository, IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> managementDashboardSectionProviders, Microsoft.Extensions.Localization.IStringLocalizer<DashboardController> localizer, ILogger<DashboardController> logger) : base(localizer, logger)
        {
            this.managementDashboardSectionProviders = managementDashboardSectionProviders;
            this.pageVisitRepository = pageVisitRepository;
            this.contactRecordRepository = contactRecordRepository;
        }

        public IActionResult Index()
        {
            var now = System.DateTime.Now;

            var weekPageVisit = pageVisitRepository.FindBy(_entity => _entity.CreatedAt > now.AddDays(-5)).ToArray();

            var model = new Models.View.Backend.ManagementDashboardViewModel
            {
                Sections = managementDashboardSectionProviders.ToManagementDashboardSectionGroups(),
                VisitsBySection =
                [
                    pageVisitRepository.Count(_entity => _entity.PageId == Web.Persistence.Enumerations.PageId.About),
                    pageVisitRepository.Count(_entity => _entity.PageId == Web.Persistence.Enumerations.PageId.Services),
                    pageVisitRepository.Count(_entity => _entity.PageId == Web.Persistence.Enumerations.PageId.Products),
                    pageVisitRepository.Count(_entity => _entity.PageId == Web.Persistence.Enumerations.PageId.Solutions),
                    pageVisitRepository.Count(_entity => _entity.PageId == Web.Persistence.Enumerations.PageId.News),
                    pageVisitRepository.Count(_entity => _entity.PageId == Web.Persistence.Enumerations.PageId.Contact)
                ],
                WeekUserActivity =
                [
                    new KeyValuePair<System.DayOfWeek,long>(now.DayOfWeek, weekPageVisit.LongCount(_entity => _entity.CreatedAt.Day == now.Day)),
                    new KeyValuePair<System.DayOfWeek,long>(now.AddDays(-1).DayOfWeek, weekPageVisit.LongCount(_entity => _entity.CreatedAt.Day == now.Day - 1)),
                    new KeyValuePair<System.DayOfWeek,long>(now.AddDays(-2).DayOfWeek, weekPageVisit.LongCount(_entity => _entity.CreatedAt.Day == now.Day - 2)),
                    new KeyValuePair<System.DayOfWeek,long>(now.AddDays(-3).DayOfWeek, weekPageVisit.LongCount(_entity => _entity.CreatedAt.Day == now.Day - 3)),
                    new KeyValuePair<System.DayOfWeek,long>(now.AddDays(-4).DayOfWeek, weekPageVisit.LongCount(_entity => _entity.CreatedAt.Day == now.Day - 4)),
                    new KeyValuePair<System.DayOfWeek,long>(now.AddDays(-5).DayOfWeek, weekPageVisit.LongCount(_entity => _entity.CreatedAt.Day == now.Day - 5)),
                    new KeyValuePair<System.DayOfWeek,long>(now.AddDays(-6).DayOfWeek, weekPageVisit.LongCount(_entity => _entity.CreatedAt.Day == now.Day - 6))
                ],
                UnreadContactRecordCount = contactRecordRepository.Count(_entity => _entity.ReadAt == null),
                WeekContactRecordCount = contactRecordRepository.Count(_entity => _entity.CreatedAt > now.AddDays(-7))
            };

            return View(model);
        }
    }
}
