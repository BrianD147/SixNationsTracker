using Neo4jClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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

        //Function is loaded when FixturesPage is navigated to
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Establish a connection to the database
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "Rubydoy14");
            client.Connect();

            //Variables
            IEnumerable<string> fixtures = null;
            //Characters to remove and words to replace declared

            var charsToRemove = new string[] { "{", "}", ",", "\"", "[", "]" };
            var wordsToReplace = new string[] { "V", "home", "away", "date", "name:", "round: ", "2018.1", "2018.2", "2018.3", "2018.4", "2018.5", "2019.1", "2019.2", "2019.3", "2019.4", "2019.5" };

            //Loop through 10 times for each fixture and result
            for (int i=1; i<=10; i++)
            {
                //Call different data each time through the loop
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

                //Whatever data was collected is put into a string
                var fixturesInfo = string.Join(",", fixtures.ToArray());

                //check every character in charsToRemove and remove them from all data
                foreach (var c in charsToRemove)
                {
                    fixturesInfo = fixturesInfo.Replace(c, string.Empty);
                }

                //check every word in wordsToReplace and in each case replace relevent data with new word formatting, or removing it entirely
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
                        case "date":
                            fixturesInfo = fixturesInfo.Replace(c, "Date");
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

                //Apply data to relative element
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

        //Function to navigate back to MainPage
        private void tbReturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
