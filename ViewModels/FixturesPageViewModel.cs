using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using MySql.Data.MySqlClient;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FinalYearProjectDesktop.ViewModels;

public partial class FixturesPageViewModel : ViewModelBase, INotifyPropertyChanged
{
    [ObservableProperty]
    private bool _isManagerLoggedIn = Login.IsManagerLoggedIn;

    public int fixtureCount = 0;
    public int seTigersFixtureCount = 0;

    public List<Tuple<int, DateTime, string, string, string, string, string>> fixtureInfo = new List<Tuple<int, DateTime, string, string, string, string, string>>();
    public List<Tuple<int, DateTime, string, string, string, string, string>> seTigersFixtureInfo = new List<Tuple<int, DateTime, string, string, string, string, string>>();

    // All SE Tigers fixtures
    public ObservableCollection<Fixture> SETigersFixtures { get; } = new();

    // Fixtures for one week (changes depending on week selected)
    public ObservableCollection<Fixture> WeekFixtures { get; } = SearchResults.WeekFixtures;
    private void SearchResults_Searched(object? sender, EventArgs e)
    {
        //SearchResults.WeekFixtures;
    }

    /* Set of fixtures for each week.
     * 
     * The fixtures are seperated week by week so that they can be bound to 
     * seperate grids, and appear cleaner in the app, rather than just a 
     * long list of 90 fixtures.
     */
    public ObservableCollection<Fixture> Week1Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week2Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week3Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week4Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week5Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week6Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week7Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week8Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week9Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week10Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week11Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week12Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week13Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week14Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week15Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week16Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week17Fixtures { get; } = new();
    public ObservableCollection<Fixture> Week18Fixtures { get; } = new();

    public FixturesPageViewModel() : base()
    {
        getFixtureInfo();

        // Populate the SETigersFixtures ObservableCollection
        for (int i = 0; i < seTigersFixtureCount; i++)
        {
            SETigersFixtures.Add(new Fixture(
            "Week " + seTigersFixtureInfo[i].Item1.ToString(),
            seTigersFixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
            seTigersFixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
            seTigersFixtureInfo[i].Item3,
            $"{seTigersFixtureInfo[i].Item4}-{seTigersFixtureInfo[i].Item5}",
            seTigersFixtureInfo[i].Item6,
            seTigersFixtureInfo[i].Item7
            ));
        }

        // Populate the week-by-week fixture ObservableCollections
        for (int i = 0; i < fixtureCount; i++)
        {
            switch (i) {
                case int n when (n >= 0 && n < 5):
                    Week1Fixtures.Add(new Fixture(
                    "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                    fixtureInfo[i].Item3,
                    $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                    fixtureInfo[i].Item6,
                    fixtureInfo[i].Item7
                    ));
                    break;
                case int n when (n >= 5 && n < 10):
                    Week2Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                     break;
                case int n when (n >= 10 && n < 15):
                    Week3Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 15 && n < 20):
                    Week4Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 20 && n < 25):
                    Week5Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 25 && n < 30):
                    Week6Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 30 && n < 35):
                    Week7Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 35 && n < 40):
                    Week8Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 40 && n < 45):
                    Week9Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 45 && n < 50):
                    Week10Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 50 && n < 55):
                    Week11Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 55 && n < 60):
                    Week12Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 60 && n < 65):
                    Week13Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 65 && n < 70):
                    Week14Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 70 && n < 75):
                    Week15Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 75 && n < 80):
                    Week16Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 80 && n < 85):
                    Week17Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0, 5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
                case int n when (n >= 85 && n < 90):
                    Week18Fixtures.Add(new Fixture(
                     "Week " + fixtureInfo[i].Item1.ToString(),
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[0],
                     fixtureInfo[i].Item2.ToString("dd/MM/yy hh:mm:ss").Split()[1].Substring(0,5),
                     fixtureInfo[i].Item3,
                     $"{fixtureInfo[i].Item4}-{fixtureInfo[i].Item5}",
                     fixtureInfo[i].Item6,
                     fixtureInfo[i].Item7
                     ));
                    break;
            }
        }
    }

    public void getFixtureInfo()
    {
        using (var connection = new MySqlConnection(DatabaseInfo.connString))
        {
            connection.Open();
            var command = connection.CreateCommand();

            // Counting fixture list size
            command.CommandText = "SELECT COUNT(*) FROM fixtures";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read() != false)
                {
                    fixtureCount = reader.GetInt32(0);
                }
                reader.Close();
            }

            // Counting games played by SE Tigers
            command.CommandText = "SELECT COUNT(*) FROM fixtures WHERE home_team = 'SE Tigers' OR away_team = 'SE Tigers'";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read() != false)
                {
                    seTigersFixtureCount = reader.GetInt32(0);
                }
                reader.Close();
            }

            // Take fixture information from database
            fixtureInfo = new List<Tuple<int, DateTime, string, string, string, string, string>>();
            command.CommandText = "SELECT * FROM fixtures ORDER BY date_and_time, home_team";
            using (var reader = command.ExecuteReader())
            {
                fixtureInfo = new List<Tuple<int, DateTime, string, string, string, string, string>>();
                for (int i = 0; i < fixtureCount; i++)
                {
                    if (reader.Read() != false)
                    {
                        if (reader.IsDBNull(0))
                        {
                            continue;
                        }
                        else
                        {
                            fixtureInfo.Add(new Tuple<int, DateTime, string, string, string, string, string>
                                (reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                reader.Close();
            }

            // Take fixture information from database where SE Tigers are playing
            seTigersFixtureInfo = new List<Tuple<int, DateTime, string, string, string, string, string>>();
            command.CommandText = "SELECT * FROM fixtures WHERE home_team = 'SE Tigers' OR away_team = 'SE Tigers' ORDER BY date_and_time, home_team";
            using (var reader = command.ExecuteReader())
            {
                seTigersFixtureInfo = new List<Tuple<int, DateTime, string, string, string, string, string>>();
                for (int i = 0; i < seTigersFixtureCount; i++)
                {
                    if (reader.Read() != false)
                    {
                        if (reader.IsDBNull(0))
                        {
                            continue;
                        }
                        else
                        {
                            seTigersFixtureInfo.Add(new Tuple<int, DateTime, string, string, string, string, string>
                                (reader.GetInt32(0), reader.GetDateTime(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6)));
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                reader.Close();
            }
            connection.Close();
        }
    }
}

public class Fixture
{
    public Fixture(string week, string date, string time, string hometeam, string score, string awayteam, string venue)
    {
        Week = week;
        Date = date;
        Time = time;
        HomeTeam = hometeam;
        Score = score;
        AwayTeam = awayteam;
        Venue = venue;
    }
    public string Week { get; }
    public string Date { get; }
    public string Time { get; }
    public string HomeTeam { get; }
    public string Score { get; }
    public string AwayTeam { get; }
    public string Venue { get; }

}

public static class SearchResults
{
    public static event EventHandler? Searched;

    private static ObservableCollection<Fixture> _weekFixtures = new();

    public static ObservableCollection<Fixture> WeekFixtures
    {
        get => _weekFixtures;
        set
        {
            _weekFixtures = value;
            Searched?.Invoke(null, EventArgs.Empty);
        }
    }

}