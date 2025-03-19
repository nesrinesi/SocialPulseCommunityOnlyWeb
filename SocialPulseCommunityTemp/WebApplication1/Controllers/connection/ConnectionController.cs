using Microsoft.AspNetCore.Mvc;
using SocialPulseCommunityWeb.helper.connection;
using SocialPulseCommunityWeb.Models.Connection;
using System.Text.RegularExpressions;

namespace SocialPulseCommunityWeb.Controllers.connection
{
    public class ConnectionController : Controller
    {
        public IActionResult Connection()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Verification(ConnectionModel model)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(model.Email))
            {
                model.EmailError = "required";
                hasError = true;
            }
            if (model?.Email != null && !string.IsNullOrEmpty(model.Email))
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(model.Email);
                if (!match.Success)
                {
                    model.EmailError = "Email not valid";
                    hasError = true;
                }
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                model.PasswordError = "required";
                hasError = true;
            }



            object result = new { HasError = hasError, Html = ConnectionHelper.Verification(model) };
            return Json(result);
        }

    }

}

