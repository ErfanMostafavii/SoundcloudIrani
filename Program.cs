using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using soundcloud_.Models.Countexts;
using soundcloud_.Models.Utilitis;
using soundcloud_.Models.ViewModels;
using soundcloud_.Service.Commands.Admin.AcceptMusic;
using soundcloud_.Service.Commands.Admin.RejectMusic;
using soundcloud_.Service.Commands.Musics;
using soundcloud_.Service.Commands.UserRegister;
using soundcloud_.Service.Queries.Admin.AcceptUserMusic;
using soundcloud_.Service.Queries.Admin.GetMusicNumbers;
using soundcloud_.Service.Queries.Admin.GetUSerNumber;
using soundcloud_.Service.Queries.Authentication;
using soundcloud_.Service.Queries.GetAllMusic;
using soundcloud_.Service.Queries.GetArtist;
using soundcloud_.Service.Queries.GetUserInfo;
using soundcloud_.Service.Queries.GetUserMusic;
using soundcloud_.Service.Queries.UserPlaylist;

var builder = WebApplication.CreateBuilder(args);



//builder.Services.AddDbContext<DataBaseContext>(options =>
//        options.UseSqlServer(
//            builder.Configuration.GetConnectionString("DBConnection")));


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton(typeof(DataBaseContext));

builder.Services.AddScoped(typeof(IUserRegister), typeof(UserRegister));
builder.Services.AddScoped(typeof(IAddMusics), typeof(AddMusic));
builder.Services.AddScoped(typeof(IUserAuthenticate), typeof(UserAuthenticate));
builder.Services.AddScoped(typeof(IGetUserInfo), typeof(GetUserInfo));
builder.Services.AddScoped(typeof(IGetUserMusic), typeof(GetUserMusic));
builder.Services.AddScoped(typeof(IGetUsersMusic), typeof(GetUsersMusic));

builder.Services.AddScoped(typeof(IRejectMusic), typeof(RejectMusic));

builder.Services.AddScoped(typeof(IAcceptMusic), typeof(AcceptMusic));
builder.Services.AddScoped(typeof(IGetUserNumber), typeof(GetUserNumber));
builder.Services.AddScoped(typeof(IGetMusicNumber), typeof(GetMusicNumber));
builder.Services.AddScoped(typeof(IGetAllMusic), typeof(GetAllMusic));
builder.Services.AddScoped(typeof(IGetArtists), typeof(GetArtists));

builder.Services.AddScoped(typeof(IGetUserPlaylist), typeof(GetUserPlaylist));



builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;


}).AddCookie(options =>
{
    options.LoginPath = new PathString("/User/Login");
    options.ExpireTimeSpan=TimeSpan.FromMinutes(45);
    options.AccessDeniedPath = new PathString("/Home/Index");
    }) ;
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.User, policy => policy.RequireRole(UserRoles.User));

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

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
