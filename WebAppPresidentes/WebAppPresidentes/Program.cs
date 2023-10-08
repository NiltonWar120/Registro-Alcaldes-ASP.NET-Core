using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebAppPresidentes.Data;
using static WebAppPresidentes.Data.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resource");//
builder.Services.AddMvc(options =>
{
    options.CacheProfiles.Add("Default",
        new CacheProfile()
        {
            Duration = 06,
            Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any
        });
    options.CacheProfiles.Add("Never",
        new CacheProfile()
        {
            Duration = 06,
            Location = ResponseCacheLocation.None,
            NoStore = true
        });
}).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);


builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options => options.AddPolicy("AllowLayoutJefe",
    policy => policy.RequireRole("Jefe")));

builder.Services.AddAuthorization(options => options.AddPolicy("AllowLayoutAnalista",
    policy => policy.RequireRole("Analista")));

builder.Services.AddAuthorization(options => options.AddPolicy("AllowLayoutJefeAnalista",
    policy => policy.RequireRole("Jefe", "Analista")));

builder.Services.AddControllersWithViews();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var cultures = new List<CultureInfo>();
cultures.Add(new CultureInfo("en-US"));
cultures.Add(new CultureInfo("fr-FR"));
cultures.Add(new CultureInfo("es-PE"));
var requestLocations = new RequestLocalizationOptions
{

    SupportedCultures = cultures,
    SupportedUICultures = cultures,
    DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-Us"),

};

app.UseRequestLocalization(requestLocations);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
   name: "default",
 pattern: "{controller=Presidentes}/{action=ListadoPresidentes}/{id?}");
app.MapRazorPages();

app.Run();
