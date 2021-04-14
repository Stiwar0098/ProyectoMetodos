using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMetodosNumericos.algoritmos
{
    public class Validaciones
    {
       
        public static void validarTamanioString(KeyPressEventArgs e, TextBox texto, int tamLimite)
        {
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                if (texto.Text.Length >= tamLimite)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
        }

        public static void validarDecimalCelda(KeyPressEventArgs e, string texto)
        {

            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator)
            {
                if (texto.Contains(",") && e.KeyChar.ToString() == ",")
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }

        }

        public static void validarDecimal(KeyPressEventArgs e, TextBox texto)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) ||
                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || 
                e.KeyChar.ToString() == "-")
            {
                if ((texto.Text.Contains(",") && e.KeyChar.ToString() == ",") || 
                    (texto.Text.Contains("-") && e.KeyChar.ToString() == "-"))
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        public static bool esDecimal(String dec)
        {
            try
            {
                if (decimal.Parse(dec) >= 0)
                    return true;
                else
                    return false;
            }
            catch (Exception /*ex*/)
            {
                return false;
            }
        }

        public static void validarEntero(KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }        
    }
}
