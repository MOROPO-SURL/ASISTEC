namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Frontend
{
    public class NewsIndexViewModel
    {
        public IlustrationDisplayViewModel HeaderIlustration { get; set; }

        public TextBlockDisplayViewModel IntroTextBlock { get; set; }

        public BlogEntryDisplayViewModel[] BlogEntries { get; set; }
    }
}
