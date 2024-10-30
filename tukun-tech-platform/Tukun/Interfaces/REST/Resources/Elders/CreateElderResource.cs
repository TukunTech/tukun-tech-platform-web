namespace tukun_tech_platform.Tukun.Interfaces.REST.Resources.Elders;

public record CreateElderResource(int Id,string Name, string LastName, string Dni,string Gender, int Age, string BloodType, string Nationality, string NumberPolicies, string Insurance, string Allergies);