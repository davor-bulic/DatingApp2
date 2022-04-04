using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            var resultCOntext = await next();

            if(!resultCOntext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = resultCOntext.HttpContext.User.GetUserId(); 
            var repo = resultCOntext.HttpContext.RequestServices.GetService<IUserRepository>();

            var user = await repo.GetUserByIdAsync(userId);
            user.LastActive = DateTime.Now;

            await repo.SaveAllAsync();

        }
    }
}