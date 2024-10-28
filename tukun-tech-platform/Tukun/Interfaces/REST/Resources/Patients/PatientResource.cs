namespace tukun_tech_platform.Tukun.Interfaces.REST.Resources.Patients;

public record PatientResource(int Id,string Name, string LastName, string Dni,string Gender, int Age, string BloodType, string Nationality, string NumberPolicies, string Insurance, string AlLergies);