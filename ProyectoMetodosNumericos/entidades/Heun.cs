using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMetodosNumericos.entidades
{
    public class Heun
    {
        private int iteracion;
        private double xi;
        private double fxiyi;
        private double y0i;
        private double fxiy0i;
        private double yHeun;
        private double yt;
        private double et;
        private double ea;

        public Heun()
        {
        }

        public Heun(int iteracion, double xi, double fxiyi, double y0i, double fxiy0i, double yHeun, double yt, double et, double ea)
        {
            this.iteracion = iteracion;
            this.xi = xi;
            this.fxiyi = fxiyi;
            this.y0i = y0i;
            this.fxiy0i = fxiy0i;
            this.yHeun = yHeun;
            this.yt = yt;
            this.et = et;
            this.ea = ea;
        }

        public int Iteracion { get => iteracion; set => iteracion = value; }
        public double Xi { get => xi; set => xi = value; }
        public double Fxiyi { get => fxiyi; set => fxiyi = value; }
        public double Y0i { get => y0i; set => y0i = value; }
        public double Fxiy0i { get => fxiy0i; set => fxiy0i = value; }
        public double YHeun { get => yHeun; set => yHeun = value; }
        public double Yt { get => yt; set => yt = value; }
        public double Et { get => et; set => et = value; }
        public double Ea { get => ea; set => ea = value; }
    }
}
