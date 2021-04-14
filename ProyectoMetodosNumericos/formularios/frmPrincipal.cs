using ProyectoMetodosNumericos.Formularios;
using System;
using System.Windows.Forms;

namespace ProyectoMetodosNumericos.Formularios
{    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void bisecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBiseccion fb = new frmBiseccion();
            Algoritmos.Algoritmos.addFormulario(panel1, fb);
        }

        private void falsaPosiciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void newtonRaphsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewtonRaphson fnr = new frmNewtonRaphson();
            Algoritmos.Algoritmos.addFormulario(panel1, fnr);
        }

        private void secanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSecante fs = new frmSecante();
            Algoritmos.Algoritmos.addFormulario(panel1, fs);
        }

        private void müllerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void reglaDelTrapecioMùltipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrapecioMultiple ftm = new frmTrapecioMultiple();
            Algoritmos.Algoritmos.addFormulario(panel1, ftm);
        }

        private void gaussLegendreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGaussLegendre fgl = new frmGaussLegendre();
            Algoritmos.Algoritmos.addFormulario(panel1, fgl);
        }

        private void heunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHeun fh = new frmHeun();
            Algoritmos.Algoritmos.addFormulario(panel1, fh);
        }

        private void rKClásico4toOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRK_CuartoOrden frk = new frmRK_CuartoOrden();
            Algoritmos.Algoritmos.addFormulario(panel1, frk);
        }

        private void puntoMedioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPuntoMedio fpm = new frmPuntoMedio();
            Algoritmos.Algoritmos.addFormulario(panel1, fpm);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void métodosAbiertosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
