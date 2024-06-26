using MOROPO.ASISTEC.Web.Persistence.Entities;
using System;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class TestimonialDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Testimonial, System.Guid>
    {
        public Guid Id { get ; set ; }

        public ImageDisplayViewModel ContextImage { get; set ; }
       
        public string InstitutionName { get; set; }

        public string RepresentativeName { get; set; }

        public string RepresentativePosition { get; set; }

        public ImageDisplayViewModel RepresentativeImage { get; set; }

        public string Review { get; set; }

        public void Import(Testimonial entity)
        {
            Id = entity.Id;
            InstitutionName = entity.InstitutionName;
            RepresentativeName = entity.RepresentativeName;
            RepresentativePosition = entity.RepresentativePosition;
            Review = entity.Review;
            RepresentativeImage = new ImageDisplayViewModel();
            ContextImage = new ImageDisplayViewModel();

            RepresentativeImage.Import(entity.RepresentativeImage);
            ContextImage.Import(entity.ContextImage);
        }
    }
}
