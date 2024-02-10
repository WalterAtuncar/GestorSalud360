using Business.Logic.ILogic.calendar;
using Business.Logic.ILogic.Login;
using Business.Logic.Logic.Login;
using Unit.Of.Work;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUnitOfWork>(option => new Data.Access.UnitOfWork(builder.Configuration.GetConnectionString("local")));
builder.Services.AddTransient<ICalendarLogic, calendarLogic>();

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
