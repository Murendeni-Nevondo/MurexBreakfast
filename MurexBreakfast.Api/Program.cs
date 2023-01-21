using MurexBreakfast.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureDatabaseConnection(builder.Configuration);
builder.Services.ConfigureIdentityCore();
builder.Services.AddAuthentication();
builder.Services.AddUserService();

builder.Services.ConfigureJwt(builder.Configuration);
builder.Services.AddAuthService();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("devcors", builder =>
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

//app cors
app.UseCors("devcors");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
