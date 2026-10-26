using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using System.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Frontend
{
    public class AboutController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IEntityRepository<Ilustration, IlustrationId> ilustrationRepository;
        private readonly IEntityRepository<TextBlock, TextBlockId> textBlockRepository;
        private readonly IEntityRepository<Representative, System.Guid> representativeRepository;
        private readonly IEntityRepository<PageVisit, long> pageVisitRepository;

        public AboutController(IEntityRepository<PageVisit, long> pageVisitRepository, IEntityRepository<Representative, System.Guid> representativeRepository, IEntityRepository<TextBlock, TextBlockId> textBlockRepository, IEntityRepository<Ilustration, IlustrationId> ilustrationRepository)
        {
            this.ilustrationRepository = ilustrationRepository;
            this.textBlockRepository = textBlockRepository;
            this.representativeRepository = representativeRepository;
            this.pageVisitRepository = pageVisitRepository;
        }

        public Microsoft.AspNetCore.Mvc.IActionResult Index()
        {
            pageVisitRepository.Add(new PageVisit
            {
                PageId = PageId.About,
                Context = Request.Path,
                Carrier = Request.Headers.UserAgent,
                NetworkIdentifier = Request.Headers.Host
            }, "system");

            var ilustrations = ilustrationRepository.FindBy(_entity =>
                _entity.Id == IlustrationId.AboutHeader ||
                _entity.Id == IlustrationId.AboutIntro ||
                _entity.Id == IlustrationId.AboutMission ||
                _entity.Id == IlustrationId.AboutVision ||
                _entity.Id == IlustrationId.AboutValues ||
                _entity.Id == IlustrationId.AboutHistory).ToArray();

            var headerIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.AboutHeader);
            var introIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.AboutIntro);
            var missionIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.AboutMission);
            var visionIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.AboutVision);
            var valuesIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.AboutValues);
            var historyIlustration = ilustrations.FirstOrDefault(_entity => _entity.Id == IlustrationId.AboutHistory);

            var textBlocks = textBlockRepository.FindBy(_entity =>
                _entity.Id == TextBlockId.AboutIntro ||
                _entity.Id == TextBlockId.AboutMission ||
                _entity.Id == TextBlockId.AboutVision ||
                _entity.Id == TextBlockId.AboutValues ||
                _entity.Id == TextBlockId.AboutHistory);

            var introTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.AboutIntro);
            var missionTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.AboutMission);
            var visionTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.AboutVision);
            var valuesTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.AboutValues);
            var historyTextBlock = textBlocks.First(_entity => _entity.Id == TextBlockId.AboutHistory);

            var model = new Models.View.Frontend.AboutIndexViewModel
            {
                IntroTextBlock = new TextBlockDisplayViewModel(),
                MissionTextBlock = new TextBlockDisplayViewModel(),
                VisionTextBlock = new TextBlockDisplayViewModel(),
                ValuesTextBlock = new TextBlockDisplayViewModel(),
                HistoryTextBlock = new TextBlockDisplayViewModel(),
                Representatives = representativeRepository.FindBy(_entity => _entity.Enabled).ToArray().Select(_entity =>
                {
                    var _model = new RepresentativeDisplayViewModel();

                    _model.Import(_entity);

                    return _model;
                }).ToArray()
            };

            model.IntroTextBlock.Import(introTextBlock);
            model.MissionTextBlock.Import(missionTextBlock);
            model.VisionTextBlock.Import(visionTextBlock);
            model.ValuesTextBlock.Import(valuesTextBlock);
            model.HistoryTextBlock.Import(historyTextBlock);

            if (headerIlustration != null)
            {
                model.HeaderIlustration = new IlustrationDisplayViewModel();

                model.HeaderIlustration.Import(headerIlustration);
            }

            if (introIlustration != null)
            {
                model.IntroIlustration = new IlustrationDisplayViewModel();

                model.IntroIlustration.Import(introIlustration);
            }

            if (missionIlustration != null)
            {
                model.MissionIlustration = new IlustrationDisplayViewModel();

                model.MissionIlustration.Import(missionIlustration);
            }

            if (visionIlustration != null)
            {
                model.VisionIlustration = new IlustrationDisplayViewModel();

                model.VisionIlustration.Import(visionIlustration);
            }

            if (valuesIlustration != null)
            {
                model.ValuesIlustration = new IlustrationDisplayViewModel();

                model.ValuesIlustration.Import(valuesIlustration);
            }

            if (historyIlustration != null)
            {
                model.HistoryIlustration = new IlustrationDisplayViewModel();

                model.HistoryIlustration.Import(historyIlustration);
            }

            return View(model);
        }
    }
}
