using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MonumentManager.Model
{
    class InspectionModel
    {

        public InspectionModel()
        {

        }
        //Properties
        [JsonProperty(PropertyName = "Inspection_Id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "Inspection_Date")]
        public DateTime date { get; set; }
        [JsonProperty(PropertyName = "Sculpture_Id")]
        public int sculptureId { get; set; }
        [JsonProperty(PropertyName = "Inspection_NoteTitle")]
        public string NoteTitle { get; set; }
        [JsonProperty(PropertyName = "Inspection_NoteContent")]
        public string NoteContent { get; set; }

        public virtual SculptureModel Sculpture { get; set; }

        public override string ToString()
        {
            return string.Format("InspectionID{0} InspectionDate{1} SculptureID{2} NoteTitle{3},NoteContent{4}",Id,date,sculptureId,NoteTitle, NoteContent);
        }
        
    }
}
