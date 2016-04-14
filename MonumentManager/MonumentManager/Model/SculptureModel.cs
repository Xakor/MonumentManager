using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentManager.Model
{
    class SculptureModel
    {
        //Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Placement { get; set; }

        public int InspectionId { get; set; }

        public int InspectionFrequency { get; set; }

        public bool DoNotInspect { get; set; }
    }
}
