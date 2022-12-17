using CarpetStoreAndManagement.Data;
using CarpetStoreAndManagement.Data.Models.User;
using CarpetStoreAndManagement.ModelBinders;
using CarpetStoreAndManagement.Services.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CarpetStoreAndManagementDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequiredLength = 5;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<CarpetStoreAndManagementDbContext>();

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    });

builder.Services.AddMvc(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Error/AccessDenied";
    options.LoginPath = "/User/Login";
});

builder.Services.AddAppServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
}
else
{
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
    //app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<CarpetStoreAndManagementDbContext>();
    dataContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
});

app.Run();
