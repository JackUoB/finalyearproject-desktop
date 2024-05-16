using Avalonia.Controls;
using FinalYearProjectDesktop.ViewModels;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using DynamicData;
using MySql.Data.MySqlClient;

namespace FinalYearProjectDesktop.Views;

public partial class FixturesPageView : UserControl, INotifyPropertyChanged
{
    public FixturesPageViewModel fixturesVm = new FixturesPageViewModel();

    public FixturesPageView()
    {
        InitializeComponent();

        fixturesVm.getFixtureInfo();
        List<Tuple<int, DateTime, string, string, string, string, string>> fixtureInfo = fixturesVm.fixtureInfo;

        for (int i = 1; i <= fixturesVm.seTigersFixtureCount; i++)
        {
            WeekSelect.Items.Add($"Week {i} - {fixtureInfo[(i * 5) - 4].Item2.ToString().Split()[0]}");
            InputWeekSelect.Items.Add($"Week {i} - {fixtureInfo[(i * 5) - 4].Item2.ToString().Split()[0]}");
        }
    }

    private void ViewSearch_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        fixturesVm.getFixtureInfo();
        List<Tuple<int, DateTime, string, string, string, string, string>> fixtureInfo = fixturesVm.fixtureInfo;

        if (WeekSelect.SelectedItem == null)
        {
            ErrorMessage.Text = "Please select a week";
        }
        else
        {
            ErrorMessage.Text = "";
            SearchResults.WeekFixtures.Clear();
            switch (fixtureInfo[WeekSelect.SelectedIndex * 5].Item1)
            {
                case 1:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week1Fixtures);
                    break;
                case 2:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week2Fixtures);
                    break;
                case 3:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week3Fixtures);
                    break;
                case 4:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week4Fixtures);
                    break;
                case 5:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week5Fixtures);
                    break;
                case 6:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week6Fixtures);
                    break;
                case 7:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week7Fixtures);
                    break;
                case 8:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week8Fixtures);
                    break;
                case 9:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week9Fixtures);
                    break;
                case 10:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week10Fixtures);
                    break;
                case 11:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week11Fixtures);
                    break;
                case 12:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week12Fixtures);
                    break;
                case 13:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week13Fixtures);
                    break;
                case 14:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week14Fixtures);
                    break;
                case 15:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week15Fixtures);
                    break;
                case 16:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week16Fixtures);
                    break;
                case 17:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week17Fixtures);
                    break;
                case 18:
                    SearchResults.WeekFixtures.AddRange(fixturesVm.Week18Fixtures);
                    break;
            }
        }
    }
    private void InputSearch_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        fixturesVm.getFixtureInfo();
        List<Tuple<int, DateTime, string, string, string, string, string>> fixtureInfo = fixturesVm.fixtureInfo;

        if (InputWeekSelect.SelectedItem == null)
        {
            InputErrorMessage.Text = "Please select a week";
        }
        else
        {
            InputErrorMessage.Text = "";
            Results.IsVisible = true;
            InputSave.IsVisible = true;

            home0.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5].Item3;
            homeScore0.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5].Item4;
            awayScore0.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5].Item5;
            away0.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5].Item6;
            venue0.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5].Item7;

            home1.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 1].Item3;
            homeScore1.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 1].Item4;
            awayScore1.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 1].Item5;
            away1.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 1].Item6;
            venue1.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 1].Item7;

            home2.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 2].Item3;
            homeScore2.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 2].Item4;
            awayScore2.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 2].Item5;
            away2.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 2].Item6;
            venue2.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 2].Item7;

            home3.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 3].Item3;
            homeScore3.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 3].Item4;
            awayScore3.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 3].Item5;
            away3.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 3].Item6;
            venue3.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 3].Item7;

            home4.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 4].Item3;
            homeScore4.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 4].Item4;
            awayScore4.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 4].Item5;
            away4.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 4].Item6;
            venue4.Text = fixtureInfo[InputWeekSelect.SelectedIndex * 5 + 4].Item7;
        }
    }

    private void InputSave_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (homeScore0.Text == null || homeScore0.Text == "" ||
            homeScore1.Text == null || homeScore1.Text == "" ||
            homeScore2.Text == null || homeScore2.Text == "" ||
            homeScore3.Text == null || homeScore3.Text == "" ||
            homeScore4.Text == null || homeScore4.Text == "" ||
            awayScore0.Text == null || awayScore0.Text == "" ||
            awayScore1.Text == null || awayScore1.Text == "" ||
            awayScore2.Text == null || awayScore2.Text == "" ||
            awayScore3.Text == null || awayScore3.Text == "" ||
            awayScore4.Text == null || awayScore4.Text == "")
        {
            SaveErrorMessage.Text = "Please input scores for all fixtures";
        }
        else
        {
            using (var connection = new MySqlConnection(DatabaseInfo.connString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText = "UPDATE fixtures SET home_score=@home_score, away_score=@away_score WHERE week=@week and home_team=@home_team";
                command.Parameters.AddWithValue("@home_score", homeScore0.Text);
                command.Parameters.AddWithValue("@away_score", awayScore0.Text);
                command.Parameters.AddWithValue("@week", InputWeekSelect.SelectedIndex+1);
                command.Parameters.AddWithValue("@home_team", home0.Text);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.CommandText = "UPDATE fixtures SET home_score=@home_score, away_score=@away_score WHERE week=@week and home_team=@home_team";
                command.Parameters.AddWithValue("@home_score", homeScore1.Text);
                command.Parameters.AddWithValue("@away_score", awayScore1.Text);
                command.Parameters.AddWithValue("@week", InputWeekSelect.SelectedIndex + 1);
                command.Parameters.AddWithValue("@home_team", home1.Text);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.CommandText = "UPDATE fixtures SET home_score=@home_score, away_score=@away_score WHERE week=@week and home_team=@home_team";
                command.Parameters.AddWithValue("@home_score", homeScore2.Text);
                command.Parameters.AddWithValue("@away_score", awayScore2.Text);
                command.Parameters.AddWithValue("@week", InputWeekSelect.SelectedIndex + 1);
                command.Parameters.AddWithValue("@home_team", home2.Text);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.CommandText = "UPDATE fixtures SET home_score=@home_score, away_score=@away_score WHERE week=@week and home_team=@home_team";
                command.Parameters.AddWithValue("@home_score", homeScore3.Text);
                command.Parameters.AddWithValue("@away_score", awayScore3.Text);
                command.Parameters.AddWithValue("@week", InputWeekSelect.SelectedIndex + 1);
                command.Parameters.AddWithValue("@home_team", home3.Text);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                command.CommandText = "UPDATE fixtures SET home_score=@home_score, away_score=@away_score WHERE week=@week and home_team=@home_team";
                command.Parameters.AddWithValue("@home_score", homeScore4.Text);
                command.Parameters.AddWithValue("@away_score", awayScore4.Text);
                command.Parameters.AddWithValue("@week", InputWeekSelect.SelectedIndex + 1);
                command.Parameters.AddWithValue("@home_team", home4.Text);
                command.ExecuteNonQuery();
                command.Parameters.Clear();

                connection.Close();
            }
            SaveErrorMessage.Text = "Scores updated";
        }
    }
}