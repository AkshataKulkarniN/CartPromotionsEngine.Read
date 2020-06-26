using CartPromotionEngine.Service.Read.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CartPromotionEngine.Service.Read
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
                 .AddTransient<ICartPromotionEngineService, CartPromotionEngineService>()
                 
                ;
        }
    }
}
