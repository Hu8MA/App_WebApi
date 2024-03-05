using Com.Core.Reposetory;
using Com.Core.ValueObject;
using Com.Data;
using Com.Data.Configration;
using Com.Services.File;
using Com.Services.GlobalRepo;
using Com.Services.Query;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddDbContext<MyAppDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped(typeof(IReposetory<>), typeof(Repository<>));
builder.Services.AddScoped<Image_Value>();
builder.Services.AddScoped<IRepo_UserImage, Repo_UserImage>();
builder.Services.AddScoped<IRepo_UserInfo, Repo_UserInfo>();
builder.Services.AddScoped<IRepo_UserState, Repo_UserState>();
builder.Services.AddScoped<IService_Image, Service_Image>();
builder.Services.AddScoped<IServices_FilePDF, Services_FilePDF>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.ConfigrationExceptionMiddleware();
app.UseAuthorization();

app.MapControllers();
 
 

app.Run();
