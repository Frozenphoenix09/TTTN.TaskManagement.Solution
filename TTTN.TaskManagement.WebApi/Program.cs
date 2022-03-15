using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TTTN.TaskManagement.Data.Entities;
using TTTN.TaskManagement.WebApi.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy",
        builder => builder
        .SetIsOriginAllowed((host)=>true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        );
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new EFModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new RepositoryModule()));
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new ServicesModule()));
string connString = builder.Configuration.GetConnectionString("TTTN_TaskManagement");
builder.Services.AddDbContext<TTTNTaskManagementDbcontext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TTTN_TaskManagement"));

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
app.UseCors("CorsPolicy");

app.Run();
