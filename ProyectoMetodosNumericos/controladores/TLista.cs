using ProyectoMetodosNumericos.entidades;
using ProyectoMetodosNumericos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMetodosNumericos.Controladores
{
    public class TLista
    {
        public static List<Biseccion> listaBiseccion = new List<Biseccion>();        
        public static List<NewtonRaphson> listaNewtonRaphson = new List<NewtonRaphson>();
        public static List<Secante> listaSecante = new List<Secante>();        
        public static List<Heun> listaHeun = new List<Heun>();
    }
}
