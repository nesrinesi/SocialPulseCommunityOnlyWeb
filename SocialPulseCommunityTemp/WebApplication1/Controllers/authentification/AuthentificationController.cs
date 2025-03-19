using Microsoft.AspNetCore.Mvc;
using SocialPulseCommunityWeb.helper.authentification.createUser;
using SocialPulseCommunityWeb.Models.controller;
using SocialPulseCommunityWeb.Models.user;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using MimeKit;
using MailKit.Security;

namespace SocialPulseCommunityWeb.Controllers.authentification
{
    public class AuthentificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NextStep1(UserModel model)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(model.Mail))
            {
                model.MailError = "required";
                hasError = true;
            }
            if (model?.Mail != null && !string.IsNullOrEmpty(model.Mail))
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(model.Mail);
                if (!match.Success)
                {
                    model.MailError = "Email not valid";
                    hasError = true;
                }
            }


            if (string.IsNullOrEmpty(model.Firstname))
            {
                model.FirstnameError = "required";
                hasError = true;
            }
                
            if (string.IsNullOrEmpty(model.Lastname))
            {
                model.LastnameError = "required";
                hasError = true;
            }
            if (string.IsNullOrEmpty(model.Phone))
            {
                model.PhoneError = "required";
                hasError = true;
            }
            string error = "";
            
            if (!hasError)
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("contact@socialpulsecommunity.com"));
                email.To.Add(MailboxAddress.Parse(model.Mail));
                email.Subject = "Confirmation de Mail SPC";
                email.Body = new TextPart("code secret 11111") { Text = "<h1>Example HTML Message Body</h1>" };

                // send email
                var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.ionos.fr", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("contact@socialpulsecommunity.com", "aT0QWXZt5CcEdLTFxLjiVB");

                try
                {
                    smtp.Send(email);
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    smtp.Disconnect(true);
                }

            }
                

            object result =new { HasError = hasError, Html =CreateUserHelper.Step1(model)};
            return Json(result);
        }

        [HttpPost]

        public IActionResult NextStep2(UserModel model)
        {
            bool hasError = false;
            


            object result = new { HasError = hasError, Html = CreateUserHelper.Step2(model) };
            return Json(result);
        }

        [HttpPost]
        public IActionResult NextStep3(UserModel model)
        {
            bool hasError = false;
            if (string.IsNullOrEmpty(model.Companyname))
            {
                model.CompanynameError = "required";
                hasError = true;
            }

            if (string.IsNullOrEmpty(model.CompanyType))
            {
                model.CompanyTypeError = "required";
                hasError = true;
            }
            if (model.CompanyType == "other" && string.IsNullOrEmpty(model.OtherSociety))
            {
                model.OtherSocietyError = "required";
                hasError = true;
            }
            object result = new { HasError = hasError, Html = CreateUserHelper.Step3(model) };
            return Json(result);
        }
        [HttpPost]
        public IActionResult NextStep4(UserModel model)
        {
            bool hasError = false;

            if (string.IsNullOrEmpty(model.Companyadress))
            {
                model.CompanyadressError = "required";
                hasError = true;
            }
            if (string.IsNullOrEmpty(model.Postalcode))
            {
                model.PostalcodeError = "required";
                hasError = true;
            }


            if (string.IsNullOrEmpty(model.City))
            {
                model.CityError = "required";
                hasError = true;
            }

            object result = new { HasError = hasError, Html = CreateUserHelper.Step4(model) };
            return Json(result);
        }

        [HttpPost]
        public IActionResult NextStep5(UserModel model)
        {
            bool hasError = false;
            if (string.IsNullOrEmpty(model.Password))
            {
                model.PasswordError = "required";
                hasError = true;
            }

            if (string.IsNullOrEmpty(model.PasswordConfirm))
            {
                model.PasswordConfirmError = "required";
                hasError = true;
            }

            if ( !hasError && model.Password!=model.PasswordConfirm)
            {
                model.PasswordConfirmError = "The password seems not the same !";
                hasError = true;
            }


            object result = new { HasError = hasError, Html = CreateUserHelper.Step5(model) };
            return Json(result);
        }
    }
}
