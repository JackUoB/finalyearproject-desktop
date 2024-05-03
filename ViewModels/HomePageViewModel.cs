using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;

namespace FinalYearProjectDesktop.ViewModels;

public partial class HomePageViewModel : ViewModelBase, INotifyPropertyChanged
{
    [ObservableProperty]
    public string _lastMatchHomeTeam = string.Empty;

    [ObservableProperty]
    public string _lastMatchHomeScore = string.Empty;

    [ObservableProperty]
    public string _lastMatchAwayScore = string.Empty;

    [ObservableProperty]
    public string _lastMatchAwayTeam = string.Empty;

    [ObservableProperty]
    public string _lastMatchInfo = string.Empty;

    [ObservableProperty]
    public string _nextMatchHome = string.Empty;

    [ObservableProperty]
    public string _nextMatchAway = string.Empty;

    [ObservableProperty]
    public string _nextMatchInfo = string.Empty;

    int teamCount = 0;
    public ObservableCollection<Team> Teams { get; } = new();

    public HomePageViewModel() {
        getMatchInfo();
        getLeagueTableInfo();
    }

    public void getMatchInfo()
    {
        using (var connection = new MySqlConnection(DatabaseInfo.connString))
        {
            connection.Open();
            var command = connection.CreateCommand();

            // Counting league size
            command.CommandText = "SELECT * FROM fixtures " +
                "WHERE home_team = 'SE Tigers' AND date_and_time < CURRENT_TIMESTAMP " +
                "OR away_team = 'SE Tigers' AND date_and_time < CURRENT_TIMESTAMP " +
                "ORDER BY week DESC LIMIT 1";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read() != false)
                {
                    LastMatchHomeTeam = reader.GetString(2);
                    LastMatchHomeScore = reader.GetString(3);
                    LastMatchAwayScore = reader.GetString(4);
                    LastMatchAwayTeam = reader.GetString(5);
                    LastMatchInfo = $"Match was played on {reader.GetDateTime(1).ToString("dd/MM/yy hh:mm:ss").Split()[0]} at {reader.GetString(6)}";
                }
                reader.Close();
            }

            command.CommandText = "SELECT * FROM fixtures " +
                "WHERE home_team = 'SE Tigers' AND date_and_time > CURRENT_TIMESTAMP " +
                "OR away_team = 'SE Tigers' and date_and_time > CURRENT_TIMESTAMP " +
                "ORDER BY week LIMIT 1";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read() != false)
                {
                    NextMatchHome = reader.GetString(2);
                    NextMatchAway = reader.GetString(5);
                    NextMatchInfo = $"Match will be played on {reader.GetDateTime(1).ToString("dd/MM/yy hh:mm:ss").Split()[0]} at {reader.GetString(6)}";
                }
                reader.Close();
            }

            connection.Close();
        }
    }

    public void getLeagueTableInfo()
    {
        LeagueTablePageViewModel league = new LeagueTablePageViewModel();
        league.getLeagueTableInfo();

        using (var connection = new MySqlConnection(DatabaseInfo.connString))
        {
            connection.Open();
            var command = connection.CreateCommand();

            // Counting league size
            command.CommandText = "SELECT COUNT(*) FROM squad";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read() != false)
                {
                    teamCount = reader.GetInt32(0);
                }
                reader.Close();
            }

            // Take league table information from database
            command.CommandText = "SELECT * FROM league_table ORDER BY points DESC, goal_difference DESC, goals_for DESC, name";
            using (var reader = command.ExecuteReader())
            {
                for (int i = 0; i < teamCount; i++)
                {
                    if (reader.Read() != false)
                    {
                        if (reader.IsDBNull(0))
                        {
                            continue;
                        }
                        else
                        {
                            Teams.Add(new Team(
                                i + 1,
                                reader.GetString(0),
                                reader.GetInt32(1),
                                reader.GetInt32(2),
                                reader.GetInt32(3),
                                reader.GetInt32(4),
                                reader.GetInt32(5),
                                reader.GetInt32(6),
                                reader.GetInt32(7),
                                reader.GetInt32(8)));
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
