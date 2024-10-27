namespace tukun_tech_platform.Tukun.Domain.Model.Commands.Doctors;

public record CreateDoctorCommand(string Name, string LastName, string Dni, int Age, string CmpCode, string Nationality, string Specialization, string Contact);