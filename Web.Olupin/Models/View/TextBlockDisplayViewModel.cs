using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class TextBlockDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<TextBlock, Web.Persistence.Enumerations.TextBlockId>
    {
        public TextBlockId Id { get ; set ; }

        public string Title { get; set; }

        public string Description { get; set; }

        public void Import(TextBlock entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;

        }
    }
}
