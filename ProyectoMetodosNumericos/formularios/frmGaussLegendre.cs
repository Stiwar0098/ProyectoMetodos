using Calculus;
using ProyectoMetodosNumericos.algoritmos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMetodosNumericos.Formularios
{
    public partial class frmGaussLegendre : Form
    {
        public frmGaussLegendre()
        {
            InitializeComponent();
        }

        public bool datosLlenos()
        {
            bool aux = true;
            if (string.IsNullOrEmpty(txtExpresion.Text))
                aux = false;
            if (string.IsNullOrEmpty(txta.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtb.Text))
                aux = false;
            if (cmbPuntos.SelectedIndex < 0)
                aux = false;
            if (cmbCifrasSignif.SelectedIndex < 0)
                aux = false;
            return aux;
        }

        private void btnAplicarMetodo_Click(object sender, EventArgs e)
        {
            double valorAprox = 0;
            double et = 0;
            int puntos = 0;
            double a = 0;
            double b = 0;
            string expresion = null;
            double valorVerdadero = 0;
            bool hayErrores = false;
            int cifrasSignif = 0;

            Calculo funcion = new Calculo();

            bool hayValorVerdadero = true;

            if (string.IsNullOrEmpty(txtValorVerdadero.Text))
                hayValorVerdadero = false;
            else
            {
                valorVerdadero = Convert.ToDouble(txtValorVerdadero.Text);
                if (valorVerdadero == 0)
                    hayValorVerdadero = false;
            }

            if (datosLlenos())
            {
                expresion = txtExpresion.Text;
                expresion = expresion.Replace(',', '.');
                txtExpresion.Text = expresion;

                if (!funcion.Sintaxis(expresion, 'x'))
                {
                    errorProvider1.SetError(txtExpresion, "Hay un error en la expresión f(x)");
                    hayErrores = true;
                }

                cifrasSignif = Convert.ToInt32(cmbCifrasSignif.SelectedItem);
                puntos = Convert.ToInt32(cmbPuntos.Text);
                a = Convert.ToDouble(txta.Text);
                b = Convert.ToDouble(txtb.Text);

                //APLICACION DEL METODO DE GAUSS-LEGENDRE
                if (!hayErrores)
                {
                    valorAprox = Algoritmos.Algoritmos.metodoGaussLegendre(expresion, puntos, a, b);
                    lblValorAproxT.Text = Algoritmos.Algoritmos.toCifraSignif(valorAprox, cifrasSignif);

                    if (hayValorVerdadero)
                    {
                        et = Algoritmos.Algoritmos.calcularErrorVerdadero(valorVerdadero, valorAprox);
                        lblErrorVerdT.Text = Algoritmos.Algoritmos.toCifraSignif(et, cifrasSignif) + "%";
                    }
                }
            }
            else
                MessageBox.Show("Faltan datos por ingresar", "¡ERROR!");
        }

        public void limpiarDatos()
        {
            txta.Clear();
            txtb.Clear();
            txtExpresion.Clear();
            cmbPuntos.SelectedIndex = -1;
            txtValorVerdadero.Clear();
            cmbCifrasSignif.SelectedIndex = -1;
            lblErrorVerdT.Text = "%";
            lblValorAproxT.Text = " - ";
            txtExpresion.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void frmGaussLegendre_Load(object sender, EventArgs e)
        {
            txtExpresion.Focus();
        }

        private void txtValorVerdadero_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }
    }
}
