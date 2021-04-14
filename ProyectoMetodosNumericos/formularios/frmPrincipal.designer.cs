namespace ProyectoMetodosNumericos.Formularios
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.métodosAbiertosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bisecciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.métodosCerradosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newtonRaphsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cudraturaDeGaussToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reglaDelTrapecioMùltipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussLegendreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.métodosDeRungeKuttaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoMedioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rKClásico4toOrdenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.métodosAbiertosToolStripMenuItem,
            this.métodosCerradosToolStripMenuItem,
            this.cudraturaDeGaussToolStripMenuItem,
            this.métodosDeRungeKuttaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 28);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // métodosAbiertosToolStripMenuItem
            // 
            this.métodosAbiertosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bisecciónToolStripMenuItem});
            this.métodosAbiertosToolStripMenuItem.Name = "métodosAbiertosToolStripMenuItem";
            this.métodosAbiertosToolStripMenuItem.Size = new System.Drawing.Size(140, 24);
            this.métodosAbiertosToolStripMenuItem.Text = "Métodos Abiertos";
            this.métodosAbiertosToolStripMenuItem.Click += new System.EventHandler(this.métodosAbiertosToolStripMenuItem_Click);
            // 
            // bisecciónToolStripMenuItem
            // 
            this.bisecciónToolStripMenuItem.Name = "bisecciónToolStripMenuItem";
            this.bisecciónToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.bisecciónToolStripMenuItem.Text = "Bisección";
            this.bisecciónToolStripMenuItem.Click += new System.EventHandler(this.bisecciónToolStripMenuItem_Click);
            // 
            // métodosCerradosToolStripMenuItem
            // 
            this.métodosCerradosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newtonRaphsonToolStripMenuItem,
            this.secanteToolStripMenuItem});
            this.métodosCerradosToolStripMenuItem.Name = "métodosCerradosToolStripMenuItem";
            this.métodosCerradosToolStripMenuItem.Size = new System.Drawing.Size(143, 24);
            this.métodosCerradosToolStripMenuItem.Text = "Métodos Cerrados";
            // 
            // newtonRaphsonToolStripMenuItem
            // 
            this.newtonRaphsonToolStripMenuItem.Name = "newtonRaphsonToolStripMenuItem";
            this.newtonRaphsonToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.newtonRaphsonToolStripMenuItem.Text = "Newton Raphson";
            this.newtonRaphsonToolStripMenuItem.Click += new System.EventHandler(this.newtonRaphsonToolStripMenuItem_Click);
            // 
            // secanteToolStripMenuItem
            // 
            this.secanteToolStripMenuItem.Name = "secanteToolStripMenuItem";
            this.secanteToolStripMenuItem.Size = new System.Drawing.Size(191, 24);
            this.secanteToolStripMenuItem.Text = "Secante";
            this.secanteToolStripMenuItem.Click += new System.EventHandler(this.secanteToolStripMenuItem_Click);
            // 
            // cudraturaDeGaussToolStripMenuItem
            // 
            this.cudraturaDeGaussToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reglaDelTrapecioMùltipleToolStripMenuItem,
            this.gaussLegendreToolStripMenuItem});
            this.cudraturaDeGaussToolStripMenuItem.Name = "cudraturaDeGaussToolStripMenuItem";
            this.cudraturaDeGaussToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.cudraturaDeGaussToolStripMenuItem.Text = "Cuadratura de Gauss";
            // 
            // reglaDelTrapecioMùltipleToolStripMenuItem
            // 
            this.reglaDelTrapecioMùltipleToolStripMenuItem.Name = "reglaDelTrapecioMùltipleToolStripMenuItem";
            this.reglaDelTrapecioMùltipleToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.reglaDelTrapecioMùltipleToolStripMenuItem.Text = "Trapecio Múltiple";
            this.reglaDelTrapecioMùltipleToolStripMenuItem.Click += new System.EventHandler(this.reglaDelTrapecioMùltipleToolStripMenuItem_Click);
            // 
            // gaussLegendreToolStripMenuItem
            // 
            this.gaussLegendreToolStripMenuItem.Name = "gaussLegendreToolStripMenuItem";
            this.gaussLegendreToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.gaussLegendreToolStripMenuItem.Text = "Gauss - Legendre";
            this.gaussLegendreToolStripMenuItem.Click += new System.EventHandler(this.gaussLegendreToolStripMenuItem_Click);
            // 
            // métodosDeRungeKuttaToolStripMenuItem
            // 
            this.métodosDeRungeKuttaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puntoMedioToolStripMenuItem,
            this.heunToolStripMenuItem,
            this.rKClásico4toOrdenToolStripMenuItem});
            this.métodosDeRungeKuttaToolStripMenuItem.Name = "métodosDeRungeKuttaToolStripMenuItem";
            this.métodosDeRungeKuttaToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.métodosDeRungeKuttaToolStripMenuItem.Text = "Métodos de Runge-Kutta";
            // 
            // puntoMedioToolStripMenuItem
            // 
            this.puntoMedioToolStripMenuItem.Name = "puntoMedioToolStripMenuItem";
            this.puntoMedioToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.puntoMedioToolStripMenuItem.Text = "Punto Medio";
            this.puntoMedioToolStripMenuItem.Click += new System.EventHandler(this.puntoMedioToolStripMenuItem_Click);
            // 
            // heunToolStripMenuItem
            // 
            this.heunToolStripMenuItem.Name = "heunToolStripMenuItem";
            this.heunToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.heunToolStripMenuItem.Text = "Heun";
            this.heunToolStripMenuItem.Click += new System.EventHandler(this.heunToolStripMenuItem_Click);
            // 
            // rKClásico4toOrdenToolStripMenuItem
            // 
            this.rKClásico4toOrdenToolStripMenuItem.Name = "rKClásico4toOrdenToolStripMenuItem";
            this.rKClásico4toOrdenToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.rKClásico4toOrdenToolStripMenuItem.Text = "RK Clásico de 4to Orden";
            this.rKClásico4toOrdenToolStripMenuItem.Click += new System.EventHandler(this.rKClásico4toOrdenToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 543);
            this.panel1.TabIndex = 5;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 571);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 610);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora Metodos Numéricos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem métodosAbiertosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bisecciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem métodosCerradosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newtonRaphsonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secanteToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem cudraturaDeGaussToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reglaDelTrapecioMùltipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussLegendreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem métodosDeRungeKuttaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoMedioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rKClásico4toOrdenToolStripMenuItem;
    }
}

