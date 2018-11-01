namespace Core.Interfaces.Models
{
    public interface ICustomer : IBaseEntity
    {
        string Name { get; set; }
        int Age { get; set; }
        string Address { get; set; }
    }
}
