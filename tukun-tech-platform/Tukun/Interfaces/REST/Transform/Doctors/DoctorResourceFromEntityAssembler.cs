using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Doctors;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.Doctors;

public class DoctorResourceFromEntityAssembler
{
    public static DoctorResource ToResourceFromEntity(Doctor entity) => new DoctorResource(entity.Id, entity.Name,
        entity.LastName, entity.Dni, entity.Age, entity.CmpCode, entity.Nationality, entity.Specialization,
        entity.Contact);
}