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

            switch (e.Parameter) {
                case 1:
                    tblHeader.Text = "Ireland";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Ireland'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = players;
                    break;
                case 2:
                    tblHeader.Text = "SCOTLAND";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Scotland'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = players;
                    break;
                case 3:
                    tblHeader.Text = "ENGLAND";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'England'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = players;
                    break;
                case 4:
                    tblHeader.Text = "FRANCE";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'France'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = players;
                    break;
                case 5:
                    tblHeader.Text = "WALES";

                    players = client.Cypher
                .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Wales'})")
                .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = players;
                    break;
                case 6:
                    tblHeader.Text = "Italy";

                    players = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Italy'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = players;
                    break;
            }

            coach = client.Cypher
            .Match("(p:Person)-[:COACHS]->(m:Team {name: '" + tblHeader.Text + "'})")
            .Return<string>("properties(p)").Results;

            grounds = client.Cypher
           .Match("(g:Grounds)-[:GROUNDS_OF]->(m:Team {name: '" + tblHeader.Text + "'})")
           .Return<string>("properties(g)").Results;

            var singleString1 = string.Join(",", coach.ToArray());
            var singleString2 = string.Join(",", grounds.ToArray());
            var charsToRemove = new string[] { "{", "}", " ", ",", "name", "position", "caps", "points", ":", "\"" };

            foreach (var c in charsToRemove)
            {
                singleString1 = singleString1.Replace(c, string.Empty);
                singleString2 = singleString2.Replace(c, string.Empty);
            }

            tbCoach.Text = singleString1;
            tbGrounds.Text = singleString2;
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
            tbCoach.Text = "" + name;

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
