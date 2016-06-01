using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tank.Model;
using Tank.ViewModel;

namespace Tank
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private TankModel _model;
        private TankViewModel _viewModel;
        private MainWindow _view;

        public App()
        {
            Startup += new StartupEventHandler(App_Start);
        }

        private void App_Start(object sender, StartupEventArgs e)
        {
            _model = new TankModel();
            _model.NewGame();

            _viewModel = new TankViewModel(_model);
            _viewModel.NewGame();

            _view = new MainWindow();
            _view.DataContext = _viewModel;
            _view.Show();
        }
    }
}
