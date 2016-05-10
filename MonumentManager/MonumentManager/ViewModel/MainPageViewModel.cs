using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using MonumentManager.Annotations;
using MonumentManager.Model;
using MonumentManager.View;

namespace MonumentManager.ViewModel
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        //Constructor - you need to instanciate the various properties here
        public MainPageViewModel()
        {
            SculptureCatalogSingleton = SculptureCatalogSingleton.Instance;
        }
        
        //View Model Code
        public SculptureCatalogSingleton SculptureCatalogSingleton { get; set; }
        
        //Selected Item from lists
        private SculptureModel _selectedSculpture;

        public SculptureModel SelectedSculpture
        {
            get { return _selectedSculpture; }
            set { _selectedSculpture = value; OnPropertyChanged(); }
        }

        private RadioButton _detailsPageRadioButton;

        public RadioButton DetailsPageRadioButton
        {
            get { return _detailsPageRadioButton; }
            set { _detailsPageRadioButton = value; OnPropertyChanged(); }
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
