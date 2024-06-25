using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.ASISTEC.Web.Olupin.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySections = new List<ManagementDashboardSectionViewModel>();

            foreach (var provider in self)
            {
                if (provider is Framework.Guama.Security.Personal.Presentation.Web.Backend.Providers.ManagementDashboardSectionProvider)
                {
                    securitySections.AddRange(provider.GetManagementDashboardSections());
                }
            }

            securitySections.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Changes",
                Controller = "traces",
                Action = "index",
                Area = "security",
                Role = Constants.Authorization.TraceViewerPermission
            });

            var siteContentsSection = new List<ManagementDashboardSectionViewModel>
            {
                new ManagementDashboardSectionViewModel
                {
                    Title = "Ilustraciones",
                    Controller = "ilustrations",
                    Action= "index",
                    Area = "site",
                    Role = Constants.Authorization.IlustrationViewerPermission
                },
                new ManagementDashboardSectionViewModel
                {
                    Title = "Text Blocks",
                    Controller = "textblocks",
                    Action= "index",
                    Area = "site",
                    Role = Constants.Authorization.TextBlockViewerPermission
                }
            };

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySections },
                { "Contenidos del Sitio", siteContentsSection },
            };
        }
    }
}
