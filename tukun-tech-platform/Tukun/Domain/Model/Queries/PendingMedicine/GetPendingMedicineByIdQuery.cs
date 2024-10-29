namespace tukun_tech_platform.Tukun.Domain.Model.Queries.PendingMedicine;

public class GetPendingMedicineByIdQuery
{
    public int Id { get; }

    public GetPendingMedicineByIdQuery(int id)
    {
        Id = id;
    }
}