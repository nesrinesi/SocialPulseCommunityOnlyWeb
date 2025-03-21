namespace SocialPulseCommunityWeb.Models.user
{
    public class UserModel
    {
        /* Step 1 */
        public string Mail { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }

        /* Step 2 */
        public string Confirm { get; set; }
        public string verificationCode { get; set; }

        /* Step 3 */
        public string Companyname { get; set; }
        public string CompanyType { get; set; }
        public string OtherSociety { get; set; }
        public string Logo { get; set; }

        /* Step 4 */
        public string Companyadress { get; set; }
        public string Postalcode{ get; set; }
        public string City { get; set; }


        /* Step 5 */
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }



        #region Errors
        /* Step 1 */
        public string MailError { get; set; }
        public string FirstnameError { get; set; }
        public string LastnameError { get; set; }
        public string PhoneError { get; set; }

        /* Step 2 */

      
        public string ConfirmError { get; set; }

        /* Step 3 */
        public string CompanynameError { get; set; }
        public string CompanyTypeError { get; set; }
        public string OtherSocietyError{ get; set; }
        public string LogoError { get; set; }

        /* Step 4 */
        public string CompanyadressError { get; set; }
        public string PostalcodeError { get; set; }
        public string CityError { get; set; }


        /* Step 5 */
        public string PasswordError { get; set; }
        public string PasswordConfirmError { get; set; }



        #endregion Errors
    }
}
