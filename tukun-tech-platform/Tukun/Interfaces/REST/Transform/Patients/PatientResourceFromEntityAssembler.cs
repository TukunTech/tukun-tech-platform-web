using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Patients;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.Patients;

public class PatientResourceFromEntityAssembler
{
    public static PatientResource ToResourceFromEntity(Patient entity) => new PatientResource(entity.Id, entity.Name, entity.LastName, entity.Dni, entity.Gender, entity.Age, entity.BloodType,
        entity.Nationality, entity.NumberPolicies, entity.Insurance, entity.AlLergies);
}