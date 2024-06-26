using MOROPO.ASISTEC.Web.Persistence.Entities;
using System.ComponentModel.DataAnnotations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class ContactRecordInputViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityInputModel<ContactRecord, long>
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Phone]
        [Display(Name = "Número de Teléfono")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Especificaciones")]
        public string Message { get; set; }

        [Required(ErrorMessage = "RequiredValidationErrorMessage")]
        [Display(Name = "Asunto")]
        public string Subject { get; set; }

        public ContactRecord Export()
        {
            return new ContactRecord
            {
                Name = Name,
                EmailAddress = EmailAddress,
                PhoneNumber = PhoneNumber,
                Subject = Subject,
                Message = Message
            };
        }

        public void Import(ContactRecord entity)
        {
            throw new System.NotImplementedException();
        }

        public void Mergue(ContactRecord entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
