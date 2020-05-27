using System.Windows;
using Kalum2020_v1.ModelViews;

namespace Kalum2020_v1.Views
{
    public partial class InstructorView : Window
    {
        private InstructorViewModel ModelView;
        public InstructorView()
        {
            InitializeComponent();
            this.ModelView = new InstructorViewModel();
            this.DataContext = ModelView;
        }
    }
}