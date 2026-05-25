using Microsoft.EntityFrameworkCore;
using TaskCore.IRepository;
using TaskInfastructure.ApplicationDBContext;
using TaskInfastructure.Repository;
using TaskInfastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string? conn = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskDBcontext>(options => options.UseSqlServer(conn));

builder.Services.AddScoped<TaskDBcontext>();
builder.Services.AddScoped<IUnitOfwork, UnitofWork>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<TaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
