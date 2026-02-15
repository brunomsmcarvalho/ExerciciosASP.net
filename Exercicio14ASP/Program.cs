using Exercicio14ASP.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// BD
builder.Services.AddDbContext<DbMiniCMSContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("miniBdCMSConnection")));

// Sessões
builder.Services.AddSession();

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
    var context = services.GetRequiredService<DbMiniCMSContext>();
    context.Database.EnsureCreated();

    DbInitializer.Initialize(context);
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
