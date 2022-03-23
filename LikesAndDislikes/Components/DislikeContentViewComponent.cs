using LikesAndDislikes.Models;
using Microsoft.AspNetCore.Mvc;

namespace LikesAndDislikes.Components
{
    public class DislikeContentViewComponent : ViewComponent
    {
        List<ItemModel> dislikeList = new();

        // Försökte använda icke-async metoden Invoke() enligt dokumentationen då async ändå inte används här, men fick det aldrig att fungera.
        public async Task<IViewComponentResult> InvokeAsync(string username)
        {
            // Hantering av möjligt nullvärde, NullReferenceException, sker i HomeController IActionResult Profile().
            dislikeList = AccountsModel.DisplayContent(username).Dislikes;

            return View(dislikeList);
        }
    }
}
