using System.Linq;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;

namespace MOROPO.ASISTEC.Web.Olupin.Helpers
{
    public class DataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            #region TextBlocks

            var textBlockDbSet = dbContext.Set<TextBlock>();

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.HomeHero))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.HomeHero, Title = "Arreglando tu vida", Description = "Shun fabled prose amiss ways are fathers to felt which what call in one such a of was in sick thee atonement to ofttimes fame way vulgar in lemans his ofttimes plain of heavenly pomp mirthful delight for bliss parting and he resolved could mote are so crime his would awake tales ways suits his harold could with sight it to unto seek and to like to a sea prose could cheer whence a men aisle his one he of that favour he done sacred muse dote or yet third he apart climes sad tis his none was in that sighed to as for memory another lands full his or had the now gathered not his oer that flaunting still" });
            }
            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.HomeAboutSummary))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.HomeAboutSummary, Title = "ASISTECT S.R.L.", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }
            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.HomeMainPromo))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.HomeMainPromo, Title = "Refresca tu vida con calidad y estilo", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }
            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.HomeServicesHeader))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.HomeServicesHeader, Title = "Nuestros Servicios", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }
            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.HomeProductsHeader))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.HomeProductsHeader, Title = "Nuestros Productos", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }
            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.HomeTestimonialsHeader))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.HomeTestimonialsHeader, Title = "Nuestros Referencias", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }
            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.HomePartnersHeader))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.HomePartnersHeader, Title = "Nuestros Socios", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }
            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.HomeCallToAction))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.HomeCallToAction, Title = "Necesitas un aliado confiable en servicios (...) ?", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.AboutIntro))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.AboutIntro, Title = "Nosotros", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.AboutMission))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.AboutMission, Title = "Misión", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.AboutVision))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.AboutVision, Title = "Visión", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.AboutValues))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.AboutValues, Title = "Valores", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.AboutHistory))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.AboutHistory, Title = "Historia", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.ServicesIntro))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.ServicesIntro, Title = "Servicios", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.ProductsIntro))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.ProductsIntro, Title = "Productos", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.SolutionsIntro))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.SolutionsIntro, Title = "Soluciones", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.NewsIntro))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.NewsIntro, Title = "Noticias", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            if (!textBlockDbSet.Any(entity => entity.Id == TextBlockId.ContactIntro))
            {
                textBlockDbSet.Add(new TextBlock { Id = TextBlockId.ContactIntro, Title = "Contacto", Description = "Gubergren no accumsan illum consetetur hendrerit gubergren consequat voluptua facilisis invidunt ut justo diam duis soluta enim nonumy duis amet" });
            }

            #endregion

            #region Permissions

            var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

            if (!permissionDbSet.Any(role => role.Code.Equals(Constants.Authorization.TraceViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TraceViewerPermission.ToPermissionEntity());
            }

            #region Ilustration

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.IlustrationViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.IlustrationViewerPermission.ToPermissionEntity(Constants.Authorization.IlustrationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.IlustrationCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.IlustrationCreatorPermission.ToPermissionEntity(Constants.Authorization.IlustrationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.IlustrationEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.IlustrationEditorPermission.ToPermissionEntity(Constants.Authorization.IlustrationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.IlustrationRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.IlustrationRemoverPermission.ToPermissionEntity(Constants.Authorization.IlustrationManagementPermissionGroup));
            }

            #endregion

            #region TextBlock

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TextBlockViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TextBlockViewerPermission.ToPermissionEntity(Constants.Authorization.TextBlockManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TextBlockCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TextBlockCreatorPermission.ToPermissionEntity(Constants.Authorization.TextBlockManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TextBlockEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TextBlockEditorPermission.ToPermissionEntity(Constants.Authorization.TextBlockManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TextBlockRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TextBlockRemoverPermission.ToPermissionEntity(Constants.Authorization.TextBlockManagementPermissionGroup));
            }

            #endregion

            #region Partner

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.PartnerViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.PartnerViewerPermission.ToPermissionEntity(Constants.Authorization.PartnerManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.PartnerCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.PartnerCreatorPermission.ToPermissionEntity(Constants.Authorization.PartnerManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.PartnerEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.PartnerEditorPermission.ToPermissionEntity(Constants.Authorization.PartnerManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.PartnerRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.PartnerRemoverPermission.ToPermissionEntity(Constants.Authorization.PartnerManagementPermissionGroup));
            }

            #endregion

            #region Testimonial

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TestimonialViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TestimonialViewerPermission.ToPermissionEntity(Constants.Authorization.TestimonialManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TestimonialCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TestimonialCreatorPermission.ToPermissionEntity(Constants.Authorization.TestimonialManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TestimonialEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TestimonialEditorPermission.ToPermissionEntity(Constants.Authorization.TestimonialManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.TestimonialRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.TestimonialRemoverPermission.ToPermissionEntity(Constants.Authorization.TestimonialManagementPermissionGroup));
            }

            #endregion

            #region Service

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.ServiceViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.ServiceViewerPermission.ToPermissionEntity(Constants.Authorization.ServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.ServiceCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.ServiceCreatorPermission.ToPermissionEntity(Constants.Authorization.ServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.ServiceEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.ServiceEditorPermission.ToPermissionEntity(Constants.Authorization.ServiceManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.ServiceRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.ServiceRemoverPermission.ToPermissionEntity(Constants.Authorization.ServiceManagementPermissionGroup));
            }

            #endregion

            #region BlogEntry

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.BlogEntryViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.BlogEntryViewerPermission.ToPermissionEntity(Constants.Authorization.BlogEntryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.BlogEntryCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.BlogEntryCreatorPermission.ToPermissionEntity(Constants.Authorization.BlogEntryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.BlogEntryEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.BlogEntryEditorPermission.ToPermissionEntity(Constants.Authorization.BlogEntryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.BlogEntryRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.BlogEntryRemoverPermission.ToPermissionEntity(Constants.Authorization.BlogEntryManagementPermissionGroup));
            }

            #endregion

            #region Solution

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.SolutionViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.SolutionViewerPermission.ToPermissionEntity(Constants.Authorization.SolutionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.SolutionCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.SolutionCreatorPermission.ToPermissionEntity(Constants.Authorization.SolutionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.SolutionEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.SolutionEditorPermission.ToPermissionEntity(Constants.Authorization.SolutionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.SolutionRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.SolutionRemoverPermission.ToPermissionEntity(Constants.Authorization.SolutionManagementPermissionGroup));
            }

            #endregion

            #region Representative

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.RepresentativeViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.RepresentativeViewerPermission.ToPermissionEntity(Constants.Authorization.RepresentativeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.RepresentativeCreatorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.RepresentativeCreatorPermission.ToPermissionEntity(Constants.Authorization.RepresentativeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.RepresentativeEditorPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.RepresentativeEditorPermission.ToPermissionEntity(Constants.Authorization.RepresentativeManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.RepresentativeRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.RepresentativeRemoverPermission.ToPermissionEntity(Constants.Authorization.RepresentativeManagementPermissionGroup));
            }

            #endregion

            #region ContactRecord

            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.ContactRecordViewerPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.ContactRecordViewerPermission.ToPermissionEntity(Constants.Authorization.ContactRecordManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Constants.Authorization.ContactRecordRemoverPermission)))
            {
                permissionDbSet.Add(Constants.Authorization.ContactRecordRemoverPermission.ToPermissionEntity(Constants.Authorization.ContactRecordManagementPermissionGroup));
            }

            #endregion

            #endregion

            if (dbContext is Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)
            {
                ((Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)dbContext).SaveChanges("system");
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}
