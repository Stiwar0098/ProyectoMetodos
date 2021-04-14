using Calculus;
using ProyectoMetodosNumericos.entidades;
using ProyectoMetodosNumericos.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace ProyectoMetodosNumericos.Algoritmos
{
    public class Algoritmos
    {
        public static void addFormulario(Panel panel, Form form)
        {
            if(panel.Controls.Count > 0) //Verifica si hay formularios dentro del panel
                panel.Controls.RemoveAt(0); //Remueve todos los formularios del panel antes de agregar otro
            form.TopLevel = false;
            panel.Controls.Add(form);
            form.Show();
        }

        public static double redondear(double numero, int cf)
        {
            string decimales = "0.";

            for (int i = 1; i <= cf; i++)
                decimales = decimales + "0";

            return Convert.ToDouble(numero.ToString(decimales)) ;
        }

        public static string getCifras(double num, int cf)
        {
            string cifrasSig = "0.";
            string numero = num.ToString();
            char[] vectorNum = numero.ToCharArray();
            int nCf = 0;
            int i = 0;
            bool DiferenteDeCero = false;

            if (num >= 1)
                for (i = 1; i < cf; i++)
                    cifrasSig = cifrasSig + "0";
            else
            {
                i = 1;
                while (!DiferenteDeCero)
                {
                    i++;
                    if (vectorNum[i] != '0')
                    {
                        DiferenteDeCero = true;
                        nCf++;
                    }
                    cifrasSig = cifrasSig + "0";
                }

                if (DiferenteDeCero)
                {
                    while (nCf < cf)
                    {
                        nCf++;
                        cifrasSig = cifrasSig + "0";
                    }
                }
            }

            return cifrasSig;
        }
        
        public static string toCifraSignif(double num, int cf)
        {
            string cifrasSig = null;
            string numero = null;

            if (num - Convert.ToInt64(num) == 0)
                numero = Math.Abs(num).ToString("0.0");
            else
                numero = Math.Abs(num).ToString();

            char[] vectorNum = numero.ToCharArray();
            int cont = 0;
            bool huboPrimerDifCero = false;
            bool esNegativo = false;

            
            if (num < 0) esNegativo = true;
            try
            {
                for (int i = 0; cont < cf; i++)
                {
                    if (vectorNum[i] == ',')
                        cifrasSig = cifrasSig + ".";
                    else if (vectorNum[i] == '0')
                    {
                        cifrasSig = cifrasSig + "0";
                        if (huboPrimerDifCero)
                            cont = cont + 1;
                    }
                    else
                    {
                        huboPrimerDifCero = true;
                        cifrasSig = cifrasSig + "0";
                        cont = cont + 1;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                while(cont < cf)
                {
                    cifrasSig = cifrasSig + "0";
                    cont = cont + 1;
                }
            }

            if (esNegativo)
                return "-" + num.ToString(cifrasSig);
            else
                return num.ToString(cifrasSig);
        }

        public static double calcularErrorVerdadero(double valorVerdadero, double valorAproximado)
        {
            return Math.Abs((valorVerdadero - valorAproximado) / valorVerdadero) * 100.0;
        }

        public static double calcularErrorAproximacion(double valorAproximado, double valorAnterior)
        {
            return Math.Abs((valorAproximado - valorAnterior) / valorAproximado) * 100.0;
        }

        public static List<FalsaPosicion> falsaPosicion(string expresion, double xl, double xu, double valorVerdadero, double errorTolerancia, bool hayValorVerdadero)
        {
            int iteracion = 0;
            double intervalo = 0;
            double xr = 0;
            double xrAnt = 0;
            double fxl = 0;
            double fxu = 0;
            double fxr = 0;
            double fxlfxr = 0;
            double errorAprox = 0;
            double errorVerd = 0;
            bool ea_menor_es = false;
            FalsaPosicion falsaPos = null;
            List<FalsaPosicion> listaFalsaPos = new List<FalsaPosicion>();

            do
            {
                iteracion++;
                intervalo = xu - xl;
                xrAnt = xr;

                fxl = evaluarFuncion(expresion, xl);
                fxu = evaluarFuncion(expresion, xu);
                fxr = evaluarFuncion(expresion, xr);

                xr = xu - (fxu * (xl - xu)) / (fxl - fxu);

                fxlfxr = fxl * fxr;
                if(hayValorVerdadero)
                    errorVerd = calcularErrorVerdadero(valorVerdadero, xr);

                if (iteracion > 1)
                {
                    errorAprox = calcularErrorAproximacion(xr, xrAnt);
                    if (errorAprox < errorTolerancia)
                        ea_menor_es = true;
                }

                if (hayValorVerdadero)
                    falsaPos = new FalsaPosicion(iteracion, intervalo, xl, xu, xr, fxl, fxu, fxr, fxlfxr, errorVerd, errorAprox);
                else
                    falsaPos = new FalsaPosicion(iteracion, intervalo, xl, xu, xr, fxl, fxu, fxr, fxlfxr, 0, errorAprox);
                listaFalsaPos.Add(falsaPos);

                if (fxlfxr < 0)
                    xu = xr;
                if (fxlfxr > 0)
                    xl = xr;

            } while (!ea_menor_es);

            return listaFalsaPos;
        }

        public static double evaluarFuncion(string expresion, double x)
        {
            double result = 0;
            Calculo funcion = new Calculo();
            if (funcion.Sintaxis(expresion, 'x'))
                result = funcion.EvaluaFx(x);
            return result;
        }

        public static List<Biseccion> biseccion(string expresion, double xl, double xu, double valorVerdadero, double errorTolerancia, bool hayValorVerdadero)
        {
            int iteracion = 0;
            double intervalo = 0;
            double xr = 0;
            double xrAnt = 0;
            double fxl = 0;
            double fxu = 0;
            double fxr = 0;
            double fxlfxr = 0;
            double errorAprox = 0;
            double errorVerd = 0;
            bool ea_menor_es = false;
            Biseccion biseccion = null;
            List<Biseccion> listaBiseccion = new List<Biseccion>();
            do
            {
                iteracion++;
                intervalo = xu - xl;
                xrAnt = xr;
                xr = (xl + xu) / 2;

                fxl = evaluarFuncion(expresion, xl);
                fxu = evaluarFuncion(expresion, xu);
                fxr = evaluarFuncion(expresion, xr);

                fxlfxr = fxl * fxr;

                if (hayValorVerdadero)                                 
                errorVerd = calcularErrorVerdadero(valorVerdadero, xr);                

                if (iteracion > 1)
                {
                    errorAprox = calcularErrorAproximacion(xr, xrAnt);
                    if (errorAprox < errorTolerancia)
                        ea_menor_es = true;
                }

                if (hayValorVerdadero)
                    biseccion = new Biseccion(iteracion, intervalo, xl, xu, xr, fxl, fxu, fxr, fxlfxr, errorVerd, errorAprox);
                else
                    biseccion = new Biseccion(iteracion, intervalo, xl, xu, xr, fxl, fxu, fxr, fxlfxr, 0, errorAprox);
                listaBiseccion.Add(biseccion);

                if (fxlfxr < 0)
                    xu = xr;
                if (fxlfxr > 0)
                    xl = xr;
            } while (!ea_menor_es);

            return listaBiseccion;
        }

        public static List<NewtonRaphson> newtonRaphson(string expresion, string derivada, double x0, double valorVerdadero, double errorTolerancia, bool hayValorVerdadero)
        {
            int iteracion = 0;
            double x0Ant = 0;
            double fx0 = 0;
            double dfx0 = 0;
            double errorAprox = 0;
            double errorVerd = 0;

            //Se realiza iteracion = 0
            NewtonRaphson newtonRaphson = null;
            List<NewtonRaphson> listaNewtonRaphson = new List<NewtonRaphson>();

            fx0 = evaluarFuncion(expresion, x0);
            dfx0 = evaluarFuncion(derivada, x0);

            newtonRaphson = new NewtonRaphson(iteracion, x0, fx0, dfx0, errorAprox, errorVerd);
            listaNewtonRaphson.Add(newtonRaphson);

            do //Se realiza el resto de iteraciones
            {
                iteracion++;

                x0Ant = x0;
                x0 = x0 - (fx0 / dfx0);

                fx0 = evaluarFuncion(expresion, x0);
                dfx0 = evaluarFuncion(derivada, x0);

                if(hayValorVerdadero)
                    errorVerd = calcularErrorVerdadero(valorVerdadero, x0);
                errorAprox = calcularErrorAproximacion(x0, x0Ant);

                if(hayValorVerdadero)
                    newtonRaphson = new NewtonRaphson(iteracion, x0, fx0, dfx0, errorAprox, errorVerd);
                else
                    newtonRaphson = new NewtonRaphson(iteracion, x0, fx0, dfx0, errorAprox, 0);

                listaNewtonRaphson.Add(newtonRaphson);

            } while (errorAprox > errorTolerancia);

            return listaNewtonRaphson;
        }

        public static List<Muller> muller(string expresion, double x0, double x1, double x2, double valorVerdadero, double errorTolerancia, bool hayValorVerdadero)
        {
            int iteracion = 0;
            double h0 = 0;
            double h1 = 0;
            double s0 = 0;
            double s1 = 0;
            double fx0 = 0;
            double fx1 = 0;
            double fx2 = 0;
            double a = 0;
            double b = 0;
            double c = 0;
            double signoP = 0;
            double signoN = 0;
            double x3 = 0;
            double errorAprox = 0;
            double errorVerd = 0;

            Muller muller = null;
            List<Muller> listaMuller = new List<Muller>();

            do
            {
                iteracion++;

                fx0 = evaluarFuncion(expresion, x0);
                fx1 = evaluarFuncion(expresion, x1);
                fx2 = evaluarFuncion(expresion, x2);

                h0 = x1 - x0;
                h1 = x2 - x1;

                s0 = (fx1 - fx0) / h0;
                s1 = (fx2 - fx1) / h1;

                a = (s1 - s0) / (h0 + h1);
                b = s1 + h1 * a;
                c = fx2;

                signoP = b + Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);
                signoN = b - Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);

                if (Math.Abs(signoP) > Math.Abs(signoN))
                    x3 = x2 + (-2 * c) / signoP;
                else
                    x3 = x2 + (-2 * c) / signoN;

                if(hayValorVerdadero)
                    errorVerd = calcularErrorVerdadero(valorVerdadero, x3);
                errorAprox = calcularErrorAproximacion(x3, x2);

                x0 = x1;
                x1 = x2;
                x2 = x3;

                if(hayValorVerdadero)
                    muller = new Muller(iteracion, x2, fx0, fx1, fx2, h0, h1, s0, s1, a, b, c, signoP, signoN, x3, errorVerd, errorAprox);
                else
                    muller = new Muller(iteracion, x2, fx0, fx1, fx2, h0, h1, s0, s1, a, b, c, signoP, signoN, x3, 0, errorAprox);

                listaMuller.Add(muller);

            } while (errorAprox > errorTolerancia);

            return listaMuller;
        }

        public static List<Secante> secante(string expresion, double x0, double x1, double valorVerdadero, double errorTolerancia, bool hayValorVverdadero)
        {
            int iteracion = 0;
            double fx0 = 0;
            double fx1 = 0;
            double aux = 0;
            double errorAprox = 0;
            double errorVerd = 0;
            bool ea_menor_es = false;

            Secante secante = new Secante();
            List<Secante> listaSecante = new List<Secante>();
            do
            {
                iteracion++;

                fx0 = evaluarFuncion(expresion, x0);
                fx1 = evaluarFuncion(expresion, x1);

                aux = x1;
                x1 = x1 - (fx1 * (x0 - x1)) / (fx0 - fx1);
                x0 = aux;

                if(hayValorVverdadero)
                    errorVerd = calcularErrorVerdadero(valorVerdadero, x1);

                errorAprox = calcularErrorAproximacion(x1, x0);
                if (iteracion > 1)
                {
                    if (errorAprox < errorTolerancia)
                        ea_menor_es = true;
                }

                if(hayValorVverdadero)
                    secante = new Secante(iteracion, x1, x0, fx1, fx0, errorVerd, errorAprox);
                else
                    secante = new Secante(iteracion, x1, x0, fx1, fx0, 0, errorAprox);
                listaSecante.Add(secante);

            } while (!ea_menor_es);

            return listaSecante;
        }

        public static double aplicarMetodoTrapecio(string expresion, double a, double b, int n)
        {
            double h = 0;
            double x = 0;
            double suma = 0;

            List<double> listaX = new List<double>();
            List<double> listaFx = new List<double>();

            Calculo funcion = new Calculo();

            x = a;
            h = (b - a) / n;

            while (x <= b)
            {
                listaX.Add(x);
                listaFx.Add(evaluarFuncion(expresion, x));
                x = x + h;
            }

            for (int i = 0; i <= n - 1; i++)
                suma = suma + (listaFx[i + 1] + listaFx[i]);

            return (h / 2) * suma;
        }

        public static List<double> getCoeficientes(int puntos)
        {
            List<double> coeficientes = new List<double>();
            switch (puntos)
            {
                case 2:
                    coeficientes.Add(1.0); coeficientes.Add(1.0);
                    break;
                case 3:
                    coeficientes.Add(0.5555556); coeficientes.Add(0.8888889); coeficientes.Add(0.5555556);
                    break;
                case 4:
                    coeficientes.Add(0.3478548); coeficientes.Add(0.6521452);
                    coeficientes.Add(0.6521452); coeficientes.Add(0.3478548);
                    break;
                case 5:
                    coeficientes.Add(0.2369269); coeficientes.Add(0.4786287); coeficientes.Add(0.5688889);
                    coeficientes.Add(0.4786287); coeficientes.Add(0.2369269);
                    break;
                case 6:
                    coeficientes.Add(0.1713245); coeficientes.Add(0.3607616); coeficientes.Add(0.4679139);
                    coeficientes.Add(0.4679139); coeficientes.Add(0.3607616); coeficientes.Add(0.1713245);
                    break;
            }
            return coeficientes;
        }

        public static List<double> getArgumentos(int puntos)
        {
            List<double> argumentos = new List<double>();
            switch (puntos)
            {
                case 2:
                    argumentos.Add(-0.577350269); argumentos.Add(0.57735269);
                    break;
                case 3:
                    argumentos.Add(-0.774596669); argumentos.Add(0.0);
                    argumentos.Add(0.774596669);
                    break;
                case 4:
                    argumentos.Add(-0.861136312); argumentos.Add(-0.339981044);
                    argumentos.Add(0.339981044); argumentos.Add(0.861136312);
                    break;
                case 5:
                    argumentos.Add(-0.906179846); argumentos.Add(-0.538469310); argumentos.Add(0.0);
                    argumentos.Add(0.538469310); argumentos.Add(0.906179846);
                    break;
                case 6:
                    argumentos.Add(-0.932469514); argumentos.Add(-0.661209386); argumentos.Add(-0.238619186);
                    argumentos.Add(0.238619186); argumentos.Add(0.661209386); argumentos.Add(0.932469514);
                    break;
            }

            return argumentos;
        }

        public static double metodoGaussLegendre(string expresion, int puntos, double a, double b)
        {
            Calculo funcion = new Calculo();
            double x = 0;
            double dx = 0;
            double fx = 0;
            double valorAprox = 0;
            List<double> coeficientes = getCoeficientes(puntos);
            List<double> argumentos = getArgumentos(puntos);

            dx = (b - a) / 2;

            if(funcion.Sintaxis(expresion, 'x'))
            {
                for (int i = 0; i < puntos; i++)
                {
                    x = (a + b) / 2 + ((b - a) /2 * argumentos[i]);
                    fx = dx * funcion.EvaluaFx(x);
                    valorAprox = valorAprox + (coeficientes[i] * fx);
                }
            }
            return valorAprox;
        }
            
        public static List<Heun> heun(string expresion, string solucionAnalitica, 
            double a, double b, double h, double x0, double y0)
        {
            List<Heun> listaHeun = new List<Heun>();
            Heun heun = null;
            Calculo funcion = new Calculo();
            int iteracion = 0;
            double xi = x0;
            double fxiyi = 0;
            double y0i = y0;
            double fxiy0i = 0;
            double yHeun = y0;
            double yt = evaluarFuncion(solucionAnalitica, xi);
            double et = 0;
            double ea = 0;
            string expresionConY = null;

            heun = new Heun(iteracion, xi, fxiyi, y0i, fxiy0i, yHeun, yt, et, ea);
            listaHeun.Add(heun);

            while (xi < b)
            {
                iteracion = iteracion + 1;
                xi = listaHeun[iteracion - 1].Xi + h;
                fxiyi = evaluarFuncion(expresion, listaHeun[iteracion-1].Xi);
                y0i = listaHeun[iteracion - 1].YHeun + fxiyi * h;
                expresionConY = expresion.Replace("y", y0i.ToString());
                fxiy0i = evaluarFuncion(expresionConY, xi);
                yHeun = listaHeun[iteracion - 1].YHeun + (fxiyi + fxiy0i) / 2 * h;
                yt = evaluarFuncion(solucionAnalitica, xi);
                et = (yt - yHeun) / yt;
                ea = calcularErrorAproximacion(yHeun, listaHeun[iteracion-1].YHeun);

                heun = new Heun(iteracion, xi, fxiyi, y0i, fxiy0i, yHeun, yt, et, ea);
                listaHeun.Add(heun);
            }

            return listaHeun;
        }

        public static double calcularK(string expresion, double x, double y)
        {
            double result = 0;
            Calculo funcion = new Calculo();
            expresion = expresion.Replace("y", y.ToString());
            expresion = expresion.Replace(',', '.');
            if (funcion.Sintaxis(expresion, 'x'))
                result = funcion.EvaluaFx(x);
            return result;
        }

        public static List<RK_CuartoOrden> RKCuartoOrden(string expresion, string solucionAnalitica, 
            double a, double b, double h, double x0, double y0)
        {
            List<RK_CuartoOrden> listaRK = new List<RK_CuartoOrden>();
            RK_CuartoOrden rkCuartoOrden = null;
            
            int iteracion = 0;
            double xi = 0;
            double yrk = 0;
            double k1 = 0;
            double k2 = 0;
            double k3 = 0;
            double k4 = 0;
            double yt = 0;
            double et = 0;
            double xAux = 0;
            double yAux = 0;

            while (xi < b)
            {
                if (iteracion == 0)
                {
                    xi = x0;
                    yrk = y0;
                }
                else 
                {
                    xi = xi + h;
                    yrk = yrk + (1 / 6) * (k1 + 2 * k2 + 2 * k3 + k4) * h;
                }
                    
                

                k1 = calcularK(expresion, xi, yrk);

                xAux = xi + h / 2.0;
                yAux = yrk + k1 * h / 2.0;
                k2 = calcularK(expresion, xAux, yAux);

                yAux = yrk + k2 * h / 2.0;
                k3 = calcularK(expresion, xAux, yAux);

                xAux = xi + h;
                yAux = yrk + k3 * h;
                k4 = calcularK(expresion, xAux, yAux);

                yt = evaluarFuncion(solucionAnalitica, xi);
                et = (yt - yrk);

                rkCuartoOrden = new RK_CuartoOrden(iteracion, xi, yrk, k1, k2, k3, k4, yt, et);
                listaRK.Add(rkCuartoOrden);

                iteracion = iteracion + 1;
            }

            return listaRK;
        }

        public static List<PuntoMedio> puntoMedio(string expresion, string solucionAnalitica, 
            double a, double b, double h, double x0, double y0)
        {
            List<PuntoMedio> listaPuntoMedio = new List<PuntoMedio>();
            PuntoMedio puntoMedio = null;
            int iteracion = 0;
            double xi = 0;
            double yrk = 0;
            double k1 = 0;
            double k2 = 0;
            double yt = 0;
            double et = 0;
            double xAux = 0;
            double yAux = 0;

            while (xi < b)
            {
                if(iteracion == 0)
                {
                    xi = x0;
                    yrk = y0;
                }
                else
                {
                    xi = xi + h;
                    yrk = yrk + k1 * h;
                }

                k1 = calcularK(expresion, xi, yrk);

                xAux = xi + h / 2.0;
                yAux = yrk + k1 * h / 2.0;
                k2 = calcularK(expresion, xAux, yAux);

                yt = evaluarFuncion(solucionAnalitica, xi);
                et = ((yt - yrk) / yt) * 100.0;

                puntoMedio = new PuntoMedio(iteracion, xi, yrk, k1, k2, yt, et);
                listaPuntoMedio.Add(puntoMedio);

                iteracion = iteracion + 1;
            }

            return listaPuntoMedio;
        }
    }
}
