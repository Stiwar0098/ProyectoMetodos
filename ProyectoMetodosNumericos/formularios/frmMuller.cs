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
    public partial class frmMuller : Form
    {
        public frmMuller()
        {
            InitializeComponent();
        }

        List<Muller> listaMuller = new List<Muller>();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            listaMuller.Clear();
            txtExpresion.Clear();
            cmbCifras.SelectedIndex = -1;
            txtEs.Clear();
            txtVv.Clear();
            txtX0.Clear();
            txtX1.Clear();
            txtX2.Clear();
            lblEa.Text = " ";
            lblRaiz.Text = " ";
            txtExpresion.Focus();
            mostrarDatosEnTabla(0, true);
        }

        public bool datosLlenos()
        {
            bool aux = true;
            if (string.IsNullOrEmpty(txtExpresion.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtEs.Text))
                aux = false;
            if (cmbCifras.SelectedIndex < 0)
                aux = false;
            if (string.IsNullOrEmpty(txtX0.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtX1.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtX2.Text))
                aux = false;

            return aux;
        }

        private void btnAplicarMetodo_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            listaMuller.Clear();
            Calculo funcion = new Calculo();
            bool hayErrores = false;

            int cifrasSignif = 0;
            string expresion = null;
            double x0 = 0;
            double x1 = 0;
            double x2 = 0;
            double valorVerd = 0;
            double es = 0;

            bool hayValorVerdadero = true;
            if (string.IsNullOrEmpty(txtVv.Text))
                hayValorVerdadero = false;
            else
            {
                valorVerd = Convert.ToDouble(txtVv.Text);
                if (valorVerd == 0)
                    hayValorVerdadero = false;
            }

            if (datosLlenos())
            {
                expresion = txtExpresion.Text;
                txtExpresion.Text = expresion;

                if (!funcion.Sintaxis(expresion, 'x'))
                {
                    errorProvider.SetError(txtExpresion, "Hay un error en la expresión f(x)");
                    hayErrores = true;
                }

                cifrasSignif = Convert.ToInt32(cmbCifras.SelectedItem);
                x0 = Convert.ToDouble(txtX0.Text);
                x1 = Convert.ToDouble(txtX1.Text);
                x2 = Convert.ToDouble(txtX2.Text);
                es = Convert.ToDouble(txtEs.Text);

                if (!hayErrores)
                {
                    //Llama al método de Müller
                    listaMuller = Algoritmos.Algoritmos.muller(expresion, x0, x1, x2, valorVerd, es, hayValorVerdadero);

                    mostrarDatosEnTabla(cifrasSignif, hayValorVerdadero);
                    lblRaiz.Text = Algoritmos.Algoritmos.toCifraSignif(listaMuller[listaMuller.Count-1].X3, cifrasSignif);
                    lblEa.Text = Algoritmos.Algoritmos.toCifraSignif(listaMuller[listaMuller.Count - 1].Ea, cifrasSignif) + "%";
                }
            }
            else
                MessageBox.Show("Faltan datos por ingresar", "¡ERROR!");
        }

        public void mostrarDatosEnTabla(int cifrasSignif, bool hayValorVerdadero)
        {
            if (hayValorVerdadero)
            {
                dataGridView1.DataSource = listaMuller.Select(lt => new {
                    Iteración = lt.Iteracion,
                    Xi = Algoritmos.Algoritmos.toCifraSignif(lt.X2, cifrasSignif),
                    fx0 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx0, cifrasSignif),
                    fx1 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx1, cifrasSignif),
                    fx2 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx2, cifrasSignif),
                    h0 = Algoritmos.Algoritmos.toCifraSignif(lt.H0, cifrasSignif),
                    h1 = Algoritmos.Algoritmos.toCifraSignif(lt.H1, cifrasSignif),
                    sigma0 = Algoritmos.Algoritmos.toCifraSignif(lt.S0, cifrasSignif),
                    sigma1 = Algoritmos.Algoritmos.toCifraSignif(lt.S1, cifrasSignif),
                    a = Algoritmos.Algoritmos.toCifraSignif(lt.A, cifrasSignif),
                    b = Algoritmos.Algoritmos.toCifraSignif(lt.B, cifrasSignif),
                    c = Algoritmos.Algoritmos.toCifraSignif(lt.B, cifrasSignif),
                    signo_Positivo = Algoritmos.Algoritmos.toCifraSignif(lt.SignoP, cifrasSignif),
                    signo_Negativo = Algoritmos.Algoritmos.toCifraSignif(lt.SignoN, cifrasSignif),
                    X3 = Algoritmos.Algoritmos.toCifraSignif(lt.X3, cifrasSignif),
                    Error_de_Aproximación = Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%",
                    Error_Verdadero = Algoritmos.Algoritmos.toCifraSignif(lt.Et, cifrasSignif) + "%"
                }).ToList();
            }
            else
            {
                dataGridView1.DataSource = listaMuller.Select(lt => new {
                    Iteración = lt.Iteracion,
                    Xi = Algoritmos.Algoritmos.toCifraSignif(lt.X2, cifrasSignif),
                    fx0 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx0, cifrasSignif),
                    fx1 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx1, cifrasSignif),
                    fx2 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx2, cifrasSignif),
                    h0 = Algoritmos.Algoritmos.toCifraSignif(lt.H0, cifrasSignif),
                    h1 = Algoritmos.Algoritmos.toCifraSignif(lt.H1, cifrasSignif),
                    sigma0 = Algoritmos.Algoritmos.toCifraSignif(lt.S0, cifrasSignif),
                    sigma1 = Algoritmos.Algoritmos.toCifraSignif(lt.S1, cifrasSignif),
                    a = Algoritmos.Algoritmos.toCifraSignif(lt.A, cifrasSignif),
                    b = Algoritmos.Algoritmos.toCifraSignif(lt.B, cifrasSignif),
                    c = Algoritmos.Algoritmos.toCifraSignif(lt.B, cifrasSignif),
                    signo_Positivo = Algoritmos.Algoritmos.toCifraSignif(lt.SignoP, cifrasSignif),
                    signo_Negativo = Algoritmos.Algoritmos.toCifraSignif(lt.SignoN, cifrasSignif),
                    X3 = Algoritmos.Algoritmos.toCifraSignif(lt.X3, cifrasSignif),
                    Error_de_Aproximación = Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%"
                }).ToList();
            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmMuller_Load(object sender, EventArgs e)
        {
            mostrarDatosEnTabla(0, true);
            txtExpresion.Focus();
        }

        private void txtX0_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtX2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtX1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtVv_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtEs_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }
    }
}
