using System.Text;

namespace SocialPulseCommunityWeb.helper.forms
{
    public static class InputHelper
    {
        public static string Input(string label,  string id, string placeholder, string value=null, string errorValue = null,string type="text")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"<div class=""input-container"">");
            sb.Append($@"<label class=""fieldlabels"">{label}</label>");
            sb.Append($@"<input type=""{type}"" id=""{id}"" name=""{id}"" {(string.IsNullOrEmpty(value)?"":$@"value=""{value}""")} placeholder=""{placeholder}"" />");
            sb.Append($@"<div class=""error {id}-error"">{(string.IsNullOrEmpty(errorValue)?"": errorValue )}</div>");
            sb.Append($@"</div>");
            return sb.ToString();
        }

        public static string InputPassword(string label, string id, string placeholder, string value = null, string errorValue = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"<div class=""input-container password-container"">");
            sb.Append($@"<label class=""fieldlabels"">{label}</label>");
            sb.Append($@"<div class=""password-input-wrapper"">");
            sb.Append($@"<input type=""password"" id=""{id}"" name=""{id}"" placeholder=""{placeholder}"" {(string.IsNullOrEmpty(value) ? "" : $@"value=""{value}""")} />");
            sb.Append($@"<i class=""fas fa-eye-slash toggle-password""></i>");
            sb.Append("</div>");
            sb.Append($@"<div class=""error {id}-error"">{(string.IsNullOrEmpty(errorValue) ? "" : errorValue)}</div>");
            sb.Append("</div>");
            return sb.ToString();
        }

        public static string InputHidden(string id, string value)
        {
            return $@"<input type=""hidden"" id=""{id}"" value=""{value}"" />";
        }
    }
}
