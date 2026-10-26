namespace MOROPO.ASISTEC.Web.Olupin.Models.View.Frontend
{
    public class HomeIndexViewModel
    {
        public IlustrationDisplayViewModel HeroIlustration {  get; set; }

        public IlustrationDisplayViewModel AboutSummaryIlustration { get; set; }

        public IlustrationDisplayViewModel MainPromoIlustration { get; set; }

        public TextBlockDisplayViewModel HeroTextBlock { get; set; }

        public TextBlockDisplayViewModel AboutSummaryTextBlock { get; set; }

        public TextBlockDisplayViewModel MainPromoTextBlock { get; set; }

        public TextBlockDisplayViewModel ServicesHeaderTextBlock { get; set; }

        public TextBlockDisplayViewModel ProductsHeaderTextBlock { get; set; }

        public TextBlockDisplayViewModel TestimonialsHeaderTextBlock { get; set; }

        public TextBlockDisplayViewModel PartnersHeaderTextBlock { get; set; }

        public TextBlockDisplayViewModel CallToActionTextBlock { get; set; }

        public ServiceDisplayViewModel[] Services { get; set; }

        public TestimonialDisplayViewModel[] Testimonials { get; set; }

        public PartnerDisplayViewModel[] Partners { get; set; }
    }
}
