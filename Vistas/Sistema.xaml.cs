using ProyectoFinal23AM.Entities;
using ProyectoFinal23AM.Services;
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
using System.Windows.Shapes;

namespace ProyectoFinal23AM.Vistas
{
    /// <summary>
    /// Lógica de interacción para Sistema.xaml
    /// </summary>
    public partial class Sistema : Window
    {
        public Sistema()
        {
            InitializeComponent();
            GetUsersTable();
            GetRoles();
        }
        UsuarioServices services = new UsuarioServices();
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtPkUser.Text != null)
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;
                services.EditUser(usuario);
                MessageBox.Show("USUARIO MODIFICADO");
            }
            else
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = txtNombre.Text;
                usuario.UserName = txtUserName.Text;
                usuario.Password = txtPassword.Text;
                services.AddUser(usuario);
                MessageBox.Show("USUARIO REGISTRADO");
            }
            txtNombre.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            GetUsersTable();
        }
        public void EditItem(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (sender as FrameworkElement).DataContext as Usuario;
            
            txtPkUser.Text = usuario.PkUsuario.ToString();
            txtNombre.Text = usuario.Nombre.ToString();
            txtUserName.Text = usuario.UserName.ToString();
            txtPassword.Text = usuario.Password.ToString();
        }
        public void GetUsersTable()
        {
            UserTable.ItemsSource = services.GetUsuarios();
        }
        public void GetRoles()
        {
            SelectRol.ItemsSource = services.GetRoles();
            SelectRol.DisplayMemberPath = "Nombre";
            SelectRol.SelectedValuePath = "PkRol";
        }
    }
}
