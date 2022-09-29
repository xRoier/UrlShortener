using UrlShortener.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls($"http://*:{builder.Configuration["RunningPort"]}");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MySqlInit>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Services.GetService<MySqlInit>()?.CreateDatabase();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();