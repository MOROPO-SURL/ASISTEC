namespace MOROPO.ASISTEC.Web.Persistence.Entities
{
    public class ContactRecord : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<long>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public long Id { get; set; }

        public System.DateTime CreatedAt { get; set; } = System.DateTime.Now;

        public System.DateTime? ReadAt { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Subject { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string EmailAddress { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Phone]
        public string PhoneNumber { get; set; }

        public string Message { get; set; }
    }
}
