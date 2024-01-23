using AppMvcNet.Status;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Shop.BLL.AutoMapper;
using Shop.BLL.Service;
using Shop.BLL.Service.IServices;
using Shop.DAL.Entity.Mail;
using Shop.DAL.Entity.Role;
using ShopBussinessLogic.Service;
using ShopBussinessLogic.Service.IServices;
using ShopDataAccess.Interface;
using ShopDataAccess.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopConnectionString"));
});/*
builder.Services.AddDbContext<ShopDbContext>(options => {
    string connectstring = builder.Configuration.GetConnectionString("ShopConnectionString");
    options.UseSqlServer(connectstring);
});*/
/*
builder.Services.AddDefaultIdentity<IdentityUser>(options
    => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ShopDbContext>();*/
/*
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ShopDbContext>();*/
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IEntityService<>), typeof(EntityService<>));
builder.Services.AddAutoMapper(typeof(MappingProfile));
/*builder.Services.AddScoped<SendMailService>();*/
//Đăng kí mail
builder.Services.AddOptions();
var mailsetting = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSetting>(mailsetting);
builder.Services.AddSingleton<SendMailService>();

//dang ki identity
builder.Services.AddIdentity<ShopUser, IdentityRole>()
    .AddEntityFrameworkStores<ShopDbContext>()
    .AddDefaultTokenProviders();

// Truy cập IdentityOptions
builder.Services.Configure<IdentityOptions>(options => {
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true; // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = true; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại

});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add Razor Pages service

builder.Services.Configure<RouteOptions>(options => {
    options.AppendTrailingSlash = false;        // Thêm dấu / vào cuối URL
    options.LowercaseUrls = true;               // url chữ thường
    options.LowercaseQueryStrings = false;      // không bắt query trong url phải in thường
});
// Cấu hình Cookie
builder.Services.ConfigureApplicationCookie(options => {
    // options.Cookie.HttpOnly = true;  
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    options.LoginPath = $"/login/";                                 // Url đến trang đăng nhập
    options.LogoutPath = $"/logout/";
    options.AccessDeniedPath = $"/Account/AdminAccount/AccessDenied";   // Trang khi User bị cấm truy cập
});
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    // Trên 5 giây truy cập lại sẽ nạp lại thông tin User (Role)
    // SecurityStamp trong bảng User đổi -> nạp lại thông tinn Security
    options.ValidationInterval = TimeSpan.FromSeconds(5);
});
//Xác thực GG
builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        var gConfig = builder.Configuration.GetSection("Authentication:Google");
        options.ClientId = gConfig["ClientId"];
        options.ClientSecret = gConfig["ClientSecret"];
        options.CallbackPath = "/dang-nhap-tu-Google";
    })
//Add fb 
  .AddFacebook(options =>
  {
      var fconfig = builder.Configuration.GetSection("Authentication:Facebook");
      options.AppId = fconfig["AppId"];
      options.AppSecret = fconfig["AppSecret"];
      options.CallbackPath = "/dang-nhap-tu-facebook";
  });

//Thay thế error identity 
builder.Services.AddSingleton<IdentityErrorDescriber, IdentityErrorDescriberService>();

//Thêm chính sách policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ViewManageMenu", builders =>
    {
        builders.RequireAuthenticatedUser();
        builders.RequireRole(RoleName.Administrator);
    });
});
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

app.UseCustomStatusCodePage();//custom err 

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

//app.MapRazorPages();//endpoin cho razor 


app.Run();