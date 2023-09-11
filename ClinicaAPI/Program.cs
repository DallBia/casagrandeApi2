using ClinicaAPI.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors.Infrastructure;
using ClinicaAPI.Service.ClienteService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Reflection;
using ClinicaAPI.Service.PerfilService;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { 
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Devplus Robot Proccess Automation", 
        Version = "v1", 
        Description = "API de comunicação entre sistemas RPA Devplus.", 
    }); 
    /*c.IncludeXmlComments(Path.Combine(
        AppContext.BaseDirectory, 
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml")); */
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() { 
        Name = "Authorization", 
        Type = SecuritySchemeType.ApiKey, 
        Scheme = "Bearer", BearerFormat = "JWT", 
        In = ParameterLocation.Header, 
        Description = "Token de Autorização Dev+ API \r\n\r\n Entre com 'Bearer' [space] e seu token de autorização.\r\n\r\n Exemplo: \"Bearer token\"",
    }); 
    c.AddSecurityRequirement(new OpenApiSecurityRequirement { 
        { new OpenApiSecurityScheme { 
            Reference = new OpenApiReference { 
                Type = ReferenceType.SecurityScheme, Id = "Bearer" } 
        }, new string[] { } 
        } 
    }); 
});
builder.Services.AddScoped<IClienteInterface, ClienteService>();
builder.Services.AddScoped<IPerfilInterface, PerfilService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

//======================================

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters 
    { 
        ValidateIssuer = true, 
        ValidateAudience = true, 
        ValidateLifetime = true, 
        ValidateIssuerSigningKey = true, 
        ValidIssuer = configuration["Jwt:Issuer"], 
        ValidAudience = configuration["Jwt:Audience"], 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])) 
    }; 
});

//====================================



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowMyOrigin");

app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();

app.MapControllers();

app.Run(); 

