﻿using System;
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
        private static SculptureCatalogSingleton _instance; // = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance
        {
            get { return _instance ?? new SculptureCatalogSingleton();  }
        }

        //Actual Hotel Collection
        public ObservableCollection<SculptureModel> Sculptures { get; set; }


        private SculptureCatalogSingleton()
        {
            //Sculptures = new ObservableCollection<SculptureModel>();
            //This is to get data from the database
            Sculptures = new ObservableCollection<SculptureModel>(new PersistencyFacade().GetSculptures());

            //This is to get data from the database

        }

        //Add to SculptureCatalog Method
        public void Add(int sculptureId, string sculptureName, string sculptureAddress,string sculpturePlacement, string sculpturePicture, int sculptureInsFreq, bool sculptureDNI, string sculptureMaterial, string sculptureType)
        {
            Sculptures.Add(new SculptureModel( sculptureId,sculptureName,sculptureAddress, sculpturePlacement, sculpturePicture, sculptureInsFreq, sculptureDNI, sculptureMaterial, sculptureType));
        }
    }
}
