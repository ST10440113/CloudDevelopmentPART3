using System.ComponentModel.DataAnnotations;

namespace CloudDevelopmentPART3.Models
{
    public class EventTypeModel
    {
        [Key]
        public int EventTypeId { get; set; }

        [Display(Name = "Event Type")]
        public required string EventType { get; set; }
    }
}

