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

        //this is a method for refreshing the list -to be used after add/delete/update
        public void UpdateSculptureCollection()
        {
            var sculptures = new PersistencyFacade().GetSculptures();

            MainPageViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach (var sculpt in sculptures)
            {
                MainPageViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpt);
            }

        }

        //public void UpdateInspectionCollection()
        //{
        //    var inspections = new PersistencyFacade().GetInspections();

        //    MainPageViewModel.SculptureCatalogSingleton.Inspections.Clear();
        //    foreach (var inspection in inspections)
        //    {
        //        MainPageViewModel.SculptureCatalogSingleton.Inspections.Add(inspection);
        //    }

        //}

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

            // this can also be done by simply calling the UpdateSculptureCollection() but for now we do it like this.
            var sculptures = new PersistencyFacade().GetSculptures();

            MainPageViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach (var sculpt in sculptures)
            {
                MainPageViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpt);
            }
            


        }

        public void DelSculpture()
        {   //this is for doing it without icommands but we can't :(
            //var sculptureId = MainPageViewModel.SelectedSculpture.Id;
            //await new Persistency.PersistencyFacade().DeleteSculpture(sculptureId);

            new PersistencyFacade().DeleteSculpture(MainPageViewModel.SelectedSculpture);

            //refresh collection
            UpdateSculptureCollection();
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

    //    public void AddInspection()
    //    {
    //        InspectionModel inspection = new InspectionModel();
    //        inspection.sculptureId = MainPageViewModel.SelectedSculpture.Id;// not sure about this one
    //        inspection.Id = MainPageViewModel.SelectedInspection.Id;
    //        inspection.NoteContent = MainPageViewModel.SelectedInspection.NoteContent;
    //        inspection.NoteTitle = MainPageViewModel.SelectedInspection.NoteTitle;
    //        inspection.date = MainPageViewModel.SelectedInspection.date;

    //        make a new instance of persistency class and pass on the save method with the parameter we created above
    //        new PersistencyFacade().SaveInspection(inspection);
    //    refresh collection
    //        UpdateInspectionCollection();

    //}

    public void AddDamage()
        {
            //DamageModel damage = new DamageModel();
            //damage.Id = MainPageViewModel.
        }
    }
    }


