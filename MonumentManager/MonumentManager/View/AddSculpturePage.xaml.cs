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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MonumentManager.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSculpturePage : Page
    {
        public AddSculpturePage()
        {
            this.InitializeComponent();
            NameBox.Text = String.Empty;
            AddressBox.Text = String.Empty;
            PlacementBox.Text = String.Empty;
            MaterialsBox.Text = String.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Implement Click event/Command that adds the sculpture to the database
            Frame.Navigate(typeof(ListPage));
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            InsFreqBox.IsEnabled = false;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            InsFreqBox.IsEnabled = true;
        }
    }
}
