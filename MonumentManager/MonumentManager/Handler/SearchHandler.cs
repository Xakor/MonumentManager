using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using MonumentManager.Annotations;
using MonumentManager.Model;
using MonumentManager.ViewModel;

namespace MonumentManager.Handler
{
    class SearchHandler
    {
        //reference to the view model
        public MainPageViewModel MainPageViewModel { get; set; }
        //an instance of it
        public SearchHandler(MainPageViewModel searchViewModel)
        {
            MainPageViewModel = searchViewModel;
            
        }

        //Run the search command, and retrieve data based on the specified term in the search box.
        public async void RunSearch()
        {
            //Clear the SearchCollection, in case of a previous search
            MainPageViewModel.SearchResults.Clear();

            //Check if the content of the box is null
            if (MainPageViewModel.SearchTerm != null) {
                //Save the search term from the search box, as a string
                string searchTerm = MainPageViewModel.SearchTerm;

                //LINQ Query of our Sculpture Catalog
                IEnumerable<SculptureModel> sculptureQuery =
                    from sculp in MainPageViewModel.SculptureCatalogSingleton.Sculptures
                    where sculp.Name.Contains(searchTerm)
                    orderby sculp.Name
                    select sculp;

                //Add the result to our own list
                if (sculptureQuery.Count() != 0 || searchTerm == String.Empty)
                {
                    foreach (var sculpture in sculptureQuery)
                    {
                        MainPageViewModel.SearchResults.Add(sculpture);
                    }
                }
                else
                {
                    var dialog = new MessageDialog("The Search Term: " + searchTerm + " - did not yield a result");
                    await dialog.ShowAsync();
                    //Message.CreateMessage(MessageVersion.Default, "The Search Term: " + searchTerm + " - did not yield a result");
                }
                MainPageViewModel.SearchTerm = String.Empty;
            }
            else
            {
                var nullDialog = new MessageDialog("The Searchbox is empty, please fill in a word or phrase");
                await nullDialog.ShowAsync();
            }
        }
    }
}
