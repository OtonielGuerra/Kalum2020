using System.Windows;
using Kalum2020_v1.ModelViews;

namespace Kalum2020_v1.Views
{
    public partial class CarreraTecnicaView : Window
    {
        private CarreraTecnicaViewModel Model;
        public CarreraTecnicaView()
        {
            InitializeComponent();
            Model = new CarreraTecnicaViewModel();
            this.DataContext = Model;
        }
    }
}