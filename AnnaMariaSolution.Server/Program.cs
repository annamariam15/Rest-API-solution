using AnnaMariaSolution.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

//program.cs
var builder = WebApplication.CreateBuilder(args);

//add sevices
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "Sample Swagger setup in ASP.NET Core"
    });
});

//builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddSingleton<ApplicationDbContext>();

var app = builder.Build();
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider; 
}

//https request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = "My Custom API Docs";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });

    app.MapGet("/", () => Results.Redirect("/swagger"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


//use swagger! & test api
//shif db
//commit