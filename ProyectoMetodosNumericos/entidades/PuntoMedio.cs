using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMetodosNumericos.entidades
{
    public class PuntoMedio
    {
        private int iteracion;
        private double xi;
        private double k1;
        private double xi2;
        private double y0i;
        private double k2;
        private double ypuntoMedio;
        private double yt;
        private double errorGlobal;

        public PuntoMedio()
        {

        }

        public PuntoMedio(int iteracion, double xi, double k1, double xi2, double y0i, double k2, double ypuntoMedio, double yt, double errorGlobal)
        {
            this.iteracion = iteracion;
            this.xi = xi;
            this.k1 = k1;
            this.xi2 = xi2;
            this.y0i = y0i;
            this.k2 = k2;
            this.ypuntoMedio = ypuntoMedio;
            this.yt = yt;
            this.errorGlobal = errorGlobal;
        }

        public int Iteracion { get => iteracion; set => iteracion = value; }
        public double Xi { get => xi; set => xi = value; }
        public double K1 { get => k1; set => k1 = value; }
        public double Xi2 { get => xi2; set => xi2 = value; }
        public double Y0i { get => y0i; set => y0i = value; }
        public double K2 { get => k2; set => k2 = value; }
        public double YpuntoMedio { get => ypuntoMedio; set => ypuntoMedio = value; }
        public double Yt { get => yt; set => yt = value; }
        public double ErrorGlobal { get => errorGlobal; set => errorGlobal = value; }
    }
}
