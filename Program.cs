using Microsoft.EntityFrameworkCore;
using MVC_Web_App.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� ����������� � ���� ������
string connection = "Server=(localdb)\\mssqllocaldb;Database=contacts;Trusted_Connection=true";
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// ���������� ������������ � ���������������
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ��������� ������������� ����������� ������
app.UseStaticFiles();

// ��������� �������������
app.MapDefaultControllerRoute();

app.Run();
