using GetGether.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetGether.Models
{

    /// <summary>
    /// Модель события
    /// </summary>

    public class Event : BaseModel
    {
        public string SurveyName { get; set; }   //Название события

        [ForeignKey("Organizer")]
        public string OrganizerUserNameId { get; set; } // Внешний ключ для организатора
        public Profile Organizer { get; set; }    // Организатор события


        public string Descriprion { get; set; }  //Описание события

        public virtual ICollection<EventParticipant> EventParticipants { get; set; }

        public Event() 
        {
            EventParticipants = new List<EventParticipant>();
        }

    }
    
}
