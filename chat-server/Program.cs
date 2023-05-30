using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// TODO: get issuer and key from env
var issuer = "http://localhost:10000/realms/master";
var key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAlqdJKpiBcJkm/yrLcG67h5me+FVEawVfE64STs6Azv2viFHIdDpD6Fu9c3ig2qQJPMVveBSmWU/SjYCx/cnO8c/H4fT+rU5mZVk1nj5FnEIeb9MDTruKrN7JFu9nXFBPQ5aVvV8oiAQWkNd3B9t0O9OtbLjI/QVOIFAx6TsqlwtvDSqpmeQwD6aciisFZ7ZSwALgrReIyGbPjoKW9Ioz1+e4Se5hb/xzjnqrIcS5qK7yK68tE8aqDXYPtK05KI6OQ0flVMw6cFNpYe7fq6hrfZQCSqd2d40OGrTuMmRYhEZyLD6I4jZaMXHSCI2HYSUCyMAB9VnT1qUECExMNqIiCQIDAQAB";
builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(opt =>
    {
        opt.RequireHttpsMetadata = true;
        opt.Authority = issuer;
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
        opt.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/chat")))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true);
    });
});
builder.Services.AddSignalR();
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

app.UseHttpsRedirection();
app.UseWebSockets();
app.UseCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MyHub>("/chat");
    endpoints.MapDefaultControllerRoute();
});

app.MapControllers();
app.Run();
