using Microsoft.EntityFrameworkCore;
using RSMCHALLANGE.Infrastructure.Interface;
using RSMCHALLANGE.Infrastructure.Repository;
using RSMCHALLANGE.Infrastructure;
using RSMCHALLANGE.Application.Interface;
using RSMCHALLANGE.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AdvWorksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        opt => opt.MigrationsAssembly(typeof(AdvWorksDbContext).Assembly.FullName));
});

builder.Services.AddTransient<ISalesReportRepository, SalesReportRepository>();
builder.Services.AddTransient<ISalesReportService, SalesReportService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
