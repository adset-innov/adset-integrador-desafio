using CatalogoVeiculo.Dados.Data;
using CatalogoVeiculo.Dados.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("AdSetDBConnection")));
builder.Services.AddTransient<IRepositoryService, RepositoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Catálogo",
    pattern: "{controller=Catalogo}/{action=Index}");

app.Run();
