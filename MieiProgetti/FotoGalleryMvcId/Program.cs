using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FotoGalleryMvcId.Data;
using FotoGalleryMvcId.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)  //!!! Modifica da IdentityUser ad AppUser (1/4)
    .AddRoles<IdentityRole>()   //!!! aggiunto per gestire i ruoli  (2/4)
    .AddEntityFrameworkStores<ApplicationDbContext>();
// .AddDefaultTokenProviders();    //!!! per aggiungere i campi nuovi in Register (DA TESTARE)
builder.Services.AddControllersWithViews();

var app = builder.Build();

//!!! seeding del database    (3/4)
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        //Risolvi il RoleManager del provider di servizi
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();  //!!! aggiunto per gestire model AppUser (4/4)
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //chiamata al metodo per assicurare che i ruoli esistano
        await SeedData.InitializeAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un errore è avvenuto durante il seeding del database");
    }
}

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

