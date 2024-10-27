using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Doctors;

namespace tukun_tech_platform.Tukun.Domain.Services.Doctors;

public interface IDoctorQueryService
{
    Task<Doctor?> Handle(GetAllDoctorsByDniQuery query);
    Task<Doctor?> Handle(GetDoctorsByNameQuery query);
    Task<Doctor?> Handle(GetDoctorsByCmpQuery query);
    Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query);
}