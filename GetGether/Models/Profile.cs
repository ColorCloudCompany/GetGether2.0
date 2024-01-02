using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetGether.Models
{
    /// <summary>
    /// User profile
    /// </summary>
    public class Profile
    {
        [Key]
        public string UserNameId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Event> Events { get; set; }  //Список событий в которых учавствует пользователь

        public virtual ICollection<EventParticipant> EventParticipants { get; set; }

        public Profile() 
        {
            EventParticipants = new List<EventParticipant>();
            Events = new List<Event>();
        }
  

    }
}
