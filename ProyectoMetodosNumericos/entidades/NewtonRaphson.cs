using Calculus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMetodosNumericos.Entidades
{
    public class NewtonRaphson
    {
        private int iteracion;
        private double x0;
        private double fx0;
        private double dfx0;
        private double ea;
        private double et;

        public NewtonRaphson()
        {
        }

        public NewtonRaphson(int iteracion, double x0, double fx0, double dfx0, double ea, double et)
        {
            this.iteracion = iteracion;
            this.x0 = x0;
            this.fx0 = fx0;
            this.dfx0 = dfx0;
            this.ea = ea;
            this.et = et;
        }

        public int Iteracion { get => iteracion; set => iteracion = value; }
        public double X0 { get => x0; set => x0 = value; }
        public double Fx0 { get => fx0; set => fx0 = value; }
        public double Dfx0 { get => dfx0; set => dfx0 = value; }
        public double Ea { get => ea; set => ea = value; }
        public double Et { get => et; set => et = value; }
    }
}
