using System.Linq;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Frontend
{
    public class NewsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IEntityRepository<Ilustration, IlustrationId> ilustrationRepository;
        private readonly IEntityRepository<TextBlock, TextBlockId> textBlockRepository;
        private readonly IEntityRepository<PageVisit, long> pageVisitRepository;
        private readonly IEntityRepository<BlogEntry, long> blogEntryRepository;

        public NewsController(IEntityRepository<BlogEntry, long> blogEntryRepository, IEntityRepository<PageVisit, long> pageVisitRepository, IEntityRepository<TextBlock, TextBlockId> textBlockRepository, IEntityRepository<Ilustration, IlustrationId> ilustrationRepository)
        {
            this.ilustrationRepository = ilustrationRepository;
            this.textBlockRepository = textBlockRepository;
            this.pageVisitRepository = pageVisitRepository;
            this.blogEntryRepository = blogEntryRepository;
        }

        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            pageVisitRepository.Add(new PageVisit
            {
                PageId = PageId.News,
                Context = Request.Path,
                Carrier = Request.Headers.UserAgent,
                NetworkIdentifier = Request.Headers.Host
            }, "system");

            var headerIlustration = ilustrationRepository.FindOneBy(_entity => _entity.Id == IlustrationId.NewsHeader);

            var model = new Models.View.Frontend.NewsIndexViewModel
            {
                IntroTextBlock = new TextBlockDisplayViewModel(),
                BlogEntries = blogEntryRepository.FindBy(_entity => _entity.Enabled).OrderByDescending(_entity => _entity.CreatedAt).Take(20).ToArray().Select(_entity =>
                {
                    var _model = new BlogEntryDisplayViewModel();

                    _model.Import(_entity);

                    return _model;
                }).ToArray()
            };

            model.IntroTextBlock.Import(textBlockRepository.Get(TextBlockId.NewsIntro));

            if (headerIlustration != null)
            {
                model.HeaderIlustration = new IlustrationDisplayViewModel();

                model.HeaderIlustration.Import(headerIlustration);
            }

            return View(model);
        }
    }
}
