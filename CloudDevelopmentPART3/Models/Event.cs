using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CloudDevelopmentPART3.Models
{
    public class Event
    {


        [Key]
        public int EventId { get; set; }

        [Display(Name = "Event Name")]
        public required string EventName { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Date of Event")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }


        public int EventTypeId { get; set; }
        [ForeignKey("EventTypeId")]
        [ValidateNever]
        public EventTypeModel? EventTypeModel { get; set; }

    }
}

