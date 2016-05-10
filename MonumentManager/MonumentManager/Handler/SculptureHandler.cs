using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonumentManager.Model;
using MonumentManager.Persistency;
using MonumentManager.ViewModel;

namespace MonumentManager.Handler
{
    class SculptureHandler
    {
        //reference to the view model
        public MainPageViewModel MainPageViewModel { get; set; }
        //an instance of it
        public SculptureHandler(MainPageViewModel SculptureViewModel)
        {
            MainPageViewModel = SculptureViewModel;
        }

        public void AddSculpture()
        {
            SculptureModel sculpture = new SculptureModel();
            sculpture.Id = MainPageViewModel.NewSculpture.Id;
            sculpture.Name = MainPageViewModel.NewSculpture.Name;
            sculpture.Address = MainPageViewModel.NewSculpture.Address;
            sculpture.InspectionFrequency = MainPageViewModel.NewSculpture.InspectionFrequency;
            sculpture.Placement = MainPageViewModel.NewSculpture.Placement;
            sculpture.Picture = MainPageViewModel.NewSculpture.Picture;
            sculpture.DoNotInspect = MainPageViewModel.NewSculpture.DoNotInspect;
            sculpture.Material = MainPageViewModel.NewSculpture.Material;
            sculpture.Type = MainPageViewModel.NewSculpture.Type;

            // make a new instance of persistency class and pass on save method with the parameter we created above 
            new PersistencyFacade().SaveSculpture(sculpture);

            //HotelViewModel.HotelCatalogSingleton.Hotels.Add(hotel);
            // we do this because we want to get an update on the hotels 
            // once we have added a new one
            var sculptures = new PersistencyFacade().GetSculptures();

            MainPageViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach (var sculpt in sculptures)
            {
                MainPageViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpt);
            }

            //HotelViewModel.NewHotel.Hotel_No = 0;
            //HotelViewModel.NewHotel.HotelName = "";
            //HotelViewModel.NewHotel.HotelAddress = "";



        }

        public void DelSculpture()
        {
            throw new NotImplementedException();
        }

        public void SortListByAddress()
        {
            throw new NotImplementedException();
        }

        public void SortListNumerically()
        {
            throw new NotImplementedException();
        }

        public void SortListAlphabetically()
        {
            throw new NotImplementedException();
        }

        public void AddInspection()
        {
            throw new NotImplementedException();
        }

        public void AddDamage()
        {
            throw new NotImplementedException();
        }
    }
    }


