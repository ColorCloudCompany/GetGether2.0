using System.ComponentModel.DataAnnotations;

namespace GetGether.Models
{
    /// <summary>
    /// Base data model for some other model.
    /// </summary>
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
