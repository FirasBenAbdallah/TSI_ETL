using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using TSI_ERP_ETL.Models.Document;
using TSI_ERP_ETL.Models.sDbContext;
using Microsoft.EntityFrameworkCore.SqlServer;
using ETLBox;
namespace TSI_ERP_ETL.ETL.Document
{
    public class DocumentLoad
    {
        //public static async Task LoadDocumentAsync(IEnumerable<DocumentModel> data, string connectionString)
        //{
        //    using var connection = new SqlConnection(connectionString);
        //    await connection.OpenAsync();

        //    foreach (var item in data)
        //    {

        //        var command = new SqlCommand("INSERT INTO Document (MontantTimbre) VALUES (@Value1)", connection);
        //        command.Parameters.AddWithValue("@Value1", item.MontantTimbre);
        //        await command.ExecuteNonQueryAsync();
        //    }
        //}

        public async Task LoadDocumentAsync(IEnumerable<DocumentModel> data, string connectionString)
        {
            // Build DbContextOptions
            var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connectionString).Options;



            using (var dbContext = new ApplicationDbContext(dbOptions))

            {

                var articles = dbContext.Document.ToList().Take(10);

                foreach (var article in articles)

                {

                    Console.WriteLine($"Title: ");

                }

            }
        }
    }
}




