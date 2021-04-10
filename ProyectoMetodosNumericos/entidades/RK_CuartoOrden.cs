using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMetodosNumericos.entidades
{
    public class RK_CuartoOrden
    {
        private int iteracion;
        private double xi;
        private double yrk;
        private double k1;
        private double k2;
        private double k3;
        private double k4;
        private double yt;
        private double et;

        public RK_CuartoOrden()
        {

        }

        public RK_CuartoOrden(int iteracion, double xi, double yrk, double k1, double k2, double k3, double k4, double yt, double et)
        {
            this.iteracion = iteracion;
            this.xi = xi;
            this.yrk = yrk;
            this.k1 = k1;
            this.k2 = k2;
            this.k3 = k3;
            this.k4 = k4;
            this.yt = yt;
            this.et = et;
        }

        public int Iteracion { get => iteracion; set => iteracion = value; }
        public double Xi { get => xi; set => xi = value; }
        public double Yrk { get => yrk; set => yrk = value; }
        public double K1 { get => k1; set => k1 = value; }
        public double K2 { get => k2; set => k2 = value; }
        public double K3 { get => k3; set => k3 = value; }
        public double K4 { get => k4; set => k4 = value; }
        public double Yt { get => yt; set => yt = value; }
        public double Et { get => et; set => et = value; }
    }
}
