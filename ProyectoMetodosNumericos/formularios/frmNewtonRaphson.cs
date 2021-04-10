using Calculus;
using ProyectoMetodosNumericos.algoritmos;
using ProyectoMetodosNumericos.Controladores;
using ProyectoMetodosNumericos.Entidades;
using ProyectoMetodosNumericos.Formularios;
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
    public partial class frmNewtonRaphson : Form
    {
        public frmNewtonRaphson()
        {
            InitializeComponent();
        }

        List<NewtonRaphson> listaNewtonRaphson = new List<NewtonRaphson>();

        public bool datosLlenos()
        {
            bool aux = true;
            if (string.IsNullOrEmpty(txtExpresion.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtDerivada.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtEs.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtX0.Text))
                aux = false;
            if (cmbCifras.SelectedIndex < 0)
                aux = false;
            return aux;
        }

        public double calcularExpresion(string expresion, double x0)
        {
            Calculo funcion = new Calculo();
            double fx = 0;
            if(funcion.Sintaxis(expresion, 'x'))
                fx = funcion.EvaluaFx(x0);
            return fx;
        }

        public void mostrarDatosEnTabla(int cifrasSignif, bool hayValorVerdadero)
        {
            if (hayValorVerdadero)
            {
                dataGridView1.DataSource = listaNewtonRaphson.Select(lt => new {
                    Iteración = lt.Iteracion,
                    X0 = Algoritmos.Algoritmos.toCifraSignif(lt.X0, cifrasSignif),
                    fx0 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx0, cifrasSignif),
                    dfx0 = Algoritmos.Algoritmos.toCifraSignif(lt.Dfx0, cifrasSignif),
                    Error_de_Aproximación = lt.Iteracion == 0? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%",
                    Error_Verdadero = lt.Et == 0 ? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Et, cifrasSignif) + "%"
                }).ToList();
            }
            else
            {
                dataGridView1.DataSource = listaNewtonRaphson.Select(lt => new {
                    Iteración = lt.Iteracion,
                    X0 = Algoritmos.Algoritmos.toCifraSignif(lt.X0, cifrasSignif),
                    fx0 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx0, cifrasSignif),
                    dfx0 = Algoritmos.Algoritmos.toCifraSignif(lt.Dfx0, cifrasSignif),
                    Error_de_Aproximación = lt.Iteracion == 0 ? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%"
                }).ToList();
            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmNewtonRaphson_Load(object sender, EventArgs e)
        {
            listaNewtonRaphson.Clear();
            mostrarDatosEnTabla(0, true);
            txtExpresion.Focus();
        }

        private void btnAplicarMetodo_Click_1(object sender, EventArgs e)
        {
            listaNewtonRaphson.Clear();
            errorProvider.Clear();
            int cifrasSignif = 0;
            bool hayErrores = false;

            double x0 = 0;
            double es = 0;
            double valorVerd = 0;
            string expresion = null;
            string derivada = null;

            bool hayValorVerdadero = true;

            if (string.IsNullOrEmpty(txtVv.Text))
                hayValorVerdadero = false;
            else
            {
                valorVerd = Convert.ToDouble(txtVv.Text);
                if (valorVerd == 0)
                    hayValorVerdadero = false;
            }

            Calculo funcion = new Calculo();

            if (datosLlenos())
            {
                //CORRECCIÓN DE ERRORES
                expresion = txtExpresion.Text;
                expresion = expresion.Replace(',', '.');
                txtExpresion.Text = expresion;

                if (!funcion.Sintaxis(expresion, 'x'))
                {
                    errorProvider.SetError(txtExpresion, "Hay un error en la expresión f(x)");
                    hayErrores = true;
                }

                derivada = txtDerivada.Text;
                derivada = derivada.Replace(',', '.');
                txtDerivada.Text = derivada;

                if (!funcion.Sintaxis(derivada, 'x'))
                {
                    errorProvider.SetError(txtExpresion, "Hay un error en la derivada f'(x)");
                    hayErrores = true;
                }

                cifrasSignif = Convert.ToInt32(cmbCifras.SelectedItem);
                x0 = Convert.ToDouble(txtX0.Text);
                es = Convert.ToDouble(txtEs.Text);

                //APLICACIÓN DEL MÉTODO
                if (!hayErrores)
                {
                    //Llama al método de Newton Raphson
                    listaNewtonRaphson = Algoritmos.Algoritmos.newtonRaphson(expresion, derivada, x0, valorVerd, es, hayValorVerdadero);

                    //MUESTRO DATOS
                    mostrarDatosEnTabla(cifrasSignif, hayValorVerdadero);
                    lblRaiz.Text = Algoritmos.Algoritmos.toCifraSignif(listaNewtonRaphson[listaNewtonRaphson.Count - 1].X0, cifrasSignif);
                    lblEa.Text = Algoritmos.Algoritmos.toCifraSignif(listaNewtonRaphson[listaNewtonRaphson.Count - 1].Ea, cifrasSignif) + "%";
                }
            }
            else
                MessageBox.Show("Aún hay datos por llenar", "¡ERROR!");
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            errorProvider.Clear();
            listaNewtonRaphson.Clear();
            txtExpresion.Clear();
            txtDerivada.Clear();
            txtEs.Clear();
            txtVv.Clear();
            txtX0.Clear();
            lblRaiz.Text = " ";
            lblEa.Text = " ";
            cmbCifras.SelectedIndex = -1;
            txtExpresion.Focus();
            mostrarDatosEnTabla(0, true);
        }

        private void txtX0_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtEs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtVv_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtVv_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cmbCifras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
