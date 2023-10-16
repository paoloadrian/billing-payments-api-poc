using Microsoft.EntityFrameworkCore;
using BasicBilling.API.Models;
using BasicBilling.API.Services;

var MyCorsPolicy = "_myCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if(builder.Environment.IsDevelopment())  
{  
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: MyCorsPolicy,
            policy  =>
            {
                policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}

builder.Services.AddControllers();
builder.Services.AddDbContext<ClientContext>(opt =>
    opt.UseSqlite("BasicBilling"));
builder.Services.AddScoped<IBillService, BillService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UsePathBase("/billing");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyCorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
