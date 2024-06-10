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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sergioteacher.Csharp06.MisNotas
{
    // Hay que comentar todo ...

    /// <summary>
    /// Interacción lógica para MainWindow.xaml
    /// Además hay que indicar que métodos desplegará
    /// ...
    /// de forma pedagógica indicar que variables internas usará
    /// y el ¿por qué? 
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 1;
        int cantidad = 1;
        bool haCambiado = false;
        List<Datos> registro = new List<Datos>();

        /// <summary>
        /// Constructor de la ventana principal.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento al hacer clic en el botón "Nuevo".
        /// </summary>
        /// <param name="sender">Es un parámetro tipo objeto...</param>
        /// <param name="e">Es un parámetro tipo evento...</param>
        private void BNuevo_Click(object sender, RoutedEventArgs e)
        {
            cantidad++;
            TCantidad.Text = cantidad.ToString();

            registro.Add(new Datos() {Data = CajaTexto.Text });

            CajaTexto.Text = "";
            haCambiado = false;

            i++;
            TContador.Text = i.ToString();
        }

        /// <summary>
        /// Evento al hacer clic en el botón Guardar.
        /// ahora sólo muestra un mensaje
        /// (Se debería indicar que trabajo realiza internamente)
        /// </summary>
        /// <param name="sender">¿?</param>
        /// <param name="e">¿?</param>
        private void BGuardar_Click(object sender, RoutedEventArgs e)
        {
          MessageBox.Show("Tocaría guardar", "Guardando...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        /// <summary>
        /// Evento al hacer clic en el botón Ayuda.
        /// ahora sólo muestra un mensaje
        /// (Se debería indicar que trabajo realiza internamente)
        /// </summary>
        /// <param name="sender">¿?</param>
        /// <param name="e">¿?</param>
        private void BAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Es un miniprograma creador de pequeñas notas", "Acerca de", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Método para cambiar y refrescar la caja de texto
        /// con los datos de la lista
        /// (Se debería indicar que trabajo realiza internamente)
        /// </summary>
        /// <param name="sender">¿?</param>
        /// <param name="e">¿?</param>
        private void BMenos_Click(object sender, RoutedEventArgs e)
        {
            if (i > 1)
            {
                if (registro.Count < Int32.Parse(TContador.Text))
                {
                    registro.Add(new Datos() { Data = CajaTexto.Text });
                }

                if (haCambiado)
                {

                    registro[(Int32.Parse(TContador.Text) - 1)].Data = CajaTexto.Text;

                }

                i--;
                TContador.Text = i.ToString();

                CajaTexto.Text = registro[(Int32.Parse(TContador.Text) - 1)].Data.ToString();
            }
            if (i < cantidad)
            {
                BNuevo.IsEnabled = false;
            }
        }

        /// <summary>
        /// Método para cambiar y refrescar la caja de texto
        /// con los datos de la lista
        /// (Se debería indicar que trabajo realiza internamente)
        /// </summary>
        /// <param name="sender">¿?</param>
        /// <param name="e">¿?</param>
        private void BMas_Click(object sender, RoutedEventArgs e)
        {
            if (i < cantidad)
            {
                if (haCambiado)
                {
                    registro[(Int32.Parse(TContador.Text) - 1)].Data = CajaTexto.Text;
                }

                i++;
                TContador.Text = i.ToString();

                CajaTexto.Text = registro[(Int32.Parse(TContador.Text) - 1)].Data.ToString();
            }
            if (i == cantidad)
            {
                BNuevo.IsEnabled = true;
            }
        }

        /// <summary>
        /// Método que controla si se ha modificado el contenido
        /// (de forma muy básica)
        /// (Se debería indicar que trabajo realiza internamente)
        /// </summary>
        /// <param name="sender">¿?</param>
        /// <param name="e">¿?</param>
        private void CajaTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            haCambiado = true;
        }
    }

    /// <summary>
    /// Clase para representar los datos de los registros.
    /// (fácilmente escalable)
    /// </summary>
    public class Datos
    {
        private String data;
        /// <summary>
        /// Implementación de los métodos get set.
        /// </summary>
        public string Data { get => data; set => data = value; }

    }
}
