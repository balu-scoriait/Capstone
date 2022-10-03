using Ecommerces_MS.helpers;
using Ecommerces_MS.Models;
using Ecommerces_MS.Repository;
using Ecommerces_MS.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepo, Repo>();

builder.Services.AddDbContext<UserdbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("registerConn")));
//*********************Service container*********************

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
var appSettingSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<helperAppSettings>(appSettingSection);
builder.Services.AddScoped<ITokenService , TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
builder.Services.AddHttpContextAccessor();
// *********** Added CORS ***********
builder.Services.AddCors(c => { c.AddPolicy("AllowOrigin", Options => Options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); });
// *********** Added CORS ***********
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings").GetSection("Secret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false,
           /* ValidateLifetime = true,*/
            ClockSkew =TimeSpan.Zero
        };
    });

var app = builder.Build();
// *********** Added CORS ***********
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()); // Added CORS
// *********** Added CORS ***********

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*app.UseCors("NgOrigins");*/

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();