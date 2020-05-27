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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kalum2020_v1.Views;
using Kalum2020_v1.ModelViews;
using MahApps.Metro.Controls;

namespace Kalum2020_v1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MainViewModel Model;
        public MainWindow()
        {
            InitializeComponent();
            Model = new MainViewModel();
            this.DataContext = Model;
        }
    }
}
