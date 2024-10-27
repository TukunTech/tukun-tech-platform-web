namespace tukun_tech_platform.Tukun.Interfaces.REST.Resources.Doctors;

public record CreateDoctorResource(string Name, string LastName, string Dni, int Age, string CmpCode, string Nationality, string Specialization, string Contact);