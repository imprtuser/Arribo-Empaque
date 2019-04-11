namespace ArriboEmpaque.CapturaArriboEmpaque
{
    partial class frmCapturaArriboEmpaque
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puertoBasculaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbControl = new System.Windows.Forms.TabControl();
            this.tabCapturaArriboEmpaque = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtIDCaptura = new System.Windows.Forms.TextBox();
            this.lblIDCaptura = new System.Windows.Forms.Label();
            this.lblIdHeader = new System.Windows.Forms.Label();
            this.dgvAddFolios = new System.Windows.Forms.DataGridView();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblLibs = new System.Windows.Forms.Label();
            this.pgInfoFolio = new System.Windows.Forms.ProgressBar();
            this.lblLoadingInfo = new System.Windows.Forms.Label();
            this.btnHasConnection = new System.Windows.Forms.PictureBox();
            this.btnLangCAE = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtGrossLibs = new System.Windows.Forms.TextBox();
            this.txtBoxes = new System.Windows.Forms.TextBox();
            this.lblBoxes = new System.Windows.Forms.Label();
            this.chEnableWeigth = new System.Windows.Forms.CheckBox();
            this.cbTareBox = new System.Windows.Forms.ComboBox();
            this.lblTareBox = new System.Windows.Forms.Label();
            this.cbTareTarima = new System.Windows.Forms.ComboBox();
            this.lblTareTarima = new System.Windows.Forms.Label();
            this.lblGP = new System.Windows.Forms.Label();
            this.lblQuality = new System.Windows.Forms.Label();
            this.lblGreenhouse = new System.Windows.Forms.Label();
            this.lblPlant = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblFolioName = new System.Windows.Forms.Label();
            this.lblCapArribo = new System.Windows.Forms.Label();
            this.lblFolio = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.tabConsultaArriboEmpaque = new System.Windows.Forms.TabPage();
            this.tlpConsult = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIDConsulta = new System.Windows.Forms.TextBox();
            this.lblIDConsulta = new System.Windows.Forms.Label();
            this.txtFolioFilter = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.dtpDateIni = new System.Windows.Forms.DateTimePicker();
            this.lblDateIni = new System.Windows.Forms.Label();
            this.lblFolioFilter = new System.Windows.Forms.Label();
            this.cbPlants = new System.Windows.Forms.ComboBox();
            this.lblPlantFilter = new System.Windows.Forms.Label();
            this.dgvFolios = new System.Windows.Forms.DataGridView();
            this.backgroundWorkerFindFolio = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSaveFolio = new System.ComponentModel.BackgroundWorker();
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerGetFolios = new System.ComponentModel.BackgroundWorker();
            this.lblLoadingFolios = new System.Windows.Forms.Label();
            this.pbFolios = new System.Windows.Forms.ProgressBar();
            this.lblReady = new System.Windows.Forms.Label();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.backgroundWorkerGetFoliosByID = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.tbControl.SuspendLayout();
            this.tabCapturaArriboEmpaque.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddFolios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHasConnection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLangCAE)).BeginInit();
            this.tabConsultaArriboEmpaque.SuspendLayout();
            this.tlpConsult.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolios)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.configuracionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1270, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puertoBasculaToolStripMenuItem});
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // puertoBasculaToolStripMenuItem
            // 
            this.puertoBasculaToolStripMenuItem.Name = "puertoBasculaToolStripMenuItem";
            this.puertoBasculaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.puertoBasculaToolStripMenuItem.Text = "Puerto Bascula";
            this.puertoBasculaToolStripMenuItem.Click += new System.EventHandler(this.puertoBasculaToolStripMenuItem_Click);
            // 
            // tbControl
            // 
            this.tbControl.Controls.Add(this.tabCapturaArriboEmpaque);
            this.tbControl.Controls.Add(this.tabConsultaArriboEmpaque);
            this.tbControl.HotTrack = true;
            this.tbControl.Location = new System.Drawing.Point(0, 27);
            this.tbControl.Name = "tbControl";
            this.tbControl.SelectedIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(1270, 542);
            this.tbControl.TabIndex = 1;
            this.tbControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tbControl_Selecting);
            // 
            // tabCapturaArriboEmpaque
            // 
            this.tabCapturaArriboEmpaque.BackgroundImage = global::ArriboEmpaque.Properties.Resources.background_planning;
            this.tabCapturaArriboEmpaque.Controls.Add(this.panel1);
            this.tabCapturaArriboEmpaque.Location = new System.Drawing.Point(4, 22);
            this.tabCapturaArriboEmpaque.Name = "tabCapturaArriboEmpaque";
            this.tabCapturaArriboEmpaque.Padding = new System.Windows.Forms.Padding(3);
            this.tabCapturaArriboEmpaque.Size = new System.Drawing.Size(1262, 516);
            this.tabCapturaArriboEmpaque.TabIndex = 0;
            this.tabCapturaArriboEmpaque.Text = "Captura de Arribo Empaque";
            this.tabCapturaArriboEmpaque.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.txtIDCaptura);
            this.panel1.Controls.Add(this.lblIDCaptura);
            this.panel1.Controls.Add(this.lblIdHeader);
            this.panel1.Controls.Add(this.dgvAddFolios);
            this.panel1.Controls.Add(this.lblVersion);
            this.panel1.Controls.Add(this.lblLibs);
            this.panel1.Controls.Add(this.pgInfoFolio);
            this.panel1.Controls.Add(this.lblLoadingInfo);
            this.panel1.Controls.Add(this.btnHasConnection);
            this.panel1.Controls.Add(this.btnLangCAE);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.txtGrossLibs);
            this.panel1.Controls.Add(this.txtBoxes);
            this.panel1.Controls.Add(this.lblBoxes);
            this.panel1.Controls.Add(this.chEnableWeigth);
            this.panel1.Controls.Add(this.cbTareBox);
            this.panel1.Controls.Add(this.lblTareBox);
            this.panel1.Controls.Add(this.cbTareTarima);
            this.panel1.Controls.Add(this.lblTareTarima);
            this.panel1.Controls.Add(this.lblGP);
            this.panel1.Controls.Add(this.lblQuality);
            this.panel1.Controls.Add(this.lblGreenhouse);
            this.panel1.Controls.Add(this.lblPlant);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblFolioName);
            this.panel1.Controls.Add(this.lblCapArribo);
            this.panel1.Controls.Add(this.lblFolio);
            this.panel1.Controls.Add(this.txtFolio);
            this.panel1.Location = new System.Drawing.Point(59, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1144, 466);
            this.panel1.TabIndex = 0;
            // 
            // txtIDCaptura
            // 
            this.txtIDCaptura.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCaptura.Location = new System.Drawing.Point(287, 89);
            this.txtIDCaptura.Margin = new System.Windows.Forms.Padding(2);
            this.txtIDCaptura.Name = "txtIDCaptura";
            this.txtIDCaptura.Size = new System.Drawing.Size(47, 30);
            this.txtIDCaptura.TabIndex = 151;
            this.txtIDCaptura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDCaptura_KeyPress);
            this.txtIDCaptura.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtIDCaptura_PreviewKeyDown);
            // 
            // lblIDCaptura
            // 
            this.lblIDCaptura.AutoSize = true;
            this.lblIDCaptura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDCaptura.Location = new System.Drawing.Point(283, 67);
            this.lblIDCaptura.Name = "lblIDCaptura";
            this.lblIDCaptura.Size = new System.Drawing.Size(28, 20);
            this.lblIDCaptura.TabIndex = 150;
            this.lblIDCaptura.Text = "ID";
            // 
            // lblIdHeader
            // 
            this.lblIdHeader.AutoSize = true;
            this.lblIdHeader.Location = new System.Drawing.Point(263, 102);
            this.lblIdHeader.Name = "lblIdHeader";
            this.lblIdHeader.Size = new System.Drawing.Size(0, 13);
            this.lblIdHeader.TabIndex = 149;
            this.lblIdHeader.Visible = false;
            // 
            // dgvAddFolios
            // 
            this.dgvAddFolios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddFolios.Location = new System.Drawing.Point(19, 125);
            this.dgvAddFolios.Name = "dgvAddFolios";
            this.dgvAddFolios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAddFolios.Size = new System.Drawing.Size(1106, 207);
            this.dgvAddFolios.TabIndex = 148;
            this.dgvAddFolios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAddFolios_CellClick);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(1002, 95);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 20);
            this.lblVersion.TabIndex = 147;
            this.lblVersion.Text = "v4.0";
            // 
            // lblLibs
            // 
            this.lblLibs.AutoSize = true;
            this.lblLibs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibs.Location = new System.Drawing.Point(169, 347);
            this.lblLibs.Name = "lblLibs";
            this.lblLibs.Size = new System.Drawing.Size(108, 20);
            this.lblLibs.TabIndex = 146;
            this.lblLibs.Text = "Libras netas";
            // 
            // pgInfoFolio
            // 
            this.pgInfoFolio.Location = new System.Drawing.Point(21, 417);
            this.pgInfoFolio.Name = "pgInfoFolio";
            this.pgInfoFolio.Size = new System.Drawing.Size(714, 21);
            this.pgInfoFolio.TabIndex = 144;
            this.pgInfoFolio.Visible = false;
            // 
            // lblLoadingInfo
            // 
            this.lblLoadingInfo.AutoSize = true;
            this.lblLoadingInfo.Location = new System.Drawing.Point(18, 441);
            this.lblLoadingInfo.Name = "lblLoadingInfo";
            this.lblLoadingInfo.Size = new System.Drawing.Size(119, 13);
            this.lblLoadingInfo.TabIndex = 143;
            this.lblLoadingInfo.Text = "Cargando información...";
            this.lblLoadingInfo.Visible = false;
            // 
            // btnHasConnection
            // 
            this.btnHasConnection.Image = global::ArriboEmpaque.Properties.Resources.green;
            this.btnHasConnection.Location = new System.Drawing.Point(1104, 14);
            this.btnHasConnection.Margin = new System.Windows.Forms.Padding(2);
            this.btnHasConnection.Name = "btnHasConnection";
            this.btnHasConnection.Size = new System.Drawing.Size(18, 17);
            this.btnHasConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHasConnection.TabIndex = 142;
            this.btnHasConnection.TabStop = false;
            // 
            // btnLangCAE
            // 
            this.btnLangCAE.BackColor = System.Drawing.Color.Transparent;
            this.btnLangCAE.ErrorImage = global::ArriboEmpaque.Properties.Resources.spanish_flag;
            this.btnLangCAE.Image = global::ArriboEmpaque.Properties.Resources.spanish_flag;
            this.btnLangCAE.Location = new System.Drawing.Point(1031, 14);
            this.btnLangCAE.Margin = new System.Windows.Forms.Padding(2);
            this.btnLangCAE.Name = "btnLangCAE";
            this.btnLangCAE.Size = new System.Drawing.Size(48, 45);
            this.btnLangCAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLangCAE.TabIndex = 141;
            this.btnLangCAE.TabStop = false;
            this.btnLangCAE.Click += new System.EventHandler(this.btnLangCAE_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Location = new System.Drawing.Point(1001, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 39);
            this.btnSave.TabIndex = 140;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(837, 415);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 39);
            this.btnCancel.TabIndex = 139;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtGrossLibs
            // 
            this.txtGrossLibs.Enabled = false;
            this.txtGrossLibs.Location = new System.Drawing.Point(173, 368);
            this.txtGrossLibs.Name = "txtGrossLibs";
            this.txtGrossLibs.Size = new System.Drawing.Size(104, 20);
            this.txtGrossLibs.TabIndex = 138;
            // 
            // txtBoxes
            // 
            this.txtBoxes.Location = new System.Drawing.Point(21, 368);
            this.txtBoxes.Name = "txtBoxes";
            this.txtBoxes.Size = new System.Drawing.Size(108, 20);
            this.txtBoxes.TabIndex = 136;
            // 
            // lblBoxes
            // 
            this.lblBoxes.AutoSize = true;
            this.lblBoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxes.Location = new System.Drawing.Point(16, 347);
            this.lblBoxes.Name = "lblBoxes";
            this.lblBoxes.Size = new System.Drawing.Size(54, 20);
            this.lblBoxes.TabIndex = 135;
            this.lblBoxes.Text = "Cajas";
            // 
            // chEnableWeigth
            // 
            this.chEnableWeigth.AutoSize = true;
            this.chEnableWeigth.Cursor = System.Windows.Forms.Cursors.Default;
            this.chEnableWeigth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chEnableWeigth.Location = new System.Drawing.Point(868, 364);
            this.chEnableWeigth.Name = "chEnableWeigth";
            this.chEnableWeigth.Size = new System.Drawing.Size(140, 24);
            this.chEnableWeigth.TabIndex = 134;
            this.chEnableWeigth.Text = "Habilitar Peso";
            this.chEnableWeigth.UseVisualStyleBackColor = true;
            this.chEnableWeigth.CheckedChanged += new System.EventHandler(this.chEnableWeigth_CheckedChanged);
            // 
            // cbTareBox
            // 
            this.cbTareBox.FormattingEnabled = true;
            this.cbTareBox.Location = new System.Drawing.Point(600, 369);
            this.cbTareBox.Name = "cbTareBox";
            this.cbTareBox.Size = new System.Drawing.Size(228, 21);
            this.cbTareBox.TabIndex = 133;
            // 
            // lblTareBox
            // 
            this.lblTareBox.AutoSize = true;
            this.lblTareBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTareBox.Location = new System.Drawing.Point(596, 347);
            this.lblTareBox.Name = "lblTareBox";
            this.lblTareBox.Size = new System.Drawing.Size(86, 20);
            this.lblTareBox.TabIndex = 132;
            this.lblTareBox.Text = "Tara Caja";
            // 
            // cbTareTarima
            // 
            this.cbTareTarima.FormattingEnabled = true;
            this.cbTareTarima.Location = new System.Drawing.Point(328, 368);
            this.cbTareTarima.Name = "cbTareTarima";
            this.cbTareTarima.Size = new System.Drawing.Size(227, 21);
            this.cbTareTarima.TabIndex = 131;
            // 
            // lblTareTarima
            // 
            this.lblTareTarima.AutoSize = true;
            this.lblTareTarima.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTareTarima.Location = new System.Drawing.Point(324, 347);
            this.lblTareTarima.Name = "lblTareTarima";
            this.lblTareTarima.Size = new System.Drawing.Size(104, 20);
            this.lblTareTarima.TabIndex = 130;
            this.lblTareTarima.Text = "Tara Tarima";
            // 
            // lblGP
            // 
            this.lblGP.AutoSize = true;
            this.lblGP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGP.Location = new System.Drawing.Point(116, 274);
            this.lblGP.Name = "lblGP";
            this.lblGP.Size = new System.Drawing.Size(0, 20);
            this.lblGP.TabIndex = 129;
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuality.Location = new System.Drawing.Point(116, 246);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(0, 20);
            this.lblQuality.TabIndex = 128;
            // 
            // lblGreenhouse
            // 
            this.lblGreenhouse.AutoSize = true;
            this.lblGreenhouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreenhouse.Location = new System.Drawing.Point(116, 217);
            this.lblGreenhouse.Name = "lblGreenhouse";
            this.lblGreenhouse.Size = new System.Drawing.Size(0, 20);
            this.lblGreenhouse.TabIndex = 127;
            // 
            // lblPlant
            // 
            this.lblPlant.AutoSize = true;
            this.lblPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlant.Location = new System.Drawing.Point(115, 187);
            this.lblPlant.Name = "lblPlant";
            this.lblPlant.Size = new System.Drawing.Size(0, 20);
            this.lblPlant.TabIndex = 126;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(116, 155);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 20);
            this.lblDate.TabIndex = 125;
            // 
            // lblFolioName
            // 
            this.lblFolioName.AutoSize = true;
            this.lblFolioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioName.Location = new System.Drawing.Point(117, 125);
            this.lblFolioName.Name = "lblFolioName";
            this.lblFolioName.Size = new System.Drawing.Size(0, 20);
            this.lblFolioName.TabIndex = 124;
            // 
            // lblCapArribo
            // 
            this.lblCapArribo.AutoSize = true;
            this.lblCapArribo.BackColor = System.Drawing.Color.Transparent;
            this.lblCapArribo.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapArribo.Location = new System.Drawing.Point(488, 14);
            this.lblCapArribo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapArribo.Name = "lblCapArribo";
            this.lblCapArribo.Size = new System.Drawing.Size(154, 22);
            this.lblCapArribo.TabIndex = 119;
            this.lblCapArribo.Text = "Arribo Empaque";
            // 
            // lblFolio
            // 
            this.lblFolio.AutoSize = true;
            this.lblFolio.BackColor = System.Drawing.Color.Transparent;
            this.lblFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblFolio.Location = new System.Drawing.Point(20, 67);
            this.lblFolio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFolio.Name = "lblFolio";
            this.lblFolio.Size = new System.Drawing.Size(48, 20);
            this.lblFolio.TabIndex = 120;
            this.lblFolio.Text = "Folio";
            // 
            // txtFolio
            // 
            this.txtFolio.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.Location = new System.Drawing.Point(22, 89);
            this.txtFolio.Margin = new System.Windows.Forms.Padding(2);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(227, 30);
            this.txtFolio.TabIndex = 121;
            this.txtFolio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolio_KeyPress);
            this.txtFolio.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtFolio_PreviewKeyDown);
            // 
            // tabConsultaArriboEmpaque
            // 
            this.tabConsultaArriboEmpaque.BackgroundImage = global::ArriboEmpaque.Properties.Resources.background_planning;
            this.tabConsultaArriboEmpaque.Controls.Add(this.tlpConsult);
            this.tabConsultaArriboEmpaque.Location = new System.Drawing.Point(4, 22);
            this.tabConsultaArriboEmpaque.Name = "tabConsultaArriboEmpaque";
            this.tabConsultaArriboEmpaque.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsultaArriboEmpaque.Size = new System.Drawing.Size(1262, 516);
            this.tabConsultaArriboEmpaque.TabIndex = 1;
            this.tabConsultaArriboEmpaque.Text = "Consulta de Arribo Empaque";
            this.tabConsultaArriboEmpaque.UseVisualStyleBackColor = true;
            // 
            // tlpConsult
            // 
            this.tlpConsult.BackColor = System.Drawing.SystemColors.Control;
            this.tlpConsult.ColumnCount = 1;
            this.tlpConsult.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpConsult.Controls.Add(this.groupBox1, 0, 0);
            this.tlpConsult.Controls.Add(this.dgvFolios, 0, 1);
            this.tlpConsult.Location = new System.Drawing.Point(-4, 3);
            this.tlpConsult.Name = "tlpConsult";
            this.tlpConsult.RowCount = 2;
            this.tlpConsult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.03131F));
            this.tlpConsult.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.96868F));
            this.tlpConsult.Size = new System.Drawing.Size(1266, 517);
            this.tlpConsult.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.txtIDConsulta);
            this.groupBox1.Controls.Add(this.lblIDConsulta);
            this.groupBox1.Controls.Add(this.txtFolioFilter);
            this.groupBox1.Controls.Add(this.btnFilter);
            this.groupBox1.Controls.Add(this.dtpDateFin);
            this.groupBox1.Controls.Add(this.lblDateFin);
            this.groupBox1.Controls.Add(this.dtpDateIni);
            this.groupBox1.Controls.Add(this.lblDateIni);
            this.groupBox1.Controls.Add(this.lblFolioFilter);
            this.groupBox1.Controls.Add(this.cbPlants);
            this.groupBox1.Controls.Add(this.lblPlantFilter);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1260, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // txtIDConsulta
            // 
            this.txtIDConsulta.Location = new System.Drawing.Point(43, 27);
            this.txtIDConsulta.Name = "txtIDConsulta";
            this.txtIDConsulta.Size = new System.Drawing.Size(57, 20);
            this.txtIDConsulta.TabIndex = 124;
            // 
            // lblIDConsulta
            // 
            this.lblIDConsulta.AutoSize = true;
            this.lblIDConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDConsulta.Location = new System.Drawing.Point(16, 30);
            this.lblIDConsulta.Name = "lblIDConsulta";
            this.lblIDConsulta.Size = new System.Drawing.Size(20, 13);
            this.lblIDConsulta.TabIndex = 123;
            this.lblIDConsulta.Text = "ID";
            // 
            // txtFolioFilter
            // 
            this.txtFolioFilter.Location = new System.Drawing.Point(149, 27);
            this.txtFolioFilter.Name = "txtFolioFilter";
            this.txtFolioFilter.Size = new System.Drawing.Size(150, 20);
            this.txtFolioFilter.TabIndex = 122;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(1057, 17);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(197, 36);
            this.btnFilter.TabIndex = 121;
            this.btnFilter.Text = "Filtrar";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Location = new System.Drawing.Point(853, 26);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(195, 20);
            this.dtpDateFin.TabIndex = 120;
            // 
            // lblDateFin
            // 
            this.lblDateFin.AutoSize = true;
            this.lblDateFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFin.Location = new System.Drawing.Point(791, 30);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(60, 13);
            this.lblDateFin.TabIndex = 119;
            this.lblDateFin.Text = "Fecha fin";
            // 
            // dtpDateIni
            // 
            this.dtpDateIni.Location = new System.Drawing.Point(587, 26);
            this.dtpDateIni.Name = "dtpDateIni";
            this.dtpDateIni.Size = new System.Drawing.Size(197, 20);
            this.dtpDateIni.TabIndex = 118;
            // 
            // lblDateIni
            // 
            this.lblDateIni.AutoSize = true;
            this.lblDateIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateIni.Location = new System.Drawing.Point(510, 30);
            this.lblDateIni.Name = "lblDateIni";
            this.lblDateIni.Size = new System.Drawing.Size(76, 13);
            this.lblDateIni.TabIndex = 4;
            this.lblDateIni.Text = "Fecha inicio";
            // 
            // lblFolioFilter
            // 
            this.lblFolioFilter.AutoSize = true;
            this.lblFolioFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioFilter.Location = new System.Drawing.Point(114, 30);
            this.lblFolioFilter.Name = "lblFolioFilter";
            this.lblFolioFilter.Size = new System.Drawing.Size(34, 13);
            this.lblFolioFilter.TabIndex = 2;
            this.lblFolioFilter.Text = "Folio";
            // 
            // cbPlants
            // 
            this.cbPlants.FormattingEnabled = true;
            this.cbPlants.Location = new System.Drawing.Point(357, 26);
            this.cbPlants.Name = "cbPlants";
            this.cbPlants.Size = new System.Drawing.Size(149, 21);
            this.cbPlants.TabIndex = 1;
            // 
            // lblPlantFilter
            // 
            this.lblPlantFilter.AutoSize = true;
            this.lblPlantFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantFilter.Location = new System.Drawing.Point(313, 30);
            this.lblPlantFilter.Name = "lblPlantFilter";
            this.lblPlantFilter.Size = new System.Drawing.Size(43, 13);
            this.lblPlantFilter.TabIndex = 0;
            this.lblPlantFilter.Text = "Planta";
            // 
            // dgvFolios
            // 
            this.dgvFolios.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvFolios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFolios.Location = new System.Drawing.Point(3, 80);
            this.dgvFolios.Name = "dgvFolios";
            this.dgvFolios.Size = new System.Drawing.Size(1260, 433);
            this.dgvFolios.TabIndex = 1;
            // 
            // backgroundWorkerFindFolio
            // 
            this.backgroundWorkerFindFolio.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerFindFolio_DoWork);
            // 
            // backgroundWorkerSaveFolio
            // 
            this.backgroundWorkerSaveFolio.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSaveFolio_DoWork);
            // 
            // timerPing
            // 
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick);
            // 
            // backgroundWorkerGetFolios
            // 
            this.backgroundWorkerGetFolios.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGetFolios_DoWork);
            // 
            // lblLoadingFolios
            // 
            this.lblLoadingFolios.AutoSize = true;
            this.lblLoadingFolios.Location = new System.Drawing.Point(1, 580);
            this.lblLoadingFolios.Name = "lblLoadingFolios";
            this.lblLoadingFolios.Size = new System.Drawing.Size(120, 13);
            this.lblLoadingFolios.TabIndex = 2;
            this.lblLoadingFolios.Text = "Cargando Información...";
            this.lblLoadingFolios.Visible = false;
            // 
            // pbFolios
            // 
            this.pbFolios.Location = new System.Drawing.Point(122, 577);
            this.pbFolios.Name = "pbFolios";
            this.pbFolios.Size = new System.Drawing.Size(477, 18);
            this.pbFolios.TabIndex = 3;
            this.pbFolios.Visible = false;
            // 
            // lblReady
            // 
            this.lblReady.AutoSize = true;
            this.lblReady.Location = new System.Drawing.Point(1203, 582);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(32, 13);
            this.lblReady.TabIndex = 4;
            this.lblReady.Text = "Listo.";
            this.lblReady.Visible = false;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Location = new System.Drawing.Point(936, 582);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(88, 13);
            this.lblTotalRecords.TabIndex = 5;
            this.lblTotalRecords.Text = "Registros totales:";
            this.lblTotalRecords.Visible = false;
            // 
            // backgroundWorkerGetFoliosByID
            // 
            this.backgroundWorkerGetFoliosByID.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGetFoliosByID_DoWork);
            // 
            // frmCapturaArriboEmpaque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 602);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.lblReady);
            this.Controls.Add(this.pbFolios);
            this.Controls.Add(this.lblLoadingFolios);
            this.Controls.Add(this.tbControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCapturaArriboEmpaque";
            this.Text = "Arribo Empaque";
            this.Load += new System.EventHandler(this.frmCapturaArriboEmpaque_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tbControl.ResumeLayout(false);
            this.tabCapturaArriboEmpaque.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddFolios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHasConnection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLangCAE)).EndInit();
            this.tabConsultaArriboEmpaque.ResumeLayout(false);
            this.tlpConsult.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFolios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.TabControl tbControl;
        private System.Windows.Forms.TabPage tabCapturaArriboEmpaque;
        private System.Windows.Forms.TabPage tabConsultaArriboEmpaque;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTareTarima;
        private System.Windows.Forms.Label lblTareTarima;
        private System.Windows.Forms.Label lblGreenhouse;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblCapArribo;
        private System.Windows.Forms.Label lblFolio;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.TextBox txtGrossLibs;
        private System.Windows.Forms.TextBox txtBoxes;
        private System.Windows.Forms.Label lblBoxes;
        private System.Windows.Forms.CheckBox chEnableWeigth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox btnLangCAE;
        private System.Windows.Forms.PictureBox btnHasConnection;
        private System.ComponentModel.BackgroundWorker backgroundWorkerFindFolio;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSaveFolio;
        private System.Windows.Forms.ProgressBar pgInfoFolio;
        private System.Windows.Forms.Label lblLoadingInfo;
        private System.Windows.Forms.Label lblLibs;
        private System.Windows.Forms.TableLayoutPanel tlpConsult;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.DateTimePicker dtpDateIni;
        private System.Windows.Forms.Label lblDateIni;
        private System.Windows.Forms.Label lblFolioFilter;
        private System.Windows.Forms.ComboBox cbPlants;
        private System.Windows.Forms.Label lblPlantFilter;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetFolios;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView dgvFolios;
        private System.Windows.Forms.TextBox txtFolioFilter;
        private System.Windows.Forms.Label lblLoadingFolios;
        private System.Windows.Forms.ProgressBar pbFolios;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ComboBox cbTareBox;
        private System.Windows.Forms.Label lblTareBox;
        private System.Windows.Forms.Label lblGP;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.Label lblPlant;
        private System.Windows.Forms.Label lblFolioName;
        private System.Windows.Forms.DataGridView dgvAddFolios;
        private System.Windows.Forms.Label lblIdHeader;
        private System.Windows.Forms.TextBox txtIDConsulta;
        private System.Windows.Forms.Label lblIDConsulta;
        private System.Windows.Forms.TextBox txtIDCaptura;
        private System.Windows.Forms.Label lblIDCaptura;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetFoliosByID;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puertoBasculaToolStripMenuItem;
    }
}