using ArriboEmpaque.Classes;
using ArriboEmpaque.Screens;
using arrivov2.helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace ArriboEmpaque.CapturaArriboEmpaque
{
    public partial class frmCapturaArriboEmpaque : Form
    {
        //Variables globales
        private Boolean english = false;
        private ResourceManager resourceManager;
        private CultureInfo culture;
        private DataSet dsInfo;
        private DataSet dsInfoFoliosByID;
        private DataSet dsFolios;
        private DataSet dsFoliosByID;
        private Folio _Folio;
        private String folio;
        private int idPlant;
        private int idFolioHeader;
        private String dateIni;
        private String dateFin;
        private DataTable dtFolios;
        private DataTable dtFoliosByID;
        private DataTable dtTaresPallet;
        private DataTable dtTaresBox;
        private SerialPort oSerialPort;
        private Port port;
        public static String userSession = String.Empty;
        private int currentValueCajas = 0;
        private ResponseType res;

        public frmCapturaArriboEmpaque()
        {
            InitializeComponent();
        }

        private void frmCapturaArriboEmpaque_Load(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            resourceManager = new ResourceManager("ArriboEmpaque.Language.Res", typeof(frmCapturaArriboEmpaque).Assembly);
            backgroundWorkerFindFolio.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerFindFolio_RunWorkerCompleted);
            backgroundWorkerSaveFolio.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerSaveFolio_RunWorkerCompleted);
            backgroundWorkerGetFolios.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerGetFolios_RunWorkerCompleted);
            backgroundWorkerGetFoliosByID.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerGetFoliosByID_RunWorkerCompleted);
            backgroundWorkerFilterFoliosByID.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerFilterFoliosByID_RunWorkerCompleted);

            dtpDateIni.Format = DateTimePickerFormat.Custom;
            dtpDateIni.CustomFormat = "yyyy-MM-dd";

            dtpDateFin.Format = DateTimePickerFormat.Custom;
            dtpDateFin.CustomFormat = "yyyy-MM-dd";

            pingToWS();
            loadTexts();
            generateTableCapture();
            timerPing.Enabled = true;
            timerPing.Interval = 30000;
            timerPing.Start();

            lblIdHeader.Text = "0";

            this.idPlant = 0;
            this.folio = null;
            this.dateIni = null;
            this.dateFin = null;
            this.idFolioHeader = 0;
            txtBoxes.Enabled = false;
            txtGrossLibs.Enabled = false;
            txtNetLibsPlants.Enabled = false;
            txtNetLibsPesaje.Enabled = false;
            txtDifference.Enabled = false;
            txtFolio.Focus();

            userSession = frmLogin.userSession;
            //initializePortWeighingMachine();
        }

        private void btnLangCAE_Click(object sender, EventArgs e)
        {
            changeLanguage();
        }

        protected void loadTaresPallet(DataTable dtTaresPallet)
        {
            try
            {
                cbTareTarima.DataSource = null;
                cbTareTarima.DataSource = dtTaresPallet;
                cbTareTarima.ValueMember = "ID";
                cbTareTarima.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void loadTaresBox(DataTable dtTaresBox)
        {
            try
            {
                cbTareBox.DataSource = null;
                cbTareBox.DataSource = dtTaresBox;
                cbTareBox.ValueMember = "ID";
                cbTareBox.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void loadTexts()
        {
            lblCapArribo.Text = resourceManager.GetString("capArribo", culture);
            lblFolio.Text = resourceManager.GetString("folio");
            lblTareTarima.Text = resourceManager.GetString("taraTarima", culture);
            lblTareBox.Text = resourceManager.GetString("taraCaja", culture);
            chEnableWeigth.Text = resourceManager.GetString("habilitarPeso", culture);
            lblBoxes.Text = resourceManager.GetString("cajas", culture);
            lblLibs.Text = resourceManager.GetString("librasNetas", culture);
            btnCancel.Text = resourceManager.GetString("cancelar", culture);
            btnSave.Text = resourceManager.GetString("guardar", culture);
            lblNetLibsPlants.Text = resourceManager.GetString("librasNetasPlantaOrigen", culture);
            lblNetLibsPesaje.Text = resourceManager.GetString("librasNetasPesaje", culture);
            lblDifference.Text = resourceManager.GetString("diferencia", culture);
        }

        protected void changeLanguage()
        {
            try
            {
                english = !english;
                if (english)
                {
                    culture = CultureInfo.CreateSpecificCulture("en");
                    btnLangCAE.Image = ArriboEmpaque.Properties.Resources.english_flag;
                }
                else
                {
                    culture = CultureInfo.CreateSpecificCulture("es");
                    btnLangCAE.Image = ArriboEmpaque.Properties.Resources.spanish_flag;
                }

                loadTexts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void enableWeight()
        {
            try
            {
                if (chEnableWeigth.Checked)
                {
                    txtGrossLibs.Enabled = true;
                }
                else
                {
                    txtGrossLibs.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chEnableWeigth_CheckedChanged(object sender, EventArgs e)
        {
            enableWeight();
        }

        protected DataSet getInfoFolio(String folio)
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodGetInfoFolio;
                String postString = String.Format("folio={0}", folio);

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = postString.Length;

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                DataSet ds = (DataSet)JsonConvert.DeserializeObject(responseData, typeof(DataSet));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void setValues(Folio _Folio)
        {
            try
            {
                lblFolioName.Text = _Folio.folioCode;
                lblDate.Text = String.Format("Fecha: {0}", _Folio.vDate);
                lblPlant.Text = _Folio.vPlant;
                lblGreenhouse.Text = _Folio.vGreenhouse;
                lblQuality.Text = String.Format("Calidad {0}", _Folio.vQuality);

                if (_Folio.isGP == 1)
                {
                    lblGP.Text = "Está en GP";
                    lblGP.ForeColor = Color.FromArgb(0, 128, 0);
                }
                else
                {
                    lblGP.Text = "No está en GP";
                    lblGP.ForeColor = Color.FromArgb(220, 20, 60);
                }

                txtBoxes.Text = _Folio.iBoxes.ToString();
                txtGrossLibs.Text = _Folio.dNet.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void backgroundWorkerFindFolio_DoWork(object sender, DoWorkEventArgs e)
        {
            String folio = txtFolio.Text.ToString().Trim();
            dsInfo = getInfoFolio(folio);
        }

        private void backgroundWorkerFindFolio_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable dt = dsInfo.Tables[0];
                ResponseType res = new ResponseType();

                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(lblIdHeader.Text.ToString()) > 0)
                    {
                        dgvAddFolios.Rows.Clear();
                        txtBoxes.Text = String.Empty;
                        txtNetLibsPlants.Text = String.Empty;
                        lblIdHeader.Text = "0";
                    }

                    res.responseType = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
                    res.descriptionType = dt.Rows[0]["descriptionType"].ToString();
                    res.message = dt.Rows[0]["message"].ToString();

                    if (res.responseType == 1)
                    {
                        DataTable dtFolio = new DataTable();
                        dtTaresPallet = new DataTable();
                        dtTaresBox = new DataTable();

                        dtFolio = dsInfo.Tables[1];

                        dtTaresPallet = dsInfo.Tables[2];
                        dtTaresBox = dsInfo.Tables[3];

                        _Folio = new Folio();

                        _Folio.idWnW = Convert.ToInt32(dtFolio.Rows[0]["idWnW"].ToString());
                        _Folio.dNet = Convert.ToDecimal(dtFolio.Rows[0]["dNet"].ToString());
                        _Folio.iBoxes = Convert.ToInt32(dtFolio.Rows[0]["iBoxes"].ToString());
                        _Folio.vUserCreated = dtFolio.Rows[0]["userCreated"].ToString();
                        _Folio.folioCode = dtFolio.Rows[0]["Folio"].ToString();
                        _Folio.vDate = dtFolio.Rows[0]["Fecha"].ToString();
                        _Folio.vPlant = dtFolio.Rows[0]["Planta"].ToString();
                        _Folio.vGreenhouse = dtFolio.Rows[0]["Invernadero"].ToString();
                        _Folio.vQuality = dtFolio.Rows[0]["Calidad"].ToString();
                        _Folio.isGP = Convert.ToInt32(dtFolio.Rows[0]["esGP"].ToString());
                        _Folio.idTarePlantPallet = Convert.ToInt32(dtFolio.Rows[0]["idTarePlantPallet"].ToString());
                        _Folio.idTarePlantCaja = Convert.ToInt32(dtFolio.Rows[0]["idTarePlantCaja"].ToString());

                        loadTaresBox(dtTaresBox);
                        loadTaresPallet(dtTaresPallet);

                        if (dgvAddFolios.Rows.Count > 0)
                        {
                            if (!RowExistsInGridView(_Folio.folioCode))
                            {
                                addFolioGridView(dtFolio);
                            }
                            else
                            {
                                MessageBox.Show("El folio ya ha sido agregado a la tabla", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            addFolioGridView(dtFolio);
                        }


                        pgInfoFolio.Value = 100;
                        pgInfoFolio.Hide();
                        lblLoadingInfo.Hide();
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        txtFolio.Enabled = true;
                        txtFolio.Text = String.Empty;
                        cbTareTarima.Enabled = true;
                        cbTareBox.Enabled = true;
                        txtIDCaptura.Enabled = true;
                        // txtBoxes.Enabled = true;
                        txtFolio.Focus();
                    }
                    else if (res.responseType == 2)
                    {
                        MessageBox.Show(res.message, "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pgInfoFolio.Value = 100;
                        pgInfoFolio.Hide();
                        lblLoadingInfo.Hide();
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        txtFolio.Enabled = true;
                        txtFolio.Text = String.Empty;
                        txtBoxes.Text = String.Empty;
                        txtGrossLibs.Text = String.Empty;
                        cbTareBox.DataSource = null;
                        cbTareTarima.DataSource = null;
                        cbTareTarima.Enabled = true;
                        cbTareBox.Enabled = true;
                        txtIDCaptura.Enabled = true;
                        //txtBoxes.Enabled = true;
                        txtFolio.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void addFolioGridView(DataTable dtFolio)
        {
            try
            {
                int rowIndex = dgvAddFolios.Rows.Add();
                DataGridViewRow row = dgvAddFolios.Rows[rowIndex];

                row.Cells[0].Value = dtFolio.Rows[0]["idWnW"].ToString();
                row.Cells[1].Value = dtFolio.Rows[0]["Folio"].ToString();
                row.Cells[2].Value = dtFolio.Rows[0]["Invernadero"].ToString();
                row.Cells[3].Value = dtFolio.Rows[0]["Producto"].ToString();
                row.Cells[4].Value = dtFolio.Rows[0]["Planta"].ToString();
                row.Cells[5].Value = dtFolio.Rows[0]["Calidad"].ToString();
                row.Cells[6].Value = dtFolio.Rows[0]["esGP"].ToString() == "1" ? "SI" : "NO";
                row.Cells[7].Value = dtFolio.Rows[0]["dNet"].ToString();
                row.Cells[8].Value = dtFolio.Rows[0]["CajaName"].ToString();
                row.Cells[9].Value = dtFolio.Rows[0]["idTarePlantCaja"].ToString();
                row.Cells[10].Value = dtFolio.Rows[0]["iBoxes"].ToString();
                row.Cells[11].Value = dtFolio.Rows[0]["Fecha"].ToString();

                if (Convert.ToInt32(lblIdHeader.Text.ToString()) == 0)
                {
                    if (!String.IsNullOrEmpty(txtBoxes.Text.ToString()))
                    {
                        txtBoxes.Text = (Convert.ToInt32(txtBoxes.Text.ToString()) + Convert.ToInt32(dtFolio.Rows[0]["iBoxes"].ToString())).ToString();
                        txtNetLibsPlants.Text = (Convert.ToInt32(txtNetLibsPlants.Text.ToString()) + Convert.ToInt32(dtFolio.Rows[0]["dNet"].ToString())).ToString();
                    }
                    else
                    {
                        txtBoxes.Text = dtFolio.Rows[0]["iBoxes"].ToString();
                        txtNetLibsPlants.Text = dtFolio.Rows[0]["dNet"].ToString();
                    }
                }
                getNetLibsPesaje();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void customizationTableFolios()
        {
            Font fontGridFolios = new Font("Tahoma", 8, FontStyle.Regular);

            dgvFolios.AutoGenerateColumns = true;
            dgvFolios.AllowUserToAddRows = false;
            dgvFolios.AllowUserToDeleteRows = false;
            dgvFolios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFolios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFolios.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvFolios.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvFolios.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvFolios.Font = fontGridFolios;
            dgvFolios.DefaultCellStyle.SelectionBackColor = (Color)System.Drawing.ColorTranslator.FromHtml("#78B266");
            dgvFolios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFolios.AllowUserToResizeColumns = false;
            dgvFolios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        protected void generateTableCapture()
        {
            Font font = new Font("Tahoma", 8, FontStyle.Bold);

            dgvAddFolios.AutoGenerateColumns = false;
            dgvAddFolios.AllowUserToAddRows = false;
            dgvAddFolios.AllowUserToDeleteRows = false;
            dgvAddFolios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAddFolios.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvAddFolios.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvAddFolios.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAddFolios.Font = font;
            dgvAddFolios.DefaultCellStyle.SelectionBackColor = (Color)System.Drawing.ColorTranslator.FromHtml("#78B266");
            dgvAddFolios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAddFolios.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAddFolios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAddFolios.AllowUserToResizeColumns = false;
            dgvAddFolios.RowTemplate.Height = 30;

            DataGridViewTextBoxColumn idWnWCol = new DataGridViewTextBoxColumn();
            idWnWCol.HeaderText = "idWnW";
            idWnWCol.DataPropertyName = "idWnW";
            idWnWCol.Name = "idWnW";
            idWnWCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idWnWCol.ReadOnly = true;
            idWnWCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idWnWCol.Visible = false;
            idWnWCol.Width = 50;
            dgvAddFolios.Columns.Add(idWnWCol);
            dgvAddFolios.Columns[0].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn folioCol = new DataGridViewTextBoxColumn();
            folioCol.HeaderText = "Folio";
            folioCol.DataPropertyName = "Folio";
            folioCol.Name = "Folio";
            folioCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            folioCol.ReadOnly = true;
            folioCol.Width = 50;
            folioCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(folioCol);
            dgvAddFolios.Columns[1].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn GHCol = new DataGridViewTextBoxColumn();
            GHCol.HeaderText = "Invernadero";
            GHCol.DataPropertyName = "Invernadero";
            GHCol.Name = "Invernadero";
            GHCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GHCol.ReadOnly = true;
            GHCol.Width = 50;
            GHCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(GHCol);
            dgvAddFolios.Columns[2].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn productCol = new DataGridViewTextBoxColumn();
            productCol.HeaderText = "Producto";
            productCol.DataPropertyName = "Producto";
            productCol.Name = "Producto";
            productCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            productCol.ReadOnly = true;
            productCol.Width = 50;
            productCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(productCol);
            dgvAddFolios.Columns[3].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn plantCol = new DataGridViewTextBoxColumn();
            plantCol.HeaderText = "Planta";
            plantCol.DataPropertyName = "Planta";
            plantCol.Name = "Planta";
            plantCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            plantCol.ReadOnly = true;
            plantCol.Width = 50;
            plantCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(plantCol);
            dgvAddFolios.Columns[4].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn qualityCol = new DataGridViewTextBoxColumn();
            qualityCol.HeaderText = "Calidad";
            qualityCol.DataPropertyName = "Calidad";
            qualityCol.Name = "Calidad";
            qualityCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            qualityCol.ReadOnly = true;
            qualityCol.Width = 50;
            qualityCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(qualityCol);
            dgvAddFolios.Columns[5].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn GPCol = new DataGridViewTextBoxColumn();
            GPCol.HeaderText = "GP";
            GPCol.DataPropertyName = "esGP";
            GPCol.Name = "GP";
            GPCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            GPCol.ReadOnly = true;
            GPCol.Width = 50;
            GPCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(GPCol);
            dgvAddFolios.Columns[6].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn netCol = new DataGridViewTextBoxColumn();
            netCol.HeaderText = "Libras netas";
            netCol.DataPropertyName = "dNet";
            netCol.Name = "dNet";
            netCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            netCol.ReadOnly = true;
            netCol.Width = 50;
            netCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(netCol);
            dgvAddFolios.Columns[7].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn tareBoxCol = new DataGridViewTextBoxColumn();
            tareBoxCol.Name = "tareBox";
            tareBoxCol.HeaderText = "Tara Caja";
            tareBoxCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tareBoxCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            tareBoxCol.ReadOnly = true;
            tareBoxCol.Width = 50;
            dgvAddFolios.Columns.Add(tareBoxCol);
            dgvAddFolios.Columns[8].HeaderCell.Style.Font = font;


            DataGridViewTextBoxColumn idTareBox = new DataGridViewTextBoxColumn();
            idTareBox.Name = "idTareBox";
            idTareBox.HeaderText = "idTareBox";
            idTareBox.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idTareBox.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idTareBox.ReadOnly = true;
            idTareBox.Visible = false;
            idTareBox.Width = 50;
            dgvAddFolios.Columns.Add(idTareBox);
            dgvAddFolios.Columns[9].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn boxesCol = new DataGridViewTextBoxColumn();
            boxesCol.HeaderText = "Cajas";
            boxesCol.DataPropertyName = "iBoxes";
            boxesCol.Name = "Cajas";
            boxesCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            boxesCol.ReadOnly = true;
            boxesCol.Width = 50;
            boxesCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(boxesCol);
            dgvAddFolios.Columns[10].HeaderCell.Style.Font = font;

            DataGridViewTextBoxColumn dateCol = new DataGridViewTextBoxColumn();
            dateCol.HeaderText = "Fecha Arribo";
            dateCol.DataPropertyName = "Fecha";
            dateCol.Name = "FechaArribo";
            dateCol.Width = 50;
            dateCol.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dateCol.ReadOnly = true;
            dateCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(dateCol);
            dgvAddFolios.Columns[11].HeaderCell.Style.Font = font;

            DataGridViewImageColumn EditCol = new DataGridViewImageColumn();
            EditCol.Width = 50;
            EditCol.Image = global::ArriboEmpaque.Properties.Resources.edit;
            EditCol.HeaderText = "Editar";
            EditCol.Name = "delete";
            EditCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(EditCol);
            dgvAddFolios.Columns[12].HeaderCell.Style.Font = font;

            DataGridViewImageColumn DeleteCol = new DataGridViewImageColumn();
            DeleteCol.Width = 50;
            DeleteCol.Image = global::ArriboEmpaque.Properties.Resources.delete;
            DeleteCol.HeaderText = "Eliminar";
            DeleteCol.Name = "delete";
            DeleteCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAddFolios.Columns.Add(DeleteCol);
            dgvAddFolios.Columns[13].HeaderCell.Style.Font = font;


        }

        protected String generateXMLFoliosDetails()
        {
            try
            {
                String xml = "<Details>";
                FolioDetails folioDetails = null;
                List<FolioDetails> lsFolioDetails = new List<FolioDetails>();

                foreach (DataGridViewRow row in dgvAddFolios.Rows)
                {
                    folioDetails = new FolioDetails();
                    folioDetails.idWnW = Convert.ToInt32(row.Cells[0].Value.ToString());
                    folioDetails.iBoxes = Convert.ToInt32(row.Cells[10].Value.ToString());
                    folioDetails.userCreated = userSession;

                    xml += folioDetails.toXML();
                }

                xml += "</Details>";

                return xml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected String generateXMLFoliosHeader()
        {
            try
            {
                FolioHeader folioHeader = new FolioHeader();
                folioHeader.idHeader = lblIdHeader.Text.ToString() != "0" ? Convert.ToInt32(lblIdHeader.Text.ToString()) : 0;
                folioHeader.iBoxes = Convert.ToInt32(txtBoxes.Text.ToString());
                folioHeader.dGrossLibs = Convert.ToDecimal(txtGrossLibs.Text.ToString());
                folioHeader.idTarePlant = Convert.ToInt32(cbTareTarima.SelectedValue);
                folioHeader.idTareBox = Convert.ToInt32(cbTareBox.SelectedValue);
                folioHeader.userCreated = userSession;

                return folioHeader.toXML();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected Boolean saveInfoFolio()
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodSaveInfoFolio;
                Boolean savedFolio = false;

                String xmlFoliosHeader = generateXMLFoliosHeader();
                String xmlFoliosDetails = generateXMLFoliosDetails();
                String postString = String.Format("xmlFoliosHeader={0}&xmlFoliosDetails={1}", xmlFoliosHeader, xmlFoliosDetails);

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = postString.Length;

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();


                responseReader.Close();
                webRequest.GetResponse().Close();

                DataSet ds = (DataSet)JsonConvert.DeserializeObject(responseData, typeof(DataSet));
                DataTable dt = ds.Tables[0];
                res = new ResponseType();

                if (dt.Rows.Count > 0)
                {
                    res.responseType = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
                    res.descriptionType = dt.Rows[0]["descriptionResponse"].ToString();
                    if (res.responseType == 1)
                    {
                        savedFolio = true;
                    }
                }

                return savedFolio;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void backgroundWorkerSaveFolio_DoWork(object sender, DoWorkEventArgs e)
        {
            ResponseType response = new ResponseType();

            if (saveInfoFolio())
            {
                response.responseType = 1;
                response.message = "Datos de folio guardados correctamente";
                txtFolio.Text = String.Empty;
                txtIDCaptura.Enabled = true;
                txtBoxes.Enabled = true;
                txtBoxes.Text = String.Empty;
                txtGrossLibs.Enabled = false;
                txtGrossLibs.Text = String.Empty;
                cbTareBox.DataSource = null;
                cbTareTarima.DataSource = null;
                cbTareBox.Enabled = true;
                cbTareTarima.Enabled = true;
                dgvAddFolios.Rows.Clear();
                lblIdHeader.Text = "0";
                chEnableWeigth.Checked = false;
                pgInfoFolio.Value = 100;
                pgInfoFolio.Hide();
                lblLoadingInfo.Hide();
                txtNetLibsPlants.Text = String.Empty;
                txtNetLibsPesaje.Text = String.Empty;
                txtDifference.Text = String.Empty;
            }
            else
            {
                pgInfoFolio.Value = 100;
                pgInfoFolio.Hide();
                lblLoadingInfo.Hide();

                if(res.responseType == 3)
                {
                    response.responseType = 3;
                    response.message = "Los folios deben ser de la misma planta";
                }

                if(res.responseType == 2)
                {
                    response.responseType = 2;
                    response.message = "No se pudo guardar la información del folio";
                }
            }

            e.Result = response;

        }

        private void backgroundWorkerSaveFolio_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResponseType response = (ResponseType)e.Result;
            if (response.responseType == 1)
            {
                MessageBox.Show(response.message, "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (response.responseType == 2)
                {
                    MessageBox.Show(response.message, " Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if(response.responseType == 3)
                {
                    MessageBox.Show(response.message, " Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtBoxes.Text.ToString()) && !String.IsNullOrEmpty(txtGrossLibs.Text.ToString()))
            {
                if (validateCajasAndGrossLibs(txtBoxes.Text.ToString(), txtGrossLibs.Text.ToString()))
                {
                    if (Convert.ToDecimal(txtGrossLibs.Text.ToString()) > 0 && Convert.ToInt32(txtBoxes.Text.ToString()) > 0)
                    {
                        pgInfoFolio.Show();
                        pgInfoFolio.Value = 50;
                        lblLoadingInfo.Show();
                        lblLoadingInfo.Text = "Cargando información...";
                        backgroundWorkerSaveFolio.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("Las cajas y/o libras netas deben ser mayor a 0", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Las cajas y/o libras no tienen el formato correcto", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar las cajas y/o libras del folio", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        protected Boolean validateCajasAndGrossLibs(String cajas, String grossLibs)
        {
            try
            {
                int outCajas;
                int outGrossLibs;
                if (int.TryParse(cajas, out outCajas) && int.TryParse(grossLibs, out outGrossLibs))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void findInfoFolioThread()
        {
            if (!String.IsNullOrEmpty(txtFolio.Text.ToString()))
            {
                pgInfoFolio.Show();
                pgInfoFolio.Value = 50;
                lblLoadingInfo.Show();
                lblLoadingInfo.Text = "Cargando Información...";
                btnCancel.Enabled = false;
                btnSave.Enabled = false;
                txtFolio.Enabled = false;
                txtIDCaptura.Enabled = false;
                //txtBoxes.Enabled = false;
                txtGrossLibs.Enabled = false;
                cbTareTarima.Enabled = false;
                cbTareBox.Enabled = false;
                backgroundWorkerFindFolio.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Debes ingresar un folio", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                initializePortWeighingMachine();
                findInfoFolioThread();
            }

        }

        private void txtFolio_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyData == Keys.Tab)
            {
                initializePortWeighingMachine();
                findInfoFolioThread();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Arribo Empaque", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    this.Dispose();
                    timerPing.Enabled = false;
                    timerPing.Dispose();

                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var result = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Arribo Empaque", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Dispose();
                timerPing.Enabled = false;
                timerPing.Dispose();

                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        protected DataSet getFolios(int idPlant, String folio, String dateIni, String dateFin, int idFolioHeader)
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodGetFolios;
                String postString = String.Format("idPlant={0}&folio={1}&dateIni={2}&dateFin={3}&idFolioHeader={4}", idPlant, folio, dateIni, dateFin, idFolioHeader);

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = postString.Length;

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                DataSet ds = (DataSet)JsonConvert.DeserializeObject(responseData, typeof(DataSet));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void pingToWS()
        {
            try
            {

                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodPingWS;

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = 0;

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                if (responseData == "1")
                {
                    btnHasConnection.Image = ArriboEmpaque.Properties.Resources.green;
                }
                else
                {
                    btnHasConnection.Image = ArriboEmpaque.Properties.Resources.red;
                }
            }
            catch (Exception ex)
            {
                btnHasConnection.Image = ArriboEmpaque.Properties.Resources.red;
            }
        }

        private void timerPing_Tick(object sender, EventArgs e)
        {
            pingToWS();
        }

        private void backgroundWorkerGetFolios_DoWork(object sender, DoWorkEventArgs e)
        {
            dateIni = dtpDateIni.Value.Date.ToString("yyyy-MM-dd");
            dateFin = dtpDateFin.Value.Date.ToString("yyyy-MM-dd");
            dsFolios = getFolios(idPlant, folio, dateIni, dateFin, idFolioHeader);
        }

        private void backgroundWorkerGetFolios_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dtFolios = dsFolios.Tables[0];

                if (dtFolios.Rows.Count > 0)
                {
                    dgvFolios.DataSource = dtFolios;
                    pbFolios.Value = 100;
                    pbFolios.Hide();
                    lblLoadingFolios.Hide();
                    txtIDConsulta.Enabled = true;
                    txtFolioFilter.Enabled = true;
                    cbPlants.Enabled = true;
                    dtpDateIni.Enabled = true;
                    dtpDateFin.Enabled = true;
                    btnFilter.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron registros para la fecha actual", "Consulta Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pbFolios.Hide();
                    lblLoadingFolios.Hide();
                    txtIDConsulta.Enabled = true;
                    txtFolioFilter.Enabled = true;
                    cbPlants.Enabled = true;
                    dtpDateIni.Enabled = true;
                    dtpDateFin.Enabled = true;
                    btnFilter.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            folio = txtFolioFilter.Text.ToString();
            idPlant = Convert.ToInt32(cbPlants.SelectedValue);
            idFolioHeader = !String.IsNullOrEmpty(txtIDConsulta.Text.ToString()) ? Convert.ToInt32(txtIDConsulta.Text.ToString()) : 0;
            pbFolios.Show();
            pbFolios.Value = 50;
            lblLoadingFolios.Show();
            lblLoadingFolios.Text = "Cargando Información...";
            txtIDConsulta.Enabled = false;
            txtFolioFilter.Enabled = false;
            cbPlants.Enabled = false;
            dtpDateIni.Enabled = false;
            dtpDateFin.Enabled = false;
            btnFilter.Enabled = false;
            backgroundWorkerGetFolios.RunWorkerAsync();
        }

        protected void loadPlants()
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodGetPlants;

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = 0;

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                DataTable dtPlants = (DataTable)JsonConvert.DeserializeObject(responseData, typeof(DataTable));

                cbPlants.ValueMember = "ID";
                cbPlants.DisplayMember = "Name";
                cbPlants.DataSource = dtPlants;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void loadPlants2()
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodGetPlants;

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = 0;

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                DataTable dtPlants = (DataTable)JsonConvert.DeserializeObject(responseData, typeof(DataTable));

                cbPlants2.ValueMember = "ID";
                cbPlants2.DisplayMember = "Name";
                cbPlants2.DataSource = dtPlants;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tbControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPage.Name)
            {
                case "tabCapturaArriboEmpaque":
                    break;
                case "tabConsultaArriboEmpaque":
                    customizationTableFolios();
                    loadPlants();
                    pbFolios.Show();
                    pbFolios.Value = 50;
                    lblLoadingFolios.Show();
                    lblLoadingFolios.Text = "Cargando Información...";
                    txtIDConsulta.Enabled = false;
                    txtFolioFilter.Enabled = false;
                    cbPlants.Enabled = false;
                    dtpDateIni.Enabled = false;
                    dtpDateFin.Enabled = false;
                    btnFilter.Enabled = false;
                    backgroundWorkerGetFolios.RunWorkerAsync();
                    break;
                case "tabConsultaFoliosByID":
                    customizationTableFoliosByID();
                    loadPlants2();
                    pbFolios.Show();
                    pbFolios.Value = 50;
                    lblLoadingFolios.Show();
                    lblLoadingFolios.Text = "Cargando Información...";
                    txtIDConsulta.Enabled = false;
                    txtFolioFilter.Enabled = false;
                    cbPlants2.Enabled = false;
                    dtpDateIni2.Enabled = false;
                    dtpDateFin2.Enabled = false;
                    btnFilter2.Enabled = false;
                    backgroundWorkerFilterFoliosByID.RunWorkerAsync();
                    break;
                default:
                    break;
            }
        }

        private void dgvAddFolios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                currentValueCajas = Convert.ToInt32(dgvAddFolios.Rows[e.RowIndex].Cells[10].Value.ToString());
                String folio = dgvAddFolios.Rows[e.RowIndex].Cells[1].Value.ToString();
                String newValue = Microsoft.VisualBasic.Interaction.InputBox("Ingrese nuevo valor de cajas", "Edición de cajas para folio" + " " + folio, currentValueCajas.ToString());

                if (!String.IsNullOrEmpty(newValue))
                {
                    if (validateValueCajas(newValue))
                    {
                        setNewValueCajas(e.RowIndex, Convert.ToInt32(newValue));
                    }
                    else
                    {
                        MessageBox.Show("El formato del valor de cajas no es correcto.", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    return;
                }
            }

            if (e.ColumnIndex == 13)
            {
                int sumBoxes = 0;
                int sumLibs = 0;

                DialogResult result = MessageBox.Show("¿Está seguro que desea salir eliminar el folio?", "Captura Arribo Empaque", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvAddFolios.SelectedRows)
                    {
                        dgvAddFolios.Rows.RemoveAt(row.Index);
                    }

                    foreach (DataGridViewRow row in dgvAddFolios.Rows)
                    {
                        sumBoxes += Convert.ToInt32(row.Cells[10].Value.ToString());
                        sumLibs += Convert.ToInt32(row.Cells[7].Value.ToString());
                    }

                    if (sumBoxes > 0 && sumLibs > 0)
                    {

                        txtBoxes.Text = sumBoxes.ToString();
                        txtNetLibsPlants.Text = sumLibs.ToString();
                        getNetLibsPesaje();
                    }
                    else
                    {
                        txtBoxes.Text = String.Empty;
                        txtNetLibsPlants.Text = String.Empty;
                        txtNetLibsPesaje.Text = String.Empty;
                        txtDifference.Text = String.Empty;
                        cbTareBox.DataSource = null;
                        cbTareTarima.DataSource = null;
                    }
                    txtFolio.Text = String.Empty;
                }
            }
        }

        protected Boolean RowExistsInGridView(String folio)
        {
            Boolean exists = false;
            try
            {
                foreach (DataGridViewRow row in dgvAddFolios.Rows)
                {
                    if ((String)row.Cells[1].Value == folio)
                    {
                        exists = true;
                    }
                }

                return exists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtIDCaptura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                findFoliosByID();
            }
        }

        private void txtIDCaptura_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                findFoliosByID();
            }
        }

        protected void findFoliosByID()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIDCaptura.Text.ToString()))
                {
                    pgInfoFolio.Show();
                    pgInfoFolio.Value = 50;
                    lblLoadingInfo.Show();
                    lblLoadingInfo.Text = "Cargando Información...";
                    btnCancel.Enabled = false;
                    btnSave.Enabled = false;
                    txtFolio.Enabled = false;
                    txtIDCaptura.Enabled = false;
                    txtGrossLibs.Enabled = false;
                    cbTareBox.Enabled = false;
                    cbTareTarima.Enabled = false;
                    backgroundWorkerGetFoliosByID.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Debes ingresar un ID", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected DataSet getFoliosByID(int idFolioHeader)
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodGetFoliosByID;
                String postString = String.Format("idFolioHeader={0}", idFolioHeader);

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = postString.Length;

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                DataSet ds = (DataSet)JsonConvert.DeserializeObject(responseData, typeof(DataSet));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void backgroundWorkerGetFoliosByID_DoWork(object sender, DoWorkEventArgs e)
        {
            int idFolioHeader = Convert.ToInt32(txtIDCaptura.Text.ToString().Trim());
            dsInfoFoliosByID = getFoliosByID(idFolioHeader);
        }

        private void backgroundWorkerGetFoliosByID_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable dt = dsInfoFoliosByID.Tables[0];
                ResponseType res = new ResponseType();
                int sumaLibrasNetas = 0;

                if (dt.Rows.Count > 0)
                {
                    dgvAddFolios.Rows.Clear();
                    txtBoxes.Text = String.Empty;
                    txtNetLibsPlants.Text = String.Empty;
                    lblIdHeader.Text = "0";

                    res.responseType = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
                    res.descriptionType = dt.Rows[0]["descriptionType"].ToString();
                    res.message = dt.Rows[0]["message"].ToString();

                    if (res.responseType == 1)
                    {
                        DataTable dtFolioHeader = new DataTable();
                        DataTable dtFoliosDetails = new DataTable();
                        dtTaresPallet = new DataTable();
                        dtTaresBox = new DataTable();

                        dtFolioHeader = dsInfoFoliosByID.Tables[1];
                        dtFoliosDetails = dsInfoFoliosByID.Tables[2];
                        dtTaresPallet = dsInfoFoliosByID.Tables[3];
                        dtTaresBox = dsInfoFoliosByID.Tables[4];

                        loadTaresBox(dtTaresBox);
                        loadTaresPallet(dtTaresPallet);

                        lblIdHeader.Text = dtFolioHeader.Rows[0]["idFolioHeader"].ToString();
                        txtBoxes.Text = dtFolioHeader.Rows[0]["iBoxes"].ToString();
                        cbTareTarima.SelectedValue = Convert.ToInt32(dtFolioHeader.Rows[0]["idTarePlant"].ToString());
                        cbTareBox.SelectedValue = Convert.ToInt32(dtFolioHeader.Rows[0]["idTareBox"].ToString());


                        foreach (DataRow drow in dtFoliosDetails.Rows)
                        {
                            int rowIndex = dgvAddFolios.Rows.Add();
                            DataGridViewRow row = dgvAddFolios.Rows[rowIndex];
                            row.Cells[0].Value = drow["idWnW"].ToString();
                            row.Cells[1].Value = drow["Folio"].ToString();
                            row.Cells[2].Value = drow["Invernadero"].ToString();
                            row.Cells[3].Value = drow["Producto"].ToString();
                            row.Cells[4].Value = drow["Planta"].ToString();
                            row.Cells[5].Value = drow["Calidad"].ToString();
                            row.Cells[6].Value = drow["esGP"].ToString() == "1" ? "SI" : "NO";
                            row.Cells[7].Value = drow["dNet"].ToString();
                            row.Cells[8].Value = drow["CajaName"].ToString();
                            row.Cells[9].Value = drow["idTarePlantCaja"].ToString();
                            row.Cells[10].Value = drow["iBoxes"].ToString();
                            row.Cells[11].Value = drow["Fecha"].ToString();
                        }


                        foreach (DataGridViewRow row in dgvAddFolios.Rows)
                        {
                            sumaLibrasNetas += Convert.ToInt32(row.Cells[7].Value.ToString());
                        }

                        txtNetLibsPlants.Text = sumaLibrasNetas.ToString();

                        getNetLibsPesaje();

                        pgInfoFolio.Value = 100;
                        pgInfoFolio.Hide();
                        lblLoadingInfo.Hide();
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        txtFolio.Enabled = true;
                        txtFolio.Text = String.Empty;
                        txtIDCaptura.Enabled = true;
                        txtIDCaptura.Text = String.Empty;
                        txtGrossLibs.Enabled = false;
                        cbTareBox.Enabled = true;
                        cbTareTarima.Enabled = true;
                        txtFolio.Focus();
                    }
                    else if (res.responseType == 2)
                    {
                        MessageBox.Show(res.message, "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pgInfoFolio.Value = 100;
                        pgInfoFolio.Hide();
                        lblLoadingInfo.Hide();
                        btnCancel.Enabled = true;
                        btnSave.Enabled = true;
                        txtFolio.Enabled = true;
                        txtIDCaptura.Enabled = true;
                        txtIDCaptura.Text = String.Empty;
                        cbTareTarima.Enabled = true;
                        cbTareBox.Enabled = true;
                        txtFolio.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtFolio.Text = String.Empty;
            txtIDCaptura.Text = String.Empty;
            dgvAddFolios.Rows.Clear();
            txtBoxes.Text = String.Empty;
            txtGrossLibs.Text = String.Empty;
            cbTareBox.DataSource = null;
            cbTareTarima.DataSource = null;
        }



        #region Sección para inicializar el puerto de la báscula
        public void initializePortWeighingMachine()
        {
            String serialPort = String.Empty;

            try
            {
                port = new Port();

                if (!String.IsNullOrEmpty(port.getSerialPort()))
                {
                    serialPort = port.getSerialPort();
                    oSerialPort = new SerialPort(serialPort);

                    if (oSerialPort.IsOpen)
                    {
                        oSerialPort.Close();
                    }

                    oSerialPort.PortName = serialPort;
                    oSerialPort.BaudRate = 9600;
                    oSerialPort.Parity = Parity.Even;
                    oSerialPort.StopBits = StopBits.One;
                    oSerialPort.DataBits = 7;
                    oSerialPort.Handshake = Handshake.None;
                    oSerialPort.DtrEnable = true;
                    oSerialPort.RtsEnable = true;
                    oSerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    oSerialPort.Open();
                }
                else
                {
                    MessageBox.Show("No se ha inicializado un puerto para la báscula", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                if (oSerialPort.IsOpen)
                {
                    oSerialPort.Close();
                }
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                String cadenaSalida = "";
                List<String> lista = new List<String>();

                for (int i = 0; i < 5; i++)
                {
                    string ind = sp.ReadLine();
                    ind = ind.Replace("?", "");
                    ind = ind.Replace(" ", "").Trim();

                    String x = ind;

                    Regex reg = new Regex("[0-9]");
                    for (int j = 0; j < x.Length; j++)
                    {
                        if (reg.IsMatch(Convert.ToString(x[j])))
                        {
                            cadenaSalida += Convert.ToString(x[j]);
                        }
                        else if (Convert.ToString(x[j]).Equals("."))
                        {
                            cadenaSalida += Convert.ToString(x[j]);
                        }
                    }

                    lista.Add(cadenaSalida);
                    cadenaSalida = "";
                }
                oSerialPort.Close();

                String librasFinalCadena = "";
                int mayor = 0, contador = 0;
                for (int i = 0; i < lista.Count; i++)
                {
                    contador = 0;
                    for (int j = 0; j < lista.Count; j++)
                    {
                        if (i != j)
                        {
                            if (lista[i].Equals(lista[j]))
                            {
                                contador++;
                            }
                        }
                    }
                    if (contador > mayor)
                    {
                        librasFinalCadena = lista[i];
                        mayor = contador;
                    }
                }
                Control.CheckForIllegalCrossThreadCalls = false;

                int librasFinales = Convert.ToInt32(Math.Round(Convert.ToDecimal(librasFinalCadena)));

                txtGrossLibs.Text = "" + librasFinales.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #endregion

        private void puertoBasculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigPort frmConfigPort = new ConfigPort();
            frmConfigPort.Show();
        }

        protected void setNewValueCajas(int rIndex, int newValueCajas)
        {
            if (newValueCajas > 0)
            {
                int total = 0;
                if (dgvFolios.Rows.Count == 1)
                {
                    dgvAddFolios.Rows[rIndex].Cells[10].Value = newValueCajas;
                    total = newValueCajas;
                    txtBoxes.Text = total.ToString();
                }
                else
                {
                    dgvAddFolios.Rows[rIndex].Cells[10].Value = newValueCajas;
                    for (int i = 0; i < dgvAddFolios.Rows.Count; i++)
                    {
                        total += Convert.ToInt32(dgvAddFolios.Rows[i].Cells[10].Value.ToString());
                    }
                    txtBoxes.Text = total.ToString();
                    getNetLibsPesaje();
                }
            }
            else
            {
                MessageBox.Show("El valor del cajas del folio debe ser mayor a 0", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        protected Boolean validateValueCajas(String newValueCajas)
        {
            int newValue;
            if (int.TryParse(newValueCajas, out newValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbControl.SelectedIndex == 0)
            {
                txtFolio.Focus();
            }
        }



        #region Sección para reporte de folios por ID

        protected void customizationTableFoliosByID()
        {
            Font fontGridFoliosID = new Font("Tahoma", 8, FontStyle.Regular);

            dgvFoliosByID.AutoGenerateColumns = true;
            dgvFoliosByID.AllowUserToAddRows = false;
            dgvFoliosByID.AllowUserToDeleteRows = false;
            dgvFoliosByID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvFoliosByID.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFoliosByID.RowsDefaultCellStyle.BackColor = Color.Bisque;
            dgvFoliosByID.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvFoliosByID.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvFoliosByID.Font = fontGridFoliosID;
            dgvFoliosByID.DefaultCellStyle.SelectionBackColor = (Color)System.Drawing.ColorTranslator.FromHtml("#78B266");
            dgvFoliosByID.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFoliosByID.AllowUserToResizeColumns = false;
            dgvFoliosByID.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnFiltrar2_Click(object sender, EventArgs e)
        {
            folio = txtFolioFilter.Text.ToString();
            idPlant = Convert.ToInt32(cbPlants.SelectedValue);
            idFolioHeader = !String.IsNullOrEmpty(txtID.Text.ToString()) ? Convert.ToInt32(txtID.Text.ToString()) : 0;
            pbFoliosByID.Show();
            pbFoliosByID.Value = 50;
            lblLoadingFoliosByID.Show();
            lblLoadingFoliosByID.Text = "Cargando Información...";
            txtID.Enabled = false;
            cbPlants2.Enabled = false;
            dtpDateIni2.Enabled = false;
            dtpDateFin2.Enabled = false;
            btnFilter2.Enabled = false;
            backgroundWorkerFilterFoliosByID.RunWorkerAsync();
        }

        private void backgroundWorkerFilterFoliosByID_DoWork(object sender, DoWorkEventArgs e)
        {
            String dateIni2 = dtpDateIni2.Value.Date.ToString("yyyy-MM-dd");
            String dateFin2 = dtpDateFin2.Value.Date.ToString("yyyy-MM-dd");
            int idPlant = Convert.ToInt32(cbPlants2.SelectedValue.ToString());
            dsFoliosByID = filterFoliosByID(idFolioHeader, idPlant, dateIni2, dateFin2);
        }

        private void backgroundWorkerFilterFoliosByID_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                dtFoliosByID = dsFoliosByID.Tables[0];

                if (dtFoliosByID.Rows.Count > 0)
                {
                    dgvFoliosByID.DataSource = dtFoliosByID;
                    pbFoliosByID.Value = 100;
                    pbFoliosByID.Hide();
                    lblLoadingFoliosByID.Hide();
                    txtID.Enabled = true;
                    cbPlants2.Enabled = true;
                    dtpDateIni2.Enabled = true;
                    dtpDateFin2.Enabled = true;
                    btnFilter2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se encontraron registros para la fecha actual", "Consulta Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pbFoliosByID.Hide();
                    lblLoadingFoliosByID.Hide();
                    txtID.Enabled = true;
                    cbPlants2.Enabled = true;
                    dtpDateIni2.Enabled = true;
                    dtpDateFin2.Enabled = true;
                    btnFilter2.Enabled = true;
                    dgvFoliosByID.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected DataSet filterFoliosByID(int idFolioHeader, int idPlant, String dateIni, String dateFin)
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodFilterFoliosByID;
                String postString = String.Format("idFolioHeader={0}&idPlant={1}&dateIni={2}&dateFin={3}", idFolioHeader, idPlant, dateIni, dateFin);

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = postString.Length;

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                DataSet ds = (DataSet)JsonConvert.DeserializeObject(responseData, typeof(DataSet));

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void cbTareTarima_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTareTarima.SelectedIndex >= 0)
            {
                if (!String.IsNullOrEmpty(txtBoxes.Text.ToString()) && !String.IsNullOrEmpty(txtGrossLibs.Text.ToString()) 
                    && !String.IsNullOrEmpty(cbTareTarima.SelectedValue.ToString()) && !String.IsNullOrEmpty(cbTareBox.SelectedValue.ToString()))
                {

                    getNetLibsPesaje();

                }
            }
        }

        protected void getNetLibsPesaje()
        {
            try
            {
                int cajas = Convert.ToInt32(txtBoxes.Text.ToString());

                String gross = txtGrossLibs.Text.ToString();


                int librasGross = Convert.ToInt32(txtGrossLibs.Text.ToString());
                int idTarePlant = Convert.ToInt32(cbTareTarima.SelectedValue.ToString());
                int idTareBox = Convert.ToInt32(cbTareBox.SelectedValue.ToString());

                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodGetNetLibsPesaje;
                String postString = String.Format("cajas={0}&librasGross={1}&idTarePlant={2}&idTareBox={3}", cajas, librasGross, idTarePlant, idTareBox);

                CookieContainer cookies = new CookieContainer();
                HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
                webRequest.Method = "POST";
                webRequest.ContentType = contentType;
                webRequest.ContentLength = postString.Length;

                StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());
                requestWriter.Write(postString);
                requestWriter.Close();

                StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                string responseData = responseReader.ReadToEnd();

                responseReader.Close();
                webRequest.GetResponse().Close();

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(responseData, typeof(DataTable));

                if (dt.Rows.Count > 0)
                {
                    int librasPlantaOrigen = Convert.ToInt32(txtNetLibsPlants.Text.ToString());
                    Decimal librasPesaje = Convert.ToDecimal(dt.Rows[0]["dPoundsWeighing"].ToString());

                    Decimal diferencia = (librasPesaje - librasPlantaOrigen);
                    txtNetLibsPesaje.Text = librasPesaje.ToString();
                    txtDifference.Text = diferencia.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void cbTareBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbTareBox.SelectedIndex >= 0)
            {
                if (!String.IsNullOrEmpty(txtBoxes.Text.ToString()) && !String.IsNullOrEmpty(txtGrossLibs.Text.ToString())
                   && !String.IsNullOrEmpty(cbTareTarima.SelectedValue.ToString()) && !String.IsNullOrEmpty(cbTareBox.SelectedValue.ToString()))
                {

                    getNetLibsPesaje();

                }
            }
        }

        private void txtGrossLibs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                getNetLibsPesaje();
            }
        }

        private void txtGrossLibs_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                getNetLibsPesaje();
            }
        }
    }
}
