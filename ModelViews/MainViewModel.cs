using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Kalum2020_v1.Views;

namespace Kalum2020_v1.ModelViews
{
    public class MainViewModel : INotifyPropertyChanged, ICommand
    {
        private MainViewModel _Instancia;
        public MainViewModel Instancia
        {
            get { return _Instancia; }
            set 
            { 
                _Instancia = value;
                NotificarCambio("Instancia");
            }
        }
        
        public event EventHandler CanExecuteChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.Equals("Alumno"))
            {
                new AlumnoView().ShowDialog();
            }
            else if (parameter.Equals("CarreraTecnica"))
            {
                new CarreraTecnicaView().ShowDialog();
            }
            else if (parameter.Equals("Horario"))
            {
                new HorarioView().ShowDialog();
            }
            else if (parameter.Equals("Instructor"))
            {
                new InstructorView().ShowDialog();
            }
            else if (parameter.Equals("Salon"))
            {
                new SalonView().ShowDialog();
            }
        }

        public MainViewModel()
        {
            this.Instancia = this;
        }

        public void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}