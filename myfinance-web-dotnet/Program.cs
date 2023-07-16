using myfinance_web_netcore;
using myfinance_web_netcore.Application.CadastrarPlanoContaUseCase;
using myfinance_web_netcore.Application.Interfaces;
using myfinance_web_netcore.Application.ObterPlanoContaUseCase;
using myfinance_web_netcore.Repository.Interfaces;
using myfinance_web_netcore.Repository.Repositories;
using myfinance_web_netcore.Services.Interfaces;
using myfinance_web_netcore.Services.PlanoContaService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext PlanoConta
builder.Services.AddDbContext<MyFinanceDbContext>();

// Repositories
builder.Services.AddScoped<IPlanoContaRepository, PlanoContaRepository>();

// services
builder.Services.AddScoped<IPlanoContaService, PlanoContaService>();

// use case
builder.Services.AddScoped<IObterPlanoContaUseCase, ObterPlanoContaUseCase>();
builder.Services.AddScoped<ICadastrarPlanoContaUseCase, CadastrarPlanoContaUseCase>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
