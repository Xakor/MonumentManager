using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MonumentManager.Model;
using MonumentManager.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MonumentManager.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
        }

        private void SearchFormBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            
        }

        private void ListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

            Frame.Navigate(typeof (DetailsPage));
        }
    }
}
