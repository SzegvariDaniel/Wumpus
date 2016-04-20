using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wumpus.Model;
using Wumpus.ViewModel;

namespace Wumpus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private WumpusViewModel _viewModel;
        private WumpusModel _model;
        private MainWindow _view;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            GameSettings settings = new GameSettings
            {
                TableSize = 6,
                NumberOfArrows = 6,
                NumberOfBats = 3,
                NumberOfPits = 3
            };

            _model = new WumpusModel();
            _model.NewGame(settings);

            _viewModel = new WumpusViewModel(_model);
            _viewModel.NewGame(settings);

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();

            Console.WriteLine(_model.TableSize);
        }
    }
}
