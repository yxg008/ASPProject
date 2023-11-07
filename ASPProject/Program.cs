
using ASPProject.Data;
using ASPProject.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);// basic feature of the ASP.NET core platform
builder.Services.AddControllersWithViews();//add services needed 4 controllers
builder.Services.AddSingleton<MyServiceInterface, MyServiceClass>();//register our code as a service

//builder.Services.AddDbContext<SMUDbContext>(options => options.UseSqlite("Data source=mySMUData.db"));
//builder.Services.AddDbContext<SMUDbContext>(
//   options => options.UseSqlite(builder.Configuration.GetConnectionString("myDB"))
//   );

builder.Services.AddDbContext<SMUDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("mySQLServer"))
    );

var app = builder.Build();
var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<SMUDbContext>();
//context.Database.EnsureDeleted(); //if our database exists, then erase it! - only want this while developing the code
context.Database.EnsureCreated(); //if our database does not exist, then create it!


//app.MapGet("/", () => "Hello World!");

//middleware pipeline
app.UseStaticFiles(); //usually comes first
app.UseRouting(); //add route matching to the middleware pipeline
//app.MapDefaultControllerRoute(); //adds default routing 
app.MapControllerRoute(
    name: "default",
    pattern: "Students/{id}",
    defaults: new { controller = "Student", action = "Show" });

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Instructor}/{Action=Index}/{id?}");

///to do ..
app.Run();//do not delete
