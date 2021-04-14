using Calculus;
using ProyectoMetodosNumericos.algoritmos;
using ProyectoMetodosNumericos.entidades;
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
    public partial class frmPuntoMedio : Form
    {
        public frmPuntoMedio()
        {
            InitializeComponent();
        }

        List<PuntoMedio> listaPuntoMedio = new List<PuntoMedio>();

        public bool datosLlenos()
        {
            bool aux = true;
            if (string.IsNullOrEmpty(txtExpresion.Text))
                aux = false;
            if (string.IsNullOrEmpty(txta.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtb.Text))
                aux = false;
            if (string.IsNullOrEmpty(txth.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtXo.Text))
                aux = false;
            if (string.IsNullOrEmpty(txtYo.Text))
                aux = false;
            if (cmbCifrasSignif.SelectedIndex < 0)
                aux = false;
            return aux;
        }

        public void mostrarDatosEnTabla(int cifrasSignif, bool hayValorVerdadero)
        {
            if (hayValorVerdadero)
            {
                dataGridView1.DataSource = listaPuntoMedio.Select(lt => new
                {
                    Iteración = lt.Iteracion,
                    Xi = Algoritmos.Algoritmos.toCifraSignif(lt.Xi, cifrasSignif),
                    k1 = Algoritmos.Algoritmos.toCifraSignif(lt.K1, cifrasSignif),
                    Xi2 = Algoritmos.Algoritmos.toCifraSignif(lt.Xi2, cifrasSignif),
                    y0i = Algoritmos.Algoritmos.toCifraSignif(lt.Y0i, cifrasSignif),
                    k2 = Algoritmos.Algoritmos.toCifraSignif(lt.K2, cifrasSignif),
                    yPuntoMedio = Algoritmos.Algoritmos.toCifraSignif(lt.YpuntoMedio, cifrasSignif),
                    yt = Algoritmos.Algoritmos.toCifraSignif(lt.Yt, cifrasSignif),
                    ErrorGlobal = Algoritmos.Algoritmos.toCifraSignif(lt.ErrorGlobal, cifrasSignif) + "%",
                }).ToList();
            }
            else
            {
                dataGridView1.DataSource = listaPuntoMedio.Select(lt => new
                {
                    Iteración = lt.Iteracion,
                    Xi = Algoritmos.Algoritmos.toCifraSignif(lt.Xi, cifrasSignif),
                    k1 = Algoritmos.Algoritmos.toCifraSignif(lt.K1, cifrasSignif),
                    Xi2 = Algoritmos.Algoritmos.toCifraSignif(lt.Xi2, cifrasSignif),
                    y0i = Algoritmos.Algoritmos.toCifraSignif(lt.Y0i, cifrasSignif),
                    k2 = Algoritmos.Algoritmos.toCifraSignif(lt.K2, cifrasSignif),
                    yPuntoMedio = Algoritmos.Algoritmos.toCifraSignif(lt.YpuntoMedio, cifrasSignif),
                    yt = Algoritmos.Algoritmos.toCifraSignif(lt.Yt, cifrasSignif),
                }).ToList();
            }
        }

        private void frmPuntoMedio_Load(object sender, EventArgs e)
        {
            mostrarDatosEnTabla(0, false);
            txtExpresion.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtExpresion.Clear();
            txtSolucionAnalitica.Clear();
            txta.Clear();
            txtb.Clear();
            txth.Clear();
            txtXo.Clear();
            txtYo.Clear();
            cmbCifrasSignif.SelectedIndex = -1;
            listaPuntoMedio.Clear();
            mostrarDatosEnTabla(0, false);
        }

        private void btnAplicarMetodo_Click(object sender, EventArgs e)
        {
            listaPuntoMedio.Clear();
            errorProvider.Clear();
            int cifrasSignif = 0;
            double x0 = 0;
            double a = 0;
            double b = 0;
            double h = 0;
            string expresion = null;
            string expresionConY = null;
            string solucionAnalitica = null;
            double y0 = 0;
            bool hayErrores = false;
            bool hayValorVerdadero = false;

            Calculo funcion = new Calculo();

            if (datosLlenos())
            {
                //CORRECCIÓN DE ERRORES
                y0 = Convert.ToDouble(txtYo.Text);

                expresion = txtExpresion.Text;
                expresion = expresion.Replace(',', '.');
                expresionConY = expresion.Replace("y", y0.ToString());
                txtExpresion.Text = expresion;

                if (!funcion.Sintaxis(expresionConY, 'x'))
                {
                    errorProvider.SetError(txtExpresion, "Hay un error en la expresión f(x)");
                    hayErrores = true;
                }

                if (string.IsNullOrEmpty(txtSolucionAnalitica.Text))
                    hayValorVerdadero = false;
                else
                {
                    solucionAnalitica = txtSolucionAnalitica.Text;
                    solucionAnalitica = solucionAnalitica.Replace(',', '.');
                    txtSolucionAnalitica.Text = solucionAnalitica;

                    if (!funcion.Sintaxis(solucionAnalitica, 'x'))
                    {
                        errorProvider.SetError(txtSolucionAnalitica, "Hay un error en la solución analítica f'(x)");
                        hayErrores = true;
                    }
                }

                cifrasSignif = Convert.ToInt32(cmbCifrasSignif.SelectedItem);
                a = Convert.ToDouble(txta.Text);
                b = Convert.ToDouble(txtb.Text);
                h = Convert.ToDouble(txth.Text);
                x0 = Convert.ToDouble(txtXo.Text);

                //APLICACIÓN DEL MÉTODO
                if (!hayErrores)
                {
                    //Llama al método de Heun
                    listaPuntoMedio = Algoritmos.Algoritmos.puntoMedio2(expresion, solucionAnalitica, a, b, h, x0, y0);

                    //MUESTRO DATOS
                    mostrarDatosEnTabla(cifrasSignif, hayValorVerdadero);
                }
            }
            else
                MessageBox.Show("Aún hay datos por llenar", "¡ERROR!");
        }

        private void txta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtb_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtXo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txth_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void txtYo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.validarDecimal(e, (TextBox)sender);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
