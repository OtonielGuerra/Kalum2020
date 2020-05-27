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
    public class CarreraTecnicaViewModel : INotifyPropertyChanged, ICommand
    {
        private KalumDB dbContext;
        private CarreraTecnica _ElementoSeleccionado;
        public CarreraTecnica ElementoSeleccionado
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
        
        private CarreraTecnicaViewModel _Instancia;
        public CarreraTecnicaViewModel Instancia
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
        
        public ObservableCollection<CarreraTecnica> _ListaCarreraTecnica;

        public ObservableCollection<CarreraTecnica> ListaCarreraTecnica { 
            get
            {
                if(_ListaCarreraTecnica == null)
                {
                    _ListaCarreraTecnica = new ObservableCollection<CarreraTecnica>(dbContext.CarrerasTecnicas.ToList());
                }
                return _ListaCarreraTecnica;
            }
            set {
                _ListaCarreraTecnica = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public CarreraTecnicaViewModel()
        {
            this.dbContext = new KalumDB();
            this.Instancia = this;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parametro)
        {
            if(parametro.Equals("Nuevo"))
            {
                this.ElementoSeleccionado = new CarreraTecnica();
            }
            else if(parametro.Equals("Guardar"))
            {
                try
                {
                    this.dbContext.CarrerasTecnicas.Add(this.ElementoSeleccionado);
                    this.dbContext.SaveChanges();

                    this.ListaCarreraTecnica.Add(this.ElementoSeleccionado);
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
                    this.dbContext.CarrerasTecnicas.Remove(this.ElementoSeleccionado);
                    this.dbContext.SaveChanges();

                    MessageBox.Show("Datos Eliminados Exitosamente");
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Excepción econtrada: {e}");
                }
            }
        }

        private void NotificarCambio(string propiedad)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}