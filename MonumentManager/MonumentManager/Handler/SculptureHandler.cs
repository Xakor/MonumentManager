using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MonumentManager.Model;
using MonumentManager.Persistency;
using MonumentManager.ViewModel;
//using SculptureCatalogSingleton  = MonumentManager.Model.SculptureCatalogSingleton;

namespace MonumentManager.Handler
{
     class SculptureHandler

    {
       // private static SculptureCatalogSingleton CatalogSingleton { get; } = SculptureCatalogSingleton.Instance;

        //reference to the view model
        public MainPageViewModel MainPageViewModel { get; set; }
        //an instance of it
        public SculptureHandler(MainPageViewModel SculptureViewModel)
        {
            MainPageViewModel = SculptureViewModel;
        }

        //this is a method for refreshing the list -to be used after add/delete
        public void UpdateSculptureCollection()
        {
            var sculptures = new PersistencyFacade().GetSculptures();
            //var sculptures = new ObservableCollection<SculptureModel>(new PersistencyFacade().GetSculptures());

            MainPageViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach (var sculpture in sculptures)
            {
                MainPageViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpture);
            }

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

            // this can also be done by simply calling the UpdateSculptureCollection() but for now we do it like this.
            var sculptures = new PersistencyFacade().GetSculptures();

            MainPageViewModel.SculptureCatalogSingleton.Sculptures.Clear();
            foreach (var sculpt in sculptures)
            {
                MainPageViewModel.SculptureCatalogSingleton.Sculptures.Add(sculpt);
            }



        }
        public void DelSculpture()
        {

            //new PersistencyFacade().DeleteSculpture(MainPageViewModel.SelectedSculpture);

            new PersistencyFacade().DeleteSculpture(MainPageViewModel.SelectedSculpture);
            //refresh collection
            
            UpdateSculptureCollection();

            // MainPageViewModel.SculptureCatalogSingleton.Sculptures.RemoveAt(MainPageViewModel.SelectedSculpture.Id);
        }

         public void FetchDamages()
         {
            
            if (MainPageViewModel.SelectedSculpture != null)
             {
                IEnumerable<DamageModel> damageQuery =
                     from damage in SculptureCatalogSingleton.Instance.Damages
                     where damage.SculptureId == MainPageViewModel.SelectedSculpture.Id
                     select damage;

                 foreach (var damage in damageQuery)
                 {
                     MainPageViewModel.DamageQueryCollection.Add(damage);
                 }
             }
         }

         public void FetchInspections()
         {
             if (MainPageViewModel.SelectedSculpture != null)
             {
                IEnumerable<InspectionModel> inspectionQuery =
                     from ins in SculptureCatalogSingleton.Instance.Inspections
                     where ins.sculptureId == MainPageViewModel.SelectedSculpture.Id
                     select ins;

                 foreach (var inspection in inspectionQuery)
                 {
                     MainPageViewModel.InspectionQueryCollection.Add(inspection);
                 }
             }
        }//end FetchInspections


         public void AddInspection()
         {
             //int Sculpture_Id = MainPageViewModel.SelectedSculpture.Id;
             //int Inspection_Id = MainPageViewModel.NewInspection.Id;
             ////DateTime Date = MainPageViewModel.NewInspection.date;
             //string NoteTitle = MainPageViewModel.NewInspection.NoteTitle;
             //string NoteContent = MainPageViewModel.NewInspection.NoteContent;
             
             InspectionModel ins = new InspectionModel();

             ins.Sculpture = MainPageViewModel.SelectedSculpture;
             ins.sculptureId = MainPageViewModel.SelectedSculpture.Id;
             ins.Id =MainPageViewModel.NewInspection.Id;
             ins.NoteTitle = MainPageViewModel.NewInspection.NoteTitle;
             ins.NoteContent =MainPageViewModel.NewInspection.NoteContent;

            new PersistencyFacade().AddInspection(ins);

            var inspections = new PersistencyFacade().GetInspections();

            MainPageViewModel.SculptureCatalogSingleton.Inspections.Clear();
            foreach (var inspection in inspections)
            {
                MainPageViewModel.SculptureCatalogSingleton.Inspections.Add(inspection);
            }


           FetchInspections();
         }
    }//end Class
}//End Namespace

       

        //public static void SortCollection(string criteria)
        //{
        //    var sortedCollection = CatalogSingleton.Sculptures.ToList();

        //    switch (criteria)
        //    {
        //        case "id":
        //            sortedCollection = CatalogSingleton.Sculptures.OrderBy(x => x.Id).ToList();
        //            break;
        //        case "name":
        //            sortedCollection = CatalogSingleton.Sculptures.OrderBy(x => x.Name).ToList();
        //            break;
        //        case "address":
        //            sortedCollection = CatalogSingleton.Sculptures.OrderBy(x => x.Address).ToList();
        //            break;
        //        default:
        //            throw new Exception(criteria);
        //    }
        //    // sortedCollection = sortedCollection.OrderBy(x => x.Name).ToList();
        //    CatalogSingleton.Sculptures.Clear();

        //    foreach (var sculpture in sortedCollection)
        //    {
        //        CatalogSingleton.Sculptures.Add(sculpture);
        //    }

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

//    public
//void AddDamage()
//    {
//        //DamageModel damage = new DamageModel();
//        //damage.Id = MainPageViewModel.
//    }



