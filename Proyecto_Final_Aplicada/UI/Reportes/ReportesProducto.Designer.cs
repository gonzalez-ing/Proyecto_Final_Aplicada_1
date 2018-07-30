namespace Proyecto_Final_Aplicada.UI.Reportes
{
    partial class ReportesProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReporteLogInViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReporteLogInViewer
            // 
            this.ReporteLogInViewer.ActiveViewIndex = -1;
            this.ReporteLogInViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReporteLogInViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReporteLogInViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteLogInViewer.Location = new System.Drawing.Point(0, 0);
            this.ReporteLogInViewer.Name = "ReporteLogInViewer";
            this.ReporteLogInViewer.Size = new System.Drawing.Size(639, 491);
            this.ReporteLogInViewer.TabIndex = 2;
            this.ReporteLogInViewer.Load += new System.EventHandler(this.ReporteLogInViewer_Load);
            // 
            // ReportesProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 491);
            this.Controls.Add(this.ReporteLogInViewer);
            this.Name = "ReportesProducto";
            this.Text = "ReportesProducto";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReporteLogInViewer;
    }
}