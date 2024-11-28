using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System.Data;
using WebAPITest.Infastructure.RabbitMQBus;
using WebAPITest.Infastructure.Repository;
using WebAPITest.Infastructure.UnitOfWork;
using WebTest.Applicationn.Commands.EmployeeCommand;
using WebTest.Applicationn.Commands.PaymentCommand;
using WebTest.Applicationn.Commands.ProductCommand;
using WebTest.Applicationn.Event.OrderEvent;
using WebTest.Applicationn.Event.ProductEvent;
using WebTest.Applicationn.ICommand;
using WebTest.Applicationn.IEvent;
using WebTest.Applicationn.Service;
using WebTest.Domain.Common;
using WebTest.Domain.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionstring = "DefaultConnection";

// Đăng ký DbContext
builder.Services.AddDbContext<ApplicationDbContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString(connectionstring)));
builder.Services.AddScoped<IDbConnection>(ops => new SqlConnection(builder.Configuration.GetConnectionString(connectionstring)));
builder.Services.AddSingleton<IRabbitMQBus>(new RabbitMQBus());
builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();

builder.Services.AddTransient<IEventHandler<CreateProductEvent>, ProductEventHandler>();
builder.Services.AddTransient<IEventHandler<CreateOrderEvent>, OrderEventHandler>();

builder.Services.AddMediatR(typeof(ProductCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(EmployeCommandHandler).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Đăng ký repository
builder.Services.Scan(scan => scan
    .FromAssemblyOf<GenerateRepository<object>>()
    .AddClasses(classes => classes
        .Where(type => type.IsClass
            && !type.IsAbstract
            && type.GetInterfaces().Any(i =>
                i.IsGenericType
                && i.GetGenericTypeDefinition() == typeof(IGenerateRepositoy<>))))
    .AsImplementedInterfaces()
    .WithScopedLifetime());

// Đăng ký handler cho ProcessPaymentCommand là scoped
builder.Services.AddScoped<ICommandHandler<ProcessPaymentCommand, string>, PaymentCommandHandler>();

builder.Services.AddHostedService<PaymentConsumer>(); 
// handler acction replace PaymentCOnsumer

var app = builder.Build();

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
