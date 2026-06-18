using Microsoft.EntityFrameworkCore;
using SBBClean.Application.Interfaces;
using SBBClean.Application.Services;
using SBBClean.Infrastructure;
using SBBClean.Infrastructure.Persistence;
using SBBClean.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// in memory db postgresql 'e gecene kadar
// builder.Services.AddDbContext<AppDbContext>(options =>options.UseInMemoryDatabase("SBBClean"));

builder.Services.AddDbContext<AppDbContext>(options =>options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI kayitlari

builder.Services.AddScoped<IUrunRepository,UrunRepository>();
builder.Services.AddScoped<IUrunService,UrunService>();
builder.Services.AddScoped<IUnitOfWorks, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IYazarRepository,YazarRepository>();
builder.Services.AddScoped<IYazarService,YazarService>();
builder.Services.AddScoped<IKitapRepository,KitapRepository>();
builder.Services.AddScoped<IKitapService,KitapService>();
var app = builder.Build();  

app.UseHttpsRedirection();

app.MapControllers();
app.Run();