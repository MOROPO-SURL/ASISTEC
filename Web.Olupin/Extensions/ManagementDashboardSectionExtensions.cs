namespace MOROPO.ASISTEC.Web.Olupin.Extensions
{
    public static class ManagementDashboardSectionExtensions
    {
        public static Microsoft.AspNetCore.Html.HtmlString ToIconographyHtmlString(this Framework.Guama.Core.Presentation.Web.Backend.Models.View.ManagementDashboardSectionViewModel target)
        {
            if (target.Controller == "users") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-user");

            if (target.Controller == "roles") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-users");

            if (target.Controller == "traces") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-book");

            if (target.Controller == "textblocks") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-align-justify");

            if (target.Controller == "ilustrations") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-image");

            if (target.Controller == "testimonials") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-quote-left");

            if (target.Controller == "partners") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-handshake");

            if (target.Controller == "blogentries") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-newspaper");

            if (target.Controller == "representatives") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-id-badge");

            if (target.Controller == "contactrecords") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-envelope");

            if (target.Controller == "solutions") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-star");

            if (target.Controller == "services") return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-wrench");

            return new Microsoft.AspNetCore.Html.HtmlString("fas fa-fw fa-cog");
        }
    }
}
