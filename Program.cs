using Microsoft.FeatureManagement;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Configuration.AddAzureAppConfiguration(
    options=> 
    {
        options.Connect("Endpoint=https://appconfigbykerim.azconfig.io;Id=4MIO;Secret=9OpeXA3nqLPE3skrC7Xok8oLEKoobg3AmN7549Qo5YmUTJf8DBRBJQQJ99BDAC5T7U2ZAx3ZAAACAZAC2ByG");
        options.UseFeatureFlags();
    });

builder.Services.AddFeatureManagement();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
