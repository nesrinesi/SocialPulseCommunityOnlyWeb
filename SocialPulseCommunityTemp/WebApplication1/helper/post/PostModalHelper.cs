using SocialPulseCommunityWeb.Models;
using System.Text;

namespace SocialPulseCommunityWeb.helper.post
{
    public static class PostModalHelper
    {
        public static string GetPostModal(PostModel model)
        {
            //Stringstr str = new Stringstr();
            string str = "";

            str+=$@"<div id=""cardModal"" class=""modal"" style=""display: flex;"">";
            str+=$@"<div class=""modal-content""><span class=""close"">&times;</span>";

            str+=$@"<div class=""details"" id=""postContainer"">";
            str+=$@"<div class=""recentOrders"">";
            str+=$@"<h2 class=""postTitle"" id=""modalTitle"">{model.Title}</h2>";

            // Description (Editable) 
            str+=$@"<p id=""postDesc"" class=""postContent"" contenteditable=""false"">{model.Description}</p>";

            //Link (Editable)
            str+=$@"<a id=""postLink"" class=""postContent postLink"" href=""#"" contenteditable=""false""></a>";

            // Image Section
            str+=$@"<div class=""imageContainer"" id=""imageContainer"">";
            // Dynamic Image 
            str+=$@"<div class=""imgedit"">";
            str+=$@"<img id=""modalImage"" alt=""Post Image"" ";
            str+=$@"src=""{model.Image}""";
            str+=$@"/>";
            str+=$@"<button class=""deleteImgBtn"" onclick=""deleteImage(this)"">";
            str+=$@"<span class=""typcn--delete""></span>";
            str+=$@"</button>";
            str+="</div>";

            // Add Image Button -->
            str+=$@"<div class=""addImageCard"" onclick=""uploadImage()"">";
            str+=$@"<span class=""line-md--plus""></span>";
            str+="</div>";
            str+="</div>";

            // Hidden File Input -->
            str+=$@"<input type=""file"" id=""imageInput"" class=""hidden"" accept=""image/*"" />";

            // Reactions -->
            str+=$@"<div class=""reactionIconsContainer"">";
            str+=$@"<div class=""reactionIcons"">";
            str+=$@"<span class=""weui--like-outlined""></span> 12";
            str+=$@"</div>";
            str+=$@"<div class=""reactionIcons"">";
            str+=$@"<span class=""iconamoon--comment-light""></span> 5";
            str+=$@"</div>";
            str+=$@"<div class=""reactionIcons"">";
            str+=$@"<span class=""lineicons--share-1""></span> 25";
            str+=$@"</div>";
            str+=$@" </div>";



            //<!-- Action Buttons -->
            str+=$@"<div class=""buttonContainer"">";
            str+=$@"<button class=""btn editBtn"" onclick=""editPost()"">Edit</button>";
            str+=$@"<button class=""btn deleteBtn"" onclick=""deletePost()"">Delete</button>";
            str+=$@"<button class=""btn publishBtn"">Publish</button>";
            str+=$@"</div>";
            str+=$@"</div>";
            str+=$@"</div>";
            str+=$@"</div>";
            str+=$@"</div>";
            //return str+=ToString();
            return str;
        }
    }
}
