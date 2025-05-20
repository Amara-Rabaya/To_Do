using Microsoft.EntityFrameworkCore;
using DAL.DataBase;
using Microsoft.OpenApi.Models;
using System.Reflection;
using DAL.Repositores;
using DAL.Interface;
using Tranning_pro.BL;
using Tranning_pro.BLInterface;
using DAL.Repositories;
using Tranning_pro.Meddilware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tranning_pro", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddScoped<ICityRepositoryDAL, CityRepositoryDAL>();
builder.Services.AddScoped<ILogsRepository, LogsRepository>();
builder.Services.AddScoped<ICityBLServece,CityBLServece>();
builder.Services.AddScoped<ILogsBLServices,LogsBLServices>();


builder.Services.AddDbContext<DbContextDLA>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<DbContextDLA>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<HederChickSettings>(
    builder.Configuration.GetSection("HeaderCheckSettings"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tranning_pro v1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseMiddleware<HeaderCheckMiddleware>();

app.Run();
