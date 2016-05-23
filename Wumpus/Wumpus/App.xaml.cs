using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wumpus.Model;
using Wumpus.View;
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
        private NewGameOptionsWindow _optionsWindow;

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
            _viewModel.NewGameOptions += new EventHandler<EventArgs>(App_ShowNewGameOptions);
            _viewModel.OnStartNewGame += new EventHandler<WumpusEventArgs>(App_StartNewGame);
            _viewModel.NewGame(settings);

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();

            Console.WriteLine(_model.TableSize);
        }

        private void App_StartNewGame(object sender, WumpusEventArgs e)
        {
            _model.NewGame(e.NewGameSettings);

            _viewModel.NewGame(e.NewGameSettings);

            _optionsWindow.Hide();

            var mainViewToClose = _view;
            Point p = _view.PointToScreen(new Point(0, 0));

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            
            _view.Show();
            _view.Left = p.X - 8;
            _view.Top = p.Y - 31;

            mainViewToClose.Close();
        }

        private void App_ShowNewGameOptions(object sender, EventArgs e)
        {
            _optionsWindow = new NewGameOptionsWindow();
            _optionsWindow.DataContext = _viewModel;
            _optionsWindow.Show();
        }
    }
}
