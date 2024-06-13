using MOROPO.ASISTEC.Web.Persistence.Entities;
using System;
using System.Xml.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class ReferenceDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Reference, System.Guid>
    {
        public Guid Id { get ; set ; }

        public ImageDisplayViewModel Image { get; set; }

        public void Import(Reference entity)
        {
            Id = entity.Id;
            Image = new ImageDisplayViewModel();

            Image.Import(entity.Identity.Image);
        }
    }
}
