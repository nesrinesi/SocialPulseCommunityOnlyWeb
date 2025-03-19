namespace SocialPulseCommunityWeb.Models.controller
{
    public class ErrorResultModel
    {
        public ErrorResultModel(string selector, string errorMessage)
        {
            Selector = selector;
            ErrorMessage = errorMessage;
        }

        public string Selector { get; set; }
        public string ErrorMessage { get; set; }

    }
}
