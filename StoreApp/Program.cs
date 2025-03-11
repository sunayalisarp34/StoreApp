using StoreApp.Infrastructure.Extensions;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//builder.Services.AddDbContext<RepositoryContext>(options =>
//{
//    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
//    b => b.MigrationsAssembly("StoreApp"));
//});

builder.Services.ConfigureDbContext(builder.Configuration);


// For session

//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.Cookie.Name = "StoreApp.Session";
//    // wait user for ten minutes in current session in idle
//    options.IdleTimeout = TimeSpan.FromMinutes(10);
//});

builder.Services.ConfigureSession();

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


//builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.ConfigureRepositoryRegistration();

//builder.Services.AddScoped<IServiceManager, ServiceManager>();
//builder.Services.AddScoped<IProductService, ProductManager>();
//builder.Services.AddScoped<ICategoryService, CategoryManager>();
//builder.Services.AddScoped<IOrderService, OrderManager>();

builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();

//builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

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
});

//app.MapControllerRoute(
//    name:"default",
//    pattern:"{controller=Home}/{action=Index}/{id?}");

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.Run();
