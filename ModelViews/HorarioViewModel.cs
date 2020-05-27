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
    public class HorarioViewModel : INotifyPropertyChanged, ICommand
    {
        private KalumDB dbContext;
        private HorarioViewModel _Instancia;
        public HorarioViewModel Instancia
        {
            get { return _Instancia; }
            set 
            { 
                _Instancia = value;
                NotificarCambio("Instancia");
            }
        }
        
        private Horario _ElementoSeleccionado;
        public Horario ElementoSeleccionado
        {
            get { return _ElementoSeleccionado; }
            set 
            { 
                _ElementoSeleccionado = value; 
                NotificarCambio("ElementoSeleccionado");
            }
        }
        public ObservableCollection<Horario> _Horario;

        public ObservableCollection<Horario> ListaHorario { 
            get
            {
                if(_Horario == null)
                {
                    _Horario = new ObservableCollection<Horario>(dbContext.Horarios.ToList());
                }
                return _Horario;
            }
            set 
            {
                _Horario = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parametro)
        {
            if(parametro.Equals("Nuevo"))
            {
                this.ElementoSeleccionado = new Horario();
            }
            else if(parametro.Equals("Guardar"))
            {
                try
                {
                    this.dbContext.Horarios.Add(this.ElementoSeleccionado);
                    this.dbContext.SaveChanges();

                    this.ListaHorario.Add(this.ElementoSeleccionado);
                    MessageBox.Show("Datos Guardados");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Excepción econtrada: {e}");
                }
            }
            else if(parametro.Equals("Eliminar"))
            {
                try
                {
                    this.dbContext.Horarios.Remove(this.ElementoSeleccionado);
                    this.dbContext.SaveChanges();

                    MessageBox.Show("Datos Eliminados Exitosamente");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Excepción econtrada: {e}");
                }
            }
        }
        public HorarioViewModel()
        {
            this.dbContext = new KalumDB();
            this.Instancia = this;        }

        private void NotificarCambio(string propiedad)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}