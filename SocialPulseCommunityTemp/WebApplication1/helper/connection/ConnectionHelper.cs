using SocialPulseCommunityWeb.helper.forms;
using SocialPulseCommunityWeb.Models.Connection;
using System.Text;


namespace SocialPulseCommunityWeb.helper.connection
{
    public static class ConnectionHelper
    {
        public static string Verification(ConnectionModel connection)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($@"<div class=""form-card"">");
            sb.Append(InputHelper.Input("Email: *", "login-email", "Email", connection?.Email, connection?.EmailError,"email"));
            sb.Append(InputHelper.InputPassword("Password: *", "login-password", "Password", connection?.Password, connection?.PasswordError));
            sb.Append($@"<div class=""form-options"">");
            sb.Append($@"<div class=""remember-me"">");
            sb.Append($@"<input type=""checkbox"" id=""remember"" name=""remember"">");
            sb.Append($@"<label for=""remember"">Remember me</label>");
            sb.Append(@"</div>");
            sb.Append($@"<a href=""#"" class=""forgot-password"">Forgot Password?</a>");
            sb.Append("</div>");

            sb.Append($@"<button type=""submit"" id=""submit"" 
                            class=""action-button login-button"" 
                            style=""background-color: #074a91;"">Login</button>");
            sb.Append("</div>");
            return sb.ToString();
        }
    }
}
