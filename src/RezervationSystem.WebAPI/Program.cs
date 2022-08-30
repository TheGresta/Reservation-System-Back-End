using Core.Utilities.Message.Turkish;
using Core.Utilities.Message;
using RezervationSystem.Business.Services.Abstract;
using RezervationSystem.Business.Services.Concrete;
using RezervationSystem.DataAccess.Abstract;
using RezervationSystem.DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region
builder.Services.AddScoped<IReserService, ReserManager>();
builder.Services.AddSingleton<ILanguageMessage, TurkishLanguageMessage>();
//builder.Services.AddScoped<IReserRentService, ReserRentManager>();

builder.Services.AddScoped<IReserDal, EfReserDal>();
builder.Services.AddScoped<IReserRentDal, EfReserRentDal>();
#endregion

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
