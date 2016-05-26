using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MonumentManager.Annotations;
using MonumentManager.Common;
using MonumentManager.Handler;
using MonumentManager.Model;

namespace MonumentManager.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        private SculptureModel _newSculpture;

        public SculptureModel NewSculpture
        {
            get { return _newSculpture; }
            set { _newSculpture = value; OnPropertyChanged(); }
        }
        //Constructor -  need to instanciate the various properties here
        public MainPageViewModel()
        {
            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;
            SearchResults = new ObservableCollection<SculptureModel>();
            DamageQueryCollection = new ObservableCollection<DamageModel>();
            InspectionQueryCollection = new ObservableCollection<InspectionModel>();
            NewSculpture = new SculptureModel();
            NewInspection= new InspectionModel();
            NewDamage= new DamageModel();
            //instance of the handler
            SculptureHandler = new Handler.SculptureHandler(this);
            SearchHandler = new Handler.SearchHandler(this);
            
            //sculpture commands 
            AddSculptureCommand = new RelayCommand(SculptureHandler.AddSculpture);
            DelSculptureCommand = new RelayCommand(SculptureHandler.DelSculpture);
            //damage/inspection commands
            AddDamageCommand = new RelayCommand(SculptureHandler.AddDamage);
            AddInspectionCommand = new RelayCommand(SculptureHandler.AddInspection);
            //search command
            RunSearchCommand = new RelayCommand(SearchHandler.RunSearch);

        }
        // handler property 
        public SculptureHandler SculptureHandler { get; set; }
        public SearchHandler SearchHandler { get; set; }

        //View Model Code
        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }
        
        
        //Delete & Add commands 
        public ICommand AddSculptureCommand { get; set; }
        public ICommand DelSculptureCommand { get; set; }


        // Inspection & Damage commands

        public ICommand AddInspectionCommand { get; set; }
        public ICommand AddDamageCommand { get; set; }

        // this is a new instance of the sculptureModel class 
        // now we can acces its properties through the AddSculpture method in the handler
        private SculptureModel _selectedSculpture;

        public SculptureModel SelectedSculpture
        {
            get { return _selectedSculpture; }
            set { _selectedSculpture = value; DamageQueryCollection.Clear(); InspectionQueryCollection.Clear(); SculptureHandler.FetchDamages(); SculptureHandler.FetchInspections(); OnPropertyChanged(); }
        }

        private InspectionModel _newInspection;

        public InspectionModel NewInspection
        {
            get { return _newInspection; }
            set { _newInspection = value; OnPropertyChanged(); }

        }


        private DamageModel _newDamage;

        public DamageModel NewDamage
        {
            get { return _newDamage; }
            set { _newDamage = value; OnPropertyChanged(); }
        }


        //The following properties are all related to the Search functionality
        public ObservableCollection<SculptureModel> SearchResults { get; set; } //List of Search Results
        public ICommand RunSearchCommand { get; set; } //The Search Button
        public string SearchTerm { get; set; } //The text in the textbox

        //This is all related to the Damages & Inspections on the detail Page
        public ObservableCollection<DamageModel> DamageQueryCollection { get; set; }
        public ObservableCollection<InspectionModel> InspectionQueryCollection { get; set; }  

        
        //Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } //End MainPageViewModel.cs
}
