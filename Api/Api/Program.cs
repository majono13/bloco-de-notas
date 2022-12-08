using Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Api.Services.Authentication;
using Api.Data.Dtos.Authentication;
using Api.Data.Daos;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddScoped<CreateUserService, CreateUserService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<UserDao, UserDao>();

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
