using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentManager.Model
{
    class DamageModel
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int CareRecommendationId { get; set; }
        public int CareFrequency { get; set; }
    }
}
