var builder = WebApplication.CreateBuilder(args);

// Add services to the container

var app = builder.Build();

// Configure GHTTP request pipeline

app.Run();
