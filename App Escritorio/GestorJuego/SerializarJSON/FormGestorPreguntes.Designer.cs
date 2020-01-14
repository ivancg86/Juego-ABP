namespace SerializarJSON
{
    partial class FormGestorPreguntes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestorPreguntes));
            this.pictureBoxSortir = new System.Windows.Forms.PictureBox();
            this.textBoxPregunta = new System.Windows.Forms.TextBox();
            this.groupBoxContenido = new System.Windows.Forms.GroupBox();
            this.pictureBoxNetejar = new System.Windows.Forms.PictureBox();
            this.panelRespostaCorrecte = new System.Windows.Forms.Panel();
            this.labelD = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelA = new System.Windows.Forms.Label();
            this.radioButtonD = new System.Windows.Forms.RadioButton();
            this.radioButtonA = new System.Windows.Forms.RadioButton();
            this.radioButtonC = new System.Windows.Forms.RadioButton();
            this.radioButtonB = new System.Windows.Forms.RadioButton();
            this.pictureBoxEliminar = new System.Windows.Forms.PictureBox();
            this.pictureBoxAfegir = new System.Windows.Forms.PictureBox();
            this.pictureBoxGuardar = new System.Windows.Forms.PictureBox();
            this.groupBoxDificultat = new System.Windows.Forms.GroupBox();
            this.radioButtonDificil = new System.Windows.Forms.RadioButton();
            this.radioButtonFacil = new System.Windows.Forms.RadioButton();
            this.textBoxResposta4 = new System.Windows.Forms.TextBox();
            this.textBoxResposta3 = new System.Windows.Forms.TextBox();
            this.textBoxResposta2 = new System.Windows.Forms.TextBox();
            this.textBoxResposta1 = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.listBoxPreguntas = new System.Windows.Forms.ListBox();
            this.groupBoxListadoContenidos = new System.Windows.Forms.GroupBox();
            this.pictureBoxGestContingut = new System.Windows.Forms.PictureBox();
            this.pictureBoxMinimizar = new System.Windows.Forms.PictureBox();
            this.pictureBoxContinuar = new System.Windows.Forms.PictureBox();
            this.pictureBoxEliminarSel = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjuda = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSortir)).BeginInit();
            this.groupBoxContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNetejar)).BeginInit();
            this.panelRespostaCorrecte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAfegir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuardar)).BeginInit();
            this.groupBoxDificultat.SuspendLayout();
            this.groupBoxListadoContenidos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGestContingut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinuar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEliminarSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjuda)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxSortir
            // 
            this.pictureBoxSortir.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSortir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSortir.Location = new System.Drawing.Point(1142, 17);
            this.pictureBoxSortir.Name = "pictureBoxSortir";
            this.pictureBoxSortir.Size = new System.Drawing.Size(82, 33);
            this.pictureBoxSortir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSortir.TabIndex = 0;
            this.pictureBoxSortir.TabStop = false;
            this.pictureBoxSortir.Click += new System.EventHandler(this.pictureBoxSortir_Click);
            // 
            // textBoxPregunta
            // 
            this.textBoxPregunta.AutoCompleteCustomSource.AddRange(new string[] {
            "Quina va ser la primera missió de l´ESA?"});
            this.textBoxPregunta.BackColor = System.Drawing.Color.LightGray;
            this.textBoxPregunta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPregunta.Font = new System.Drawing.Font("Arial", 15.75F);
            this.textBoxPregunta.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxPregunta.Location = new System.Drawing.Point(21, 67);
            this.textBoxPregunta.MaxLength = 80;
            this.textBoxPregunta.Name = "textBoxPregunta";
            this.textBoxPregunta.Size = new System.Drawing.Size(540, 25);
            this.textBoxPregunta.TabIndex = 1;
            this.textBoxPregunta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxContenido
            // 
            this.groupBoxContenido.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxContenido.Controls.Add(this.pictureBoxNetejar);
            this.groupBoxContenido.Controls.Add(this.panelRespostaCorrecte);
            this.groupBoxContenido.Controls.Add(this.pictureBoxEliminar);
            this.groupBoxContenido.Controls.Add(this.pictureBoxAfegir);
            this.groupBoxContenido.Controls.Add(this.pictureBoxGuardar);
            this.groupBoxContenido.Controls.Add(this.groupBoxDificultat);
            this.groupBoxContenido.Controls.Add(this.textBoxResposta4);
            this.groupBoxContenido.Controls.Add(this.textBoxResposta3);
            this.groupBoxContenido.Controls.Add(this.textBoxResposta2);
            this.groupBoxContenido.Controls.Add(this.textBoxResposta1);
            this.groupBoxContenido.Controls.Add(this.textBoxPregunta);
            this.groupBoxContenido.Location = new System.Drawing.Point(79, 116);
            this.groupBoxContenido.Name = "groupBoxContenido";
            this.groupBoxContenido.Size = new System.Drawing.Size(641, 430);
            this.groupBoxContenido.TabIndex = 0;
            this.groupBoxContenido.TabStop = false;
            // 
            // pictureBoxNetejar
            // 
            this.pictureBoxNetejar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxNetejar.Location = new System.Drawing.Point(21, 371);
            this.pictureBoxNetejar.Name = "pictureBoxNetejar";
            this.pictureBoxNetejar.Size = new System.Drawing.Size(120, 41);
            this.pictureBoxNetejar.TabIndex = 15;
            this.pictureBoxNetejar.TabStop = false;
            this.pictureBoxNetejar.Click += new System.EventHandler(this.pictureBoxNetejar_Click);
            // 
            // panelRespostaCorrecte
            // 
            this.panelRespostaCorrecte.Controls.Add(this.labelD);
            this.panelRespostaCorrecte.Controls.Add(this.labelC);
            this.panelRespostaCorrecte.Controls.Add(this.labelB);
            this.panelRespostaCorrecte.Controls.Add(this.labelA);
            this.panelRespostaCorrecte.Controls.Add(this.radioButtonD);
            this.panelRespostaCorrecte.Controls.Add(this.radioButtonA);
            this.panelRespostaCorrecte.Controls.Add(this.radioButtonC);
            this.panelRespostaCorrecte.Controls.Add(this.radioButtonB);
            this.panelRespostaCorrecte.Location = new System.Drawing.Point(567, 134);
            this.panelRespostaCorrecte.Name = "panelRespostaCorrecte";
            this.panelRespostaCorrecte.Size = new System.Drawing.Size(70, 188);
            this.panelRespostaCorrecte.TabIndex = 12;
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelD.Location = new System.Drawing.Point(32, 157);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(21, 20);
            this.labelD.TabIndex = 19;
            this.labelD.Text = "D";
            this.labelD.Visible = false;
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelC.Location = new System.Drawing.Point(32, 108);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(20, 20);
            this.labelC.TabIndex = 18;
            this.labelC.Text = "C";
            this.labelC.Visible = false;
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelB.Location = new System.Drawing.Point(32, 59);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(20, 20);
            this.labelB.TabIndex = 17;
            this.labelB.Text = "B";
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.labelA.Location = new System.Drawing.Point(32, 10);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(20, 20);
            this.labelA.TabIndex = 16;
            this.labelA.Text = "A";
            // 
            // radioButtonD
            // 
            this.radioButtonD.AutoSize = true;
            this.radioButtonD.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.radioButtonD.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonD.Location = new System.Drawing.Point(18, 160);
            this.radioButtonD.Name = "radioButtonD";
            this.radioButtonD.Size = new System.Drawing.Size(14, 13);
            this.radioButtonD.TabIndex = 9;
            this.radioButtonD.TabStop = true;
            this.radioButtonD.UseVisualStyleBackColor = true;
            this.radioButtonD.Visible = false;
            // 
            // radioButtonA
            // 
            this.radioButtonA.AutoSize = true;
            this.radioButtonA.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.radioButtonA.Location = new System.Drawing.Point(18, 13);
            this.radioButtonA.Name = "radioButtonA";
            this.radioButtonA.Size = new System.Drawing.Size(14, 13);
            this.radioButtonA.TabIndex = 6;
            this.radioButtonA.TabStop = true;
            this.radioButtonA.UseVisualStyleBackColor = true;
            // 
            // radioButtonC
            // 
            this.radioButtonC.AutoSize = true;
            this.radioButtonC.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.radioButtonC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonC.Location = new System.Drawing.Point(18, 110);
            this.radioButtonC.Name = "radioButtonC";
            this.radioButtonC.Size = new System.Drawing.Size(14, 13);
            this.radioButtonC.TabIndex = 8;
            this.radioButtonC.TabStop = true;
            this.radioButtonC.UseVisualStyleBackColor = true;
            this.radioButtonC.Visible = false;
            // 
            // radioButtonB
            // 
            this.radioButtonB.AutoSize = true;
            this.radioButtonB.Font = new System.Drawing.Font("Malgun Gothic", 11.25F);
            this.radioButtonB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonB.Location = new System.Drawing.Point(18, 62);
            this.radioButtonB.Name = "radioButtonB";
            this.radioButtonB.Size = new System.Drawing.Size(14, 13);
            this.radioButtonB.TabIndex = 7;
            this.radioButtonB.TabStop = true;
            this.radioButtonB.UseVisualStyleBackColor = true;
            // 
            // pictureBoxEliminar
            // 
            this.pictureBoxEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEliminar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxEliminar.Location = new System.Drawing.Point(295, 108);
            this.pictureBoxEliminar.Name = "pictureBoxEliminar";
            this.pictureBoxEliminar.Size = new System.Drawing.Size(100, 34);
            this.pictureBoxEliminar.TabIndex = 13;
            this.pictureBoxEliminar.TabStop = false;
            this.pictureBoxEliminar.Click += new System.EventHandler(this.pictureBoxEliminar_Click);
            // 
            // pictureBoxAfegir
            // 
            this.pictureBoxAfegir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAfegir.Location = new System.Drawing.Point(187, 108);
            this.pictureBoxAfegir.Name = "pictureBoxAfegir";
            this.pictureBoxAfegir.Size = new System.Drawing.Size(100, 34);
            this.pictureBoxAfegir.TabIndex = 13;
            this.pictureBoxAfegir.TabStop = false;
            this.pictureBoxAfegir.Click += new System.EventHandler(this.pictureBoxAfegir_Click);
            // 
            // pictureBoxGuardar
            // 
            this.pictureBoxGuardar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxGuardar.Location = new System.Drawing.Point(410, 371);
            this.pictureBoxGuardar.Name = "pictureBoxGuardar";
            this.pictureBoxGuardar.Size = new System.Drawing.Size(120, 41);
            this.pictureBoxGuardar.TabIndex = 12;
            this.pictureBoxGuardar.TabStop = false;
            this.pictureBoxGuardar.Click += new System.EventHandler(this.pictureBoxGuardar_Click);
            // 
            // groupBoxDificultat
            // 
            this.groupBoxDificultat.Controls.Add(this.radioButtonDificil);
            this.groupBoxDificultat.Controls.Add(this.radioButtonFacil);
            this.groupBoxDificultat.Location = new System.Drawing.Point(373, 320);
            this.groupBoxDificultat.Name = "groupBoxDificultat";
            this.groupBoxDificultat.Size = new System.Drawing.Size(188, 43);
            this.groupBoxDificultat.TabIndex = 11;
            this.groupBoxDificultat.TabStop = false;
            // 
            // radioButtonDificil
            // 
            this.radioButtonDificil.AutoSize = true;
            this.radioButtonDificil.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonDificil.Location = new System.Drawing.Point(97, 17);
            this.radioButtonDificil.Name = "radioButtonDificil";
            this.radioButtonDificil.Size = new System.Drawing.Size(14, 13);
            this.radioButtonDificil.TabIndex = 0;
            this.radioButtonDificil.TabStop = true;
            this.radioButtonDificil.UseVisualStyleBackColor = true;
            // 
            // radioButtonFacil
            // 
            this.radioButtonFacil.AutoSize = true;
            this.radioButtonFacil.Location = new System.Drawing.Point(16, 17);
            this.radioButtonFacil.Name = "radioButtonFacil";
            this.radioButtonFacil.Size = new System.Drawing.Size(14, 13);
            this.radioButtonFacil.TabIndex = 0;
            this.radioButtonFacil.TabStop = true;
            this.radioButtonFacil.UseVisualStyleBackColor = true;
            // 
            // textBoxResposta4
            // 
            this.textBoxResposta4.BackColor = System.Drawing.Color.LightGray;
            this.textBoxResposta4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResposta4.Font = new System.Drawing.Font("Arial", 11.25F);
            this.textBoxResposta4.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxResposta4.Location = new System.Drawing.Point(21, 290);
            this.textBoxResposta4.MaxLength = 60;
            this.textBoxResposta4.Name = "textBoxResposta4";
            this.textBoxResposta4.Size = new System.Drawing.Size(540, 18);
            this.textBoxResposta4.TabIndex = 5;
            this.textBoxResposta4.Visible = false;
            // 
            // textBoxResposta3
            // 
            this.textBoxResposta3.BackColor = System.Drawing.Color.LightGray;
            this.textBoxResposta3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResposta3.Font = new System.Drawing.Font("Arial", 11.25F);
            this.textBoxResposta3.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxResposta3.Location = new System.Drawing.Point(21, 243);
            this.textBoxResposta3.MaxLength = 60;
            this.textBoxResposta3.Name = "textBoxResposta3";
            this.textBoxResposta3.Size = new System.Drawing.Size(540, 18);
            this.textBoxResposta3.TabIndex = 4;
            this.textBoxResposta3.Visible = false;
            // 
            // textBoxResposta2
            // 
            this.textBoxResposta2.BackColor = System.Drawing.Color.LightGray;
            this.textBoxResposta2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResposta2.Font = new System.Drawing.Font("Arial", 11.25F);
            this.textBoxResposta2.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxResposta2.Location = new System.Drawing.Point(21, 195);
            this.textBoxResposta2.MaxLength = 60;
            this.textBoxResposta2.Name = "textBoxResposta2";
            this.textBoxResposta2.Size = new System.Drawing.Size(540, 18);
            this.textBoxResposta2.TabIndex = 3;
            // 
            // textBoxResposta1
            // 
            this.textBoxResposta1.BackColor = System.Drawing.Color.LightGray;
            this.textBoxResposta1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxResposta1.Font = new System.Drawing.Font("Arial", 11.25F);
            this.textBoxResposta1.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxResposta1.Location = new System.Drawing.Point(21, 146);
            this.textBoxResposta1.MaxLength = 60;
            this.textBoxResposta1.Name = "textBoxResposta1";
            this.textBoxResposta1.Size = new System.Drawing.Size(540, 18);
            this.textBoxResposta1.TabIndex = 2;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "json";
            this.saveFileDialog1.FileName = "Contingut";
            // 
            // listBoxPreguntas
            // 
            this.listBoxPreguntas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.listBoxPreguntas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxPreguntas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxPreguntas.Font = new System.Drawing.Font("Arial", 15.75F);
            this.listBoxPreguntas.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.listBoxPreguntas.FormattingEnabled = true;
            this.listBoxPreguntas.ItemHeight = 24;
            this.listBoxPreguntas.Location = new System.Drawing.Point(3, 14);
            this.listBoxPreguntas.Margin = new System.Windows.Forms.Padding(0);
            this.listBoxPreguntas.Name = "listBoxPreguntas";
            this.listBoxPreguntas.Size = new System.Drawing.Size(420, 412);
            this.listBoxPreguntas.TabIndex = 11;
            this.listBoxPreguntas.SelectedIndexChanged += new System.EventHandler(this.listBoxContenidos_SelectedIndexChanged);
            // 
            // groupBoxListadoContenidos
            // 
            this.groupBoxListadoContenidos.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxListadoContenidos.Controls.Add(this.listBoxPreguntas);
            this.groupBoxListadoContenidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.groupBoxListadoContenidos.Location = new System.Drawing.Point(719, 117);
            this.groupBoxListadoContenidos.Margin = new System.Windows.Forms.Padding(0);
            this.groupBoxListadoContenidos.Name = "groupBoxListadoContenidos";
            this.groupBoxListadoContenidos.Size = new System.Drawing.Size(426, 429);
            this.groupBoxListadoContenidos.TabIndex = 12;
            this.groupBoxListadoContenidos.TabStop = false;
            // 
            // pictureBoxGestContingut
            // 
            this.pictureBoxGestContingut.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxGestContingut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxGestContingut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxGestContingut.Location = new System.Drawing.Point(-16, 6);
            this.pictureBoxGestContingut.Name = "pictureBoxGestContingut";
            this.pictureBoxGestContingut.Size = new System.Drawing.Size(156, 53);
            this.pictureBoxGestContingut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxGestContingut.TabIndex = 0;
            this.pictureBoxGestContingut.TabStop = false;
            this.pictureBoxGestContingut.Click += new System.EventHandler(this.pictureBoxGestContingut_Click);
            // 
            // pictureBoxMinimizar
            // 
            this.pictureBoxMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxMinimizar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBoxMinimizar.Location = new System.Drawing.Point(1051, 17);
            this.pictureBoxMinimizar.Name = "pictureBoxMinimizar";
            this.pictureBoxMinimizar.Size = new System.Drawing.Size(82, 33);
            this.pictureBoxMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMinimizar.TabIndex = 0;
            this.pictureBoxMinimizar.TabStop = false;
            this.pictureBoxMinimizar.Click += new System.EventHandler(this.pictureBoxMinimizar_Click);
            // 
            // pictureBoxContinuar
            // 
            this.pictureBoxContinuar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxContinuar.Location = new System.Drawing.Point(1002, 548);
            this.pictureBoxContinuar.Name = "pictureBoxContinuar";
            this.pictureBoxContinuar.Size = new System.Drawing.Size(143, 42);
            this.pictureBoxContinuar.TabIndex = 13;
            this.pictureBoxContinuar.TabStop = false;
            this.pictureBoxContinuar.Click += new System.EventHandler(this.pictureBoxContinuar_Click);
            // 
            // pictureBoxEliminarSel
            // 
            this.pictureBoxEliminarSel.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxEliminarSel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxEliminarSel.Location = new System.Drawing.Point(726, 548);
            this.pictureBoxEliminarSel.Name = "pictureBoxEliminarSel";
            this.pictureBoxEliminarSel.Size = new System.Drawing.Size(191, 41);
            this.pictureBoxEliminarSel.TabIndex = 14;
            this.pictureBoxEliminarSel.TabStop = false;
            this.pictureBoxEliminarSel.Click += new System.EventHandler(this.pictureBoxEliminarSel_Click);
            // 
            // pictureBoxAjuda
            // 
            this.pictureBoxAjuda.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAjuda.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureBoxAjuda.Location = new System.Drawing.Point(982, 12);
            this.pictureBoxAjuda.Name = "pictureBoxAjuda";
            this.pictureBoxAjuda.Size = new System.Drawing.Size(40, 42);
            this.pictureBoxAjuda.TabIndex = 15;
            this.pictureBoxAjuda.TabStop = false;
            this.pictureBoxAjuda.Click += new System.EventHandler(this.pictureBoxAjuda_Click);
            // 
            // FormGestorPreguntes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1230, 600);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxAjuda);
            this.Controls.Add(this.pictureBoxEliminarSel);
            this.Controls.Add(this.pictureBoxContinuar);
            this.Controls.Add(this.pictureBoxGestContingut);
            this.Controls.Add(this.pictureBoxMinimizar);
            this.Controls.Add(this.pictureBoxSortir);
            this.Controls.Add(this.groupBoxContenido);
            this.Controls.Add(this.groupBoxListadoContenidos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1230, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1230, 600);
            this.Name = "FormGestorPreguntes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de preguntes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSortir)).EndInit();
            this.groupBoxContenido.ResumeLayout(false);
            this.groupBoxContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNetejar)).EndInit();
            this.panelRespostaCorrecte.ResumeLayout(false);
            this.panelRespostaCorrecte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAfegir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGuardar)).EndInit();
            this.groupBoxDificultat.ResumeLayout(false);
            this.groupBoxDificultat.PerformLayout();
            this.groupBoxListadoContenidos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGestContingut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinuar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEliminarSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjuda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxSortir;
        private System.Windows.Forms.TextBox textBoxPregunta;
        private System.Windows.Forms.GroupBox groupBoxContenido;
        private System.Windows.Forms.TextBox textBoxResposta1;
        private System.Windows.Forms.TextBox textBoxResposta4;
        private System.Windows.Forms.TextBox textBoxResposta3;
        private System.Windows.Forms.TextBox textBoxResposta2;
        private System.Windows.Forms.RadioButton radioButtonA;
        private System.Windows.Forms.RadioButton radioButtonD;
        private System.Windows.Forms.RadioButton radioButtonC;
        private System.Windows.Forms.RadioButton radioButtonB;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListBox listBoxPreguntas;
        private System.Windows.Forms.GroupBox groupBoxListadoContenidos;
        private System.Windows.Forms.GroupBox groupBoxDificultat;
        private System.Windows.Forms.RadioButton radioButtonDificil;
        private System.Windows.Forms.RadioButton radioButtonFacil;
        private System.Windows.Forms.PictureBox pictureBoxGestContingut;
        private System.Windows.Forms.PictureBox pictureBoxMinimizar;
        private System.Windows.Forms.PictureBox pictureBoxContinuar;
        private System.Windows.Forms.PictureBox pictureBoxGuardar;
        private System.Windows.Forms.PictureBox pictureBoxEliminarSel;
        private System.Windows.Forms.PictureBox pictureBoxEliminar;
        private System.Windows.Forms.PictureBox pictureBoxAfegir;
        private System.Windows.Forms.Panel panelRespostaCorrecte;
        private System.Windows.Forms.PictureBox pictureBoxNetejar;
        private System.Windows.Forms.PictureBox pictureBoxAjuda;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelA;
    }
}

