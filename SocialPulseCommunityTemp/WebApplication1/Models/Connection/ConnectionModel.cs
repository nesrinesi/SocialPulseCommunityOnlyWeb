namespace SocialPulseCommunityWeb.Models.Connection
{
    public class ConnectionModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        #region Errors
        public string EmailError { get; set; }
        public string PasswordError { get; set; }
        #endregion Errors 
    }
}
