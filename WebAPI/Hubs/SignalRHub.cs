using Microsoft.AspNetCore.SignalR;
using Web.DataAccessLayer.Concrete;

namespace WebAPI.Hubs
{
    public class SignalRHub:Hub
    {
        ApplicationContext context=new ApplicationContext();
        public async Task GetCategoryCount()
        {
           var categoryCount=context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);
        }

    }
}
