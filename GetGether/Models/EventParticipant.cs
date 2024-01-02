namespace GetGether.Models
{
    public class EventParticipant
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public string ProfileUserNameId { get; set; }
        public Profile Profile { get; set; }
    }

}
