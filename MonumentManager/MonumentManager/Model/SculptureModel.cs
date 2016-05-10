using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentManager.Model
{
    class SculptureModel
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
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Placement
        {
            get { return _placement; }
            set { _placement = value; }
        }
        public string Picture
        {
            get { return _picture; }
            set { _picture = value; }
        }
        public int InspectionFrequency
        {
            get { return _inspectionFrequency; }
            set { _inspectionFrequency = value; }
        }
        public bool DoNotInspect
        {
            get { return _doNotInspect; }
            set { _doNotInspect = value; }
        }

        public string Material
        {
            get { return _material; }
            set { _material = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
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

        public SculptureModel()
        {
            
        }
    }
}
