  
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Kalum2020_v1.DataContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Kalum2020_v1.models;
using MahApps.Metro.Controls.Dialogs;

namespace Kalum2020_v1.ModelViews
{
    public class LoginModelView : INotifyPropertyChanged, ICommand
    {
        private MainViewModel _MainViewModel;
        public MainViewModel MainViewModel
        {
            get { return _MainViewModel; }
            set 
            { 
                _MainViewModel = value;
                NotificarCambio("MainViewModel");
            }
        }
        
        private Usuario _Usuario;
        public Usuario Usuario
        {
            get { return _Usuario; }
            set 
            { 
                _Usuario = value;
                NotificarCambio("Usuario");
            }
        }
        private KalumDB _DbContext;

        #region Propiedades
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set 
            { 
                _Password = value;
                NotificarCambio("Password");
            }
        }
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set 
            { 
                _Username = value;
                NotificarCambio("Username");
            }
        }
        
        private LoginModelView _Instancia;
        public LoginModelView Instancia
        {
            get { return _Instancia; }
            set 
            { 
                _Instancia = value;
                NotificarCambio("Instancia");
            }
        }
        #endregion

        public LoginModelView(Usuario usuario, MainViewModel mainViewModel)
        {
            this.MainViewModel = mainViewModel;
            this.Usuario = usuario;
            this.Instancia = this;       
            this._DbContext = new KalumDB();     
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Window)
            {
                Password = ((PasswordBox)((Window)parameter).FindName("txtPassword")).Password;
                var UsernameParameter = new SqlParameter("@UserName", Username);
                var PasswordParameter = new SqlParameter("@Password", Password);
                try
                {
                    //Llama al procedimiento almacenado
                    var Resultado = this._DbContext.UsuariosApp
                        .FromSqlRaw("sp_AutenticarUsuario @UserName,@Password",
                            UsernameParameter,PasswordParameter).ToList();
                    foreach (Object objecto in Resultado)
                    {
                        Usuario = (Usuario)objecto;
                    }
                    if (Usuario != null)
                    {
                        MessageBox.Show($"Bienvenido {_Usuario.Apellidos} {_Usuario.Nombres}");
                        this.MainViewModel.IsMenuCatalogo = true;
                        this.MainViewModel.Usuario = this.Usuario;
                        ((Window)parameter).Close();

                    }else
                    {
                        MessageBox.Show($"Usuario o Contraseña Incorrecctos");
                    }
                }
                catch (System.Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
                
            }
        }

        public void NotificarCambio(string propiedad)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propiedad));
            }
        }
    }
}