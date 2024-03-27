using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.ETL;
using TSI_ERP_ETL.ETL.Article;
using TSI_ERP_ETL.ETL.Client;
using TSI_ERP_ETL.ETL.Document;
using TSI_ERP_ETL.ETL.VdocumentDetail;

namespace TSI_ERP_ETL
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            // Get logger from DI
            ServiceProvider serviceProvider = Logger.Log();
            var logger = serviceProvider.GetService<ILogger<Program>>();
            //var fournisseurLogger = serviceProvider.GetService<ILogger<FournisseurProcess>>();

            try
            {
                if (args is null)
                {
                    logger!.LogError("Arguments are null.");
                    throw new ArgumentNullException(nameof(args));
                }
                //CreateHostBuilder(args).Build().Run();
                var erpApiClient = ConfigurationBuild.InitializeErpApiClient();

                // Login URL from erpApiClient instance
                string loginUrl = erpApiClient.LoginUrl!;

                // Call login method
                string Token = await Login.GetTokenAsync(loginUrl);

                logger!.LogInformation("Starting ETL procedures.");

                //! Initiate the ETL procedures
                //------------------------------------------------------------------------------------------//
                // Call the DeviseProcess.ProcessDeviseAsync method

                //  await DeviseProcess.ProcessDeviseAsync(Token, erpApiClient);

                // Call the FournisseurProcess.ProcessFpurnisseurAsync method
                //await FournisseurProcess.ProcessFournisseurAsync(Token, erpApiClient, fournisseurLogger);

                //await FournisseurProcess.ProcessFournisseurAsync();
                //await DocumentProcess.ProcessDocumentAsync(Token, erpApiClient);

                // Call the VdocumentDetailProcess.ProcessVdocumentDetailAsync method
                //await VdocumentDetailProcess.ProcessVdocumentDetailAsync(Token, erpApiClient);

                // Call the ClientProcess.ProcessClientAsync method
                await ClientProcess.ProcessClientAsync(erpApiClient);

                // Call the ArticleProcess.ProcessArticleAsync method
                await ArticleProcess.ProcessArticleAsync(Token, erpApiClient);

                // Log the process completion message for the ETL process
                //Console.WriteLine("ETL process completed successfully.\n");
                logger!.LogInformation("ETL process completed successfully.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"\nAn error occurred: \n{ex.Message}");
                logger!.LogError("An error occurred: {ErrorMessage}", ex.Message);
            }
        }
        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>()
                .UseUrls("http://*:7001");
            });
    }
}

/*using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;
using TSI_ERP_ETL.Erp_ApiEndpoints;
using TSI_ERP_ETL.ETL;
using TSI_ERP_ETL.ETL.Article;
using TSI_ERP_ETL.Front_Api.Article;
using TSI_ERP_ETL.Front_Api.ChiffreAffaire;
using TSI_ERP_ETL.Front_Api.Fournisseur;
using TSI_ERP_ETL;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:7001");

// Setup logging
var serviceProvider = Logger.Log();
var logger = serviceProvider.GetService<ILogger<Program>>();

// Setup DI, configuration, etc.
var erpApiClient = ConfigurationBuild.InitializeErpApiClient();
builder.Services.AddDbContext<ETLDbContext>(options => options.UseSqlServer(erpApiClient.DbConnection!));
builder.Services.AddScoped<FournisseurService>();
builder.Services.AddScoped<ChiffreAffaireService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TsiErp_ETL_API", Version = "v1" });
});

var app = builder.Build();
var swaggerUrl = "http://localhost:7001/swagger/index.html";

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
//app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TSI ERP ETL API V1");
    c.RoutePrefix = string.Empty;
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

app.Run();

try
{
    if (args is null)
    {
        logger!.LogError("Arguments are null.");
        throw new ArgumentNullException(nameof(args));
    }

    // Login URL from erpApiClient instance
    string loginUrl = erpApiClient.LoginUrl!;

    // Call login method and initiate the ETL procedures
    string token = await Login.GetTokenAsync(loginUrl);
    logger!.LogInformation("Starting ETL procedures.");
    await ArticleProcess.ProcessArticleAsync(token, erpApiClient);
    logger!.LogInformation("ETL process completed successfully.");
}
catch (Exception ex)
{
    logger!.LogError("An error occurred: {ErrorMessage}", ex.Message);
}*/