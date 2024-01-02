using Microsoft.EntityFrameworkCore;
using OpenDHS.Shared;
using OpenDHS.Shared.Data;
using OpenDHS.Web.Data;
using OpenDHS.Web.Middlewares;
using OpenCRM.Finance;
using OpenCRM.SwissLPD;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DBConnection") ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.");

builder.Services.AddDbContext<OpenDHSDataContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<UserEntity>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<OpenDHSDataContext>();

// Add-Registering services to the container.
builder.AddCorsMiddleware();
builder.AddAuthMiddleware();
builder.Services.AddControllers();
builder.Services.AddRazorPages();   
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.AddSwaggerMiddleware();

/// Registering OpenCRM Modules
builder.Services.AddOpenDHSServices<OpenDHSDataContext>();
builder.Services.AddOpenCRMFinance<OpenDHSDataContext>();
// builder.Services.AddOpenCRMManage<OpenDHSDataContext>();
builder.Services.AddOpenCRMSwissLPD<OpenDHSDataContext>();



var app = builder.Build();
// Use-Configure the HTTP request pipeline.
app.UseCorsMiddleware();
app.UseStaticFiles();
app.UseAuthMiddleware();
app.UseSwaggerMiddleware();

/// Using OpenCRM Modules
app.UseOpenDHSServices<OpenDHSDataContext>();
app.UseOpenCRMFinanceAsync<OpenDHSDataContext>();
// app.UseOpenCRMManage<OpenDHSDataContext>();
app.UseOpenCRMSwissLPDAsync<OpenDHSDataContext>();


app.MapControllers();
app.MapRazorPages();

app.Run();
