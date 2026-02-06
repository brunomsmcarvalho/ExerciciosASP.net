using Exercicio13ASP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DB 
builder.Services.AddDbContext<DbTurismoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TurismoDbConnection")));

//Ativar sessões
builder.Services.AddSession();

var app = builder.Build();

// Sem ser por linha de comandos e sem migrações  

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DbTurismoContext>();

    context.Database.EnsureCreated();
    // Povoar a tabela Apresentacao com dados iniciais
    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
