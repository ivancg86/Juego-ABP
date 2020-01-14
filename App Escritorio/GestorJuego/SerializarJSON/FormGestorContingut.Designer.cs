namespace SerializarJSON
{
    partial class FormGestorContingut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestorContingut));
            this.pictureBoxSiguiente = new System.Windows.Forms.PictureBox();
            this.textBoxContenido = new System.Windows.Forms.TextBox();
            this.pictureBoxAyuda = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinimizar = new System.Windows.Forms.PictureBox();
            this.pictureBoxCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBoxMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSiguiente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAyuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSiguiente
            // 
            this.pictureBoxSiguiente.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSiguiente.Location = new System.Drawing.Point(980, 527);
            this.pictureBoxSiguiente.Name = "pictureBoxSiguiente";
            this.pictureBoxSiguiente.Size = new System.Drawing.Size(145, 41);
            this.pictureBoxSiguiente.TabIndex = 0;
            this.pictureBoxSiguiente.TabStop = false;
            this.pictureBoxSiguiente.Click += new System.EventHandler(this.pictureBoxSiguiente_Click);
            // 
            // textBoxContenido
            // 
            this.textBoxContenido.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBoxContenido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxContenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContenido.Location = new System.Drawing.Point(99, 182);
            this.textBoxContenido.MaxLength = 500;
            this.textBoxContenido.Multiline = true;
            this.textBoxContenido.Name = "textBoxContenido";
            this.textBoxContenido.Size = new System.Drawing.Size(1026, 336);
            this.textBoxContenido.TabIndex = 1;
            // 
            // pictureBoxAyuda
            // 
            this.pictureBoxAyuda.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAyuda.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBoxAyuda.Location = new System.Drawing.Point(977, 12);
            this.pictureBoxAyuda.Name = "pictureBoxAyuda";
            this.pictureBoxAyuda.Size = new System.Drawing.Size(38, 40);
            this.pictureBoxAyuda.TabIndex = 2;
            this.pictureBoxAyuda.TabStop = false;
            this.pictureBoxAyuda.Click += new System.EventHandler(this.pictureBoxAyuda_Click);
            // 
            // pictureBoxMinimizar
            // 
            this.pictureBoxMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimizar.Location = new System.Drawing.Point(1053, 16);
            this.pictureBoxMinimizar.Name = "pictureBoxMinimizar";
            this.pictureBoxMinimizar.Size = new System.Drawing.Size(79, 34);
            this.pictureBoxMinimizar.TabIndex = 3;
            this.pictureBoxMinimizar.TabStop = false;
            // 
            // pictureBoxCerrar
            // 
            this.pictureBoxCerrar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCerrar.Location = new System.Drawing.Point(1143, 16);
            this.pictureBoxCerrar.Name = "pictureBoxCerrar";
            this.pictureBoxCerrar.Size = new System.Drawing.Size(79, 34);
            this.pictureBoxCerrar.TabIndex = 4;
            this.pictureBoxCerrar.TabStop = false;
            this.pictureBoxCerrar.Click += new System.EventHandler(this.pictureBoxCerrar_Click);
            // 
            // pictureBoxMenu
            // 
            this.pictureBoxMenu.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMenu.Location = new System.Drawing.Point(0, 9);
            this.pictureBoxMenu.Name = "pictureBoxMenu";
            this.pictureBoxMenu.Size = new System.Drawing.Size(125, 48);
            this.pictureBoxMenu.TabIndex = 5;
            this.pictureBoxMenu.TabStop = false;
            this.pictureBoxMenu.Click += new System.EventHandler(this.pictureBoxCerrar_Click);
            // 
            // FormGestorContingut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1230, 600);
            this.Controls.Add(this.pictureBoxMenu);
            this.Controls.Add(this.pictureBoxCerrar);
            this.Controls.Add(this.pictureBoxMinimizar);
            this.Controls.Add(this.pictureBoxAyuda);
            this.Controls.Add(this.textBoxContenido);
            this.Controls.Add(this.pictureBoxSiguiente);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1230, 600);
            this.MinimumSize = new System.Drawing.Size(1078, 600);
            this.Name = "FormGestorContingut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de contingut";
            this.Load += new System.EventHandler(this.FormGestorContingut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSiguiente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAyuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSiguiente;
        private System.Windows.Forms.TextBox textBoxContenido;
        private System.Windows.Forms.PictureBox pictureBoxAyuda;
        private System.Windows.Forms.PictureBox pictureBoxMinimizar;
        private System.Windows.Forms.PictureBox pictureBoxCerrar;
        private System.Windows.Forms.PictureBox pictureBoxMenu;
    }
}