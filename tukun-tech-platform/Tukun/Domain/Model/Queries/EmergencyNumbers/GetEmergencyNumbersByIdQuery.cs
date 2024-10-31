namespace tukun_tech_platform.Tukun.Domain.Model.Queries.EmergencyNumbers;

public class GetEmergencyNumbersByIdQuery
{
    public int Id { get; }

    public GetEmergencyNumbersByIdQuery(int id)
    {
        Id = id;
    }
}