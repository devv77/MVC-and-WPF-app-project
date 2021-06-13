﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApiConsumer
{
    /// <summary>
    /// Interaction logic for AddLeagueWindow.xaml
    /// </summary>
    public partial class AddLeagueWindow : Window
    {
        Random rnd = new Random();
        public AddLeagueWindow()
        {
            InitializeComponent();
        }

        private void AddLeague(object sender, RoutedEventArgs e)
        {
            League league = new League
            {
                Name = Name.Text.ToString(),
                Rating = rnd.Next(1, 10),
                Homology = true,
                //RaceTypes = RaceTypes.SelectedItem as RaceType
            };

            RestService restservice = new RestService(ApiAddress.Address(), "/League");
            restservice.Post<League>(league);

            MainWindow main = new MainWindow();
            main.GetLeagueListNames();
            this.Close();
        }
    }
}