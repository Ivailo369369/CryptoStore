namespace CryptoStore.Helpers.Messages
{
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using System.Text; 

    public class MessageTagHelper : TagHelper
    {
        public MessageType Type { get; set; } 

        public string Message { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var result = new StringBuilder();
            result
                .Append($"<div class=\"alert alert-{this.Type.ToString().ToLower()}\">")
                .Append("<a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">x</a>")
                .Append(this.Message)
                .Append("</div>");

            output.Content.SetHtmlContent(result.ToString());
        }
    } 
}
