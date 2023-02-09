using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LocacaoNetAPI.Data.Context;
using Microsoft.AspNetCore.Builder;

namespace LocacaoNetAPI.Data.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrateOnInit(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope
                                    .ServiceProvider
                                    .GetService<LocacaoNetAPIContext>();

                serviceDb.Database.Migrate();
            }
        }

    }
}