namespace SocialPulseCommunityWeb.Models.controller
{
    public class ResultModel
    {
        public IEnumerable<ErrorResultModel> Errors { get; set; }
        public bool HasError => (Errors != null && Errors.Count()>0) || !string.IsNullOrEmpty(ErrorModal);
        public object Data { get; set; }
        public string ErrorModal { get; set; }
    }
}
