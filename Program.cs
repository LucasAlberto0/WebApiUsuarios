using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


// var connString = builder.Configuration.GetConnectionString("UsuarioConnection");

builder.Services.AddDbContext<UsuarioDbContext>
    (opts =>
    {
        opts.UseMySql(builder.Configuration.GetConnectionString("UsuarioConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("UsuarioConnection")));
    });

builder.Services.AddDbContext<UsuarioDbContext>();


builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();



    builder.Services
    .AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioDbContext>()
    .AddDefaultTokenProviders(); 

    builder.Services.AddAutoMapper
    (AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


