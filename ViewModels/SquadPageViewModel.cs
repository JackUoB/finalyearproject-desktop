using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MySql.Data.MySqlClient;

namespace FinalYearProjectDesktop.ViewModels;

public partial class SquadPageViewModel : ViewModelBase, INotifyPropertyChanged
{
    [ObservableProperty]
    private bool _isManagerLoggedIn = Login.IsManagerLoggedIn;

    // For the list view
    public ObservableCollection<Player> PlayerListAll { get; } = new();

    // For the grid view
    public ObservableCollection<Player> PlayerListColumnA { get; } = new();
    public ObservableCollection<Player> PlayerListColumnB { get; } = new();
    public ObservableCollection<Player> PlayerListColumnC { get; } = new();

    public SquadPageViewModel()
    {
        getPlayerInfo();

        for (int i = 0; i < squadInfo.Count; i++)
        {
            PlayerListAll.Add(new Player($"{squadInfo[i].Item2} {squadInfo[i].Item3}", squadInfo[i].Item1));

            if (i % 3 == 0)
            {
                PlayerListColumnA.Add(new Player(squadInfo[i].Item3.ToUpper(), squadInfo[i].Item1));
            }
            else if (i % 3 == 1)
            {
                PlayerListColumnB.Add(new Player(squadInfo[i].Item3.ToUpper(), squadInfo[i].Item1));
            }
            else if (i % 3 == 2)
            {
                PlayerListColumnC.Add(new Player(squadInfo[i].Item3.ToUpper(), squadInfo[i].Item1));
            }
        }
    }

    int squadSize = 0;
    List<Tuple<int, string, string>> squadInfo = new List<Tuple<int, string, string>>();

    public void getPlayerInfo()
    {
        using (var connection = new MySqlConnection(DatabaseInfo.connString))
        {
            connection.Open();
            var command = connection.CreateCommand();

            // Counting squad size
            command.CommandText = "SELECT COUNT(*) FROM squad";
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read() != false)
                {
                    squadSize = reader.GetInt32(0);
                }
                reader.Close();
            }

            // Take player information from database
            command.CommandText = "SELECT * FROM squad ORDER BY squad_number ASC";
            using (var reader = command.ExecuteReader())
            {
                squadInfo = new List<Tuple<int, string, string>>();
                for (int i = 0; i < squadSize; i++)
                {
                    if (reader.Read() != false)
                    {
                        if (reader.IsDBNull(0))
                        {
                            continue;
                        } 
                        else
                        {
                            squadInfo.Add(new Tuple<int, string, string>(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
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

public class Player
{
    public Player(string name, int number)
    {
        Name = name;
        Number = number;
    }
    public string Name { get; }
    public int Number { get; }

}