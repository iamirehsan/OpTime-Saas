using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpTime_Saas.Repository.Implimentation;

namespace OpTime_Saas
{
    public static class WebHostExtension
    {
        public static WebApplication Seed(this WebApplication host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var databaseContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
               

                databaseContext.Database.Migrate();
              
 
            }

            return host;
        }
    }
}
