using System.Linq;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Frontend
{
    public class SolutionsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IEntityRepository<Ilustration, IlustrationId> ilustrationRepository;
        private readonly IEntityRepository<TextBlock, TextBlockId> textBlockRepository;
        private readonly IEntityRepository<PageVisit, long> pageVisitRepository;
        private readonly IEntityRepository<Solution, int> solutionRepository;

        public SolutionsController(IEntityRepository<Solution, int> solutionRepository, IEntityRepository<PageVisit, long> pageVisitRepository, IEntityRepository<TextBlock, TextBlockId> textBlockRepository, IEntityRepository<Ilustration, IlustrationId> ilustrationRepository)
        {
            this.ilustrationRepository = ilustrationRepository;
            this.textBlockRepository = textBlockRepository;
            this.pageVisitRepository = pageVisitRepository;
            this.solutionRepository = solutionRepository;
        }

        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            pageVisitRepository.Add(new PageVisit
            {
                PageId = PageId.Solutions,
                Context = Request.Path,
                Carrier = Request.Headers.UserAgent,
                NetworkIdentifier = Request.Headers.Host
            }, "system");

            var headerIlustration = ilustrationRepository.FindOneBy(_entity => _entity.Id == IlustrationId.SolutionsHeader);

            var model = new Models.View.Frontend.SolutionsIndexViewModel
            {
                IntroTextBlock = new TextBlockDisplayViewModel(),
                Solutions = solutionRepository.GetAll().OrderByDescending(_entity => _entity.At).Take(30).ToArray().Select(_entity =>
                {
                    var _model = new SolutionDisplayViewModel();

                    _model.Import(_entity);

                    return _model;
                }).ToArray()
            };

            model.IntroTextBlock.Import(textBlockRepository.Get(TextBlockId.SolutionsIntro));

            if (headerIlustration != null)
            {
                model.HeaderIlustration = new IlustrationDisplayViewModel();

                model.HeaderIlustration.Import(headerIlustration);
            }

            return View(model);
        }
    }
}
