using System;

namespace Core.Interfaces.Models
{
    public interface ITrackEntity
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
