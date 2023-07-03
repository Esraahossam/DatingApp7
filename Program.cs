using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationsServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
// builder.Services.AddDbContext<DataContext>(opt=>{

// opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
// });
// builder.Services.AddCors();
// builder.Services.AddScoped<ITokenService ,TokenService>();
// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(Options =>{
// Options.TokenValidationParameters = new TokenValidationParameters
// {
//     ValidateIssuerSigningKey = true,
//     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokenkey"])),
// ValidateIssuer= false,
// ValidateAudience=false
// };
// } );
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// session8
using var scope = app.Services.CreateScope();
var services=scope.ServiceProvider;
try{
    var context=services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
}
catch(Exception ex)
{
  var logger=services.GetService<ILogger<Program>>() ;
  logger.LogError(ex,"An error occurred during migration") ;

}


app.Run();
