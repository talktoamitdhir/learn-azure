using System;

namespace Core.Interfaces.Models
{
    public interface IBaseEntity //: ITrackEntity
    {
        string Id { get; set; }
        string GUId { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
