using System.Windows;
using Kalum2020_v1.ModelViews;

namespace Kalum2020_v1.Views
{
    public partial class SalonView : Window
    {
        private SalonViewModel ModelView;
        public SalonView()
        {
            InitializeComponent();
            ModelView = new SalonViewModel();
            DataContext = ModelView;
        }
    }
}