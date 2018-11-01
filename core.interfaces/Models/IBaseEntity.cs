namespace Core.Interfaces.Models
{
    public interface IBaseEntity : ITrackEntity
    {
        string Id { get; set; }
        string GUId { get; set; }
    }
}
