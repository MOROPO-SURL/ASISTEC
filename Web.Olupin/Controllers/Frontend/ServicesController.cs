using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Frontend
{
    public class ServicesController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IEntityRepository<Ilustration, IlustrationId> ilustrationRepository;
        private readonly IEntityRepository<TextBlock, TextBlockId> textBlockRepository;
        private readonly IEntityRepository<Service, System.Guid> serviceRepository;
        private readonly IEntityRepository<Solution, int> solutionRepository;
        private readonly IEntityRepository<PageVisit, long> pageVisitRepository;

        public ServicesController(IEntityRepository<PageVisit, long> pageVisitRepository, IEntityRepository<Solution, int> solutionRepository, IEntityRepository<Service, System.Guid> serviceRepository, IEntityRepository<TextBlock, TextBlockId> textBlockRepository, IEntityRepository<Ilustration, IlustrationId> ilustrationRepository)
        {
            this.ilustrationRepository = ilustrationRepository;
            this.textBlockRepository = textBlockRepository;
            this.serviceRepository = serviceRepository;
            this.solutionRepository = solutionRepository;
            this.pageVisitRepository = pageVisitRepository;
        }

        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            pageVisitRepository.Add(new PageVisit
            {
                PageId = PageId.Services,
                Context = Request.Path,
                Carrier = Request.Headers.UserAgent,
                NetworkIdentifier = Request.Headers.Host
            }, "system");

            var headerIlustration = ilustrationRepository.FindOneBy(_entity => _entity.Id == IlustrationId.ServicesHeader);

            var services = serviceRepository.FindBy(_entity => _entity.Enabled).OrderBy(_entity => _entity.Priority).ToArray();

            var solutions = solutionRepository.FindBy(_entity => _entity.Service.Enabled).ToArray();

            var model = new Models.View.Frontend.ServicesIndexViewModel
            {
                IntroTextBlock = new TextBlockDisplayViewModel()
            };

            model.IntroTextBlock.Import(textBlockRepository.Get(TextBlockId.ServicesIntro));

            if (headerIlustration != null)
            {
                model.HeaderIlustration = new IlustrationDisplayViewModel();

                model.HeaderIlustration.Import(headerIlustration);
            }

            foreach (var entity in services)
            {
                var _model = new ServiceDisplayViewModel();

                _model.Import(entity);

                model.Sections.Add(new KeyValuePair<ServiceDisplayViewModel, SolutionDisplayViewModel[]>(_model, solutions.Where(_entity => _entity.ServiceId == entity.Id).OrderByDescending(_entity => _entity.At).Take(3).Select(_entity =>
                {
                    var __model = new SolutionDisplayViewModel();

                    __model.Import(_entity);

                    return __model;
                }).ToArray()));
            }

            return View(model);
        }
    }
}
