using Employee.Ioc.Configaration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// add it reDoc

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Title",
            Version = "v1",
            Description= "This is a Employee Project to see how documentation can easily be generated \" + " +
            "for ASP.NET Core Web APIs using Swagger and ReDoc.",
            Contact= new OpenApiContact
            {
                Name = "SAJIB",
                Email = "sajib.iu@gmail.com"
            }
        });
});

// end it redoc

builder.Services.MapCore(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    //add it
    app.UseSwaggerUI(options => 
    options.SwaggerEndpoint("/swagger/v1/swagger.json" , "Demo Documentation v1" ));
    app.UseReDoc(Options =>
    {
        Options.DocumentTitle = "Demo Documentation";
        Options.SpecUrl = "/swagger/v1/swagger.json";
    }
   ); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
