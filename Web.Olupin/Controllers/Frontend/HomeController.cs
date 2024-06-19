using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Frontend
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public readonly IEntityRepository<Ilustration, IlustrationId> ilustrationRepository;

        public HomeController(IEntityRepository<Ilustration, IlustrationId> ilustrationRepository)
        {
            this.ilustrationRepository = ilustrationRepository;
        }

        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            var ilustrations = ilustrationRepository.FindBy(_entity => 
                _entity.Id == IlustrationId.HomeHero ||
                _entity.Id == IlustrationId.HomeAboutSummary ||
                _entity.Id == IlustrationId.HomeMainPromo).ToArray();

            var heroIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.HomeHero);
            var aboutSummaryIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.HomeAboutSummary);
            var mainPromoIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.HomeMainPromo);

            var model = new Models.View.Frontend.HomeIndexViewModel();

            if (heroIlustration != null)
            {
                model.HeroIlustration = new Models.View.IlustrationDisplayViewModel();

                model.HeroIlustration.Import(heroIlustration);
            }

            if (aboutSummaryIlustration != null)
            {
                model.AboutSummaryIlustration = new Models.View.IlustrationDisplayViewModel();

                model.AboutSummaryIlustration.Import(aboutSummaryIlustration);
            }

            if (mainPromoIlustration != null)
            {
                model.MainPromoIlustration = new Models.View.IlustrationDisplayViewModel();

                model.MainPromoIlustration.Import(mainPromoIlustration);
            }

            return View(model);
        }
    }
}
