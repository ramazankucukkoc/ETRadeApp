using ETRadeApp.Business;
using ETRadeApp.Business.Abstract;
using ETRadeApp.DataAccess;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessServices();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddControllers();
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

app.UseRouting(); // UseRouting' i ekle

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IProductService>("/ProductService.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.MapControllers();

app.Run();
