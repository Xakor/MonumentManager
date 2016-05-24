using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MonumentManager.Model
{
    class DamageModel
    {
        
        //Properties
        [JsonProperty(PropertyName = "Damage_Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Damage_Name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "CareRecommendation")]
        public string careRecommendation { get; set; }
        [JsonProperty(PropertyName = "CareFrequency")]
        public int careFrequency { get; set; }
        [JsonProperty(PropertyName = "Sculpture_Id")]
        public int SculptureId { get; set; }

        
        public override string ToString()
        {
            return string.Format( "DamageId {0} DamageName {1} CareRecommendation{2} CareFrequency {3} SculptureId {4} ",
                Id, Name, careRecommendation, careFrequency, SculptureId);
        }
    }
}
