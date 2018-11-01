namespace Core.Interfaces.Models
{
    public interface IOrder : IBaseEntity
    {
        string OrderNumber { get; set; }
        int Quantity { get; set; }
        string CustomerId { get; set; }
    }
}
