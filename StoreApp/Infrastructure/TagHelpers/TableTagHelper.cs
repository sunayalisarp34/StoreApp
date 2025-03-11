using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StoreApp.Infrastructure.TagHelpers
{
    [HtmlTargetElement("table")]
    public class TableTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // table etiketinin sınıfının default olarak bottstrap table olmasını sağlar
            output.Attributes.SetAttribute("class", "table table-hover table-bordered");
        }
    }
}
