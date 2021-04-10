using Calculus;
using ProyectoMetodosNumericos.algoritmos;
using ProyectoMetodosNumericos.Controladores;
using ProyectoMetodosNumericos.Entidades;
using ProyectoMetodosNumericos.formularios;
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
    public partial class frmSecante : Form
    {
        public frmSecante()
        {
            InitializeComponent();
        }

        List<Secante> listaSecante = new List<Secante>();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            txtEs.Clear();
            txtExpresion.Clear();
            txtVv.Clear();
            txtX1.Clear();
            txtX0.Clear();
            cmbCifras.SelectedIndex = -1;
            txtExpresion.Focus();
            lblRaiz.Text = " ";
            lblEa.Text = " ";
            listaSecante.Clear();
            mostrarDatosEnTabla(0, true);
        }

        public bool datosLlenos()
        {
            bool aux = true;
            if (string.IsNullOrEmpty(txtExpresion.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtX0.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtX1.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtEs.Text))
                aux = false;
            if (cmbCifras.SelectedIndex < 0)
                aux = false;

            return aux;
        }

        private void btnAplicarMetodo_Click(object sender, EventArgs e)
        {
            listaSecante.Clear();
            errorProvider.Clear();
            Secante secante = new Secante();
            Calculo funcion = new Calculo();
            int cifrasSignif = 8;
            bool hayErrores = false;

            double x0 = 0;
            double x1 = 0;
            double errorTolerancia = 0.0;
            double valorVerd = 0;
            string expresion = null;

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
                expresion = expresion.Replace(',', '.');
                txtExpresion.Text = expresion;

                if (!funcion.Sintaxis(expresion, 'x'))
                {
                    errorProvider.SetError(txtExpresion, "Hay un error en la expresión f(x)");
                    hayErrores = true;
                }

                cifrasSignif = Convert.ToInt32(cmbCifras.SelectedItem);
                x0 = Convert.ToDouble(txtX0.Text);
                x1 = Convert.ToDouble(txtX1.Text);
                errorTolerancia = Convert.ToDouble(txtEs.Text);

                if (!hayErrores)
                {
                    //Llama al método de la secante
                    listaSecante = Algoritmos.Algoritmos.secante(expresion, x0, x1, valorVerd, errorTolerancia, hayValorVerdadero);

                    mostrarDatosEnTabla(cifrasSignif, hayValorVerdadero);
                    lblRaiz.Text = Algoritmos.Algoritmos.toCifraSignif(listaSecante[listaSecante.Count-1].X1, cifrasSignif);
                    lblEa.Text = Algoritmos.Algoritmos.toCifraSignif(listaSecante[listaSecante.Count - 1].Ea, cifrasSignif) + "%";
                }
            }
            else
                MessageBox.Show("Faltan datos por ingresar", "¡ERROR!");
        }

        public void mostrarDatosEnTabla(int cifrasSignif, bool hayValorVerdadero)
        {
            if (hayValorVerdadero)
            {
                dataGridView1.DataSource = listaSecante.Select(lt => new {
                    Iteración = lt.Iteracion,
                    x1 = Algoritmos.Algoritmos.toCifraSignif(lt.X1, cifrasSignif),
                    x0 = Algoritmos.Algoritmos.toCifraSignif(lt.X0, cifrasSignif),
                    fx1 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx1, cifrasSignif),
                    fx0 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx0, cifrasSignif),
                    Error_de_Aproximación = lt.Iteracion == 0? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%",
                    Error_Verdadero = Algoritmos.Algoritmos.toCifraSignif(lt.Et, cifrasSignif) + "%"
                }).ToList();
            }
            else
            {
                dataGridView1.DataSource = listaSecante.Select(lt => new {
                    Iteración = lt.Iteracion,
                    x1 = Algoritmos.Algoritmos.toCifraSignif(lt.X1, cifrasSignif),
                    x0 = Algoritmos.Algoritmos.toCifraSignif(lt.X0, cifrasSignif),
                    fx1 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx1, cifrasSignif),
                    fx0 = Algoritmos.Algoritmos.toCifraSignif(lt.Fx0, cifrasSignif),
                    Error_de_Aproximación = lt.Iteracion == 0 ? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%",
                }).ToList();
            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmSecante_Load(object sender, EventArgs e)
        {
            mostrarDatosEnTabla(0, true);
            txtExpresion.Focus();
        }

        private void txtX0_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtX1_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
