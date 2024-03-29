using System.Diagnostics;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using Microsoft.EntityFrameworkCore;
using TSI_ERP_ETL.Front_Api.Fournisseur;
using TSI_ERP_ETL.Front_Api.ChiffreAffaire;
using Microsoft.Extensions.DependencyInjection;
using TSI_ERP_ETL.Front_Api.Article;
using TSI_ERP_ETL.Front__Api.ChiffreAffairesParClient;

namespace TSI_ERP_ETL
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            var erpApiClient = ConfigurationBuild.InitializeErpApiClient();
            services.AddDbContext<ETLDbContext>(options =>
                options.UseSqlServer(erpApiClient.DbConnection!));

            services.AddScoped<FournisseurService>();
            services.AddScoped<ChiffreAffaireService>();
            services.AddScoped<ChiffreAffaireParClientService>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddControllers();
            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TsiErp_ETL_API", Version = "v1" });
            });
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var swaggerUrl = "http://localhost:7001/swagger/index.html";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Comment out or remove the line below to temporarily disable HTTPS redirection
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TSI ERP ETL API");
                c.RoutePrefix = "swagger";
            });

            // Automatically launch Swagger UI in a browser
            Process.Start(new ProcessStartInfo
            {
                FileName = swaggerUrl,
                UseShellExecute = true
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}