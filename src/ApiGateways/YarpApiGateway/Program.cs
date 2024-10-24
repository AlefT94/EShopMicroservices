using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxyConfig"));

builder.Services.AddRateLimiter(rateLimiterOption =>
{
    rateLimiterOption.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.Window = TimeSpan.FromSeconds(10);
        opt.PermitLimit = 5;
    });
});

var app = builder.Build();

//Configure the HTTP request pipeline
app.UseRateLimiter();

app.MapReverseProxy();

app.Run();
