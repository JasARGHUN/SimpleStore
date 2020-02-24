using Microsoft.AspNetCore.Builder;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleTemplate_1.Models
{
    public static class ApplicationNameRepository
    {
        public static void SeedData(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Infos.Any())
            {
                context.Infos.Add(
                    new Info
                    {
                        AppName = "Application Name",
                        AppAddress = "Custom address 142/52",
                        AppPhone1 = "8 (700) 100 10 10",
                        AppPhone2 = "8 (702) 200 20 20",
                        AppSocialAddress = "https://web.facebook.com/",
                        AppEmail = "Application@email.com",
                        AppHomeText = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.",
                        AppHomeText2 = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.",
                        AppHomeSlideText1 = "It is a long established fact that a reader will be distracted.",
                        AppHomeSlideText2 = "It is a long established fact that a reader will be distracted.",
                        AppHomeSlideText3 = "It is a long established fact that a reader will be distracted."
                    });
                context.SaveChanges();
            }
        }
    }
}
