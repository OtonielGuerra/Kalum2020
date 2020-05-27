using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Kalum2020_v1.DataContext;
using Kalum2020_v1.models;

namespace Kalum2020_v1.ModelViews
{
    public class InstructorViewModel : INotifyPropertyChanged, ICommand
    {
        public InstructorViewModel()
        {
            this.DBContext = new KalumDB();
            this.Instancia = this;
        }
        private KalumDB DBContext;
        private InstructorViewModel _Instancia;
        public InstructorViewModel Instancia
        {
            get 
            { 
                return _Instancia;
            }
            set 
            { 
                _Instancia = value;
                NotificarCambio("Instancia");
            }
        }

        private ObservableCollection<Instructor> _ListaInstructor;
        public ObservableCollection<Instructor> ListaInstructor
        {
            get 
            {
                if (_ListaInstructor == null)
                {
                    _ListaInstructor = new ObservableCollection<Instructor>(DBContext.Instructores.ToList());
                }
                return _ListaInstructor;
            }
            set 
            { 
                _ListaInstructor = value;
            }
        }

        private Instructor _ElementoSeleccionado;
        public Instructor ElementoSeleccionado
        {
            get 
            {
                return _ElementoSeleccionado;
            }
            set
            { 
                _ElementoSeleccionado = value;
                NotificarCambio("ElementoSeleccionado");
            }
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.Equals("Nuevo"))
            {
                this.ElementoSeleccionado = new Instructor();
            }
            else if(parameter.Equals("Guardar"))
            {
                try
                {
                    this.DBContext.Instructores.Add(this.ElementoSeleccionado);
                    this.DBContext.SaveChanges();

                    this.ListaInstructor.Add(this.ElementoSeleccionado);
                    MessageBox.Show("Datos Guardados");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Excepción econtrada: {e}");
                }
            }
            else if(parameter.Equals("Eliminar"))
            {
                try
                {
                    this.DBContext.Instructores.Remove(this.ElementoSeleccionado);
                    this.DBContext.SaveChanges();

                    MessageBox.Show("Datos Eliminados Exitosamente");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Excepción econtrada: {e}");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}