using Microsoft.AspNetCore.Mvc;
using MOROPO.ASISTEC.Web.Olupin.Models.View;
using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Presentation.Models.View;

namespace MOROPO.ASISTEC.Web.Olupin.Controllers.Frontend
{
    public class ContactController : Controller
    {
        private readonly IEntityRepository<Ilustration, IlustrationId> ilustrationRepository;
        private readonly IEntityRepository<TextBlock, TextBlockId> textBlockRepository;
        private readonly IEntityRepository<PageVisit, long> pageVisitRepository;
        private readonly IEntityRepository<ContactRecord, long> contactRecordRepository;

        public ContactController(IEntityRepository<ContactRecord, long> contactRecordRepository, IEntityRepository<PageVisit, long> pageVisitRepository, IEntityRepository<TextBlock, TextBlockId> textBlockRepository, IEntityRepository<Ilustration, IlustrationId> ilustrationRepository)
        {
            this.ilustrationRepository = ilustrationRepository;
            this.textBlockRepository = textBlockRepository;
            this.pageVisitRepository = pageVisitRepository;
            this.contactRecordRepository = contactRecordRepository;
        }

        public IActionResult Index()
        {
            pageVisitRepository.Add(new PageVisit
            {
                PageId = PageId.Contact,
                Context = Request.Path,
                Carrier = Request.Headers.UserAgent,
                NetworkIdentifier = Request.Headers.Host
            }, "system");

            var headerIlustration = ilustrationRepository.FindOneBy(_entity => _entity.Id == IlustrationId.ContactHeader);

            var model = new Models.View.Frontend.ContactIndexViewModel
            {
                IntroTextBlock = new TextBlockDisplayViewModel()
            };

            model.IntroTextBlock.Import(textBlockRepository.Get(TextBlockId.ContactIntro));

            if (headerIlustration != null)
            {
                model.HeaderIlustration = new IlustrationDisplayViewModel();

                model.HeaderIlustration.Import(headerIlustration);
            }

            return View(model);
        }

        [HttpPost]
        [Route("[action]")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Contact(ContactRecordInputViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = model.Export();

                contactRecordRepository.Add(entity, User.Identity.Name ?? "guest");

                SetDefaultNotification(NotificationType.Success, "Mensaje de contacto registrado con éxito.", "Gracias por contactarnos y vistar nuestro sitio. Le prestaremos la atención adecuada a su mensaje.");

                return RedirectToAction("Index");
            }

            SetDefaultNotification(NotificationType.Danger, "Los campos especificados no son correctos.", "Los datos suministrados debe estar en el formáto correcto (Correo Electrónico y Número de Teléfono) y solo es opcional las Mensaje. Por favor, inténtelo nuevamente, asegurándose de cumplir estos sencillos requisitos.");

            return RedirectToAction("Index");
        }

        protected void SetDefaultNotification(NotificationType notificationType, string title, string message)
        {
            var notification = new NotificationViewModel
            {
                Type = notificationType,
                Title = title,
                Message = message
            };

            TempData[NotificationViewModel.DEFAULT_NOTIFICATION_MAP_KEY] = Newtonsoft.Json.JsonConvert.SerializeObject(notification);
        }
    }
}
