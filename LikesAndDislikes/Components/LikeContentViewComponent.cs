using LikesAndDislikes.Models;
using Microsoft.AspNetCore.Mvc;

namespace LikesAndDislikes.Components
{
    public class LikeContentViewComponent : ViewComponent
    {
        List<ItemModel> likeList = new();

        // Försökte använda icke-async metoden Invoke() enligt dokumentationen då async ändå inte används här, men fick det aldrig att fungera.
        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            // Hantering av möjligt nullvärde, NullReferenceException, sker i HomeController IActionResult Profile().
            likeList = AccountsModel.DisplayContent(username).Likes;

            return View(likeList);
        }
    }
}
