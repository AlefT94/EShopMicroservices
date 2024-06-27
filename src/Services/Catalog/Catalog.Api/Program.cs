var builder = WebApplication.CreateBuilder(args);

//Add Services to the container

var app = builder.Build();

//Configure HTTP request pipeline

app.Run();
