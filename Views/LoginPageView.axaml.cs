using Avalonia.Controls;
using Avalonia.Interactivity;
using FinalYearProjectDesktop.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Tmds.DBus.Protocol;

namespace FinalYearProjectDesktop.Views;

public partial class LoginPageView : UserControl
{
    int squadSize = 0;
    List<Tuple<string, string, string, string>> squadLogin = new List<Tuple<string, string, string, string>>();

    public LoginPageView()
    {
        InitializeComponent();
    }

    private void Button_Click(object? sender, RoutedEventArgs e)
    {
        LoginCredentials();

        for (int i = 0; i < squadLogin.Count; i++)
        {
            if (squadLogin[i].Item1 == UsernameEntered.Text && squadLogin[i].Item2 != PasswordEntered.Text) 
            {
                ErrorMessage.Text = "Incorrect password";
                break;
            }
            else if (squadLogin[i].Item1 == UsernameEntered.Text && squadLogin[i].Item2 == PasswordEntered.Text)
            {
                Login.LoggedIn = true;
                Login.UserLoggedIn = $"{squadLogin[i].Item3} {squadLogin[i].Item4}";

                if (squadLogin[i].Item4 == "Manager")
                {
                    Login.IsManagerLoggedIn = true;
                }
            } 
            else
            {
                ErrorMessage.Text = "Username not recognised";
            }
        }
    }

    public void LoginCredentials()
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

            // Take login credentials from database
            command.CommandText = "SELECT * FROM squad ORDER BY squad_number ASC";
            using (var reader = command.ExecuteReader())
            {
                squadLogin = new List<Tuple<string, string, string, string>>();
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
                            squadLogin.Add(new Tuple<string, string, string, string>(reader.GetString(4), reader.GetString(5), reader.GetString(1), reader.GetString(2)));
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
            squadLogin.Add(new Tuple<string, string, string, string>("Manager", "123", "The", "Manager"));
        }
    }
}