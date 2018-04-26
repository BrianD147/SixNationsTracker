using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SixNationsTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        //Ireland Button Tapped
        private void tb1_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //Navigates to fixtures page
            //Added extra parameter to determine which page should be loaded
            Frame.Navigate(typeof(TeamPage), 1);
        }

        //Scotland Button Tapped
        private void tb2_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //Navigates to fixtures page
            //Added extra parameter to determine which page should be loaded
            Frame.Navigate(typeof(TeamPage), 2);
        }

        //England Button Tapped
        private void tb3_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //Navigates to fixtures page
            //Added extra parameter to determine which page should be loaded
            Frame.Navigate(typeof(TeamPage), 3);
        }

        //France Button Tapped
        private void tb4_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //Navigates to fixtures page
            //Added extra parameter to determine which page should be loaded
            Frame.Navigate(typeof(TeamPage), 4);
        }

        //Wales Button Tapped
        private void tb5_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //Navigates to fixtures page
            //Added extra parameter to determine which page should be loaded
            Frame.Navigate(typeof(TeamPage), 5);
        }

        //Italy Button Tapped
        private void tb6_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //Navigates to fixtures page
            //Added extra parameter to determine which page should be loaded
            Frame.Navigate(typeof(TeamPage), 6);
        }

        //Fixtures Button Tapped
        private void tb7_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            //Navigates to fixtures page
            Frame.Navigate(typeof(FixturesPage));
        }
    }
}
