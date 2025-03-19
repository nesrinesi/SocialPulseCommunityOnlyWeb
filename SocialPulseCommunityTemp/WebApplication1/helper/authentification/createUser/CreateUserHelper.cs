using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialPulseCommunityWeb.helper.forms;
using SocialPulseCommunityWeb.Models.user;
using System.Reflection.Emit;
using System.Text;

namespace SocialPulseCommunityWeb.helper.authentification.createUser
{
    public static class CreateUserHelper
    {
        public static string Step1(UserModel user=null) 
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(InputHelper.Input("Email: *", "mail", "Email", user?.Mail, user?.MailError));

            sb.Append(InputHelper.Input("First Name: *", "fname", "First Name", user?.Firstname, user?.FirstnameError));

            sb.Append(InputHelper.Input("Last Name: *", "lname", "Last Name", user?.Lastname, user?.LastnameError));

            sb.Append(InputHelper.Input("Contact No.: *", "phone", "Contact No.", user?.Phone, user?.PhoneError));


            sb.Append("</div>");
            sb.Append($@"<input type=""button"" name=""next"" class=""next action-button"" value=""Next"" id=""next-step-one"" />");

            return sb.ToString();
        }
        public static string Step2(UserModel user)
        {
            StringBuilder sb = new StringBuilder();


           

            sb.Append($@"<input type=""button"" name=""next"" class=""next action-button"" value=""Next"" id=""next-step-two"" />");
            sb.Append($@"<input type=""button"" name=""previous"" class=""previous action-button-previous"" value=""Previous"" id=""prev-step-one"" />");

            return sb.ToString();
        }

        public static string Step3(UserModel user)
        {
            StringBuilder sb = new StringBuilder();
            // Logo upload container
            sb.Append("<div class='logo-upload-container text-center mb-4'>");
            sb.Append("<div class='logo-placeholder'>");
            if (!string.IsNullOrEmpty(user?.Logo))
            {
                // Display the uploaded logo if it exists
                sb.Append($"<img src='/uploads/{user.Logo}' style='max-width: 100%; max-height: 100%; object-fit: contain;' />");
            }
            else
            {
                // Display the default placeholder if no logo is uploaded
                sb.Append("<i class='fas fa-image'></i>");
                sb.Append("<div class='company-logo-text'>Company<br>logo</div>");
            }
            sb.Append("</div>");
            sb.Append("</div>");
            sb.Append("<input type='file' name='pic' id='pic' accept='image/*' style='display: none;' />");
            /*   sb.Append(InputHelper.Input("Upload Your Logo:", "pic", "", user?.Logo, user?.LogoError, "file"));*/
            sb.Append(InputHelper.Input("Company Name: *", "cname", "Company Name", user?.Companyname,user?.CompanynameError));
            sb.Append("<label for='societyType'>Society Type: *</label>");
            sb.Append("<select id='societyType' name='societyType' >");
            sb.Append("<option value=''>Sélectionner un type</option>");
            sb.Append("<option value='educational' " + (user?.CompanyType == "educational" ? "selected" : "") + ">Éducative</option>");
            sb.Append("<option value='Medical' " + (user?.CompanyType == "Medical" ? "selected" : "") + ">Médicale</option>");
            sb.Append("<option value='Sports' " + (user?.CompanyType == "Sports" ? "selected" : "") + ">Sportive</option>");
            sb.Append("<option value='other' " + (user?.CompanyType == "other" ? "selected" : "") + ">Autre</option>");
            sb.Append("</select>");
       
            if (!string.IsNullOrEmpty(user?.CompanyTypeError))
            {
                sb.Append($"<div class='error'>{user.CompanyTypeError}</div>");
            }

            sb.Append("<div id='otherSocietyInput' style='display: " + (user?.CompanyType == "other" ? "block" : "none") + ";'>");
            sb.Append(InputHelper.Input("Spécifiez le type de société :", "otherSociety", "Entrez le type de société", user?.OtherSociety, user?.OtherSocietyError));
            sb.Append("</div>");

           
            sb.Append($@"<input type=""button"" name=""next"" class=""next action-button"" value=""Next"" id=""next-step-three"" />");
            sb.Append($@"<input type=""button"" name=""previous"" class=""previous action-button-previous"" value=""Previous"" id=""prev-step-two"" />");

            return sb.ToString();
        }

        public static string Step4(UserModel user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(InputHelper.Input("Company Adress: *", "CAdress", "Company Adress", user?.Companyadress, user?.CompanyadressError));
            sb.Append(InputHelper.Input("Postal Code: *", "Pcode", "Postal Code", user?.Postalcode, user?.PostalcodeError));
            sb.Append("<label class='fieldlabels'>City: *</label>");
            sb.Append("<select id = 'City' name='City'>");            
            sb.Append("<option value=''>Sélectionner un type</option>");
            sb.Append("<option value='paris' " + (user?.City == "Paris" ? "selected" : "") + ">Paris</option>");
            sb.Append("<option value='london' " + (user?.City == "London" ? "selected" : "") + ">London</option>");
            sb.Append("<option value='new_york' " + (user?.City == "New_York" ? "selected" : "") + ">NewYork</option>");
            sb.Append("<option value='tokyo' " + (user?.City == "Tokyo" ? "selected" : "") + ">Tokyo</option>");
            sb.Append("</select>");
            sb.Append("</div>");

            if (!string.IsNullOrEmpty(user?.CityError))
            {
                sb.Append($"<div class='error'>{user.CityError}</div>");
            }
            

            sb.Append($@"<input type=""button"" name=""next"" class=""next action-button"" value=""Next"" id=""next-step-four"" />");
            sb.Append($@"<input type=""button"" name=""previous"" class=""previous action-button-previous"" value=""Previous""  id=""prev-step-three""/>");
            return sb.ToString();
        }

        public static string Step5(UserModel user)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(InputHelper.Input("Password: *", "pwd", "Password",user?.Password,user?.PasswordError, "password"));
            sb.Append(InputHelper.Input("Confirm Password: *", "cpwd", "Confirm Password", user?.PasswordConfirm, user?.PasswordConfirmError, "password"));
            sb.Append("</div>");
            sb.Append($@"<input type=""button"" name=""next"" class=""next action-button"" value=""Submit"" id=""submit"" />");
            sb.Append($@"<input type=""button"" name=""previous"" class=""previous action-button-previous"" value=""Previous""  id=""prev-step-five""/>");
            return sb.ToString();
        }
    }
}
