<<<<<<< HEAD
using TTWS_Api_Dotnet6_BusinessLogic;
using TTWS_Api_Dotnet6_BusinessLogic.Model;
using TTWS_Api_Dotnet6_BusinessLogic.Services;
using TTWS_Api_DotNet6_BusinessLogic.Repository;
using TTWS_Api_DotNet6_BusinessLogic.Services;
using TTWS_Api_DotNet6_Final;
using TTWS_Api_DotNet6_Final.Middleware;
=======
using TTWS_Api_DotNet6_Final;
using TTWS_Api_DotNet6_Final.Middleware;
using TTWS_Api_DotNet6_Final.Repository;
using TTWS_Api_DotNet6_Final.Services;
>>>>>>> d7914c22f739219ca8eae2dd2f1bd2052cd3a039

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ValidationMiddleware>();
builder.Services.AddScoped<TestMiddleware>();


var env = builder.Environment.EnvironmentName;
builder.Configuration.AddJsonFile($"appsettings{env}.json", true, false);

builder.Services.AddHttpClient<SymbolClient>((HttpClient client) =>
{
    string uri = builder.Configuration["TTWSConfiguration:Server"];
    client.BaseAddress = new Uri(uri);
});

<<<<<<< HEAD
builder.Services.AddScoped<IXMLReader, XMLReader>();
builder.Services.AddScoped<Symbol>();

=======
>>>>>>> d7914c22f739219ca8eae2dd2f1bd2052cd3a039
builder.Services.Configure<TTWSConfiguration>(builder.Configuration.GetSection("TTWSConfiguration"));
builder.Services.AddScoped<ISymbolRepository, SymbolRepository>();


//builder.Services.AddHttpClient<SymbolRepository>();

builder.Services.AddScoped<ISymbolService,SymbolService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ValidationMiddleware>();
app.UseMiddleware<TestMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
