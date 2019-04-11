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

        //Nombre de la base de datos local
        public static String dbLocalName = "ArriboEmpaqueLocalDB";

        //Rutas para webservice de pruebas y produccion
        //public static String pathWS = "http://planning.naturesweet.com/wspackwedge/WSArriboService.asmx";
        public static String pathWS = "http://192.168.167.8:289/WSArriboService.asmx/";


        public static String webMethodLogin         = "Login";
        public static String webMethodPingWS        = "pingToWS";
        public static String webMethodGetPlants     = "getPlants";
        public static String webMethodGetFoliosByID = "getInfoFoliosByID";
        public static String webMethodGetInfoFolio  = "getInfoFolio";
        public static String webMethodSaveInfoFolio = "saveInfoFolio";
        public static String webMethodGetFolios     = "getFolios";

        //VERSION 2 DE LOS WEBMETHODS
        //public static String webMethodGetInfoFolio  = "getInfoFolioV2";
        //public static String webMethodSaveInfoFolio = "saveInfoFolioV2";
        //public static String webMethodGetFolios     = "getFoliosV2";
        //public static String webMethodGetFoliosByID = "getInfoFoliosByIDV2";
    }
}
