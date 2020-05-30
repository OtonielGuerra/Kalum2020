using System.Windows;
using Kalum2020_v1.models;
using Kalum2020_v1.ModelViews;

namespace Kalum2020_v1.Views
{
    public partial class LoginView : Window
    {
        private LoginModelView ModelView;
        public LoginView(Usuario usuario, MainViewModel mainViewModel)
        {
            InitializeComponent();
            this.ModelView = new LoginModelView(usuario, mainViewModel);
            this.DataContext = ModelView;
        }
    }
}