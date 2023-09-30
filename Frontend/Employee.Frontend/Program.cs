using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(x =>
{
    x.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; // formate json with C# model
    x.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // resolve camalecase and pascale case issue
    x.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore; // ignore null values
});

var baseUrl = builder.Configuration.GetValue<string>("EmployeeAPI");
builder.Services.AddHttpClient("EmployeeAPIBase", c =>
{
    c.BaseAddress = new Uri(baseUrl!);
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
