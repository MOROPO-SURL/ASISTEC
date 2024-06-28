using System.Collections.Generic;

namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Frontend
{
    public class ServicesIndexViewModel
    {
        public IlustrationDisplayViewModel HeaderIlustration {  get; set; }

        public TextBlockDisplayViewModel IntroTextBlock { get; set; }

        public List<KeyValuePair<ServiceDisplayViewModel, SolutionDisplayViewModel[]>> Sections { get; private set; } = new List<KeyValuePair<ServiceDisplayViewModel, SolutionDisplayViewModel[]>>();
    }
}
