using LeaveManagement.Application;
using LeaveManagement.Data;
using Serilog;


var builder = WebApplication.CreateBuilder(args);



//Manually added
// Add services to the container.
DataServicesRegistraition.AddDataServices(builder.Services, builder.Configuration); // Register data services (By reference to the class DataServicesRegistration in LeaveManagement.Data project)
//All services are registered in the ApplicationServicesRegistration class in LeaveManagement.Application project
//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);
ApplicationServicesRegistration.AddApplicationServices(builder.Services); // Register application services (By reference to the class ApplicationServicesRegistration in LeaveManagement.Application project)

builder.Host.UseSerilog( (ctx, config) => 
    config.WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration)
);

//This policy allows us to add Authorization in Controlers. Go see exemple in LeaveRequest
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminSupervisorOnly", policy =>
    {
        policy.RequireRole(Roles.Administrator, Roles.Supervisor); //either Administrator or Supervisor have Authorization 
        //policy.RequireRole(Roles.Administrator, Roles.Supervisor); if we add other policy, this line would be a condition "and or &&"
    });
});

builder.Services.AddHttpContextAccessor(); // Add this line to register IHttpContextAccessor


builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
{ 
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
