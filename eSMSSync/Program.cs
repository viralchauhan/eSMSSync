using eSMSSync;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("Logs/sms_log.txt", rollingInterval: RollingInterval.Day)  // Logs to a file with daily roll-over
    .CreateLogger();

SQLitePCL.Batteries.Init();

// Add Serilog to the logging pipeline
builder.Host.UseSerilog(); // Make sure Serilog is used as the logger

// Register SmsService for Dependency Injection
builder.Services.AddScoped<SmsService>();

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();

// Log HTTP requests using Serilog
app.UseSerilogRequestLogging();  // This logs HTTP requests

app.MapControllers();

app.Run();
