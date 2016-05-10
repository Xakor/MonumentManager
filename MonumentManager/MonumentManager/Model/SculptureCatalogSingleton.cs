using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //These three should be commented out or removed once we import data from our database
           

            //This is to get data from the database, dont think about for now!
            //Sculptures = new ObservableCollection<SculptureModel>(new PersistenceFacade().GetSculptures());
        }

        //Add to SculptureCatalog Method
       
    }
}
