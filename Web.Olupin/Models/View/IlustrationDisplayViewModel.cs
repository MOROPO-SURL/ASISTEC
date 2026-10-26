using MOROPO.ASISTEC.Web.Persistence.Entities;
using MOROPO.ASISTEC.Web.Persistence.Enumerations;
using System;
using System.Xml.Linq;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class IlustrationDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Ilustration, Web.Persistence.Enumerations.IlustrationId>
    {
        public IlustrationId Id { get; set; }

        public ImageDisplayViewModel Image { get; set; }

        public void Import(Ilustration entity)
        {
            Id = entity.Id;
            Image = new ImageDisplayViewModel();

            Image.Import(entity.Image);
        }

        internal IlustrationDisplayViewModel Import(TextBlock heroTextBlock)
        {
            throw new NotImplementedException();
        }
    }
}
