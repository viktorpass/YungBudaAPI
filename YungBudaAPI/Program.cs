using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using YungBudaAPI.Context;
using YungBudaAPI.Helpers;
using YungBudaAPI.Interfaces;
using YungBudaAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPhraseRepository, PhraseRepository>();

var mysqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
var mappingConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MappingProfiles());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseMySql(mysqlConnection,
        ServerVersion.AutoDetect(mysqlConnection));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
