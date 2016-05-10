using System;
using System.Collections.Generic;
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
        //Constructor - you need to instanciate the various properties here
        public MainPageViewModel()
        {
            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;
            NewSculpture = new SculptureModel();
            //instance of the handler
            SculptureHandler = new Handler.SculptureHandler(this);

            //commands 
            AddSculptureCommand = new RelayCommand(SculptureHandler.AddSculpture);
            DelSculptureCommand = new RelayCommand(SculptureHandler.DelSculpture);
            SortListAlphabeticallyCommand = new RelayCommand(SculptureHandler.SortListAlphabetically);
            SortListNumericallyCommand = new RelayCommand(SculptureHandler.SortListNumerically);
            SortListByAddressCommand = new RelayCommand(SculptureHandler.SortListByAddress);
            AddDamageCommand = new RelayCommand(SculptureHandler.AddDamage);
            AddInspectionCommand = new RelayCommand(SculptureHandler.AddInspection);

        }
        // handler property 
        public SculptureHandler SculptureHandler { get; set; }

        //View Model Code
        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }
        
        //Delete & Add commands 
        public ICommand AddSculptureCommand { get; set; }
        public ICommand DelSculptureCommand { get; set; }

        // Sort commands
        public ICommand SortListAlphabeticallyCommand { get; set; }
        public ICommand SortListNumericallyCommand { get; set; }
        public ICommand SortListByAddressCommand { get; set; }

        // Inspection & Damage commands

        public ICommand AddInspectionCommand { get; set; }
        public ICommand AddDamageCommand { get; set; }

        //Selected Item from lists
        private SculptureModel _selectedSculpture;

        public SculptureModel SelectedSculpture
        {
            get { return _selectedSculpture; }
            set { _selectedSculpture = value; OnPropertyChanged(); }
        }

        //Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } //End MainPageViewModel.cs
}
