using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMetodosNumericos.Entidades
{
    public class Muller
    {
        private int iteracion;
        private double x0;
        private double x1;
        private double x2;
        private double fx0;
        private double fx1;
        private double fx2;
        private double h0;
        private double h1;
        private double s0;
        private double s1;
        private double a;
        private double b;
        private double c;
        private double signoP;
        private double signoN;
        private double x3;
        private double et;
        private double ea;

        public Muller()
        {
        }

        public Muller(int iteracion, double x2, double fx0, double fx1, double fx2, double h0, double h1, double s0, double s1, double a, double b, double c, double signoP, double signoN, double x3, double et, double ea)
        {
            this.iteracion = iteracion;
            this.x2 = x2;
            this.fx0 = fx0;
            this.fx1 = fx1;
            this.fx2 = fx2;
            this.h0 = h0;
            this.h1 = h1;
            this.s0 = s0;
            this.s1 = s1;
            this.a = a;
            this.b = b;
            this.c = c;
            this.signoP = signoP;
            this.signoN = signoN;
            this.x3 = x3;
            this.et = et;
            this.ea = ea;
        }

        public int Iteracion { get => iteracion; set => iteracion = value; }
        public double X0 { get => x0; set => x0 = value; }
        public double X1 { get => x1; set => x1 = value; }
        public double X2 { get => x2; set => x2 = value; }
        public double Fx0 { get => fx0; set => fx0 = value; }
        public double Fx1 { get => fx1; set => fx1 = value; }
        public double Fx2 { get => fx2; set => fx2 = value; }
        public double H0 { get => h0; set => h0 = value; }
        public double H1 { get => h1; set => h1 = value; }
        public double S0 { get => s0; set => s0 = value; }
        public double S1 { get => s1; set => s1 = value; }
        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }
        public double SignoP { get => signoP; set => signoP = value; }
        public double SignoN { get => signoN; set => signoN = value; }
        public double X3 { get => x3; set => x3 = value; }
        public double Et { get => et; set => et = value; }
        public double Ea { get => ea; set => ea = value; }
    }
}
