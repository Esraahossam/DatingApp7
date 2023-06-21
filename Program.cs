using API.Extensions;
using API.Middleware;

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

app.Run();
