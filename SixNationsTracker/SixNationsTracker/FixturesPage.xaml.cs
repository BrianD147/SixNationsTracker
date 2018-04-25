using Neo4jClient;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SixNationsTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FixturesPage : Page
    {
        public FixturesPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "Rubydoy14");
            client.Connect();

            IEnumerable<string> fixtures = null;
            var charsToRemove = new string[] { "{", "}", ",", "\"", "[", "]" };
            var wordsToReplace = new string[] { "V", "home", "away", "name:", "round: ", "2018.1", "2018.2", "2018.3", "2018.4", "2018.5", "2019.1", "2019.2", "2019.3", "2019.4", "2019.5" };

            for (int i=1; i<=10; i++)
            {
                switch (i)
                {
                    case 1:
                        fixtures = client.Cypher
                   .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                   .Where("m.round=2018.1")
                   .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 2:
                        fixtures = client.Cypher
                  .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                  .Where("m.round=2018.2")
                  .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 3:
                        fixtures = client.Cypher
                  .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                  .Where("m.round=2018.3")
                  .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 4:
                        fixtures = client.Cypher
                  .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                  .Where("m.round=2018.4")
                  .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 5:
                        fixtures = client.Cypher
                  .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                  .Where("m.round=2018.5")
                  .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 6:
                        fixtures = client.Cypher
                   .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                   .Where("m.round=2019.1")
                   .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 7:
                        fixtures = client.Cypher
                  .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                  .Where("m.round=2019.2")
                  .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 8:
                        fixtures = client.Cypher
                  .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                  .Where("m.round=2019.3")
                  .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 9:
                        fixtures = client.Cypher
                  .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                  .Where("m.round=2019.4")
                  .Return<string>("distinct (properties(m))").Results;
                        break;
                    case 10:
                        fixtures = client.Cypher
                  .Match("(t:Team)-[:PLAY_AGAINST]->(m:Match)")
                  .Where("m.round=2019.5")
                  .Return<string>("distinct (properties(m))").Results;
                        break;
                }

                var fixturesInfo = string.Join(",", fixtures.ToArray());

                foreach (var c in charsToRemove)
                {
                    fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                }

                foreach (var c in wordsToReplace)
                {
                    switch (c)
                    {
                        case "home":
                            fixturesInfo = fixturesInfo.Replace(c, "Home");
                            break;
                        case "away":
                            fixturesInfo = fixturesInfo.Replace(c, "Away");
                            break;
                        case "V":
                            fixturesInfo = fixturesInfo.Replace(c, "  V  ");
                            break;
                        case "name:":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "round: ":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2018.1":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2018.2":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2018.3":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2018.4":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2018.5":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2019.1":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2019.2":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2019.3":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2019.4":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                        case "2019.5":
                            fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                            break;
                    }
                }

                switch (i)
                {
                    case 1:
                        tbFixtures1.Text = fixturesInfo;
                        break;
                    case 2:
                        tbFixtures2.Text = fixturesInfo;
                        break;
                    case 3:
                        tbFixtures3.Text = fixturesInfo;
                        break;
                    case 4:
                        tbFixtures4.Text = fixturesInfo;
                        break;
                    case 5:
                        tbFixtures5.Text = fixturesInfo;
                        break;
                    case 6:
                        tbFixtures6.Text = fixturesInfo;
                        break;
                    case 7:
                        tbFixtures7.Text = fixturesInfo;
                        break;
                    case 8:
                        tbFixtures8.Text = fixturesInfo;
                        break;
                    case 9:
                        tbFixtures9.Text = fixturesInfo;
                        break;
                    case 10:
                        tbFixtures10.Text = fixturesInfo;
                        break;
                }
            }
        }

            private void tbReturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
