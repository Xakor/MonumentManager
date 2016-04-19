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
            SculptureModel s1 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", 1, 5, false);
            SculptureModel s2 = new SculptureModel(2, "Tre Løver", "Strøget 132", "Jorden", 2, 10, false);
            SculptureModel s3 = new SculptureModel(3, "Rytter til Fods", "Ørstedsparken", "Jorden", 3, 7, false);
            Sculptures.Add(s1);
            Sculptures.Add(s2);
            Sculptures.Add(s3);

            //This is to get data from the database, dont think about for now!
                //Sculptures = new ObservableCollection<SculptureModel>(new PersistenceFacade().GetSculptures());
        }

        //Add to SculptureCatalog Method
        public void Add(int id, string name, string address, string placement, int inspectionId, int inspectionFrequency, bool doNotInspect)
        {
            Sculptures.Add(new SculptureModel(id, name, address, placement, inspectionId, inspectionFrequency, doNotInspect));
        }
    }
}
