namespace core.Interfaces.Models
{
    interface IOrder
    {
        int Id { get; set; }
        string GUId { get; set; }
        string OrderNumber { get; set; }
        int CustomerId { get; set; }
    }
}
