using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_e_handels_API.Models
{
    public class PersonalizedContent
    {
        public int pcId { get; set; }             // Unique identifier for the content
        public string pcSegment { get; set; }     // Which user segment this content applies to (such as - "new_user")
        public string pcMessage { get; set; }     // The actual personalized message to show
    }

}