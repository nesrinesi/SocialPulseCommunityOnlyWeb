using Microsoft.AspNetCore.Mvc;

namespace SocialPulseCommunityWeb.Controllers.dashboard
{
    public class newPostController : Controller
    {
        public IActionResult newPost()
        {
            return View();
        }
    }
}
