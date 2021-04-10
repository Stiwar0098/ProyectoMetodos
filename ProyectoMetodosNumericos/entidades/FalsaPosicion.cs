using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMetodosNumericos.Entidades
{
    public class FalsaPosicion
    {
        private int iteración;
        private double intervalo;
        private double xl;
        private double xu;
        private double xr;
        private double fxl;
        private double fxu;
        private double fxr;
        private double fxl_fxr;
        private double et;
        private double ea;

        public FalsaPosicion()
        {
        }

        public FalsaPosicion(int iteración, double intervalo, double xl, double xu, double xr, double fxl, double fxu, double fxr, double fxl_fxr, double et, double ea)
        {
            this.iteración = iteración;
            this.intervalo = intervalo;
            this.xl = xl;
            this.xu = xu;
            this.xr = xr;
            this.fxl = fxl;
            this.fxu = fxu;
            this.fxr = fxr;
            this.fxl_fxr = fxl_fxr;
            this.et = et;
            this.ea = ea;
        }

        public int Iteración { get => iteración; set => iteración = value; }
        public double Intervalo { get => intervalo; set => intervalo = value; }
        public double Xl { get => xl; set => xl = value; }
        public double Xu { get => xu; set => xu = value; }
        public double Xr { get => xr; set => xr = value; }
        public double Fxl { get => fxl; set => fxl = value; }
        public double Fxu { get => fxu; set => fxu = value; }
        public double Fxr { get => fxr; set => fxr = value; }
        public double Fxl_fxr { get => fxl_fxr; set => fxl_fxr = value; }
        public double Et { get => et; set => et = value; }
        public double Ea { get => ea; set => ea = value; }
    }
}
