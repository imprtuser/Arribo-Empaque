using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace arrivov2.helper {

    class config {

        public static String pathWS = "http://planning.naturesweet.com/wspackwedge/WSArriboService.asmx";
        //public static String pathWS = "http://192.168.167.8:289/WSArriboService.asmx/";
        public static String webMethodLogin                      = "Login";
        public static String webMethodDescargarComprobarConexion = "testCon";
        public static String webMethodGetInfoFolio = "getInfoFolio";
        public static String webMethodSaveInfoFolio = "saveInfoFolio";
        public static String webMethodPingWS = "pingToWS";
        public static String webMethodGetFolios = "getFolios";
        public static String webMethodGetPlants = "getPlants";



        //public static String currentDate() {
        //    DateTime thisDay = DateTime.Now;
        //    return thisDay.ToString("yyyy-MM-dd");
        //}

        //public static String convertToDate(String date) {
        //    DateTime thisDay = DateTime.Now;

        //    return thisDay.ToString("yyyy-MM-dd");
        //}

        //public static String convertToTime(String date) {
        //    DateTime thisDay = DateTime.Now;

        //    return thisDay.ToString("H:mm");
        //}

        //public static String currentDateTime() {
        //    DateTime thisDay = DateTime.Now;

        //    return thisDay.ToString("yyyy-MM-dd HH:mm:ss");
        //}

        //public static bool AccesoWS() {
        //    var url = config.pathWS + "/" + config.webMethodDescargarComprobarConexion;

        //    try {
        //        const string contentType = "application/x-www-form-urlencoded";

        //        CookieContainer cookies = new CookieContainer();
        //        HttpWebRequest webRequest = WebRequest.Create(url) as HttpWebRequest;
        //        webRequest.Method = "POST";
        //        webRequest.ContentType = contentType;

        //        StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream());


        //        StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
        //        string responseData = responseReader.ReadToEnd();

        //        responseReader.Close();
        //        webRequest.GetResponse().Close();

        //        DataTable dt = (DataTable) JsonConvert.DeserializeObject(responseData, typeof(DataTable));

        //        if(Convert.ToInt32(dt.Rows[0]["response"]) == 200) {
        //            return true;
        //        } else {
        //            return false;
        //        }
        //    } catch(Exception e) {
        //        return false;
        //    }
        //}

        //public static bool AccesoInternet() {
        //    /*try
        //    {
        //        System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
        //        return true;

        //    }
        //    catch (Exception es)
        //    {

        //        return false;
        //    }*/
        //    return true;

        //}
    }
}
