namespace tukun_tech_platform.Tukun.Domain.Model.Commands.Patients;

public record CreatePatientCommand(string Name, string LastName, string Dni,string Gender, int Age, string BloodType, string Nationality, string NumberPolicies, string Insurance, string AlLergies);