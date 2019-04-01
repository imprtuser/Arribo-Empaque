using ArriboEmpaque.Classes;
using arrivov2.helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArriboEmpaque.CapturaArriboEmpaque
{
    public partial class frmCapturaArriboEmpaque : Form
    {
        private Boolean english = false;
        private ResourceManager resourceManager;
        private CultureInfo culture;
        private DataSet dsInfo;
        private DataSet dsFolios;
        private Folio _Folio;
        private String folio;
        private int idPlant;
        private String dateIni;
        private String dateFin;
        private DataTable dtFolios;

        public frmCapturaArriboEmpaque()
        {
            InitializeComponent();
        }

        private void frmCapturaArriboEmpaque_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            resourceManager = new ResourceManager("ArriboEmpaque.Language.Res", typeof(frmCapturaArriboEmpaque).Assembly);
            backgroundWorkerFindFolio.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerFindFolio_RunWorkerCompleted);
            backgroundWorkerSaveFolio.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerSaveFolio_RunWorkerCompleted);
            backgroundWorkerGetFolios.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorkerGetFolios_RunWorkerCompleted);

            dgvFolios.AllowUserToAddRows = false;
            dgvFolios.AllowUserToDeleteRows = false;

            dtpDateIni.Format = DateTimePickerFormat.Custom;
            dtpDateIni.CustomFormat = "yyyy-MM-dd";

            dtpDateFin.Format = DateTimePickerFormat.Custom;
            dtpDateFin.CustomFormat = "yyyy-MM-dd";

            pingToWS();
            loadTexts();
            timerPing.Enabled = true;
            timerPing.Interval = 30000;
            timerPing.Start();

            this.idPlant = 0;
            this.folio = null;
            this.dateIni = null;
            this.dateFin = null;

        }

        private void btnLangCAE_Click(object sender, EventArgs e)
        {
            changeLanguage();
        }


        protected void loadTaresPallet(DataTable dtTaresPallet, int idTarePallet) {
            try
            {
                cbTareTarima.DataSource = dtTaresPallet;
                cbTareTarima.ValueMember = "ID";
                cbTareTarima.DisplayMember = "Name";
                cbTareTarima.SelectedValue = idTarePallet;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void loadTaresBox(DataTable dtTaresBox, int idTarePlantCaja) {
            try
            {
                cbTareBox.DataSource = dtTaresBox;
                cbTareBox.ValueMember = "ID";
                cbTareBox.DisplayMember = "Name";
                cbTareBox.SelectedValue = idTarePlantCaja;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void loadTexts() {
            lblCapArribo.Text = resourceManager.GetString("capArribo", culture);
            lblFolio.Text = resourceManager.GetString("folio");
            lblTareTarima.Text = resourceManager.GetString("taraTarima", culture);
            lblTareBox.Text = resourceManager.GetString("taraCaja", culture);
            chEnableWeigth.Text = resourceManager.GetString("habilitarPeso", culture);
            lblBoxes.Text = resourceManager.GetString("cajas", culture);
            lblLibs.Text = resourceManager.GetString("librasNetas", culture);
            btnCancel.Text = resourceManager.GetString("cancelar", culture);
            btnSave.Text = resourceManager.GetString("guardar", culture);
            lblNoData.Text = resourceManager.GetString("noData", culture);
        }

        protected void changeLanguage() {
            try {
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
            catch (Exception ex) {
                throw ex;
            }
        }

        
        protected void enableWeight() {
            try {
                if (chEnableWeigth.Checked)
                {
                    txtLibs.Enabled = true;
                }
                else
                {
                    txtLibs.Enabled = false;
                }
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        private void chEnableWeigth_CheckedChanged(object sender, EventArgs e)
        {
            enableWeight();
        }


        protected DataSet getInfoFolio(String folio) {
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
                lblNoData.Hide();

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
                txtLibs.Text = _Folio.dNet.ToString();

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
            DataTable dt = dsInfo.Tables[0];
            ResponseType res = new ResponseType();

            if (dt.Rows.Count > 0)
            {
                res.responseType = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
                res.descriptionType = dt.Rows[0]["descriptionType"].ToString();
                res.message = dt.Rows[0]["message"].ToString();

                if (res.responseType == 1)
                {
                    DataTable dtFolio = new DataTable();
                    DataTable dtTaresPallet = new DataTable();
                    DataTable dtTaresBox = new DataTable();

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

                    setValues(_Folio);
                    loadTaresBox(dtTaresBox, _Folio.idTarePlantCaja);
                    loadTaresPallet(dtTaresPallet, _Folio.idTarePlantPallet);

                    pgInfoFolio.Value = 100;
                    pgInfoFolio.Hide();
                    lblLoadingInfo.Hide();
                    btnCancel.Enabled = true;
                    btnSave.Enabled = true;
                }
                else if (res.responseType == 2)
                {
                    MessageBox.Show(res.message, "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pgInfoFolio.Value = 100;
                    pgInfoFolio.Hide();
                    lblLoadingInfo.Hide();
                    btnCancel.Enabled = true;
                    btnSave.Enabled = true;
                    cleanForm();
                }
            }
        }

        private void txtFolio_TextChanged(object sender, EventArgs e)
        {
      
        }


        protected Boolean saveInfoFolio()
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodSaveInfoFolio;
                Boolean savedFolio = false;

                String xmlFolioObject = _Folio.toXML();
                String postString = String.Format("xmlFolioObject={0}", xmlFolioObject);

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
                ResponseType res = new ResponseType();

                if (dt.Rows.Count > 0)
                {
                    res.responseType = Convert.ToInt32(dt.Rows[0]["responseType"].ToString());
                    if (res.responseType == 1) {
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
            }
            else
            {
                response.responseType = 2;
                response.message = "No se pudo guardar la información del folio";
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
                MessageBox.Show(response.message, " Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtBoxes.Text.ToString()) && !String.IsNullOrEmpty(txtLibs.Text.ToString()))
            {
                _Folio.dNet = Convert.ToDecimal(txtLibs.Text.ToString());
                _Folio.iBoxes = Convert.ToInt32(txtBoxes.Text.ToString());

                if(_Folio.iBoxes > 0 && _Folio.dNet > 0)
                {
                    backgroundWorkerSaveFolio.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Las cajas y/o libras netas deben ser mayor a 0", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debes ingresar las cajas y/o libras del folio", "Captura Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                findInfoFolioThread();
            }

        }

        private void txtFolio_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyData == Keys.Tab)
            {
                findInfoFolioThread();
            }
        }


        protected void cleanForm()
        {

            //lblFolioName.Text = String.Empty;
            lblDate.Text = String.Empty;
            //lblPlant.Text = String.Empty;
            lblGreenhouse.Text = String.Empty;
            //lblQuality.Text = String.Empty;
            //lblGP.Text = String.Empty;

            txtBoxes.Text = String.Empty;
            txtLibs.Text = String.Empty;

            cbTareTarima.DataSource = null;

            lblNoData.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Arribo Empaque", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

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

        protected DataSet getFolios(int idPlant, String folio, String dateIni, String dateFin)
        {
            try
            {
                const String contentType = "application/x-www-form-urlencoded";
                var url = config.pathWS + "/" + config.webMethodGetFolios;
                String postString = String.Format("idPlant={0}&folio={1}&dateIni={2}&dateFin={3}", idPlant, folio, dateIni, dateFin);

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

                if(responseData == "1")
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
                throw ex ;
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

            dsFolios = getFolios(idPlant,folio,dateIni,dateFin);
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
                    lblTotalRecords.Show();
                    lblTotalRecords.Text = "Registros totales:" + dtFolios.Rows.Count;
                    lblReady.Show();
                }
                else
                {
                    MessageBox.Show("No se encontraron registros", "Consulta Arribo Empaque", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pbFolios.Hide();
                    lblLoadingFolios.Hide();
                    lblTotalRecords.Hide();
                    lblReady.Hide();
                    dgvFolios.DataSource = null;
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
            pbFolios.Show();
            pbFolios.Value = 50;
            lblLoadingFolios.Show();
            lblLoadingFolios.Text = "Cargando Información...";
            lblTotalRecords.Hide();
            lblReady.Hide();
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

        private void tbControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            
            if (e.TabPage.Name == tbControl.TabPages[1].Name)
            {
                loadPlants();
                pbFolios.Show();
                pbFolios.Value = 50;
                lblLoadingFolios.Show();
                lblLoadingFolios.Text = "Cargando Información...";
                lblTotalRecords.Hide();
                lblReady.Hide();
                backgroundWorkerGetFolios.RunWorkerAsync();
            }
        }

        private void cbTareBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTareBox_Click(object sender, EventArgs e)
        {

        }

        private void lblPlant_Click(object sender, EventArgs e)
        {

        }
    }
}
