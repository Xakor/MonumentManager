using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MonumentManager.Model
{
    public class SculptureModel
    {
        //Instance Field
        private int _id;
        private string _name;
        private string _address;
        private string _placement;
        private string _picture;
        private int _inspectionFrequency;
        private bool _doNotInspect;
        private string _material;
        private string _type;
        
        //Properties
        // we add this json property because we need to point directly to the tables attributes 
        //because the names of the class properties are different

        [JsonProperty(PropertyName = "Sculpture_Id")]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [JsonProperty(PropertyName = "Sculpture_Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length <= 2)
                {
                    throw new IndexOutOfRangeException();
                }
                _name = value;
            }
        }
        [JsonProperty(PropertyName = "Sculpture_Address")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        [JsonProperty(PropertyName = "Sculpture_Placement")]
        public string Placement
        {
            get { return _placement; }
            set { _placement = value; }
        }
        [JsonProperty(PropertyName = "Sculpture_Picture")]
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        [JsonProperty(PropertyName = "Sculpture_InsFreq")]
        public int InspectionFrequency
        {
            get { return _inspectionFrequency; }
            set { _inspectionFrequency = value; }
        }
        [JsonProperty(PropertyName = "Sculpture_DNI")]
        public bool DoNotInspect
        {
            get { return _doNotInspect; }
            set { _doNotInspect = value; }
        }
        [JsonProperty(PropertyName = "Sculpture_Material")]
        public string Material
        {
            get { return _material; }
            set { _material = value; }
        }
        [JsonProperty(PropertyName = "Sculpture_Type")]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        // Empty constructor
        public SculptureModel()
        {
            
        }

        //Constructor
        public SculptureModel(int id, string name, string address, string placement, string picture, int inspectionFrequency, bool doNotInspect, string material, string type)
        {
            _id = id;
            _name = name;
            _address = address;
            _placement = placement;
            _picture = picture;
            _inspectionFrequency = inspectionFrequency;
            _doNotInspect = doNotInspect;
            _material = material;
            _type = type;
        }

    }
}
