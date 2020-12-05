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
    /// Interaction logic for UserDelete.xaml
    /// </summary>
    public partial class UserDelete : Window
    {

        //Creamos el objeto 
        CurriculumEntities1 datos;

        public UserDelete()
        {
            InitializeComponent();
            datos = new CurriculumEntities1();

        }

  
        private void CargarDatosGrilla()
        {
            try
            {
                dgUsuarios.ItemsSource = datos.AspNetUsers.ToList();
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsuarios.SelectedItem != null)
            {
                AspNetUser a = (AspNetUser)dgUsuarios.SelectedItem;
                datos.AspNetUsers.Remove(a);
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un item de la grilla para eliminar!");
        }
    }
}
