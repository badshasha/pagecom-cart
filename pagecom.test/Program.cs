using MassTransit;
using pagecom.cart.app.Extender;
using pagecom.cart.data.Extender;
using pagecom.test.databaseprepreration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.pagecomcartApplicationExtenderclass(builder.Configuration);
builder.Services.pagecomachartApplicationExtender();






var app = builder.Build();

// add database information
PrepData.DatabaseCreating(app);


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