using Org.BouncyCastle.Asn1.X509;
using tukun_tech_platform.Tukun.Domain.Model.Commands.Elders;

namespace tukun_tech_platform.Tukun.Domain.Model.Aggregates.Elder;

public class Elder
{
    protected Elder()
    {
        Id = 0;
        Name = string.Empty;
        LastName = string.Empty;
        Dni = string.Empty;
        Gender = string.Empty;
        Age = 0;
        BloodType = string.Empty;
        Nationality = string.Empty;
        NumberPolicies = string.Empty;
        Insurance = string.Empty;
        Allergies = string.Empty;

    }

    public Elder(CreateElderCommand command)
    {
        Id=command.Id;
        Name = command.Name;
        LastName = command.LastName;
        Dni = command.Dni;
        Gender = command.Gender;
        Age = command.Age;
        BloodType = command.BloodType;
        Nationality = command.Nationality;
        NumberPolicies = command.NumberPolicies;
        Insurance = command.Insurance;
        Allergies = command.Allergies;
    }
    
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Dni { get; private set; }
    public string Gender { get; private set; }
    public int Age { get; private set; }
    public string BloodType { get; private set; }
    public string Nationality { get; private set; }
    public string NumberPolicies { get; private set; }
    public string Insurance { get; private set; }
    public string Allergies { get; private set; }
}