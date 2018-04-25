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
            IEnumerable<string> team = null;

            ImageBrush logo = new ImageBrush();
            SolidColorBrush theme = new SolidColorBrush();

            switch (e.Parameter) {
                case 1:
                    tblHeader.Text = "Ireland";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Ireland'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    team = client.Cypher
                    .Match("(t:Team)")
                    .Where("t.name = 'Ireland'")
                    .Return<string>("properties(t)").Results;

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

                    team = client.Cypher
                     .Match("(t:Team)")
                     .Where("t.name = 'Scotland'")
                     .Return<string>("properties(t)").Results;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/ScotlandLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 4, 77, 133));
                    break;
                case 3:
                    tblHeader.Text = "England";
                    rectLogoBackground.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'England'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    team = client.Cypher
                    .Match("(t:Team)")
                    .Where("t.name = 'England'")
                    .Return<string>("properties(t)").Results;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/EnglandLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 186, 18, 54));
                    break;
                case 4:
                    tblHeader.Text = "France";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'France'})")
                    .Return<string>("p.name").Results;
                    lvPlayers.ItemsSource = players;

                    team = client.Cypher
                    .Match("(t:Team)")
                    .Where("t.name = 'France'")
                    .Return<string>("properties(t)").Results;

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

                    team = client.Cypher
                    .Match("(t:Team)")
                    .Where("t.name = 'Wales'")
                    .Return<string>("properties(t)").Results;

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

                    team = client.Cypher
                    .Match("(t:Team)")
                    .Where("t.name = 'Italy'")
                    .Return<string>("properties(t)").Results;

                    logo.ImageSource = new BitmapImage(new Uri("ms-appx:///Images/ItalyLogo.png", UriKind.RelativeOrAbsolute));
                    rectLogo.Fill = logo;

                    theme = new SolidColorBrush(Color.FromArgb(255, 31, 79, 162));
                    break;
            }

            if(tblHeader.Text != "England")
            rectLogoBackground.Fill = theme;

            rectTop.Fill = theme;
            rectDivide1.Fill = theme;
            rectDivide2.Fill = theme;

            coach = client.Cypher
            .Match("(p:Person)-[:COACHS]->(m:Team {name: '" + tblHeader.Text + "'})")
            .Return<string>("properties(p)").Results;

            grounds = client.Cypher
           .Match("(g:Grounds)-[:GROUNDS_OF]->(m:Team {name: '" + tblHeader.Text + "'})")
           .Return<string>("properties(g)").Results;

            var coachInfo = string.Join(",", coach.ToArray());
            var groundsInfo = string.Join(",", grounds.ToArray());
            var teamStats = string.Join(",", team.ToArray());
            var charsToRemove = new string[] { "{", "}", ",", "\"" };
            var wordsToReplace = new string[] { "years_coached", "name", "opened", "capacity", "captain", "lineoutsLost", "redCards", "metresGained"
            , "lineoutsWon", "penaltiesConceded", "mostTackles", "triesScored", "totalPoints", "mostPasses", "penaltiesWon" , "yellowCards" };

            foreach (var c in charsToRemove)
            {
                coachInfo = coachInfo.Replace(c, string.Empty);
                groundsInfo = groundsInfo.Replace(c, string.Empty);
                teamStats = teamStats.Replace(c, string.Empty);
            }

            foreach (var c in wordsToReplace)
            {
                switch (c)
                {
                    case "years_coached":
                        coachInfo = coachInfo.Replace(c, "Years Coached");
                        break;
                    case "name":
                        coachInfo = coachInfo.Replace(c, "Name");
                        groundsInfo = groundsInfo.Replace(c, "Name");
                        teamStats = teamStats.Replace(c, "Name");
                        break;
                    case "opened":
                        groundsInfo = groundsInfo.Replace(c, "Year Opened");
                        break;
                    case "capacity":
                        groundsInfo = groundsInfo.Replace(c, "Capacity");
                        break;
                    case "captain":
                        teamStats = teamStats.Replace(c, "Captain");
                        break;
                    case "lineoutsLost":
                        teamStats = teamStats.Replace(c, "Lineouts Lost");
                        break;
                    case "redCards":
                        teamStats = teamStats.Replace(c, "Red Cards");
                        break;
                    case "metresGained":
                        teamStats = teamStats.Replace(c, "Metres Gained");
                        break;
                    case "lineoutsWon":
                        teamStats = teamStats.Replace(c, "Lineouts Won");
                        break;
                    case "penaltiesConceded":
                        teamStats = teamStats.Replace(c, "Penalties Conceded");
                        break;
                    case "mostTackles":
                        teamStats = teamStats.Replace(c, "Most Tackles");
                        break;
                    case "triesScored":
                        teamStats = teamStats.Replace(c, "Tries Scored");
                        break;
                    case "totalPoints":
                        teamStats = teamStats.Replace(c, "Total Points");
                        break;
                    case "mostPasses":
                        teamStats = teamStats.Replace(c, "Most Passes");
                        break;
                    case "penaltiesWon":
                        teamStats = teamStats.Replace(c, "Pentalties Won");
                        break;
                    case "yellowCards":
                        teamStats = teamStats.Replace(c, "Yellow Cards");
                        break;
                }
                
            }

            tbCoach.Text = coachInfo;
            tbGrounds.Text = groundsInfo;
            tbTeamStats.Text = teamStats;
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

            var playerInfo = string.Join(",",info.ToArray());
            var charsToRemove = new string[] { "{", "}", ",", "\"" };
            var wordsToReplace = new string[] { "name", "caps", "points", "position" };

            foreach (var c in charsToRemove)
            {
                playerInfo = playerInfo.Replace(c, string.Empty);
            }

            foreach (var c in wordsToReplace)
            {
                switch (c)
                {
                    case "name":
                        playerInfo = playerInfo.Replace(c, "Name");
                        break;
                    case "caps":
                        playerInfo = playerInfo.Replace(c, "Caps");
                        break;
                    case "points":
                        playerInfo = playerInfo.Replace(c, "Points");
                        break;
                    case "position":
                        playerInfo = playerInfo.Replace(c, "Position");
                        break;
                }

            }

            tbPlayerInfo.Text = playerInfo;
        }
    }
}
