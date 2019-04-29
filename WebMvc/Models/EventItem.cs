using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Models
{
    public class EventItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string EventImageUrl { get; set; }
        public int EventLocationId { get; set; }
        public int EventCategoryId { get; set; }

        public string EventCategory { get; set; }
        public string EventLocation { get; set; }
    }
}
