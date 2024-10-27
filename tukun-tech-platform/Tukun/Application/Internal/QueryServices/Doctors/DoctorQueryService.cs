using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;
using tukun_tech_platform.Tukun.Domain.Model.Queries.Doctors;
using tukun_tech_platform.Tukun.Domain.Repositories.Doctors;
using tukun_tech_platform.Tukun.Domain.Services.Doctors;

namespace tukun_tech_platform.Tukun.Application.Internal.QueryServices.Doctors;

public class DoctorQueryService(IDoctorRepository doctorRepository) : IDoctorQueryService
{
    public async Task<Doctor?> Handle(GetAllDoctorsByDniQuery query)
    {
        return await doctorRepository.FindByDniAsync(query.Dni);
    }

    public async Task<Doctor?> Handle(GetDoctorsByNameQuery query)
    {
        return await doctorRepository.FindByNameAsync(query.Name, query.LastName);
    }

    public async Task<Doctor?> Handle(GetDoctorsByCmpQuery query)
    {
        return await doctorRepository.FindByCmpAsync(query.Cmp);
    }

    public async Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query)
    {
        return await doctorRepository.FindAllAsync();
    }
}