using CME_Task.DAL.DBContext;
using CME_Task.DAL.Models;
using CME_Task.DAL.Repository.BaseRepository;
using CME_Task.DAL.Repository.IBaseRepository;
using CME_Task.DAL.UnitOfWork;
using CME_Task.Service.IService;
using CME_Task.Service.Service;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CME_Task.DAL.MappingProfiles.CustomerMappingProfile;
using CME_Task.DAL.MappingProfiles.ReservationMappingProfile;
using CME_Task.DAL.MappingProfiles.RoomMappingProfile;
using CME_Task.DAL.Seeder;
using Microsoft.Extensions.DependencyInjection;

var mapperConfig = new MapperConfiguration(config =>
{
    config.AddProfile<CustomerMappingProfile>();
    config.AddProfile<ReservationMappingProfile>();
    config.AddProfile<RoomMappingProfile>();
});

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

// Register the UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Register the services
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddAutoMapper(typeof(CustomerMappingProfile));
builder.Services.AddAutoMapper(typeof(ReservationMappingProfile));
builder.Services.AddAutoMapper(typeof(RoomMappingProfile));




builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
        var result = new BadRequestObjectResult(new { Errors = errors });
        result.ContentTypes.Add("application/problem+json");
        result.ContentTypes.Add("application/problem+xml");
        return result;
    };
    options.SuppressMapClientErrors = true;
    options.ClientErrorMapping[404].Link =
        "https://httpstatuses.com/404";
    options.ClientErrorMapping[500].Link =
        "https://httpstatuses.com/500";
});

var app = builder.Build();

// Configure the app
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "YourApiName v1"));
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors(); 

app.UseRouting();

app.UseAuthorization();

DataSeeder.SeedRoomTypes(app.Services.GetRequiredService<IServiceProvider>());

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();

