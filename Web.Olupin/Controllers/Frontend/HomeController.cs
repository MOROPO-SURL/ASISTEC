using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Frontend
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IEntityRepository<Ilustration, IlustrationId> ilustrationRepository;
        private readonly IEntityRepository<TextBlock, TextBlockId> textBlockRepository;
        private readonly IEntityRepository<Service, System.Guid> serviceRepository;
        private readonly IEntityRepository<Testimonial, System.Guid> testimonialRepository;
        private readonly IEntityRepository<Partner, System.Guid> partnerRepository;
        private readonly IEntityRepository<PageVisit, long> pageVisitRepository;

        public HomeController(IEntityRepository<PageVisit, long> pageVisitRepository, IEntityRepository<Partner, System.Guid> partnerRepository, IEntityRepository<Testimonial, System.Guid> testimonialRepository, IEntityRepository<Service, System.Guid> serviceRepository, IEntityRepository<TextBlock, TextBlockId> textBlockRepository, IEntityRepository<Ilustration, IlustrationId> ilustrationRepository)
        {
            this.ilustrationRepository = ilustrationRepository;
            this.textBlockRepository = textBlockRepository;
            this.serviceRepository = serviceRepository;
            this.testimonialRepository = testimonialRepository;
            this.partnerRepository = partnerRepository;
            this.pageVisitRepository = pageVisitRepository;
        }

        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            pageVisitRepository.Add(new PageVisit
            {
                PageId = PageId.Home,
                Context = Request.Path,
                Carrier = Request.Headers.UserAgent,
                NetworkIdentifier = Request.Headers.Host
            }, "system");

            var ilustrations = ilustrationRepository.FindBy(_entity => 
                _entity.Id == IlustrationId.HomeHero ||
                _entity.Id == IlustrationId.HomeAboutSummary ||
                _entity.Id == IlustrationId.HomeMainPromo).ToArray();

            var heroIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.HomeHero);
            var aboutSummaryIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.HomeAboutSummary);
            var mainPromoIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.HomeMainPromo);

            var textBlocks = textBlockRepository.FindBy(_entity =>
                _entity.Id == TextBlockId.HomeHero ||
                _entity.Id == TextBlockId.HomeAboutSummary ||
                _entity.Id == TextBlockId.HomeMainPromo ||
                _entity.Id == TextBlockId.HomeServicesHeader ||
                _entity.Id == TextBlockId.HomeProductsHeader ||
                _entity.Id == TextBlockId.HomeTestimonialsHeader ||
                _entity.Id == TextBlockId.HomePartnersHeader ||
                _entity.Id == TextBlockId.HomeCallToAction);

            var heroTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.HomeHero);
            var aboutSummaryTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.HomeAboutSummary);
            var mainPromoTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.HomeMainPromo);
            var servicesHeaderTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.HomeServicesHeader);
            var productsHeaderTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.HomeProductsHeader);
            var testimonialsHeaderTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.HomeTestimonialsHeader);
            var partnersHeaderTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.HomePartnersHeader);
            var callToActionTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.HomeCallToAction);

            var model = new Models.View.Frontend.HomeIndexViewModel
            {
                HeroTextBlock = new TextBlockDisplayViewModel(),
                AboutSummaryTextBlock = new TextBlockDisplayViewModel(),
                MainPromoTextBlock = new TextBlockDisplayViewModel(),
                ServicesHeaderTextBlock = new TextBlockDisplayViewModel(),
                ProductsHeaderTextBlock = new TextBlockDisplayViewModel(),
                TestimonialsHeaderTextBlock = new TextBlockDisplayViewModel(),
                PartnersHeaderTextBlock = new TextBlockDisplayViewModel(),
                CallToActionTextBlock = new TextBlockDisplayViewModel(),
                Services = serviceRepository.FindBy(_entity => _entity.Enabled).ToArray().Select(_entity =>
                {
                    var _model = new ServiceDisplayViewModel();

                    _model.Import(_entity);

                    return _model;
                }).ToArray(),
                Testimonials = testimonialRepository.GetPage(0, 5).Select(_entity =>
                {
                    var _model = new TestimonialDisplayViewModel();

                    _model.Import(_entity);

                    return _model;
                }).ToArray(),
                Partners = partnerRepository.GetAll().ToArray().Select(_entity =>
                {
                    var _model = new PartnerDisplayViewModel();

                    _model.Import(_entity);

                    return _model;
                }).ToArray()
            };

            model.HeroTextBlock.Import(heroTextBlock);
            model.AboutSummaryTextBlock.Import(aboutSummaryTextBlock);
            model.MainPromoTextBlock.Import(mainPromoTextBlock);
            model.ServicesHeaderTextBlock.Import(servicesHeaderTextBlock);
            model.ProductsHeaderTextBlock.Import(productsHeaderTextBlock);
            model.TestimonialsHeaderTextBlock.Import(testimonialsHeaderTextBlock);
            model.PartnersHeaderTextBlock.Import(partnersHeaderTextBlock);
            model.CallToActionTextBlock.Import(callToActionTextBlock);

            if (heroIlustration != null)
            {
                model.HeroIlustration = new IlustrationDisplayViewModel();

                model.HeroIlustration.Import(heroIlustration);
            }

            if (aboutSummaryIlustration != null)
            {
                model.AboutSummaryIlustration = new IlustrationDisplayViewModel();

                model.AboutSummaryIlustration.Import(aboutSummaryIlustration);
            }

            if (mainPromoIlustration != null)
            {
                model.MainPromoIlustration = new IlustrationDisplayViewModel();

                model.MainPromoIlustration.Import(mainPromoIlustration);
            }

            return View(model);
        }
    }
}
