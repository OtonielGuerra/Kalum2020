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
    public class SalonViewModel : INotifyPropertyChanged, ICommand
    {
        public SalonViewModel()
        {
            DBContext = new KalumDB();
            this.Instancia = this;
        }

        private KalumDB DBContext;

        private SalonViewModel _Instancia;
        public SalonViewModel Instancia
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
        
        private ObservableCollection<Salon> _ListaSalon;
        public ObservableCollection<Salon> ListaSalon
        {
            get 
            {
                if (_ListaSalon == null)
                {
                    _ListaSalon = new ObservableCollection<Salon>(DBContext.Salones.ToList());
                }
                return _ListaSalon;
            }
            set { _ListaSalon = value; }
        }
        
        private Salon _ElementoSeleccionado;
        public Salon ElementoSeleccionado
        {
            get { return _ElementoSeleccionado; }
            set 
            { 
                _ElementoSeleccionado = value;
                NotificarCambio("ElementoSeleccionado");
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.Equals("Nuevo"))
            {
                this.ElementoSeleccionado = new Salon();
            }
            else if(parameter.Equals("Guardar"))
            {
                try
                {
                    this.DBContext.Salones.Add(this.ElementoSeleccionado);
                    this.DBContext.SaveChanges();

                    this.ListaSalon.Add(this.ElementoSeleccionado);
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
                    this.DBContext.Salones.Remove(this.ElementoSeleccionado);
                    this.DBContext.SaveChanges();

                    MessageBox.Show("Datos Eliminados Exitosamente");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Excepción econtrada: {e}");
                }
            }
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