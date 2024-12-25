using Microsoft.EntityFrameworkCore;
using SaatSatisSitesi.Models;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL bağlantısını ekleyin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Gerekli hizmetleri ekleyin
builder.Services.AddControllersWithViews(); // MVC için gerekli
builder.Services.AddDistributedMemoryCache(); // Oturum için gerekli
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturum süresi
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// **Buraya ekleyin**
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Oturumu etkinleştir
app.MapDefaultControllerRoute(); // Default rota
app.Run();
