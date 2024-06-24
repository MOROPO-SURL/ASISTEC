using System.Collections.Generic;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class ManagementDashboardViewModel
    {
        public Dictionary<string, ICollection<Framework.Guama.Core.Presentation.Web.Backend.Models.View.ManagementDashboardSectionViewModel>> Sections { get; set; }
    }    
}
