using Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Api.Services.Authentication;
using Api.Data.Dtos.Authentication;
using Api.Data.Daos;
using Api.Services.Notes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddScoped<CreateUserService, CreateUserService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<UserDao, UserDao>();
builder.Services.AddScoped<NotesDao, NotesDao>();
builder.Services.AddScoped<NotesService, NotesService>();

#endregion

#region Fluente Validation
builder.Services.AddControllers().AddFluentValidation(fv => fv
    .RegisterValidatorsFromAssemblyContaining<UserValidator>());

builder.Services.AddControllers().AddFluentValidation(fv => fv
    .RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());

#endregion

//DbContext
builder.Services.AddDbContext<AppDbContext>(opts => opts
    .UseLazyLoadingProxies().UseMySql(builder.Configuration
    .GetConnectionString("DbConnection"), new MySqlServerVersion(new Version())));

//Identity
builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>();

//Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Autenticação

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})  
        .AddJwtBearer(token =>
        {
            token.RequireHttpsMetadata = false;
            token.SaveToken = true;
            token.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("kjdf2i235wqiuyasjh1o387465kqw219jKJtRERsoihoeftrqscjlqd")),
                ValidateIssuer = false, 
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
        };
        });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Cors
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
