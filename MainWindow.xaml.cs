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

namespace metodo_de_la_secante_modificada
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Iteracion> iteraciones;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TxtValorX.Text, out double x) && !string.IsNullOrEmpty(TxtValorX.Text))
            {
                Iteracion iteracion, iteracionAnterior;
                int i;

                iteraciones = new List<Iteracion>();
                iteracionAnterior = new Iteracion();
                i = 0;

                do
                {
                    iteracion = new Iteracion();
                    iteracion.I = i;
                    iteracion.Delta = 0.01;

                    if (iteracion.I == 0)
                    {
                        iteracion.Xi = x;
                    }
                    else
                    {
                        iteracion.Xi = iteracionAnterior.XiMas1;
                    }

                    iteracion.DeltaXi = iteracion.Xi * iteracion.Delta;
                    iteracion.XiMasDeltaXi = iteracion.Xi + iteracion.DeltaXi;
                    iteracion.FXi = Math.Pow(Math.E, -iteracion.Xi) - iteracion.Xi;
                    iteracion.FXiMasDeltaXi = Math.Pow(Math.E, -iteracion.XiMasDeltaXi) - iteracion.XiMasDeltaXi;
                    iteracion.XiMas1 = iteracion.Xi - ((iteracion.DeltaXi * iteracion.FXi) / (iteracion.FXiMasDeltaXi - iteracion.FXi));
                    iteracion.Error = Math.Abs((iteracion.XiMas1 - iteracionAnterior.XiMas1) / iteracion.XiMas1) * 100;

                    iteraciones.Add(iteracion);
                    iteracionAnterior = iteracion;
                    i++;

                } while (iteracion.Error != 0 && iteracion.Error != 0.001);

                DgIteraciones.ItemsSource = iteraciones;
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            TxtValorX.Clear();
            DgIteraciones.ItemsSource = null;
            TxtValorX.Focus();
        }
    }
}
