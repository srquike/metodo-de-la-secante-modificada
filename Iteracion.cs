using System;
using System.Collections.Generic;
using System.Text;

namespace metodo_de_la_secante_modificada
{
    class Iteracion
    {
        private double error;
        public int I { get; set; }
        public double Xi { get; set; }
        public double Delta { get; set; }
        public double DeltaXi { get; set; }
        public double XiMasDeltaXi { get; set; }
        public double FXi { get; set; }
        public double FXiMasDeltaXi { get; set; }
        public double XiMas1 { get; set; }
        public double Error { get => Math.Round(error, 3); set => error = value; }
    }
}
