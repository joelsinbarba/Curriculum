using Newtonsoft.Json.Linq;
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

namespace CurriculumWPF
{
    /// <summary>
    /// Interaction logic for Github.xaml
    /// </summary>
    public partial class Github : Window
    {
        CurriculumEntities1 datos;

        public Github()
        {
            InitializeComponent();
            datos = new CurriculumEntities1();
        }


        private void CargarDatosGrilla()
        {
            try
            {
                dgCurriculum.ItemsSource = datos.Curricula.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgCurriculum.SelectedItem != null)
            {
                Curriculum c = (Curriculum)dgCurriculum.SelectedItem;
                string username = (c.github);
                dynamic resultado = await Perfil.ObtenerPerfil("joelsinbarba");
                if(resultado["message"] != null)
                {
                    MessageBox.Show("No se ha encontrado el perfil de github");
                }
                txtNombre.Content = resultado["name"];
                txtUsername.Content = resultado["login"];
                txtBio.Text = resultado["bio"];
                txtRepos.Content = resultado["public_repos"];
                txtSeguidores.Content = resultado["followers"];
                imgPerfil.Source = resultado["avatar_url"];
            }
            else
                MessageBox.Show("Debe seleccionar un item de la grilla!");
        }
    }
}
