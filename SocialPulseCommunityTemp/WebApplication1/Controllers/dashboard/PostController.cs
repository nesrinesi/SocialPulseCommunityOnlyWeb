
using Microsoft.AspNetCore.Mvc;
using SocialPulseCommunityWeb.helper.post;
using SocialPulseCommunityWeb.Models;
using System.Text;

namespace SocialPulseCommunityWeb.Controllers.dashboard
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            List<PostModel> models = new List<PostModel>();
            models.Add(new PostModel()
            {
                Date = DateTime.Now,
                Description = $@"Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores beatae laboriosam dolores, accusamus quod repudiandae illo, ea dolorem nemo excepturi nam minus tempore, ipsam veritatis ipsa voluptates provident! Voluptate, rem.",
                Title = "Strawberry Treats",
                Image = "https://cdn-front.freepik.com/images/ai/image-generator/how-to/image-generator-freepik-4.webp?w=1080&amp;h=1920&amp;q=90"
            });
            models.Add(new PostModel()
            {
                Date = DateTime.Now,
                Description = $@"Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores beatae laboriosam dolores, accusamus quod repudiandae illo, ea dolorem nemo excepturi nam minus tempore, ipsam veritatis ipsa voluptates provident! Voluptate, rem.",
                Title = "Chocolate Cake",
                Image = "https://cravinghomecooked.com/wp-content/uploads/2019/12/chocolate-cake-1-25-750x938.jpg.webp"
            });
            models.Add(new PostModel()
            {
                Date = DateTime.Now,
                Description = $@"Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores beatae laboriosam dolores, accusamus quod repudiandae illo, ea dolorem nemo excepturi nam minus tempore, ipsam veritatis ipsa voluptates provident! Voluptate, rem.",
                Title = "Chocolate Test",
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwYnY98LTkjsPGxaKokvgs-3OdH8voq8vCVV9kIopnLthLvMkincvR2xfw8O5TOtIzzD8&amp;usqp=CAU"
            });
            models.Add(new PostModel()
            {
                Date = DateTime.Now,
                Description = $@"Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores beatae laboriosam dolores, accusamus quod repudiandae illo, ea dolorem nemo excepturi nam minus tempore, ipsam veritatis ipsa voluptates provident! Voluptate, rem.",
                Title = "Chocolate Test",
                Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwYnY98LTkjsPGxaKokvgs-3OdH8voq8vCVV9kIopnLthLvMkincvR2xfw8O5TOtIzzD8&amp;usqp=CAU"
            });
            return View(models);
        }

        public string GetDetails(int model)
        {

            var post = new PostModel()
            {
                Date = DateTime.Now,
                Description = $@"Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores beatae laboriosam dolores, accusamus quod repudiandae illo, ea dolorem nemo excepturi nam minus tempore, ipsam veritatis ipsa voluptates provident! Voluptate, rem.",
                Title = "Strawberry Treats",
                Image = "https://cdn-front.freepik.com/images/ai/image-generator/how-to/image-generator-freepik-4.webp?w=1080&amp;h=1920&amp;q=90"
            };

            return PostModalHelper.GetPostModal(post);

        }
        /*
        public string Test()
        {
            StringBuilder builder = new StringBuilder();

            try
            {
                Databases databases = new Databases();
                if (databases?.GetAll() != null && databases.GetAll().Count() > 0)
                {
                    foreach (var database in databases.GetAll())
                    {
                        MigrationDB db = new MigrationDB(database.Host, database.DBName, database.Password, database.UserName);
                        db.Migrate();
                    }
                }
            }catch(Exception ex)
            {
                builder.Append(ex.Message);
                builder.Append("  \n  " + ex.StackTrace);
            }
            return builder.ToString();
        }
        */
    }
}
