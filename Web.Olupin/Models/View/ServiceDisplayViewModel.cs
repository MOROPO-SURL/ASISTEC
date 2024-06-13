using MOROPO.ASISTEC.Web.Persistence.Entities;
using System;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View
{
    public class ServiceDisplayViewModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Service, System.Guid>
    {
        public Guid Id { get ; set ; }

        public string Name { get; set ; }

        public string Description { get; set ; }

        public bool Enabled { get; set; }

        public string Summary { get; set; }


        public void Import(Service entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Enabled = entity.Enabled;
            Summary = entity.Summary;
            Description = entity.Description;

        }
    }
}
