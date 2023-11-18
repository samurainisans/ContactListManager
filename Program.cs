using Microsoft.EntityFrameworkCore;
using MVC_Web_App.Models;

var builder = WebApplication.CreateBuilder(args);

// Настройка подключения к базе данных
string connection = "Server=(localdb)\\mssqllocaldb;Database=contacts;Trusted_Connection=true";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// Добавление контроллеров с представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Включение использования статических файлов
app.UseStaticFiles();

// Настройка маршрутизации
app.MapDefaultControllerRoute();

app.Run();
