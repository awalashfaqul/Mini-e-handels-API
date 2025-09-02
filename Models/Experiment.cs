using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_e_handels_API.Models
{
    public class Experiment
    {
        public int experimentId { get; set; }             // Unique identifier for the experiment
        public string experimentName { get; set; }        // Name of the experiment (example: "Button Color Test")
        public string experimentVariantA { get; set; }    // Content or feature for group A
        public string experimentVariantB { get; set; }    // Content or feature for group B
        public int experimentViewsA { get; set; }         // Count of how many users saw Variant A
        public int experimentViewsB { get; set; }         // Count of how many users saw Variant B
    }
}