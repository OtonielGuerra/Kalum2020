using System.Windows;
using Kalum2020_v1.ModelViews;

namespace Kalum2020_v1.Views
{
    public partial class HorarioView : Window
    {
        private HorarioViewModel Model;
        public HorarioView()
        {
            InitializeComponent();
            Model = new HorarioViewModel();
            this.DataContext = Model;
        }
    }
}