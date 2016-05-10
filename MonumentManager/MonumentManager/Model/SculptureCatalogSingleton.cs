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
        //Instanciate the singleton
        private static SculptureCatalogSingleton instance = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance
        {
            get { return instance; }
        }

        //Actual Hotel Collection
        public ObservableCollection<SculptureModel> Sculptures { get; set; }


        private SculptureCatalogSingleton()
        {
            Sculptures = new ObservableCollection<SculptureModel>();

            //This is to get data from the database
            Sculptures = new ObservableCollection<SculptureModel>(new PersistencyFacade().GeSculptures());
            //This is to get data from the database
            
        }

        //Add to SculptureCatalog Method
        public void Add(int Sculpture_Id, string Sculpture_Name, string Sculpture_Address,string Sculpture_InsFreq, string Sculpture_Placement, int Sculpture_Picture, bool Sculpture_DNI, string Sculpture_Material, string Sculpture_Type)
        {
            Sculptures.Add(new SculptureModel( Sculpture_Id,Sculpture_Name,Sculpture_Address,Sculpture_InsFreq,Sculpture_Placement,Sculpture_Picture,Sculpture_DNI,Sculpture_Material,Sculpture_Type));
        }
    }
}
