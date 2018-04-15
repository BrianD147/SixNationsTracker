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

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Text;
using Neo4jClient;
using Neo4j.Driver.V1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SixNationsTracker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IrelandPage : Page
    {
        
        public IrelandPage()
        {
            this.InitializeComponent();

            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "Rubydoy14");
            client.Connect();

            IEnumerable<string> results = client.Cypher
            .Match("(p:Person)-[:ACTED_IN]->(m:Movie {title: 'Top Gun'})")
            .Return<string>("p.name").Results;

            lvCenter.ItemsSource = results;

        }

        private void TbReturn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
