namespace MOROPO.ASISTEC.Web.Persistence.Entities
{
    public class Ilustration : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<Enumerations.IlustrationId>
    {
        public Enumerations.IlustrationId Id { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey(nameof(ImageId))]
        public Framework.Guama.Media.Persistence.Entities.Image Image { get; set; }
        public System.Guid ImageId { get; set; }
    }
}
