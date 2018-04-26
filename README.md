# SixNationsTracker
Application to review the years Six Nations statistics

---

### Installation Guide
Start by downloading and installing [Neo4j]

Once installed, create your login details and initialize a server.
Access the console through the ' localhost:7474 ' url. (Note: If you created the database on a different port you will need to access it through that port instead of the default :7474)

Next, copy all of the code from '6NationsNeo4j.txt' and paste it into the command line of the neo4j console.
Running this will populate your database.You can view the entire database by typing ' MATCH (n) RETURN n ' into the command line.

Next download and install [Visual Studio]

Once installed open the ' SixNationsTracker.sln ' project solution.

Before running the program, you will have to change the login details in the code (and change the port if you're database was created on a different one).
This line of code will need to be altered on both the ' TeamPage.xaml.cs ' and ' FixturesPage.xaml.cs ':

```csharp
var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "Rubydoy14");
```

> Username: neo4j

> Password: Rubydoy14

You will have to change these to your own login details.

---

Then simply run the program on Visual Studio through ' local machine '.


[Neo4j]: https://neo4j.com/download/
[Visual Studio]: https://www.visualstudio.com/vs/community/
