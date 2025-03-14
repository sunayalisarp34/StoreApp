using Microsoft.Extensions.DependencyInjection;
using StoreApp.Infrastructure.Extensions;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//builder.Services.AddDbContext<RepositoryContext>(options =>
//{
//    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
//    b => b.MigrationsAssembly("StoreApp"));
//});

// For session

//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.Cookie.Name = "StoreApp.Session";
//    // wait user for ten minutes in current session in idle
//    options.IdleTimeout = TimeSpan.FromMinutes(10);
//});
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


//builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//builder.Services.AddScoped<IServiceManager, ServiceManager>();
//builder.Services.AddScoped<IProductService, ProductManager>();
//builder.Services.AddScoped<ICategoryService, CategoryManager>();
//builder.Services.AddScoped<IOrderService, OrderManager>();

//builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

//app.MapControllerRoute(
//    name:"default",
//    pattern:"{controller=Home}/{action=Index}/{id?}");

builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();
builder.Services.ConfigureApplicationCookie();


builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
     );
    
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
    endpoints.MapControllers();
});




app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();
app.Run();
