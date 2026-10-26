namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Frontend
{
    public class AboutIndexViewModel
    {
        public IlustrationDisplayViewModel HeaderIlustration {  get; set; }

        public IlustrationDisplayViewModel IntroIlustration { get; set; }

        public IlustrationDisplayViewModel MissionIlustration { get; set; }

        public IlustrationDisplayViewModel VisionIlustration { get; set; }

        public IlustrationDisplayViewModel ValuesIlustration { get; set; }

        public IlustrationDisplayViewModel HistoryIlustration { get; set; }

        public TextBlockDisplayViewModel IntroTextBlock {  get; set; }

        public TextBlockDisplayViewModel MissionTextBlock { get; set; }

        public TextBlockDisplayViewModel VisionTextBlock { get; set; }

        public TextBlockDisplayViewModel ValuesTextBlock { get; set; }

        public TextBlockDisplayViewModel HistoryTextBlock { get; set; }

        public RepresentativeDisplayViewModel[] Representatives {  get; set; }
    }
}
