using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Sample.Music.Instrument.Services.Interfaces;
using Sample.Music.Instrument.Services.Services;
using Sample.Music.Instrument.Services.Settings;
using Sample_Music_Instrument.Business.Interfaces;
using Sample_Music_Instrument.Business.Businesses;


var builder = WebApplication.CreateBuilder(args);

#region Dependency Injection

//InstrumentType
builder.Services.Configure<IInstrumentTypeDatabaseSettings>(builder.Configuration.GetSection(nameof(InstrumentTypeDatabaseSettings)));
builder.Services.AddSingleton<IInstrumentTypeDatabaseSettings>(sp => sp.GetRequiredService<IOptions<InstrumentTypeDatabaseSettings>>().Value);
builder.Services.AddScoped<IInstrumentTypeService, InstrumentTypeService>();
builder.Services.AddScoped<IInstrumentTypeBusiness, InstrumentTypeBusiness>();

builder.Services.AddScoped<IMongoClient>();
builder.Services.AddControllers();

#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
