using Avalonia.Controls;
using FinalYearProjectDesktop.ViewModels;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System;

namespace FinalYearProjectDesktop.Views;

public partial class SquadPageView : UserControl
{
    public SquadPageView()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (FirstName.Text == "Humphrey")
        {

        } 
        else
        {
            using (var connection = new SqliteConnection(DatabaseInfo.connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO league_table (squad_number, name, position, username, password) VALUES (@squad_number, @name, @position, @username, @password)";
                command.Parameters.AddWithValue("@squad_number", SquadNumber.Text);
                command.Parameters.AddWithValue("@name", $"{FirstName.Text} {LastName.Text}");
                command.Parameters.AddWithValue("@position", Position.SelectedItem);
                command.Parameters.AddWithValue("@username", FirstName.Text[0].ToString().ToLower() + LastName.Text.ToString().ToLower());
                command.Parameters.AddWithValue("@password", "123");
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                connection.Close();
            }
        }
    }
}