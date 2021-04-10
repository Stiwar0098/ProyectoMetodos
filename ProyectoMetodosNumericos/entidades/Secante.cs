using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMetodosNumericos.Entidades
{
    public class Secante
    {
        private int iteracion;
        private double x1;
        private double x0;
        private double fx1;
        private double fx0;
        private double et;
        private double ea;

        public Secante()
        {
        }

        public Secante(int iteracion, double x1, double x0, double fx1, double fx0, double et, double ea)
        {
            this.iteracion = iteracion;
            this.x1 = x1;
            this.x0 = x0;
            this.fx1 = fx1;
            this.fx0 = fx0;
            this.et = et;
            this.ea = ea;
        }

        public int Iteracion { get => iteracion; set => iteracion = value; }
        public double X1 { get => x1; set => x1 = value; }
        public double X0 { get => x0; set => x0 = value; }
        public double Fx1 { get => fx1; set => fx1 = value; }
        public double Fx0 { get => fx0; set => fx0 = value; }
        public double Et { get => et; set => et = value; }
        public double Ea { get => ea; set => ea = value; }
    }
}
