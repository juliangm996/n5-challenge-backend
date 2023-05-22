using Elasticsearch.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using N5.Challenge.Api.Behavior;
using N5.Challenge.Api.Errors;
using N5.Challenge.Api.Kafka;
using N5.Challenge.Api.Persistence;
using N5.Challenge.Api.Repositories;
using Nest;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(opt => opt.Filters.Add<N5ChallengeExceptionHandlerAttribute>());



builder.Services.AddDbContext<DataContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))    
    );

var elasticsearchSettings = new ConnectionSettings(new Uri(builder.Configuration.GetConnectionString("ElasticsearchConnection")))
    .DefaultIndex("permission_index")
    .BasicAuthentication(builder.Configuration["ElasticsearchSettings:UserName"], builder.Configuration["ElasticsearchSettings:Password"])
    .ServerCertificateValidationCallback(CertificateValidations.AllowAll);
;
builder.Services.AddSingleton<IElasticClient>(new ElasticClient(elasticsearchSettings));

builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddSingleton<ProblemDetailsFactory, N5ChallengeProblemDetailsFactory>();
builder.Services.AddSingleton<KafkaProducer>();



WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

