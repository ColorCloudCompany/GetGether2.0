using GetGether.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetGether.Models
{

    /// <summary>
    /// Модель вступительной анкеты пользователя
    /// </summary>

        public class  Survey : BaseModel
    {
            
            public string Name { get; set; } = null!;
        
        public int YearOfBirth { get; set; }
            public string City { get; set; } = null!;
            public string Country { get; set; } = null!;
        
        public int Phone { get; set; }
            public string Email { get; set; } = null!;

        }
    
}
