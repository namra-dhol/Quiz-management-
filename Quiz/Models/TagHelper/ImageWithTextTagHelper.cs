using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Quiz
{
    [HtmlTargetElement("image-with-text")]
    public class ImageWithTextTagHelper : TagHelper
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public string Text { get; set; }
            
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "image-text-container");
            output.Content.SetHtmlContent($@"
                <div>
                    <img src='{ImageUrl}' alt='{AltText}' style='width:150px; height:auto;' />
                    <p>{Text}</p>
                </div>
            ");
        }
    }
}

