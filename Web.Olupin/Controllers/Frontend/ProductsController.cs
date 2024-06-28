using System.Linq;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Frontend
{
    public class ProductsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IEntityRepository<Ilustration, IlustrationId> ilustrationRepository;
        private readonly IEntityRepository<TextBlock, TextBlockId> textBlockRepository;
        private readonly IEntityRepository<PageVisit, long> pageVisitRepository;

        public ProductsController(IEntityRepository<PageVisit, long> pageVisitRepository, IEntityRepository<TextBlock, TextBlockId> textBlockRepository, IEntityRepository<Ilustration, IlustrationId> ilustrationRepository)
        {
            this.ilustrationRepository = ilustrationRepository;
            this.textBlockRepository = textBlockRepository;
            this.pageVisitRepository = pageVisitRepository;
        }

        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            pageVisitRepository.Add(new PageVisit
            {
                PageId = PageId.Products,
                Context = Request.Path,
                Carrier = Request.Headers.UserAgent,
                NetworkIdentifier = Request.Headers.Host
            }, "system");

            var ilustrations = ilustrationRepository.FindBy(_entity =>
                _entity.Id == IlustrationId.ProductsHeader ||
                _entity.Id == IlustrationId.ProductsStoreThumbnailMain ||
                _entity.Id == IlustrationId.ProductsStoreThumbnailSecoundary ||
                _entity.Id == IlustrationId.ProductsStoreThumbnailThirtheary);

            var headerIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.ProductsHeader);
            var storeThumbnailMain = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.ProductsStoreThumbnailMain);
            var storeThumbnailSecoundary = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.ProductsStoreThumbnailSecoundary);
            var storeThumbnailThirtheary = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.ProductsStoreThumbnailThirtheary);

            var model = new Models.View.Frontend.ProductsIndexViewModel
            {
                IntroTextBlock = new TextBlockDisplayViewModel()
            };

            model.IntroTextBlock.Import(textBlockRepository.Get(TextBlockId.ProductsIntro));

            if (headerIlustration != null)
            {
                model.HeaderIlustration = new IlustrationDisplayViewModel();

                model.HeaderIlustration.Import(headerIlustration);
            }

            if (storeThumbnailMain != null)
            {
                model.StoreThumbnailMainIlustration = new IlustrationDisplayViewModel();

                model.StoreThumbnailMainIlustration.Import(storeThumbnailMain);
            }

            if (storeThumbnailSecoundary != null)
            {
                model.StoreThumbnailSecoundaryIlustration = new IlustrationDisplayViewModel();

                model.StoreThumbnailSecoundaryIlustration.Import(storeThumbnailSecoundary);
            }

            if (storeThumbnailThirtheary != null)
            {
                model.StoreThumbnailThirtearyIlustration = new IlustrationDisplayViewModel();

                model.StoreThumbnailThirtearyIlustration.Import(storeThumbnailThirtheary);
            }

            return View(model);
        }
    }
}
