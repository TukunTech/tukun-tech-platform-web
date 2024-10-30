namespace tukun_tech_platform.Tukun.Domain.Model.Commands.Elders;

public record CreateElderCommand(int Id,string Name,string LastName,string Dni,string Gender,int Age,string BloodType, string Nationality, string NumberPolicies, string Insurance, string Allergies);