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

namespace ProyectoMetodosNumericos.formularios
{
    public partial class frmTrapecioMultiple : Form
    {
        public frmTrapecioMultiple()
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
            if (string.IsNullOrEmpty(txtn.Text))
                aux = false;
            if (cmbCifrasSignif.SelectedIndex < 0)
                aux = false;
            return aux;
        }

        private void btnAplicarMetodo_Click(object sender, EventArgs e)
        {
            double valorAprox = 0;
            double et = 0;
            int n = 0;
            double a = 0;
            double b = 0;
            string expresion = null;
            double valorVerdadero = 0;
            int cifrasSignif = 0;
            bool hayErrores = false;
            bool hayValorVerdadero = true;

            if (string.IsNullOrEmpty(txtValorVerdadero.Text))
                hayValorVerdadero = false;
            else
            {
                valorVerdadero = Convert.ToDouble(txtValorVerdadero.Text);
                if (valorVerdadero == 0)
                    hayValorVerdadero = false;
            }

            Calculo funcion = new Calculo();

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
                n = Convert.ToInt32(txtn.Text);
                a = Convert.ToDouble(txta.Text);
                b = Convert.ToDouble(txtb.Text);

                if (!hayErrores)
                {
                    if (n >= 2)
                    {
                        valorAprox = Algoritmos.Algoritmos.aplicarMetodoTrapecio(expresion, a, b, n);
                        lblValorAproxT.Text = Algoritmos.Algoritmos.toCifraSignif(valorAprox, cifrasSignif);

                        if (hayValorVerdadero)
                        {
                            et = Algoritmos.Algoritmos.calcularErrorVerdadero(valorVerdadero, valorAprox);
                            lblErrorVerdT.Text = Algoritmos.Algoritmos.toCifraSignif(et, cifrasSignif) + "%";
                        }
                    }
                    else
                        MessageBox.Show("el numero de segmentos debe ser de 2 o más", "¡ERROR!");
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
            txtn.Clear();
            txtValorVerdadero.Clear();
            cmbCifrasSignif.SelectedIndex = -1;
            lblErrorVerdT.Text = "%";
            lblValorAproxT.Text = " - ";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmTrapecioMultiple_Load(object sender, EventArgs e)
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

        private void txtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarEntero(e);
        }
    }
}
