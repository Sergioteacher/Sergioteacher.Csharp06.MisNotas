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
    
    public partial class MainWindow : Window
    {
        int i = 1;
        int cantidad = 1;
        bool haCambiado = false;
        List<Datos> registro = new List<Datos>();

        public MainWindow()
        {
            InitializeComponent();
        }

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

        private void BGuardar_Click(object sender, RoutedEventArgs e)
        {
          MessageBox.Show("Tocaría guardar", "Guardando...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        private void BAyuda_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Es un miniprograma creador de pequeñas notas", "Acerca de", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BMenos_Click(object sender, RoutedEventArgs e)
        {
            if (i > 1)
            {
                if (haCambiado)
                {
                    if (registro.Count < Int32.Parse(TContador.Text))
                    {
                        registro.Add(new Datos() { Data = CajaTexto.Text });
                    }
                    else
                    {
                        registro[(Int32.Parse(TContador.Text) - 1)].Data = CajaTexto.Text;
                    }
                }

                i--;
                TContador.Text = i.ToString();

                CajaTexto.Text = registro[(Int32.Parse(TContador.Text) -1)].Data.ToString();
            }
            if (i < cantidad)
            {
                BNuevo.IsEnabled = false;
            }
        }

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

        private void CajaTexto_TextChanged(object sender, TextChangedEventArgs e)
        {
            haCambiado = true;
        }
    }

    public class Datos
    {
        private String data;

        public string Data { get => data; set => data = value; }

    }
}
