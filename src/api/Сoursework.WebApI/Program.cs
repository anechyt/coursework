using Coursework.Application.Auth.Abstract;
using Coursework.Application.Auth.Options;
using Coursework.Application.Auth.Services;
using Coursework.Application.Auth.TokenGenerators;
using Coursework.Application.Infrastructure.Extensions;
using Coursework.Application.NearbySearch.Abstract;
using Coursework.Application.NearbySearch.Services;
using Coursework.Infrastructure.MaptilerSearch.Abstract;
using Coursework.Infrastructure.MaptilerSearch.Options;
using Coursework.Infrastructure.MaptilerSearch.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Ñoursework.WebApI.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddApplication();

JwtOptions jwtOptions = new JwtOptions();
builder.Configuration.Bind("JwtOptions", jwtOptions);

builder.Services.AddSingleton(jwtOptions);

builder.Services.Configure<MaptilerOptions>(builder.Configuration.GetSection(MaptilerOptions.SectionName));

builder.Services.AddSingleton<JwtTokenGenerator>();
builder.Services.AddSingleton<AccessTokenGenerator>();
builder.Services.AddSingleton<RefreshTokenGenerator>();
builder.Services.AddScoped<ISecurityRepository, SecurityRepository>();
builder.Services.AddTransient<IMaptilerService, MaptilerService>();
builder.Services.AddScoped<INearbySearchService, NearbySearchService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.AccessTokenSecret)),
        ValidIssuer = jwtOptions.Issuer,
        ValidAudience = jwtOptions.Audience,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
});
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(new[] { "http://localhost:4200" })
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
