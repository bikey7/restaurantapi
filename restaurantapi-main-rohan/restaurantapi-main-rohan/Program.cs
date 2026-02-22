using RestaurantUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddSingleton<FakeRestaurantService>();
builder.Services.AddControllers(); // ✅ Add API controllers

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // ✅ Map API endpoints

app.Run();