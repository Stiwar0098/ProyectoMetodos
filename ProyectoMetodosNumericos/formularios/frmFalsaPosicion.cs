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
    public partial class frmFalsaPosicion : Form
    {
        public frmFalsaPosicion()
        {
            InitializeComponent();
        }

        List<FalsaPosicion> listaFalsaPos = new List<FalsaPosicion>();

        public bool datosLlenos()
        {
            bool aux = true;
            if (string.IsNullOrEmpty(txtExpresion.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtXl.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtXu.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtEs.Text))
                aux = false;
            if (cmbCifras.SelectedIndex < 0)
                aux = false;
            return aux;
        }
        public void mostrarDatosEnTabla(int cifrasSignif, bool hayValorVerdadero)
        {
            if (hayValorVerdadero)
            {
                dataGridView1.DataSource = listaFalsaPos.Select(lt => new {
                    Iteración = lt.Iteración,
                    Intervalo = lt.Intervalo,
                    Xl = Algoritmos.Algoritmos.toCifraSignif(lt.Xl, cifrasSignif),
                    Xu = Algoritmos.Algoritmos.toCifraSignif(lt.Xu, cifrasSignif),
                    Xr = Algoritmos.Algoritmos.toCifraSignif(lt.Xr, cifrasSignif),
                    fxl = Algoritmos.Algoritmos.toCifraSignif(lt.Fxl, cifrasSignif),
                    fxu = Algoritmos.Algoritmos.toCifraSignif(lt.Fxu, cifrasSignif),
                    fxr = Algoritmos.Algoritmos.toCifraSignif(lt.Fxr, cifrasSignif),
                    fxlfxr = Algoritmos.Algoritmos.toCifraSignif(lt.Fxl_fxr, cifrasSignif),
                    Error_de_Aproximación = lt.Iteración == 1? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%",
                    Error_Verdadero = Algoritmos.Algoritmos.toCifraSignif(lt.Et, cifrasSignif) + "%"
                }).ToList();
            }
            else
            {
                dataGridView1.DataSource = listaFalsaPos.Select(lt => new {
                    Iteración = lt.Iteración,
                    Intervalo = lt.Intervalo,
                    Xl = Algoritmos.Algoritmos.toCifraSignif(lt.Xl, cifrasSignif),
                    Xu = Algoritmos.Algoritmos.toCifraSignif(lt.Xu, cifrasSignif),
                    Xr = Algoritmos.Algoritmos.toCifraSignif(lt.Xr, cifrasSignif),
                    fxl = Algoritmos.Algoritmos.toCifraSignif(lt.Fxl, cifrasSignif),
                    fxu = Algoritmos.Algoritmos.toCifraSignif(lt.Fxu, cifrasSignif),
                    fxr = Algoritmos.Algoritmos.toCifraSignif(lt.Fxr, cifrasSignif),
                    fxlfxr = Algoritmos.Algoritmos.toCifraSignif(lt.Fxl_fxr, cifrasSignif),
                    Error_de_Aproximación = lt.Iteración == 1 ? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%",
                }).ToList();

            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnAplicarMetodo_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            listaFalsaPos.Clear();
            bool hayErrores = false;

            int cifrasSignif = 0;
            string expresion = null;
            double valorVerd = 0;
            double xu = 0;
            double xl = 0;
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

            Calculo funcion = new Calculo();

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
                xl = Convert.ToDouble(txtXl.Text);
                xu = Convert.ToDouble(txtXu.Text);
                es = Convert.ToDouble(txtEs.Text);

                if (!hayErrores)
                {
                    //Llama al método de falsa posición
                    listaFalsaPos = Algoritmos.Algoritmos.falsaPosicion(expresion, xl, xu, valorVerd, es, hayValorVerdadero);

                    mostrarDatosEnTabla(cifrasSignif, hayValorVerdadero);
                    lblRaiz.Text = Algoritmos.Algoritmos.toCifraSignif(listaFalsaPos[listaFalsaPos.Count-1].Xr, cifrasSignif);
                    lblEa.Text = Algoritmos.Algoritmos.toCifraSignif(listaFalsaPos[listaFalsaPos.Count - 1].Ea, cifrasSignif) + "%";
                }
            }
            else
                MessageBox.Show("Faltan datos por ingresar", "¡ERROR!");

        }

        private void frmFalsaPosicion_Load(object sender, EventArgs e)
        {
            mostrarDatosEnTabla(0, true);
            txtExpresion.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtExpresion.Clear();
            txtXl.Clear();
            txtXu.Clear();
            lblRaiz.Text = " ";
            lblEa.Text = " ";
            txtEs.Clear();
            txtVv.Clear();
            cmbCifras.SelectedIndex = -1;
            txtExpresion.Focus();
            listaFalsaPos.Clear();
            mostrarDatosEnTabla(0, true);
        }

        private void txtXl_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtXu_KeyPress(object sender, KeyPressEventArgs e)
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
