using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonumentManager.Persistency;

namespace MonumentManager.Model
{
    class SculptureCatalogSingleton
    {
        //Here we instanciate the singleton
        private static SculptureCatalogSingleton _instance; // = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance
        {
            get { return _instance ?? new SculptureCatalogSingleton();  }
        }

        //Actual  Collections
        public ObservableCollection<SculptureModel> Sculptures { get; set; }
        public ObservableCollection<InspectionModel> Inspections { get; set; }
        // public ObservableCollection<DamageModel> Damages { get; set; }

        private SculptureCatalogSingleton()
        {
            
            //This is to get data from the database
            Sculptures = new ObservableCollection<SculptureModel>(new PersistencyFacade().GetSculptures());
           
            Inspections = new ObservableCollection<InspectionModel>(new PersistencyFacade().GetInspections());
           // Damages = new ObservableCollection<DamageModel>(new PersistencyFacade().GetDamages());

            //This is to get data from the database

        }

        //Add to SculptureCatalog Method
        public void Add(int sculptureId, string sculptureName, string sculptureAddress, string sculpturePlacement, string sculpturePicture, int sculptureInsFreq, bool sculptureDNI, string sculptureMaterial, string sculptureType)
        {
            Sculptures.Add(new SculptureModel(sculptureId, sculptureName, sculptureAddress, sculpturePlacement, sculpturePicture, sculptureInsFreq, sculptureDNI, sculptureMaterial, sculptureType));
        }

        //public void Add2(int id, DateTime date, int sculptureID, string noteTitle, string noteContent )
        //{
        //    Inspections.Add(new InspectionModel(id,date,sculptureID,noteTitle,noteContent));
        //}
    }
}
