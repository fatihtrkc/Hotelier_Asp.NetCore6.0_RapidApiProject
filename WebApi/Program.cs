using BusinessLayer.Services.Abstract;
using BusinessLayer.Services.Concrete;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Abstract;
using DataAccessLayer.Repositories.Concrete;
using DataAccessLayer.UnitOfWork.Abstract;
using DataAccessLayer.UnitOfWork.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var connectionString = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<HotelierAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient((typeof(IGenericRepository<>)), typeof(GenericRepository<>));

builder.Services.AddTransient<IAboutRepository, AboutRepository>();
builder.Services.AddTransient<IAboutService, AboutService>();

builder.Services.AddTransient<IBookingRepository, BookingRepository>();
builder.Services.AddTransient<IBookingService, BookingService>();

builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IContactService, ContactService>();

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();

builder.Services.AddTransient<IRoomRepository, RoomRepository>();
builder.Services.AddTransient<IRoomService, RoomService>();

builder.Services.AddTransient<IServiceRepository, ServiceRepository>();
builder.Services.AddTransient<IServiceService, ServiceService>();

builder.Services.AddTransient<ISubscribeRepository, SubscribeRepository>();
builder.Services.AddTransient<ISubscribeService, SubscribeService>();

builder.Services.AddTransient<IReferenceRepository, ReferenceRepository>();
builder.Services.AddTransient<IReferenceService, ReferenceService>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddCors(options => options.AddPolicy("HotelierApiCors", options2 => { options2.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));

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
app.UseCors("HotelierApiCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
