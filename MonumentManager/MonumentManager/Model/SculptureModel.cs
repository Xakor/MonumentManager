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
        private int _inspectionId;
        private int _inspectionFrequency;
        private bool _doNotInspect;

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
        public int InspectionId
        {
            get { return _inspectionId; }
            set { _inspectionId = value; }
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

        //Constructor
        public SculptureModel(int id, string name, string address, string placement, string picture, int inspectionId, int inspectionFrequency, bool doNotInspect)
        {
            _id = id;
            _name = name;
            _address = address;
            _placement = placement;
            _picture = picture;
            _inspectionId = inspectionId;
            _inspectionFrequency = inspectionFrequency;
            _doNotInspect = doNotInspect;
        }
    }
}
