using System.Threading.Tasks;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace predictor
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PredictionManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    string page = await File.ReadAllTextAsync("site/page.html");
                    await context.Response.WriteAsync(page);
                });

                endpoints.MapGet("/predictionPage", async context =>
                {
                    string page = await File.ReadAllTextAsync("site/predictionPage.html");
                    await context.Response.WriteAsync(page);
                });

                endpoints.MapGet("/addprediction", async context =>
                {
                    var prediction = context.Request.Query["prediction"].First<string>(); 
                    var predictionManager = app.ApplicationServices.GetService<PredictionManager>();
                    predictionManager.AddPrediction(prediction);
                    context.Response.Redirect($"/predictionPage");

                    await Task.Run(() => {});
                });

                endpoints.MapGet("/getprediction", async context => {
                    var predictionManager = app.ApplicationServices.GetService<PredictionManager>();
                    await context.Response.WriteAsync(predictionManager.GetRandomPrediction());
                });
            });
        }
    }
}
