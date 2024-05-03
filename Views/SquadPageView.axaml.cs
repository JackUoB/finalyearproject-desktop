using Avalonia.Controls;
using FinalYearProjectDesktop.ViewModels;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;

namespace FinalYearProjectDesktop.Views;

public partial class SquadPageView : UserControl
{
    public SquadPageView()
    {
        InitializeComponent();
    }

    private void AddButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        SquadPageViewModel squad = new SquadPageViewModel();
        string approvedCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM-'";
        bool firstNameCheck = false;
        bool lastNameCheck = false;
        bool squadNumberCheck = false;

        // Check if every field has had data entered
        if (LeftFirstName.Text == null || LeftFirstName.Text == "" ||
                LeftLastName.Text == null || LeftLastName.Text == "" ||
                LeftPosition.SelectionBoxItem == null || LeftSquadNumber.Text == null)
        {
            LeftErrorMessage.Text = "Please fill in all fields";
        }
        else
        {
            // Check if First Name is a valid input.
            foreach (char n in LeftFirstName.Text.ToCharArray())
            {
                if (!approvedCharacters.Contains(n))
                {
                    LeftErrorMessage.Text = "Please only select characters A-Z, a-z, - and '";
                    break;
                } else
                {
                    firstNameCheck = true;
                }
            }

            // Check if Last Name is a valid input.
            foreach (char n in LeftLastName.Text.ToCharArray())
            {
                if (!approvedCharacters.Contains(n))
                {
                    LeftErrorMessage.Text = "Please only select characters A-Z, a-z, - and '";
                    break;
                } else
                {
                    lastNameCheck = true;
                }
            }

            // Check if Squad Number is a valid input.
            if (LeftSquadNumber.Text != null)
            {
                for (int i = 0; i < squad.PlayerListAll.Count; i++)
                {
                    if (LeftSquadNumber.Text == squad.PlayerListAll[i].Number.ToString())
                    {
                        LeftErrorMessage.Text = "Number already assigned. Please select a new number";
                        squadNumberCheck = false;
                        break;
                    }
                    squadNumberCheck = true;
                }
            }
        }

        // If all all is valid, add player to squad table
        if (firstNameCheck && lastNameCheck && squadNumberCheck) 
        {
            using (var connection = new MySqlConnection(DatabaseInfo.connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO squad (squad_number, first_name, last_name, position, username, password) VALUES (@squad_number, @first_name, @last_name, @position, @username, @password)";
                command.Parameters.AddWithValue("@squad_number", LeftSquadNumber.Text);
                command.Parameters.AddWithValue("@first_name", LeftFirstName.Text);
                command.Parameters.AddWithValue("@last_name", LeftLastName.Text);
                command.Parameters.AddWithValue("@position", LeftPosition.SelectionBoxItem.ToString());
                command.Parameters.AddWithValue("@username", LeftFirstName.Text[0].ToString().ToLower() + LeftLastName.Text.ToString().ToLower().Replace("'","").Replace("-",""));
                command.Parameters.AddWithValue("@password", "123");
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                connection.Close();
            }
            LeftErrorMessage.Text = "Player added";
        }
    }
}