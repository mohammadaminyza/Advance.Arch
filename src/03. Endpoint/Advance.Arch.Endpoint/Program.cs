using Advance.Arch.Endpoint;
using Advance.Arch.Infra.Data.SqlCommands.Common;
using Advance.Arch.Infra.Data.SqlQueries.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCommonService();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ArchCommandDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArchCommandConnectionString"));
});
builder.Services.AddDbContext<ArchQueryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArchQueryConnectionString"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
