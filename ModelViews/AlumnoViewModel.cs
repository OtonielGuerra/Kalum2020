using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Kalum2020_v1.DataContext;
using Kalum2020_v1.models;
using Microsoft.EntityFrameworkCore;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020_v1.ModelViews
{
    enum ACCION
    {
        Ninguno,
        Nuevo,
        Modificar
    }
    public class AlumnoViewModel : INotifyPropertyChanged, ICommand
    {
        private IDialogCoordinator dialogCoordinator;
        private ACCION _accion = ACCION.Ninguno;
        private KalumDB dbContext;
        private AlumnoViewModel _Instancia;
        public AlumnoViewModel Instancia
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

        #region botones
        private Alumno _Update;
        public Alumno Update
        {
            get { return _Update; }
            set 
            { 
                _Update = value;
                NotificarCambio("Update");
            }
        }
        
        private int _Posicion;
        public int Posicion
        {
            get { return _Posicion; }
            set 
            { 
                _Posicion = value;
                NotificarCambio("Update");
            }
        }
        
        private bool _Carne = true;
        public bool Carne
        {
            get { return _Carne; }
            set 
            { 
                _Carne = value;
                NotificarCambio("Carne");
            }
        }
        
        private bool _Casilla = true;
        public bool Casilla
        {
            get 
            { 
                return _Casilla;
            }
            set 
            { 
                _Casilla = value;
                NotificarCambio("Casilla");
            }
        }
        
        private bool _Nuevo = true;
        public bool Nuevo
        {
            get 
            { 
                return _Nuevo;
            }
            set 
            { 
                _Nuevo = value;
                NotificarCambio("Nuevo");
            }
        }
        private bool _Modificar = true;
        public bool Modificar
        {
            get 
            { 
                return _Modificar;
            }
            set 
            { 
                _Modificar = value;
                NotificarCambio("Modificar");
            }
        }
        private bool _Eliminar = true;
        public bool Eliminar
        {
            get 
            { 
                return _Eliminar;
            }
            set 
            { 
                _Eliminar = value;
                NotificarCambio("Eliminar");
            }
        }
        
        
        private bool _Guardar = false;
        public bool Guardar
        {
            get 
            { 
                return _Guardar; 
            }
            set 
            { 
                _Guardar = value;
                NotificarCambio("Guardar");
            }
        }
        private bool _Cancelar = false;
        public bool Cancelar
        {
            get 
            { 
                return _Cancelar;
            }
            set 
            { 
                _Cancelar = value;
                NotificarCambio("Cancelar");
            }
        }
        #endregion
        private Alumno _ElementoSeleccionado;
        public Alumno ElementoSeleccionados
        {
            get { return _ElementoSeleccionado; }
            set 
            { 
                _ElementoSeleccionado = value; 
                NotificarCambio("ElementoSeleccionados");
            }
        }
        
        public ObservableCollection<Alumno> _ListaAlumno;

        public ObservableCollection<Alumno> ListaAlumno { 
            get
            {
                if(_ListaAlumno == null)
                {
                    _ListaAlumno = new ObservableCollection<Alumno>(dbContext.Alumnos.ToList());
                }
                return _ListaAlumno;
            }
            set {
                _ListaAlumno = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public AlumnoViewModel(IDialogCoordinator instance)
        {
            this.dialogCoordinator = instance;
            this.dbContext = new KalumDB();
            this.Instancia = this;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parametro)
        {
            if(parametro.Equals("Nuevo"))
            {
                this.ElementoSeleccionados = new Alumno();
                this._accion = ACCION.Nuevo;
                MessageBox.Show("Creando NUEVOOOO!!");

                this.Carne = false;
                this.Nuevo = false;
                this.Modificar = false;
                this.Eliminar = false;
                this.Guardar = true;
                this.Cancelar = true;

                this.Casilla = false;
            }
            else if(parametro.Equals("Modificar"))
            {
                if (this.ElementoSeleccionados != null)
                {
                    this._accion = ACCION.Modificar;
                
                    this.Nuevo = false;
                    this.Modificar = false;
                    this.Eliminar = false;
                    this.Guardar = true;
                    this.Cancelar = true;

                    this.Casilla = false;

                    this.Posicion = this.ListaAlumno.IndexOf(this.ElementoSeleccionados);
                    this.Update = new Alumno();
                    this.Update.AlumnoId = this.ElementoSeleccionados.AlumnoId;
                    this.Update.Apellidos = this.ElementoSeleccionados.Apellidos;
                    this.Update.Nombres = this.ElementoSeleccionados.Nombres;
                    this.Update.FechaNacimiento = this.ElementoSeleccionados.FechaNacimiento;

                }
                else
                {
                    await this.dialogCoordinator.ShowMessageAsync(this, "Modificar", "Elija un elemento a modificar");
                }
            }
            else if(parametro.Equals("Guardar"))
            {
                //Cuando guarda, verifíca si se guarda o se modifica, lo que está en los cuadros
                switch (this._accion)
                {
                    case ACCION.Modificar:
                        if (this.ElementoSeleccionados != null)
                        {
                            this.dbContext.Entry(this.ElementoSeleccionados).State = EntityState.Modified;
                            //this.dbContext.Alumnos.Update(this.ElementoSeleccionados); También es Funcional
                            this.dbContext.SaveChanges();

                            MessageBox.Show("Modificado con éxito");
                        }
                        else 
                        {
                            MessageBox.Show("Debe selelccionar un elemento");
                        }
                    break;
                    case ACCION.Nuevo:
                        try
                        {
                            this.dbContext.Alumnos.Add(this.ElementoSeleccionados);
                            this.dbContext.SaveChanges();

                            this.ListaAlumno.Add(this.ElementoSeleccionados);
                            MessageBox.Show("Datos Guardados");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Excepción econtrada: {e}");
                        }
                    break;
                    default:
                    break;
                }
                this.Nuevo = true;
                this.Modificar = true;
                this.Eliminar = true;
                this.Guardar = false;
                this.Cancelar = false;

                this.Casilla = true;
                this.Carne = true;
                this._accion = ACCION.Ninguno;
            }
            else if(parametro.Equals("Eliminar"))
            {
                MessageDialogResult result1 = await this.dialogCoordinator.ShowMessageAsync(this,
                    "Eliminar", "Desea Eliminar este elemento?", MessageDialogStyle.AffirmativeAndNegative);
                if (result1 == MessageDialogResult.Affirmative)
                {
                    if(this.ElementoSeleccionados != null )
                    {
                        try
                        {
                            this.dbContext.Alumnos.Remove(this.ElementoSeleccionados);
                            this.dbContext.SaveChanges();

                            this.ListaAlumno.Remove(this.ElementoSeleccionados);

                            MessageBox.Show("Datos Eliminados Exitosamente");
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show($"Excepción econtrada: {e}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debes seleccionar un elemento para borrar");
                    }
                }
            }
            else if(parametro.Equals("Cancelar"))
            {
                if (this._accion == ACCION.Modificar)
                {
                    //Quita lo que había antes
                    this.ListaAlumno.RemoveAt(this.Posicion);
                    //Y pone lo que tenía antes
                    this.ListaAlumno.Insert(this.Posicion, this.Update);
                }
                this.Nuevo = true;
                this.Modificar = true;
                this.Eliminar = true;
                this.Guardar = false;
                this.Cancelar = false;

                this.Casilla = true;
                this._accion = ACCION.Ninguno;
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