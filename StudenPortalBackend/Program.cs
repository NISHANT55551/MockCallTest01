using Microsoft.EntityFrameworkCore;
using StudentPortalBackend.Data;
using StudentPortalBackend.Repositories.Implementation;
using StudentPortalBackend.Repositories.Interface;

var builder = WebApplication.CreateBuilder(args);

// ✅ CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins(
                        "http://localhost:3000",
                        "http://localhost:5174",
                        "http://localhost:5173") // React dev ports
                    .AllowAnyHeader()
                    .AllowAnyMethod());
});

// ✅ Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Database Context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDBConnectionString"));
});

// ✅ Dependency Injection for Repository
builder.Services.AddScoped<IReceiptAvailabilityRepository, ReceiptAvailabilityRepository>();

var app = builder.Build();

// ✅ Middleware Configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ Enable CORS before Authorization
app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
