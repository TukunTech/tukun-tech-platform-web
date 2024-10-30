using tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;
using tukun_tech_platform.Tukun.Interfaces.REST.Resources.Elders;

namespace tukun_tech_platform.Tukun.Interfaces.REST.Transform.Elders;

public class ElderResourceFromEntityAssembler
{
    public static ElderResource ToResourceFromEntity(Elder entity) => new ElderResource(entity.Id, entity.Name, entity.LastName, entity.Dni, entity.Gender, entity.Age, entity.BloodType,
        entity.Nationality, entity.NumberPolicies, entity.Insurance, entity.Allergies);
}