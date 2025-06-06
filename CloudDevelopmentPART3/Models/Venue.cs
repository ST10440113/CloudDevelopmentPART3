using System.ComponentModel.DataAnnotations;

namespace CloudDevelopmentPART3.Models
{
    public class Venue
    {
        [Key] public int VenueId { get; set; }

        [Display(Name = "Venue Name")]
        public required string VenueName { get; set; }

        public string? Location { get; set; }

        public int Capacity { get; set; }

        [Display(Name = "Venue Image")]
        public string? imageUrl { get; set; }



    }

}

