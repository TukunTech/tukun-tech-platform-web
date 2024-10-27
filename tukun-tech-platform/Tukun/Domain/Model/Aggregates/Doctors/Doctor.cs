using tukun_tech_platform.Tukun.Domain.Model.Commands.Doctors;

namespace tukun_tech_platform.Tukun.Domain.Model.Aggregates.Doctors;

public class Doctor
{
    protected Doctor()
    {
        Name = string.Empty;
        LastName = string.Empty;
        Dni = string.Empty;
        Age = 0;
        CmpCode = string.Empty;
        Nationality = string.Empty;
        Specialization = string.Empty;
        Contact = string.Empty;
    }

    public Doctor(CreateDoctorCommand command)
    {
        Name = command.Name;
        LastName = command.LastName;
        Dni = command.Dni;
        Age = command.Age;
        CmpCode = command.CmpCode;
        Nationality = command.Nationality;
        Specialization = command.Specialization;
        Contact = command.Contact;
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Dni { get; private set; }
    public int Age { get; private set; }
    public string CmpCode { get; private set; }
    public string Nationality { get; private set; }
    public string Specialization { get; private set; }
    public string Contact { get; private set; }
    
}