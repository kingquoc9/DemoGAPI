using Microsoft.EntityFrameworkCore;
using DemoGAPI.Models;
using DemoGAPI.Extensions;
using DemoGAPI.Repository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
     .AddNewtonsoftJson() ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddDbContext<DG1Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));
builder.Services.AddDbContext<OpcenterAPS181DEMOforVietBayContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constringx")));
builder.Services.AddScoped<IPostRepository, PostRepository>();
// Add services to the container.
builder.Services.AddJWTTokenServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("https://localhost:7188") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });

});




var app = builder.Build();
app.UseCors("MyAllowedOrigins");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
