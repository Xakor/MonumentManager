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
using MonumentManager.Annotations;
using MonumentManager.Model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MonumentManager.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GridPage : Page
    {
        public GridPage()
        {
            this.InitializeComponent();
            MainPage Main = new MainPage(this.Frame);

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (ListPage));
        }

        private void StackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DetailsPage));
        }

        private void AppBarButtonAddSculpture_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddSculpturePage));
        }

        //public void GridView_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    MainPage.
        //}
    }
}
