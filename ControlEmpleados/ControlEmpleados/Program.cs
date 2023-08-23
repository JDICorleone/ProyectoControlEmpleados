using ControlEmpleados.Interfaces;
using ControlEmpleados.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<IUsuariosModel, UsuariosModel>();
builder.Services.AddScoped<IEmpleadosModel, EmpleadosModel>();
builder.Services.AddScoped<IPlanillasModel, PlanillasModel>();
builder.Services.AddScoped<IPuestosModel, PuestosModel>();
builder.Services.AddScoped<ISolicitudVacacionesModel, SolicitudVacacionesModel>();


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

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Login",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
