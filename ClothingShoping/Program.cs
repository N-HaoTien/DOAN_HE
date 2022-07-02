using ClothingShoping.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ClothingShoping.Services;
using ClothingShoping.Repository;
using ClothingShoping.Models;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser,ApplicationRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddMvcCore();
#region AddScoped
#region Product
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
#endregion
#region ProductPicture
builder.Services.AddScoped<IProductPicture, ProductPictureRepository>();
builder.Services.AddScoped<IProductPictureService, ProductPictureService>();
#endregion
#region User
builder.Services.AddScoped<IUser, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
#endregion
#region Category
builder.Services.AddScoped<ICategory, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
#endregion 
#region Comment
builder.Services.AddScoped<IComment, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
#endregion
#region OrderItem
builder.Services.AddScoped<IOrderItem, OrderItemRepository>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
#endregion
#region Order
builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion
#region Picture
builder.Services.AddScoped<IPicture, PictureRepository>();
builder.Services.AddScoped<IPictureService, PictureService>();
#endregion
#region ProductPicture
builder.Services.AddScoped<IProductPicture, ProductPictureRepository>();
builder.Services.AddScoped<IProductPictureService, ProductPictureService>();
#endregion
#region UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion
#endregion
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
