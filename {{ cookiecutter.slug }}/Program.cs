{%- if cookiecutter.frontend_pipeline == 'Vite' %}
using Vite.AspNetCore;
{%- endif %}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

{%- if cookiecutter.frontend_pipeline == 'Vite' %}
// Add Vite services.
builder.Services.AddViteServices(config =>
{
    config.Base = "/dist/";
    config.Server.AutoRun = true;
});
{%- endif %}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Index}/{action=Index}/{id?}")
    .WithStaticAssets();

{%- if cookiecutter.frontend_pipeline == 'Vite' %}
if (app.Environment.IsDevelopment())
{
    app.UseWebSockets();
    app.UseViteDevelopmentServer();
}
{%- endif %}

app.Run();
