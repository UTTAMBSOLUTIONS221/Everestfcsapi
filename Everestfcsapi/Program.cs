using Everestfcsapi.Helpers;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddHttpContextAccessor();
//builder.Services.AddHangfire(x =>
//{
//    x.UseSqlServerStorage(Configuration.GetConnectionString("DBConnection"));
//});

//builder.Services.AddHangfire(config =>
//                config.UseSqlServerStorage(Configuration.GetConnectionString("DatabaseConnection"))
//            );
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source=tcp:uttambsolutions.database.windows.net,1433;Initial Catalog=Everestfcs;User Id=uttambsolutionadmin;Password=Password123!;"));
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseRouting();

app.UseAuthentication(); //Authentication
app.UseAuthorization(); //Authorization

app.MapControllers();
app.UseHangfireDashboard();
app.Run();
