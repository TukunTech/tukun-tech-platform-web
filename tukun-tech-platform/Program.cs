using Microsoft.EntityFrameworkCore;
using tukun_tech_platform.Shared.Domain.Repositories;
using tukun_tech_platform.Shared.Infrastructure.EFC.Configuration;
using tukun_tech_platform.Shared.Infrastructure.EFC.Repositories;
using tukun_tech_platform.Shared.Infrastructure.Interfaces.ASP.Configuration;
using tukun_tech_platform.Tukun.Application.Internal.CommandServices.CriticalAlerts;
using tukun_tech_platform.Tukun.Application.Internal.CommandServices.Doctors;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.Doctors;
using tukun_tech_platform.Tukun.Domain.Repositories.Doctors;
using tukun_tech_platform.Tukun.Domain.Services.Doctors;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.Doctors;

using tukun_tech_platform.Tukun.Application.Internal.CommandServices.Patients;
using tukun_tech_platform.Tukun.Application.Internal.CommandServices.PendingMedicine;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.Patients;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.PendingMedicine;
using tukun_tech_platform.Tukun.Domain.Repositories.Patients;
using tukun_tech_platform.Tukun.Domain.Repositories.PendingMedicine;
using tukun_tech_platform.Tukun.Domain.Services.Patients;
using tukun_tech_platform.Tukun.Domain.Services.PendingMedicine;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.Patients;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.PendingMedicine;

using tukun_tech_platform.Tukun.Application.Internal.CommandServices.Elders;
using tukun_tech_platform.Tukun.Application.Internal.CommandServices.EmergencyNumbers;
using tukun_tech_platform.Tukun.Application.Internal.CommandServices.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.CriticalAlerts;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.Elders;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.EmergencyNumbers;
using tukun_tech_platform.Tukun.Application.Internal.QueryServices.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Repositories.Elders;
using tukun_tech_platform.Tukun.Domain.Repositories.EmergencyNumbers;
using tukun_tech_platform.Tukun.Domain.Repositories.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Domain.Services.CriticalAlerts;
using tukun_tech_platform.Tukun.Domain.Services.Elders;
using tukun_tech_platform.Tukun.Domain.Services.EmergencyNumbers;
using tukun_tech_platform.Tukun.Domain.Services.FrequentlyQuestions;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.CriticalAlerts;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.Elders;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.EmergencyNumbers;
using tukun_tech_platform.Tukun.Infrastructure.Repositories.FrequentlyQuestions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new
    KebabCaseRouteNamingConvention()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());
//DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString is null)
    throw new Exception("Database connection string not found");
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorCommandService, DoctorCommandService>();
builder.Services.AddScoped<IDoctorQueryService, DoctorQueryService>();



builder.Services.AddScoped<IPatientQeryService, PatientQueryService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientCommandService, PatientCommandService>();

builder.Services.AddScoped<IEmergencyNumbersQueryService, EmergencyNumbersQueryService>();
builder.Services.AddScoped<IEmergencyNumbersRepository, EmergencyNumbersRepository>();
builder.Services.AddScoped<IEmergencyNumbersCommandService, EmergencyNumbersCommandService>();

builder.Services.AddScoped<IPendingMedicineQueryService, PendingMedicineQueryService>();
builder.Services.AddScoped<IPendingMedicineRepository, PendingMedicineRepository>();
builder.Services.AddScoped<IPendingMedicineCommandService, PendingMedicineCommandService>();

builder.Services.AddScoped<IEldersQueryService, ElderQueryService>();
builder.Services.AddScoped<IEldersRepository, ElderRepository>();
builder.Services.AddScoped<IElderCommandService, ElderCommandService>();


builder.Services.AddScoped<IFrequentlyQuestionsQueryService, FrequentlyQuestionsQueryService>();
builder.Services.AddScoped<IFrequentlyQuestionsRepository, FrequentlyQuestionsRepository>();
builder.Services.AddScoped<IFrequentlyQuestionsCommandService, FrequentlyQuestionsCommandService>();


builder.Services.AddScoped<ICriticalAlertsQueryService, CriticalAlertsQueryService>();
builder.Services.AddScoped<ICriticalAlertsRepository, CriticalAlertsRepository>();
builder.Services.AddScoped<ICriticalAlertsCommandService, CriticalAlertsCommandService>();





var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}
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