using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.Front_Api.ChiffreAffaire;
using TSI_ERP_ETL.Front_Api.Fournisseur;

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
            services.AddControllers();
            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TSI ERP ETL API", Version = "v1" });
            });
        }

        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Comment out or remove the line below to temporarily disable HTTPS redirection
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TSI ERP ETL API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}