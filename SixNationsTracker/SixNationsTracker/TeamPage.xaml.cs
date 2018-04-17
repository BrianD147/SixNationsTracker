using Neo4jClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SixNationsTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeamPage : Page
    {
        public TeamPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "Rubydoy14");
            client.Connect();

            IEnumerable<string> players;
            IEnumerable<string> coach;
            IEnumerable<string> grounds;

            ImageBrush logo = new ImageBrush();
            SolidColorBrush theme = new SolidColorBrush();

            switch (e.Parameter) {
                case 1:
                    tblHeader.Text = "Ireland";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Ireland'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/IrelandLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 0, 105, 70));
                    break;
                case 2:
                    tblHeader.Text = "Scotland";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Scotland'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/ScotlandLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 4, 77, 133));
                    break;
                case 3:
                    tblHeader.Text = "England";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'England'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/EnglandLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    break;
                case 4:
                    tblHeader.Text = "France";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'France'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/FranceLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 0, 71, 134));
                    break;
                case 5:
                    tblHeader.Text = "Wales";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Wales'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/WalesLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 238, 71, 34));
                    break;
                case 6:
                    tblHeader.Text = "Italy";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Italy'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/ItalyLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 31, 79, 162));
                    break;
            }

            //Theme
            rectTop.Fill = theme;
            rectLogoBackground.Fill = theme;

            coach = client.Cypher
            .Match("(p:Person)-[:COACHS]->(m:Team {name: '" + tblHeader.Text + "'})")
            .Return<string>("properties(p)").Results;

            grounds = client.Cypher
           .Match("(g:Grounds)-[:GROUNDS_OF]->(m:Team {name: '" + tblHeader.Text + "'})")
           .Return<string>("properties(g)").Results;

            var coachInfo = string.Join(",", coach.ToArray());
            var groundsInfo = string.Join(",", grounds.ToArray());
            var charsToRemove = new string[] { "{", "}", " ", ",", "name", "position", "caps", "points", ":", "\"" };

            foreach (var c in charsToRemove)
            {
                coachInfo = coachInfo.Replace(c, string.Empty);
                groundsInfo = groundsInfo.Replace(c, string.Empty);
            }

            tbCoach.Text = coachInfo;
            tbGrounds.Text = groundsInfo;
        }

        private void tbReturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void lvPlayers_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var name = lvPlayers.SelectedItem;

            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "Rubydoy14");
            client.Connect();

            IEnumerable<string> info = client.Cypher
                    .Match("(p:Person) WHERE p.name = '" + name + "'")
                    .Return<string>("properties(p)").Results;

            var singleString = string.Join(",",info.ToArray());
            var charsToRemove = new string[] { "{", "}", " ", ",", "name", "position", "caps", "points", ":", "\"" };

            foreach(var c in charsToRemove)
            {
                singleString = singleString.Replace(c, string.Empty);
            }

            tbPlayerInfo.Text = singleString;
        }
    }
}
