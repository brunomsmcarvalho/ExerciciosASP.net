using Exercicio11ASP.Data;
using Microsoft.EntityFrameworkCore;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // BD
        builder.Services.AddDbContext<DbSchoolContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        // Criar a BD / Tabelas
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DbSchoolContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context); // Isso deve ser chamado apenas uma vez
        } 

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();


        app.Run();
    }
}