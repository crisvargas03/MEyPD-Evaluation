using AteneaBackend.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Add DB Context configuration
builder.Services.ConfigureDBContext(builder.Configuration);

// Add the dependency injection configuration
builder.Services.ConfigureInjections();

// Add AutoMapper Configuratio
builder.Services.ConfigureAutoMapper();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//services cors
builder.Services.AddCors(p => p.AddPolicy("cors", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
