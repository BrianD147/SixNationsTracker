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

            switch (e.Parameter) {
                case 1:
                    tblHeader.Text = "IRELAND";

                    IEnumerable<string> irelandPlayer = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Ireland'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = irelandPlayer;
                    break;
                case 2:
                    tblHeader.Text = "SCOTLAND";

                    IEnumerable<string> scotlandPlayers = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Ireland'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = scotlandPlayers;
                    break;
                case 3:
                    tblHeader.Text = "ENGLAND";

                    IEnumerable<string> englandPlayers = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Ireland'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = englandPlayers;
                    break;
                case 4:
                    tblHeader.Text = "FRANCE";

                    IEnumerable<string> francePlayers = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Ireland'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = francePlayers;
                    break;
                case 5:
                    tblHeader.Text = "WALES";

                    IEnumerable<string> walesPlayers = client.Cypher
                .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Ireland'})")
                .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = walesPlayers;
                    break;
                case 6:
                    tblHeader.Text = "ITALY";

                    IEnumerable<string> italyPlayers = client.Cypher
                    .Match("(p:Person)-[:PLAYS_FOR]->(m:Team {name: 'Italy'})")
                    .Return<string>("p.name").Results;

                    lvPlayers.ItemsSource = italyPlayers;
                    break;
            }
        }

        private void tbReturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
