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
    public partial class frmBiseccion : Form
    {
        public frmBiseccion()
        {
            InitializeComponent();
        }

        List<Biseccion> listaBiseccion = new List<Biseccion>();

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtExpresion.Clear();
            txtXl.Clear();
            txtXu.Clear();
            lblRaiz.Text = " ";
            lblEa.Text = " ";
            txtEs.Clear();
            txtVv.Clear();
            cmbCifrasSignif.SelectedIndex = -1;
            txtExpresion.Focus();
            listaBiseccion.Clear();
            mostrarDatosEnTabla(0, true);
        }

        public bool datosLlenos()
        {
            bool aux = true;
            if (string.IsNullOrEmpty(txtExpresion.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtXl.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtXu.Text))
                aux = false;           
            if (cmbCifrasSignif.SelectedIndex < 0)
                aux = false;

            if (radioButton2.Checked)
            {
                if (string.IsNullOrEmpty(txtEs.Text))
                    aux = false;
            }
            else
            {
                if (string.IsNullOrEmpty(txtCifrasSignificativas.Text))
                    aux = false;
            }
            return aux;
        }

        private void btnAplicarMetodo_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            listaBiseccion.Clear();
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
                valorVerd = Convert.ToDouble(txtVv.Text.Replace(".",","));
                
                if (valorVerd == 0)
                    hayValorVerdadero = false;
            }

            Calculo funcion = new Calculo();

            if (datosLlenos())
            {
                expresion = txtExpresion.Text;
                expresion = expresion.Replace(',', '.');
                txtExpresion.Text = expresion;

                if (!funcion.Sintaxis(expresion, 'x')) //Verifica que la expresion este correcta
                {
                    errorProvider.SetError(txtExpresion, "Hay un error en la expresión f(x)");
                    hayErrores = true;
                }

                cifrasSignif = Convert.ToInt32(cmbCifrasSignif.SelectedItem)+1;

                xl = Convert.ToDouble(txtXl.Text);
                xu = Convert.ToDouble(txtXu.Text);

                es = calcularEs();

                if (!hayErrores)
                {
                    //Llama al metodo de bisección
                    listaBiseccion = Algoritmos.Algoritmos.biseccion(expresion, xl, xu, valorVerd, es, hayValorVerdadero);

                    mostrarDatosEnTabla(cifrasSignif, hayValorVerdadero);

                    lblRaiz.Text = Algoritmos.Algoritmos.toCifraSignif(listaBiseccion[listaBiseccion.Count - 1].Xr, cifrasSignif);
                    lblEa.Text = Algoritmos.Algoritmos.toCifraSignif(listaBiseccion[listaBiseccion.Count - 1].Ea, cifrasSignif) + "%";
                }
            }
            else
                MessageBox.Show("Faltan datos por ingresar", "¡ERROR!");
        }

        public void mostrarDatosEnTabla(int cifrasSignif, bool hayValorVerdadero)
        {
            if (hayValorVerdadero)
            {
                dataGridView1.DataSource = listaBiseccion.Select(lt => new {
                    Iteración = lt.Iteración,
                    Intervalo = Algoritmos.Algoritmos.toCifraSignif(lt.Intervalo, cifrasSignif),
                    Xl = Algoritmos.Algoritmos.toCifraSignif(lt.Xl, cifrasSignif),
                    Xu = Algoritmos.Algoritmos.toCifraSignif(lt.Xu, cifrasSignif),
                    Xr = Algoritmos.Algoritmos.toCifraSignif(lt.Xr, cifrasSignif),
                    fxl = Algoritmos.Algoritmos.toCifraSignif(lt.Fxl, cifrasSignif),
                    fxu = Algoritmos.Algoritmos.toCifraSignif(lt.Fxu, cifrasSignif),
                    fxr = Algoritmos.Algoritmos.toCifraSignif(lt.Fxr, cifrasSignif),
                    fxlfxr = Algoritmos.Algoritmos.toCifraSignif(lt.Fxl_fxr, cifrasSignif),
                    Error_de_Aproximación = lt.Iteración == 1 ? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%",
                    Error_Verdadero = Algoritmos.Algoritmos.toCifraSignif(lt.Et, cifrasSignif) + "%",

                }).ToList();
            }
            else
            {
                dataGridView1.DataSource = listaBiseccion.Select(lt => new {
                    Iteración = lt.Iteración,
                    Intervalo = Algoritmos.Algoritmos.toCifraSignif(lt.Intervalo, cifrasSignif),
                    Xl = Algoritmos.Algoritmos.toCifraSignif(lt.Xl, cifrasSignif),
                    Xu = Algoritmos.Algoritmos.toCifraSignif(lt.Xu, cifrasSignif),
                    Xr = Algoritmos.Algoritmos.toCifraSignif(lt.Xr, cifrasSignif),
                    fxl = Algoritmos.Algoritmos.toCifraSignif(lt.Fxl, cifrasSignif),
                    fxu = Algoritmos.Algoritmos.toCifraSignif(lt.Fxu, cifrasSignif),
                    fxr = Algoritmos.Algoritmos.toCifraSignif(lt.Fxr, cifrasSignif),
                    fxlfxr = Algoritmos.Algoritmos.toCifraSignif(lt.Fxl_fxr, cifrasSignif),
                    Error_de_Aproximación = lt.Iteración == 1 ? " - " : Algoritmos.Algoritmos.toCifraSignif(lt.Ea, cifrasSignif) + "%"
                }).ToList();

            }
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void frmBiseccion_Load(object sender, EventArgs e)
        {
            mostrarDatosEnTabla(0, true);
            txtExpresion.Focus();
        }

        public double calcularEs()
        {            
            return Convert.ToDouble(txtEs.Text);                                      
        }

        private void txtXl_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtXu_KeyPress(object sender, KeyPressEventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtEs.Enabled = false;
            txtCifrasSignificativas.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtCifrasSignificativas.Enabled = false;
            txtEs.Enabled = true;
        }

        private void txtCifrasSignificativas_TextChanged(object sender, EventArgs e)
        {
            if (!txtCifrasSignificativas.Text.Equals(""))
            {
                txtEs.Text = (0.5 * Math.Pow(10, 2 - Convert.ToInt32(txtCifrasSignificativas.Text))) + "";
            }            
        }
    }
}
