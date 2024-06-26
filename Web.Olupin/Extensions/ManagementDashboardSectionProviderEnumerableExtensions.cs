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
                Title = "Cambios",
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
                    Title = "Bloques de Texto",
                    Controller = "textblocks",
                    Action= "index",
                    Area = "site",
                    Role = Constants.Authorization.TextBlockViewerPermission
                },
                new ManagementDashboardSectionViewModel
                {
                    Title = "Noticias",
                    Controller = "blogentries",
                    Action= "index",
                    Area = "site",
                    Role = Constants.Authorization.BlogEntryViewerPermission
                }
            };

            var businessContentsSection = new List<ManagementDashboardSectionViewModel>
            {
                new ManagementDashboardSectionViewModel
                {
                    Title = "Representantes",
                    Controller = "representatives",
                    Action= "index",
                    Area = "business",
                    Role = Constants.Authorization.RepresentativeViewerPermission
                },
                new ManagementDashboardSectionViewModel
                {
                    Title = "Servicios",
                    Controller = "services",
                    Action= "index",
                    Area = "business",
                    Role = Constants.Authorization.ServiceViewerPermission
                },
                new ManagementDashboardSectionViewModel
                {
                    Title = "Socios",
                    Controller = "partners",
                    Action= "index",
                    Area = "business",
                    Role = Constants.Authorization.PartnerViewerPermission
                },
                new ManagementDashboardSectionViewModel
                {
                    Title = "Soluciones",
                    Controller = "solutions",
                    Action= "index",
                    Area = "business",
                    Role = Constants.Authorization.SolutionViewerPermission
                },
                new ManagementDashboardSectionViewModel
                {
                    Title = "Testimonios",
                    Controller = "testimonials",
                    Action= "index",
                    Area = "business",
                    Role = Constants.Authorization.TestimonialViewerPermission
                }
            };

            var interactionContentsSection = new List<ManagementDashboardSectionViewModel>
            {
                new ManagementDashboardSectionViewModel
                {
                    Title = "Registro de Contacto",
                    Controller = "contactrecords",
                    Action= "index",
                    Area = "interaction",
                    Role = Constants.Authorization.ContactRecordViewerPermission
                }
            };

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySections },
                { "Contenidos del Sitio", siteContentsSection },
                { "Datos del Negocio", businessContentsSection },
                { "Interación", interactionContentsSection }
            };
        }
    }
}
