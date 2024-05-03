using System.Collections.Generic;
using System;
using Microsoft.Data.Sqlite;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using MySql.Data.MySqlClient;

namespace FinalYearProjectDesktop.ViewModels;

public class LeagueTablePageViewModel : ViewModelBase, INotifyPropertyChanged
{
    public List<Tuple<int, string, string, int, int, string, string>> resultInfo = new List<Tuple<int, string, string, int, int, string, string>>();
    int resultCount = 0;
    int teamCount = 10;

    public ObservableCollection<Team> Teams { get; } = new();

    public LeagueTablePageViewModel()
    {
        getResultInfo();

        List<Tuple<string, int, int, int, int, int, int>> leagueTable = new List<Tuple<string, int, int, int, int, int, int>>();

        // Names of teams into an array
        string[] teams = new string[teamCount];
        for (int i = 0; i < teamCount/2; i++)
        {
            teams[i * 2] = resultInfo[i].Item3;
            teams[i * 2 + 1] = resultInfo[i].Item6;
        }

        // Data for each team
        for (int i = 0; i < teamCount; i++)
        {
            int played = 0;
            int wins = 0;
            int draws = 0;
            int losses = 0;
            int goalsFor = 0;
            int goalsAgainst = 0;

            for (int j = 0; j < resultCount; j++)
            {
                string homeTeam = resultInfo[j].Item3;
                string awayTeam = resultInfo[j].Item6;
                int homeGoals = resultInfo[j].Item4;
                int awayGoals = resultInfo[j].Item5;

                if (teams[i] == homeTeam)
                {
                    played++;
                    goalsFor += homeGoals;
                    goalsAgainst += awayGoals;

                    if (homeGoals > awayGoals)
                    {
                        wins++;
                    }
                    else if (homeGoals == awayGoals)
                    {
                        draws++;
                    }
                    else if (homeGoals < awayGoals)
                    {
                        losses++;
                    }
                } 
                else if (teams[i] == awayTeam)
                {
                    played++;
                    goalsFor += awayGoals;
                    goalsAgainst += homeGoals;

                    if (homeGoals < awayGoals)
                    {
                        wins++;
                    }
                    else if (homeGoals == awayGoals)
                    {
                        draws++;
                    }
                    else if (homeGoals > awayGoals)
                    {
                        losses++;
                    }
                }
            }
            leagueTable.Add(new Tuple<string, int, int, int, int, int, int>(teams[i], played, wins, draws, losses, goalsFor, goalsAgainst));
        }
        insertLeagueTableInfo(leagueTable);
        getLeagueTableInfo();        
    }

    public void getResultInfo()
    {
        using (var connection = new MySqlConnection(DatabaseInfo.connString))
        {
            connection.Open();
            var command = connection.CreateCommand();

            // Counting result list size
            command.CommandText = "SELECT COUNT(*) FROM fixtures WHERE home_score != '' OR away_score != ''";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read() != false)
                {
                    resultCount = reader.GetInt32(0);
                }
                reader.Close();
            }

            // Take result information from database
            resultInfo = new List<Tuple<int, string, string, int, int, string, string>>();
            command.CommandText = "SELECT * FROM fixtures WHERE home_score != '' OR away_score != '' ORDER BY `date_and_time` ASC;";
            using (var reader = command.ExecuteReader())
            {
                resultInfo = new List<Tuple<int, string, string, int, int, string, string>>();
                for (int i = 0; i < resultCount; i++)
                {
                    if (reader.Read() != false)
                    {
                        if (reader.IsDBNull(0))
                        {
                            continue;
                        }
                        else
                        {
                            resultInfo.Add(new Tuple<int, string, string, int, int, string, string>
                                (reader.GetInt32(0), Convert.ToString(reader.GetDateTime(1)), reader.GetString(2), Convert.ToInt32(reader.GetString(3)),
                                Convert.ToInt32(reader.GetString(4)), reader.GetString(5), reader.GetString(6)));
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

    public void insertLeagueTableInfo(List<Tuple<string, int, int, int, int, int, int>> tableData)
    {
        using (var connection = new MySqlConnection(DatabaseInfo.connString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM league_table";
            command.ExecuteNonQuery();

            for (int i = 0; i < tableData.Count; i++)
            {
                command.CommandText = "INSERT INTO league_table (name, played, wins, draws, losses, goals_for, goals_against, goal_difference, points) VALUES (@name, @played, @wins, @draws, @losses, @goals_for, @goals_against, @goal_difference, @points)";
                command.Parameters.AddWithValue("@name", tableData[i].Item1);
                command.Parameters.AddWithValue("@played", tableData[i].Item2);
                command.Parameters.AddWithValue("@wins", tableData[i].Item3);
                command.Parameters.AddWithValue("@draws", tableData[i].Item4);
                command.Parameters.AddWithValue("@losses", tableData[i].Item5);
                command.Parameters.AddWithValue("@goals_for", tableData[i].Item6);
                command.Parameters.AddWithValue("@goals_against", tableData[i].Item7);
                command.Parameters.AddWithValue("@goal_difference", tableData[i].Item6 - tableData[i].Item7);
                command.Parameters.AddWithValue("@points", (tableData[i].Item3 * 3) + tableData[i].Item4);
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            connection.Close();
        }
    }

    public void getLeagueTableInfo()
    {
        using (var connection = new MySqlConnection(DatabaseInfo.connString))
        {
            connection.Open();
            var command = connection.CreateCommand();

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
                                i+1,
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

public class Team
{
    public Team(int position, string name, int played, int wins, int draws, int losses, int goalsFor, int goalsAgainst, int goalDifference, int points)
    {
        Position = position;
        Name = name;
        Played = played;
        Wins = wins;
        Draws = draws;
        Losses = losses;
        GoalsFor = goalsFor;
        GoalsAgainst = goalsAgainst;
        GoalDifference = goalDifference;
        Points = points;

    }
    public int Position { get; }
    public string Name { get; }
    public int Played { get; }
    public int Wins { get; }
    public int Draws { get; }
    public int Losses { get; }
    public int GoalsFor { get; }
    public int GoalsAgainst { get; }
    public int GoalDifference { get; }
    public int Points { get; }

}