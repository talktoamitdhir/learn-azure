namespace core.Interfaces.Models
{
    interface ICustomer
    {
        int Id { get; set; }
        string GUId { get; set; }
        string Name { get; set; }
        int age { get; set; }
        string Address { get; set; }
    }
}
