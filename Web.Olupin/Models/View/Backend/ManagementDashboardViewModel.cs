using System.Collections.Generic;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Backend
{
    public class ManagementDashboardViewModel
    {
        public Dictionary<string, ICollection<Framework.Guama.Core.Presentation.Web.Backend.Models.View.ManagementDashboardSectionViewModel>> Sections { get; set; }

        public long[] VisitsBySection { get; set; }

        public KeyValuePair<System.DayOfWeek, long>[] WeekUserActivity { get; set; }

        public int UnreadContactRecordCount { get; set; }
        public int WeekContactRecordCount { get; set; }
    }    
}
