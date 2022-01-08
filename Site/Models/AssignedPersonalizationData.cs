using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class AssignedPersonalizationData
    {
        public int PersonalizationID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
