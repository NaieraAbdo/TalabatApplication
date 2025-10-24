
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Talabat.Repository.Data;

namespace TalabatApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<StoreContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            //  Update-Database          
                           
            using var Scope = app.Services.CreateScope();
            var Services = Scope.ServiceProvider;
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();

            try { 
                var dbcontext = Services.GetRequiredService<StoreContext>();
                //Asking CLR to create obj from dbcontext Explicitly
                await dbcontext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var Logger= LoggerFactory.CreateLogger<Program>();
                Logger.LogError(ex, "An Error occured during applying the migration.");
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
