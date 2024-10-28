using tukun_tech_platform.Tukun.Domain.Model.Commands.Patients;
namespace tukun_tech_platform.Tukun.Domain.Model.Aggregates.Patients;


public class Patient
{
    protected Patient()
    
    {
        Name = string.Empty;
        LastName = string.Empty;
        Dni = string.Empty;
        Gender = string.Empty;
        Age = 0;
        BloodType = string.Empty;
        Nationality = string.Empty;
        NumberPolicies = string.Empty;
        Insurance = string.Empty;
        AlLergies = string.Empty;
    }


    public Patient(CreatePatientCommand command)
    {
        Name = command.Name;
        LastName = command.LastName;
        Dni = command.Dni;
        Gender = command.Gender;
        Age = command.Age;
        BloodType = command.BloodType;
        Nationality = command.Nationality;
        NumberPolicies = command.NumberPolicies;
        Insurance = command.Insurance;
        AlLergies = command.AlLergies;
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
    public string AlLergies { get; private set; }

}