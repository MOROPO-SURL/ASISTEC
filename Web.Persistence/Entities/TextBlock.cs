namespace MOROPO.ASISTEC.Web.Persistence.Entities
{
    public class TextBlock : Framework.Guama.Core.Persistence.Entities.Contract.IEntity<Enumerations.TextBlockId>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Enumerations.TextBlockId Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
